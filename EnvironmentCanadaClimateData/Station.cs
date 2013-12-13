using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using SocialExplorer.IO.FastDBF;

namespace HAWKLORRY
{
    class Station : BaseWithProcess
    {
        private static string DAILY_DATA_REQUEST_URL_FORMAT = @"http://climate.weather.gc.ca/climateData/bulkdata_e.html?format=csv&stationID={0}&Year={1}&Month=8&Day=1&timeframe=2&submit=Download+Data";
        private static int[] TEST_YEARS = {2010, 2000, 1990, 1980, 1970, 1960, 1950};
        
        private static int TOTAL_PRECIPITATION_COL_INDEX = 19;
        private static int MAX_T_COL_INDEX = 5;
        private static int MIN_T_COL_INDEX = 7;

        private string _id = "";
        private string _name = "";
        private string _province = "";
        private string _latitude = "";
        private string _longitude = "";
        private string _elevation = "";

        public Station(string id)
        {
            _id = id;
        }

        public string ID { get { return _id; } }
        public string Name { get { return _name; } }
        public string Province { get { return _province; } }
        public string Latitude { get { return _latitude; } }
        public string Longtitude { get { return _longitude; } }
        public string Elevation { get { return _elevation; } }

        /// <summary>
        /// try to get the basic information of this station from daily csv.
        /// </summary>
        /// <remarks>
        /// The format of CSV header
        /// <para>Line 1: "Station Name","DEERWOOD RCS"</para>
        /// <para>Line 2: "Province","MANITOBA"</para>
        /// <para>Line 3: "Latitude","49.40"</para>
        /// <para>Line 4: "Longitude","-98.32"</para>
        /// <para>Line 5: "Elevation","341.40"</para>
        /// </remarks>
        public void retrieveStationBasicInformation()
        {
            if (_name.Length > 0) return;

            foreach (int year in TEST_YEARS)
                if (retrieveStationBasicInformation(year)) return;
        }

