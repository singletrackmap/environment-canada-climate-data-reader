using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.IO.Compression;
using Ionic.Zip;

namespace HAWKLORRY.Australia
{
    enum ClimateDataType
    {
        PRECIPITATION = 136,
        MIN_TEMPERATURE = 123,
        MAX_TEMPERATURE = 122
    }

    class StationAustralia : Station
    {
        /// <summary>
        /// URL format for retrieve daily data of given type and given id
        /// </summary>
        private static string DAILY_DATA_REQUEST_URL_FORMAT =
            @"http://www.bom.gov.au/jsp/ncc/cdio/weatherData/av?p_display_type=dailyZippedDataFile&p_stn_num={0}&p_nccObsCode={1}&p_c={2}";
        
        /// <summary>
        /// URL format for retrieve available years for given data type. ALso can use to get an id used in data request (key p_c)
        /// </summary>
        private static string AVAILABLE_YEAR_REQUEST_URL_FORMAT = 
            @"http://www.bom.gov.au/jsp/ncc/cdio/weatherData/av?p_stn_num={0}&p_display_type=availableYears&p_nccObsCode={1}";
        
        //Precipitation: 136
        //available years: http://www.bom.gov.au/jsp/ncc/cdio/weatherData/av?p_stn_num=016085&p_display_type=availableYears&p_nccObsCode=136&bookmark=136
        //016085||,1985:-51966028,1986:-51966028,1987:-51966028,1988:-51966028,1989:-51966028,1990:-51966028,1991:-51966028,1992:-51966028,1993:-51966028,1994:-51966028,1995:-51966028,1996:-51966028,1997:-51966028,1998:-51966028,1999:-51966028,2000:-51966028,2001:-51966028,2002:-51966028,2003:-51966028,2004:-51966028,2005:-51966028,2006:-51966028,2007:-51966028,2008:-51966028,2009:-51966028,2010:-51966028,2011:-51966028,2012:-51966028,2013:-51966028
        
        //1 year data http://www.bom.gov.au/tmp/cdio/IDCJAC0009_016085_2013.zip
        //All year data http://www.bom.gov.au/jsp/ncc/cdio/weatherData/av?p_display_type=dailyZippedDataFile&p_stn_num=016085&p_c=-51966028&p_nccObsCode=136&p_startYear=2013

        //get data based on location: http://www.bom.gov.au/cgi-bin/ws/gis/ncc/cdio/wxs?LAYERS=IDC10002_open&TRANSPARENT=true&FORMAT=image%2Fgif&SERVICE=WMS&VERSION=1.1.1&REQUEST=GetFeatureInfo&STYLES=&EXCEPTIONS=application%2Fvnd.ogc.se_xml&SRS=EPSG%3A4283&BBOX=111.5531%2C-43.916625%2C155.3739%2C-10.010375&X=291&Y=229&INFO_FORMAT=text%2Fplain&QUERY_LAYERS=%2CIDC10002_open&FEATURE_COUNT=10&WIDTH=579&HEIGHT=448
        //result
        //GetFeatureInfo results:

        //Layer 'IDC10002_open'
        //  Feature 3683: 
        //    stn_num = '16085'
        //    name = 'Marla Police Station'
        //    latitude = '-27.300'
        //    longitude = '133.620'
        //    bgn_date = '1985-08-09'
        //    end_date = 'Null'
        //  Feature 3686: 
        //    stn_num = '16088'
        //    name = 'Mintabie'
        //    latitude = '-27.315'
        //    longitude = '133.298'
        //    bgn_date = '1992-02-13'
        //    end_date = 'Null'

        private Dictionary<ClimateDataType,int[]> _availableYears = null;
        
        public StationAustralia(string id)
            : base(id)
        {

        }

        /// <summary>
        /// Get http reponse for given year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private HttpWebResponse retrieveDailyOneTypeClimateData_Response(ClimateDataType type)
        {
            string requestURL =
                string.Format(DAILY_DATA_REQUEST_URL_FORMAT, 1006,Convert.ToInt32(type),-422991);

            HttpWebRequest r = WebRequest.Create(requestURL) as HttpWebRequest;
            r.Method = "GET";
            return r.GetResponse() as HttpWebResponse;
        }

        public string retrieveDailyOneTypeClimateData(ClimateDataType type)
        {
            string csv = "";
            using (HttpWebResponse response = retrieveDailyOneTypeClimateData_Response(type))
            {
                using (Stream stream = response.GetResponseStream()) //zip stream
                {
                    //using (FileStream zip = File.Create(@"C:\Users\zyu\Downloads\test.zip"))
                    //{
                    //    stream.CopyTo(zip);
                    //}
                    using (MemoryStream mStream = new MemoryStream())
                    {
                        stream.CopyTo(mStream);
                        using (ZipFile zip = ZipFile.Read(mStream))
                        {

                        }
                    }

                }
            }
            return csv;
        }

        public string readCsvInZip2()
        {
            string csv = "";
            using (ZipFile zip = ZipFile.Read(@"C:\Users\zyu\Downloads\test.zip"))
            {
                foreach (ZipEntry entry in zip.Entries)
                {
                    System.Diagnostics.Debug.WriteLine(entry);

                    if(entry.FileName.ToLower().Contains("csv"))
                    {
                        using (Stream csvStream = entry.OpenReader())
                        {
                            using (StreamReader reader = new StreamReader(csvStream, Encoding.Default))
                            {
                                csv = reader.ReadToEnd();
                                using (StreamWriter testFile = new StreamWriter(@"C:\Users\zyu\Downloads\testAustralia.txt"))
                                {
                                    testFile.Write(csv);
                                }
                            }
                        }
                    }
                }
            }
            return csv;
        }

        //public string readCsvInZip()
        //{
        //    string csv = "";
        //    using (Package zip = Package.Open(@"C:\Users\zyu\Downloads\test.zip", FileMode.Open, FileAccess.Read))
        //    {
        //        foreach (PackageRelationship rel in zip.GetRelationships())
        //        {
        //            System.Diagnostics.Debug.WriteLine(rel);
        //        }
        //        foreach (PackagePart part in zip.GetParts())
        //        {
        //            if (part.Uri.IsFile && part.Uri.AbsoluteUri.Contains("csv"))
        //            {
        //                using (Stream csvStream = part.GetStream())
        //                {
        //                    using (StreamReader reader = new StreamReader(csvStream, Encoding.Default))
        //                    {
        //                        csv = reader.ReadToEnd();
        //                        using (StreamWriter testFile = new StreamWriter(@"C:\Users\zyu\Downloads\testAustralia"))
        //                        {
        //                            testFile.Write(csv);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return csv;
        //}
    }
}
