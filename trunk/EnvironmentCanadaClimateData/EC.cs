using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Diagnostics;
using HtmlAgilityPack;
using LumenWorks.Framework.IO.Csv;
using System.Data;
using System.Data.OleDb;

namespace HAWKLORRY
{
    class ECRequestUtil
    {
        private static string DOMAIN = "http://climate.weather.gc.ca";

        private static string[] SEARCH_TYPE = { "stnName", "stnProv" };
        private static string STATION_NAME_SEARCH_FORMAT = "txtStationName={0}&searchMethod=contains&";
        private static string SEARCH_FORMAT =
            DOMAIN +
            "/advanceSearch/searchHistoricDataStations_e.html?" +
            "searchType={0}&timeframe=1&{1}" +
            "optLimit=yearRange&StartYear=1840&EndYear={2}&Year={2}&Month={3}&Day={4}&" +
            "selRowPerPage={6}&cmdStnSubmit=Search&startRow={5}";


        /// <summary>
        /// to request daily report for given station
        /// </summary>
        private static string DAILY_REPORT_FORMAT =
            DOMAIN + "/climateData/dailydata_e.html?timeframe=2&StationID={0}";//to get latitude,Longitude and elevation

        private static string sendRequest(string requestURL)
        {
            HttpWebRequest r = WebRequest.Create(requestURL) as HttpWebRequest;
            r.Method = "GET";
            using (HttpWebResponse response = r.GetResponse() as HttpWebResponse)
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.Default))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        public static string RequestAllStations(int numInOnePage, int startRow)
        {        
            return sendRequest
                (string.Format(SEARCH_FORMAT,
                "stnProv", "", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startRow, numInOnePage));
        }

