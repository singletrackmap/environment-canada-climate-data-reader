using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Diagnostics;

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
            "selRowPerPage=100&cmdStnSubmit=Search";

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

        public void getAllInformation()
        {
            string url = string.Format(SEARCH_FORMAT,
                SEARCH_TYPE[1], "", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            string result = sendRequest(url);

            using (StringReader reader = new StringReader(result))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (line.Contains("hidden"))
                    {
                        parseSearchResult(line);
                        Debug.WriteLine("---------------------------");                        
                    }
                    line = reader.ReadLine();
                }
            }


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
}