        /// <summary>
        /// Retrieve data header for given year. Used to get station information.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private string retrieveHeader(int year)
        {
            System.Text.StringBuilder sb = new StringBuilder();
            using (HttpWebResponse response = retrieveAnnualDailyClimateData(year))
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default))
                {
                    int lineNum = 0;
                    while (reader.Peek() >= 0 && lineNum <= 5)
                    {
                        sb.AppendLine(reader.ReadLine());
                        lineNum++;
                    }
                    if (lineNum < 5) return "";
                    return sb.ToString();
                }
            }
        }

        /// <summary>
        /// Retrieve station basic information for given year.
        /// </summary>
        /// <param name="year"></param>
        /// <returns>If information has been successfully retrieved.</returns>
        /// <remarks>The time range of climate stations are different. If there is no data in one year, the station information
        /// can't be retrieved.</remarks>
        private bool retrieveStationBasicInformation(int year)
        {
            string header = retrieveHeader(year);
            if (header.Length == 0) return false;
            using (CachedCsvReader csv = new CachedCsvReader(new StringReader(header), false))
            {
                if (csv.FieldCount < 2) return false;
                
                csv.ReadNextRecord();   //station name
                _name = csv[1];

                csv.ReadNextRecord();   //province
                _province = csv[1];

                csv.ReadNextRecord();   //Latitude
                _latitude = csv[1];
                
                csv.ReadNextRecord();   //Lontitude
                _longitude = csv[1];

                csv.ReadNextRecord();   //Elevation
                _elevation = csv[1];

                return true;
            }
        }

        /// <summary>
        /// Get http reponse for given year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private HttpWebResponse retrieveAnnualDailyClimateData(int year)
        { 
            string requestURL =
                string.Format(DAILY_DATA_REQUEST_URL_FORMAT, _id, year);

            HttpWebRequest r = WebRequest.Create(requestURL) as HttpWebRequest;
            r.Method = "GET";
            return r.GetResponse() as HttpWebResponse;            
        }

        /// <summary>
        /// retrieve daily climate data for given year from Environment Canada
        /// </summary>
        /// <param name="year"></param>
        /// <param name="keepHeader"></param>
        /// <returns></returns>
        private string retrieveAnnualDailyClimateData(int year, bool keepHeader = true)
        {
            using (HttpWebResponse response = retrieveAnnualDailyClimateData(year))
            {
                System.Text.StringBuilder sb = new StringBuilder();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default))
                {
                    int lineNum = 0;
                    int headLine = 25;
                    if (!keepHeader) headLine = 26;
                    while (reader.Peek() >= 0)
                    {
                        string line = reader.ReadLine();
                        lineNum++;

                        if (lineNum == 1 && !line.ToLower().Contains("station name")) return ""; //no data for this year
                        if (lineNum < headLine) continue;

                        if (sb.Length > 0)
                            sb.Append(Environment.NewLine);
                        sb.Append(line);
                    }
                }

                return sb.ToString();
            } 
        }

        public bool save(int[] fields,
            int startYear, int endYear, string destinationFolder, FormatType format)
        {
            if (format == FormatType.ARCSWAT_DBF)
                return save2ArcSWATdbf(startYear, endYear, destinationFolder);
            else if (format == FormatType.ARCSWAT_TEXT)
                return save2ArcSWATAscii(startYear, endYear, destinationFolder);
            else if (format == FormatType.SIMPLE_CSV || format == FormatType.SIMPLE_TEXT)
                return save2Ascii(fields, startYear, endYear, destinationFolder, format);
            else
                return false;
        }

        private string getTimeAffix()
        {
            return "";
            //return string.Format("_{0:yyyyMMddHHmmss}",DateTime.Now);
        }

        /// <summary>
        /// get result file extension (txt, csv or dbf) from result format
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string getExtentionFromType(FormatType type)
        {
            if (type == FormatType.ARCSWAT_DBF) return "dbf";
            else if (type == FormatType.SIMPLE_CSV) return "csv";
            return "txt";
        }

        private bool save2Ascii(int[] fields,
            int startYear, int endYear, string destinationFolder, FormatType format)
        {
            //get the file name using station name
            string fileName = string.Format("{0}\\{1}{2}.{3}", 
                Path.GetFullPath(destinationFolder), _id, getTimeAffix(),getExtentionFromType(format));  //precipitation

            this.setProgress(0, string.Format("Processing station {0}", _id));
            this.setProgress(0, fileName);

            //open the file and write the data
            int oneStep = (endYear - startYear) / 2;
            int processPercent = 0;
            bool hasResults = false;
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int i = startYear; i <= endYear; i++)
                {
                    setProgress(processPercent, string.Format("Downloading data for station: {0}, year: {1}", _id, i));
                    string resultsForOneYear = this.retrieveAnnualDailyClimateData(i, true);
                    if (resultsForOneYear.Length == 0) continue;

                    processPercent += oneStep;
                    setProgress(processPercent, "Writing data");

                    if (format == FormatType.SIMPLE_CSV || format == FormatType.SIMPLE_TEXT)
                        hasResults = write2FreeFormat(resultsForOneYear, fields, writer, i == startYear, format);

                    processPercent += oneStep;
                }
            }

            return hasResults;
        }

        #region Write Free Format File, Simple Text and CSV

        private static int FIXED_FIELD_WIDTH = 20; //the width of each field in text format

        private string formatFreeFormatData(string v, FormatType format, bool isDate)
        {
            if (format == FormatType.SIMPLE_CSV)
                return v;
            else if (format == FormatType.SIMPLE_TEXT)
            {
                if (isDate)
                    return v.PadRight(FIXED_FIELD_WIDTH);
                else
                    return v.PadLeft(FIXED_FIELD_WIDTH);
            }
            return "";
        }

        private bool write2FreeFormat(string resultsForOneYear, int[] fields, StreamWriter writer, bool needWriteHeader, FormatType format)
        {
            StringBuilder sb = new StringBuilder();
            using (CachedCsvReader csv = new CachedCsvReader(new StringReader(resultsForOneYear), true))
            {
                if (csv.FieldCount < 27) return false;

                if (needWriteHeader)
                {
                    string[] fieldNames = csv.GetFieldHeaders();
                    sb.Append(formatFreeFormatData(fieldNames[0], format, true));

                    foreach (int field in fields)
                    {
                        if (format == FormatType.SIMPLE_CSV)
                            sb.Append(",");
                        sb.Append(formatFreeFormatData(fieldNames[field], format, false));
                    }
                    sb.AppendLine();
                }
                while (csv.ReadNextRecord())
                {
                    string date = csv[0];
                    sb.Append(formatFreeFormatData(date, format, true));

                    foreach (int field in fields)
                    {
                        if (format == FormatType.SIMPLE_CSV)
                            sb.Append(",");
                        sb.Append(formatFreeFormatData(csv[field], format, false));
                    }

                    sb.AppendLine();
                }
            }
            if (sb.Length > 0)
                writer.Write(sb.ToString());

            return sb.Length > 0;            
        }

        #endregion

        /// <summary>
        /// Write data in given time range as ArcSWAT txt file
        /// </summary>
        /// <param name="startYear"></param>
        /// <param name="endYear"></param>
        /// <param name="destinationFolder"></param>
        /// <returns></returns>
        private bool save2ArcSWATAscii(int startYear, int endYear, string destinationFolder)
        {
            //get the file name using station name
            string timeAffix = getTimeAffix();
            string pFile = string.Format("{0}\\P{1}{2}.txt", Path.GetFullPath(destinationFolder), _id, timeAffix);  //precipitation
            string tFile = string.Format("{0}\\T{1}{2}.txt", Path.GetFullPath(destinationFolder), _id, timeAffix);  //temperature

            this.setProgress(0, string.Format("Processing station {0}", _id));
            this.setProgress(0, pFile);
            this.setProgress(0, tFile);

            int oneStep = (endYear - startYear) / 2;
            int processPercent = 0;
            bool hasResults = false;
            string numberForamt = "F1";
            string temperatureFormat = "{0:"+numberForamt+"},{1:"+numberForamt+"}";
            StringBuilder pSb = new StringBuilder();
            StringBuilder tSb = new StringBuilder();
            for (int i = startYear; i <= endYear; i++)
            {
                setProgress(processPercent, string.Format("Downloading data for station: {0}, year: {1}", _id, i));
                string resultsForOneYear = this.retrieveAnnualDailyClimateData(i, true);
                if (resultsForOneYear.Length == 0) continue;

                processPercent += oneStep;
                setProgress(processPercent, "Writing data");

                using (CachedCsvReader csv = new CachedCsvReader(new StringReader(resultsForOneYear), true))
                {
                    if (csv.FieldCount >= 27)
                    {
                        hasResults = true;
                        while (csv.ReadNextRecord())
                        {
                            //add starting date
                            if (pSb.Length == 0)
                            {
                                DateTime date = DateTime.Now;
                                if (DateTime.TryParse(csv[0], out date))
                                {
                                    string startDate = string.Format("{0:yyyyMMdd}, Generated by Environment Canada Climate Data Reader",date);
                                    pSb.AppendLine(startDate);
                                    tSb.AppendLine(startDate);
                                }
                            }
                            
                            //write data                            
                            double p = ClimateString2Double(csv[TOTAL_PRECIPITATION_COL_INDEX]);
                            pSb.AppendLine(p.ToString(numberForamt));

                            double t_max = ClimateString2Double(csv[MAX_T_COL_INDEX]);
                            double t_min = ClimateString2Double(csv[MIN_T_COL_INDEX]);
                            tSb.AppendLine(string.Format(temperatureFormat, t_max, t_min));
                        }
                    }
                }
                processPercent += oneStep;
            }

            if (pSb.Length > 0)
                using (StreamWriter writer = new StreamWriter(pFile))
                    writer.Write(pSb.ToString());
            if (tSb.Length > 0)
                using (StreamWriter writer = new StreamWriter(tFile))
                    writer.Write(tSb.ToString());

            return hasResults;
        }

        /// <summary>
        /// Write data in given time range as ArcSWAT dbf file
        /// </summary>
        /// <param name="startYear"></param>
        /// <param name="endYear"></param>
        /// <param name="destinationFolder"></param>
        /// <returns></returns>
        private bool save2ArcSWATdbf(int startYear, int endYear, string destinationFolder)
        {
            string timeAffix = getTimeAffix();
            string pFile = string.Format("{0}\\P{1}{2}.dbf", Path.GetFullPath(destinationFolder), _id, timeAffix);  //precipitation
            string tFile = string.Format("{0}\\T{1}{2}.dbf", Path.GetFullPath(destinationFolder), _id, timeAffix);  //temperature

            this.setProgress(0,string.Format("Processing station {0}", _id));
            this.setProgress(0, pFile);
            this.setProgress(0, tFile);

            //create the dbf structure based on ArcSWAT document
            DbfFile pDBF = new DbfFile();
            pDBF.Open(pFile, FileMode.Create);
            pDBF.Header.AddColumn(new DbfColumn("DATE", DbfColumn.DbfColumnType.Date));
            pDBF.Header.AddColumn(new DbfColumn("PCP", DbfColumn.DbfColumnType.Number, 5, 1));


            DbfFile tDBF = new DbfFile();
            tDBF.Open(tFile, FileMode.Create);
            tDBF.Header.AddColumn(new DbfColumn("DATE", DbfColumn.DbfColumnType.Date));
            tDBF.Header.AddColumn(new DbfColumn("MAX", DbfColumn.DbfColumnType.Number, 5, 1));
            tDBF.Header.AddColumn(new DbfColumn("MIN", DbfColumn.DbfColumnType.Number, 5, 1));

            DbfRecord pRec = new DbfRecord(pDBF.Header);
            DbfRecord tRec = new DbfRecord(tDBF.Header);

            int oneStep = (endYear - startYear) / 2;
            int processPercent = 0;
            bool hasResults = false;
            for (int i = startYear; i <= endYear; i++)
            {
                setProgress(processPercent, string.Format("Downloading data for station: {0}, year: {1}", _id, i));
                string resultsForOneYear = this.retrieveAnnualDailyClimateData(i, true);
                if (resultsForOneYear.Length == 0) continue;

                processPercent += oneStep;
                setProgress(processPercent, "Writing data");

                using (CachedCsvReader csv = new CachedCsvReader(new StringReader(resultsForOneYear), true))
                {
                    if (csv.FieldCount >= 27)
                    {
                        hasResults = true;
                        while (csv.ReadNextRecord())
                        {
                            string date = csv[0];
                            double p = ClimateString2Double(csv[TOTAL_PRECIPITATION_COL_INDEX]);
                            pRec[0] = date;
                            pRec[1] = p.ToString();
                            pDBF.Write(pRec, true);

                            double t_max = ClimateString2Double(csv[MAX_T_COL_INDEX]);
                            double t_min = ClimateString2Double(csv[MIN_T_COL_INDEX]);
                            tRec[0] = date;
                            tRec[1] = t_max.ToString();
                            tRec[2] = t_min.ToString();
                            tDBF.Write(tRec, true);
                        }
                    }
                }
                processPercent += oneStep;
            }
            pDBF.Close();
            tDBF.Close();

            return hasResults;
        }

        /// <summary>
        /// replace missing data using -99
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private double ClimateString2Double(string data)
        {
            double d = -99.0;
            if (double.TryParse(data, out d)) return d;
            return -99.0;
        }
    }
}