        /// <summary>
        /// request daily report for given station
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string RequestLatLongElevation(string id)
        {
            return sendRequest
                (string.Format(DAILY_REPORT_FORMAT,id));
        }


    }

    /// <summary>
    /// Environment Canada website
    /// </summary>
    class EC
    {        
        /// <summary>
        /// Retrieve all stations from EC and save into a csv file
        /// </summary>
        /// <param name="csvFilePath"></param>
        public static void RetrieveAndSaveAllStations(string csvFilePath)
        {
            using (StreamWriter writer = new StreamWriter(csvFilePath))
            {
                writer.WriteLine("ID,NAME,PROVINCE,LATITUDE,LONGITUDE,ELEVATION");

                int num = 100;
                int startRow = 1;
                List<ECStationInfo> stations = new List<ECStationInfo>();

                do
                {
                    string request = ECRequestUtil.RequestAllStations(num, startRow);
                    stations = ECStationInfo.FromEC(request);

                    foreach (ECStationInfo info in stations)
                        writer.WriteLine(info.ToCSVString());

                    startRow += num;
                } while (stations.Count > 0); //just for test
            }
        }

        private static string FILE_NAME_EC_STATIONS_CSV = "ecstations.csv";

        private static string GetAllStationCSVFile()
        {
            string file = System.IO.Path.GetTempPath();
            file += @"ECReader\";
            if (!Directory.Exists(file)) Directory.CreateDirectory(file);
            file += FILE_NAME_EC_STATIONS_CSV;

            if (!System.IO.File.Exists(file))
            {
                using (StreamWriter writer = new StreamWriter(file))
                    writer.Write(Properties.Resources.ecstations);
            }
            return file;
        }

        private static DataTable ReadCSV(string csvFile)
        {
            FileInfo info = new FileInfo(csvFile);
            using (OleDbDataAdapter d = new OleDbDataAdapter(
                "select * from " + info.Name,
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                info.DirectoryName + ";Extended Properties='text;HDR=Yes;FMT=Delimited'"))
            {
                DataTable dt = new DataTable();
                d.Fill(dt);
                return dt;
            }
        }

        public static DataTable ReadAllStations()
        {
            return ReadCSV(GetAllStationCSVFile());            
        }

        public void getAllInformation()
        {
            HtmlNodeCollection tdNodes = ECHtmlUtil.ReadAllNodes(ECRequestUtil.RequestLatLongElevation("49448"), "//td");
            if (tdNodes == null) return;

            double latitude = ECHtmlUtil.ReadLatitudeLongitude(tdNodes[0]);
            double longitude = -ECHtmlUtil.ReadLatitudeLongitude(tdNodes[1]);

            //double.TryParse(tdNodes[2].ChildNodes[0].InnerText.Trim(), out _elevation);

           // RetrieveAndSaveAllStations(@"C:\Users\HAWK\Downloads\ecstations.csv");
        //    DataTable dt = ReadAllStations();
        //    Debug.WriteLine(dt.Rows.Count);

        //    DataRow[] rows = dt.Select("NAME like '*100 MILE HOUSE*'");
        //    foreach(DataRow r in rows)
        //        Debug.WriteLine(string.Format("{0},{1}",r["ID"],r["NAME"]));

              System.Windows.Forms.MessageBox.Show("finished.");

        }

    }

    enum ECSearchType
    {
        StationName = 0,
        Province = 1,
    }

    enum ECDataIntervalType
    {
        HOURLY = 1,
        DAILY = 2,
        MONTHLY = 3
    }

    class ECStationDataAvailability
    {
        private static string[] INTERVAL_NAME_IN_HTML = {"hlyRange","dlyRange","mlyRange"};
        private ECDataIntervalType _intervalType = ECDataIntervalType.DAILY;
        private bool _isAvailable = false;
        private string _firstDay = "";
        private string _lastDay = "";
        private bool _isValid = false;

        /// <summary>
        /// Initialize with htmlNode corresponding to hidden input tag
        /// </summary>
        /// <param name="inputHiddenNode"></param>
        public ECStationDataAvailability(HtmlNode inputHiddenNode)
        {
            string dataRangeType = "";
            string dataRange = "";
            ECHtmlUtil.ReadInputHiddenNode(inputHiddenNode,
                out dataRangeType, out dataRange);

            if (dataRangeType.Length == 0 || !INTERVAL_NAME_IN_HTML.Contains(dataRangeType)) return;

            _isValid = true;
            _intervalType = (ECDataIntervalType)(Array.IndexOf(INTERVAL_NAME_IN_HTML,dataRangeType) + 1);

            string[] range = dataRange.Split('|');
            if (range.Length == 2)
            {
                _firstDay = range[0].Trim();
                _lastDay = range[1].Trim();
                _isAvailable = _firstDay.Length > 0 || _lastDay.Length > 0;
            }
        }

        public bool IsAvailable { get { return _isValid && _isAvailable; } }
        public string FirstDay { get { return _firstDay; } }
        public string LastDay { get { return _lastDay; } }
        public override string ToString()
        {
            if (!IsAvailable) return _intervalType + " data not available";
            return string.Format("Type={2},FirstDay={0},LastDay={1}", _firstDay, _lastDay, _intervalType);
        }
    }

    /// <summary>
    /// Util class to read html data retrieved from EC
    /// </summary>
    class ECHtmlUtil
    {
        /// <summary>
        /// Read hidden input tag. The basic information of stations are in this format, especially the station id.
        /// </summary>
        /// <param name="inputHiddenNode"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void ReadInputHiddenNode(HtmlNode inputHiddenNode,
            out string name, out string value)
        {
            name = "";
            value = "";
            if (inputHiddenNode.Attributes.Contains("name") && inputHiddenNode.Attributes.Contains("value"))
            {
                name = inputHiddenNode.Attributes["name"].Value;
                value = inputHiddenNode.Attributes["value"].Value;
            }
        }

        public static HtmlNodeCollection ReadAllNodes(string html, string xpath)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc.DocumentNode.SelectNodes(xpath);
        }

        public static HtmlNodeCollection ReadAllNodes(HtmlNode node, string xpath)
        {
            return ReadAllNodes(node.InnerHtml, xpath);
        }

        public static double ReadLatitudeLongitude(HtmlNode node)
        {
            if (node.ChildNodes.Count < 5)
            {
                Debug.WriteLine("Don't have latitude information.");
                return 0.0;
            }

            double degree = 0.0;
            double.TryParse(node.ChildNodes[0].InnerText.Trim(), out degree);

            double minute = 0.0;
            double.TryParse(node.ChildNodes[2].InnerText.Trim(), out minute);

            double second = 0.0;
            double.TryParse(node.ChildNodes[4].InnerText.Trim(), out second);

            return degree + (minute + second/60.0) / 60.0;
        }
    }

    class ECStationInfo
    {
        private string _name;
        private string _province;
        private string _id;
        private double _latitude = 0;
        private double _longitude = 0;
        private double _elevation = 0;
        private ECStationDataAvailability _hourlyAvailability = null;
        private ECStationDataAvailability _dailyAvailability = null;
        private ECStationDataAvailability _monthlyAvailability = null;

        public static List<ECStationInfo> FromEC(string htmlRequest)
        {
            HtmlNodeCollection nodes = ECHtmlUtil.ReadAllNodes(htmlRequest, "//form[@action='/climateData/Interform.php']");
            List<ECStationInfo> stations = new List<ECStationInfo>();
            if (nodes == null || nodes.Count == 0) return stations;
            foreach (HtmlNode node in nodes)
            {
                ECStationInfo info = new ECStationInfo(node);
                Debug.WriteLine(info);
                stations.Add(info);
            }
            return stations;
        }

        public ECStationInfo(HtmlNode stationFormNode)
        {
            //read basic information from hidden inputs
            HtmlNodeCollection allHiddenInputNodes = 
                ECHtmlUtil.ReadAllNodes(stationFormNode,"//input[@type='hidden']");
            if (allHiddenInputNodes == null)
            {
                //try to find parent div of hidden inputs
                while (stationFormNode != null && stationFormNode.Name != "div")
                    stationFormNode = stationFormNode.NextSibling;
                if (stationFormNode == null) return;
                allHiddenInputNodes = ECHtmlUtil.ReadAllNodes(stationFormNode, "//input[@type='hidden']");                
                if (allHiddenInputNodes == null) return;
            }

            _hourlyAvailability = new ECStationDataAvailability(allHiddenInputNodes[0]);
            _dailyAvailability = new ECStationDataAvailability(allHiddenInputNodes[1]);
            _monthlyAvailability = new ECStationDataAvailability(allHiddenInputNodes[2]);

            string key = "";
            ECHtmlUtil.ReadInputHiddenNode(allHiddenInputNodes[3],  //station id
                out key, out _id);
            ECHtmlUtil.ReadInputHiddenNode(allHiddenInputNodes[4],  //province
                out key, out _province);

            //read station name and available years from divs
            HtmlNodeCollection allDataDivNodes =
                ECHtmlUtil.ReadAllNodes(stationFormNode, "//div[@class='divTableRowOdd']");
            if(allDataDivNodes == null)
                allDataDivNodes =
                ECHtmlUtil.ReadAllNodes(stationFormNode, "//div[@class='divTableRowEven']");
            if (allDataDivNodes == null) return;

            HtmlNode tableDataNode = allDataDivNodes[0];
            allDataDivNodes = ECHtmlUtil.ReadAllNodes(tableDataNode, "//div[@class]");
            if (allDataDivNodes == null) return;

            _name = allDataDivNodes[0].InnerText.Trim(); //just read station name right now
            if (_name.Contains(',')) //some name has comma, like KEY LAKE, SK, just need first part, orelse it will conflict with csv format and would has problem when import in ArcMap
                _name = _name.Split(',')[0].Trim();


            //try to retrieve latitude, longitude and elevation
            HtmlNodeCollection tdNodes = ECHtmlUtil.ReadAllNodes(ECRequestUtil.RequestLatLongElevation(_id), "//td"); 
            if (tdNodes == null) return;

            _latitude = ECHtmlUtil.ReadLatitudeLongitude(tdNodes[0]);
            _longitude = -ECHtmlUtil.ReadLatitudeLongitude(tdNodes[1]);

            double.TryParse(tdNodes[2].ChildNodes[0].InnerText.Trim(), out _elevation);
        }

        /// <summary>
        /// read data interval types or available years from select-option tage
        /// </summary>
        /// <param name="html"></param>
        /// <remarks>may be used in the future</remarks>
        private void getOptions(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//option");
            foreach (HtmlNode node in nodes)
            {
                Debug.Write(node.Attributes[0].Value + ",");
            }
        }

        public string Name { get { return _name; } }
        public string Province { get { return _province; } }
        public string ID { get { return _id; } }
        public bool IsHourlyAvailable { get { return _hourlyAvailability != null && _hourlyAvailability.IsAvailable; } }
        public bool IsDailyAvailable { get { return _dailyAvailability != null && _dailyAvailability.IsAvailable; } }
        public bool IsMonthlyAvailable { get { return _monthlyAvailability != null && _monthlyAvailability.IsAvailable; } }

        public override string ToString()
        {
            return string.Format("Name={0},Province={1},ID={2},Latitude={6},Longitude={7},Elevation={8},{3},{4},{5}",
                _name,_province,_id,
                _hourlyAvailability == null ? "" : _hourlyAvailability.ToString(),
                _dailyAvailability == null ? "" : _dailyAvailability.ToString(),
                _monthlyAvailability == null ? "" : _monthlyAvailability.ToString(),
                _latitude,_longitude,_elevation);
        }

        public string ToCSVString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5}",
                _id,_name,_province,
                _latitude,_longitude,_elevation);
        }
    }


}
