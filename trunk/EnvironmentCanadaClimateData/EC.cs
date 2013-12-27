using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Diagnostics;
using HtmlAgilityPack;

namespace HAWKLORRY
{
    /// <summary>
    /// Environment Canada website
    /// </summary>
    class EC
    {
        private static string DOMAIN = "http://climate.weather.gc.ca";

        private static string[] SEARCH_TYPE = { "stnName", "stnProv" };

        private static string STATION_NAME_SEARCH_FORMAT = "txtStationName={0}&searchMethod=contains&";
        private static string SEARCH_FORMAT =
            DOMAIN +
            "/advanceSearch/searchHistoricDataStations_e.html?" +
            "searchType={0}&timeframe=1&{1}" +
            "optLimit=yearRange&StartYear=1840&EndYear={2}&Year={2}&Month={3}&Day={4}&" +
            "selRowPerPage=10&cmdStnSubmit=Search";

        private string sendRequest(string requestURL)
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

        private void readOneStation(string formHtml)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(formHtml);
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//input[@type='hidden']");
            //foreach (HtmlNode node in nodes)
            //    Debug.WriteLine(node.OuterHtml);

            nodes = doc.DocumentNode.SelectNodes("//div[@class='divTableRowOdd']");
            foreach (HtmlNode node in nodes)
            {
                int num = 0;
                foreach (HtmlNode child in node.ChildNodes)
                {
                    if (child.Name.ToLower() != "div") continue;

                    num += 1;
                    if (num <= 2)
                        Debug.Write(child.InnerText.Trim() + ",");
                    else
                        getOptions(child.OuterHtml);

                    if (num == 4)
                    {
                        Debug.WriteLine("");
                        break;
                    }
                }
            }
        }

        private void testHtmlAgilityPack()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load(@"C:\Users\yuz\Downloads\testHtml.html");
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//form[@action='/climateData/Interform.php']");
            //foreach (HtmlNode node in nodes)
            //    Debug.WriteLine(node.OuterHtml);
            
            nodes = doc.DocumentNode.SelectNodes("//div[@class='divTableRowOdd']");
            foreach (HtmlNode node in nodes)
            {
                int num = 0;
                foreach (HtmlNode child in node.ChildNodes)
                {
                    if (child.Name.ToLower() != "div") continue;

                    num += 1;
                    if (num <= 2)
                        Debug.Write(child.InnerText.Trim() + ",");
                    else
                        getOptions(child.OuterHtml);

                    if (num == 4) 
                    { 
                        Debug.WriteLine(""); 
                        break; 
                    }
                }               
            }
        }

        public void getAllInformation()
        {
            testHtmlAgilityPack();

            //string url = string.Format(SEARCH_FORMAT,
            //    SEARCH_TYPE[1], "", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //string result = sendRequest(url);

            //using (StreamWriter w = new StreamWriter(@"C:\Users\yuz\Downloads\testHtml.html"))
            //    w.Write(result);

            //using (StringReader reader = new StringReader(result))
            //{
            //    string line = reader.ReadLine();
            //    while (line != null)
            //    {
            //        if (line.Contains("hidden"))
            //        {
            //            parseSearchResult(line);
            //            Debug.WriteLine("---------------------------");                        
            //        }
            //        line = reader.ReadLine();
            //    }
            //}


            //using (StreamReader reader = new StreamReader(@"C:\Users\HAWK\Downloads\testECResultXML.txt"))
            //{
            //    while (!reader.EndOfStream)
            //    {
            //        string line = reader.ReadLine();
            //        if (!line.Contains("hidden")) continue;
            //        parseSearchResult(line);
            //        Debug.WriteLine("---------------------------");
            //    }
            //}
        }

        private void parseSearchResult(string searchResult)
        {
            int first = searchResult.IndexOf("<input type=\"hidden\" name=\"dlyRange\"");
            int last = searchResult.LastIndexOf("<input type=\"hidden\"");
            if (first == -1 || last == -1) return;
            searchResult = searchResult.Substring(first,last-first);
            searchResult = searchResult.Replace("\t", "");
            searchResult = "<p>" + searchResult + "</p>";
            XmlReader reader = XmlReader.Create(new StringReader(searchResult));
            while (reader.ReadToFollowing("input"))
            {
                reader.MoveToAttribute("name");
                string name = reader.Value;
                reader.MoveToAttribute("value");
                string v = reader.Value;
                Debug.WriteLine(name + "," + v);                
            }
            
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
    }

    class ECHtmlUtil
    {
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
    }

    class ECStationInfo
    {
        private string _name;
        private string _province;
        private string _id;
        private ECStationDataAvailability _hourlyAvailability = null;
        private ECStationDataAvailability _dailyAvailability = null;
        private ECStationDataAvailability _monthlyAvailability = null;


    }


}
