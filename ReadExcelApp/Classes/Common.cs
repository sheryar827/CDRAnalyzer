using ReadExcelApp.Classes;
using System;
using System.Collections.Generic;

namespace ReadExcelApp
{
    public class Common
    {
        public const string sms = "sms";
        public const string voice = "voice";
        public const string incoming = "incoming";
        public const string outgoing = "outgoing";
        public const string jazz_A_Num = "A-Party";
        public const string jazz_B_Num = "B-Party";
        public const string imei = "IMEI";
        public const string datetime = "Date & Time";
        public const string datef = "MM-dd-yyyy";
        public const string timef = "HH:mm:ss";
        public const string duration = "Duration";
        public const string jazz_Call_Type = "Call Type";
        public const string jazz_Cell_ID = "Cell ID";
        public const string jazz_Location = "Site";
        public const string jazz_Network = "jazz";
        public const string ftp_login = "test";
        public const string select_num = "Please, first select cdr number for analysis";


        public static TimeSpan mStart = Convert.ToDateTime("08:00:00").TimeOfDay;
        public static TimeSpan mEnd = Convert.ToDateTime("15:59:59").TimeOfDay;
        public static TimeSpan dStart = Convert.ToDateTime("16:00:00").TimeOfDay;
        public static TimeSpan dEnd = Convert.ToDateTime("23:59:59").TimeOfDay;
        public static TimeSpan eStart = Convert.ToDateTime("00:00:00").TimeOfDay;
        public static TimeSpan eEnd = Convert.ToDateTime("07:59:59").TimeOfDay;

        public const string NoRecord = "No Record Found!!";

        public const string warid_network = "warid";
        //DESKTOP-BE8P30Q
        //"Data Source="+serverIP+", 1433;Initial Catalog=CDRAnalyzer;User ID=Admin;Password=123";
        public static string connectionString = null;

        public static string subConnectionString = null;

        public static string sub2021ConnectionString = null;

        public const string telenor_A_Num = "MSISDN";
        public const string telenor_Call_Orig = "CALL_ORIG_NUM";
        public const string telenor_Call_Dialed = "CALL_DIALED_NUM";
        public const string telenor_date_time = "CALL_START_DT_TM";
        public const string telenor_Call_Dur = "Call_Network_Volume";
        public const string telenor_Call_Dir = "INBOUND_OUTBOUND_IND";
        public const string telenor_Cell_ID = "Cell_Site_Id";
        public const string telenor_Lac_No = "Cell_Lac_Id";
        public const string loc = "Location";
        public const string Loc = "Loc";
        public const string telenor_Lat = "LAT";
        public const string telenor_Lng = "LONGITUDE";
        public const string telenor_Network = "telenor";
        public const string call_Type = "CALL_TYPE";
        public const string telenor_Gsm = "GSM";
        public static List<String> callTypes = new List<String>()
        {
            "CALL", "GPRS", "GSM", "VOICE", "DATA"
        };

        public static string serverIP = null;

        public static string userName = null;

        public const string ufone_A_Num = "A Number";
        public const string ufone_B_Num = "B Number";
        public const string ufone_Start_Time = "Start Time";
        public const string ufone_Call_Dir = "Direction";
        public const string ufone_Cell_ID = "Cell Id";
        public const string ufone_Lat = "Latitude";
        public const string ufone_Lng = "Longitude";
        public const string ufone_Network = "ufone";
        public const string ufone_Call_Type = "Type";

        public const string zong_A_Num = "MSISDN_ID";
        public const string zong_date_time = "STRT_TM";
        public const string zong_B_Num = "BNUMBER";
        public const string zong_mins = "MINS";
        public const string zong_secs = "SECS";
        public const string zong_lac_no = "LAC_ID";
        public const string zong_cell_id = "CELL_ID";
        public const string zong_loc = "SITE_ADDRESS";
        public const string zong_lng = "LNG";
        public const string zong_lat = "LAT";
        public const string zong_network = "zong";

        public const string A_Party = "A-Party";
        public const string B_Party = "B-Party";
        public const string A_Num = "A_Num";
        public const string B_Num = "B_Num";
        public const string Cont_Num = "Cont_Num";
        public const string IMEI = "IMEI";
        public const string LAC = "Lac_No";
        public const string CELLID = "Cell_ID";
        public const string Call_Dir = "Call_Dir";
        public const string Call_Dur = "Call_Dur";
        public const string Call_Type = "Call_Type";
        public const string Network = "Network";
        public const string Date = "Date";
        public const string Time = "Time";
        public const string Weekday = "Weekday";

        public const string LAT = "Lat";
        public const string LNG = "Lng";

        public const string LAC_CELLID = "LAC/Cell-ID";
        public const string LAT_LNG = "LAT/LNG";


        public const string cdrTable = "CDRTable";

        public const string call = "call";

        public const string cdrDBTable = "CDR_DB_Tbl";

        public const string projectTable = "Projects";

        public const string projectTableA_Num = "ProjectsTableA_Num";
        public const string generalPoliceTableA_Num = "GeneralPoliceTableA_Num";

        public const string generalPoliceTable = "GeneralPoliceTable";

        public static List<DateTime> dateTimeList = new List<DateTime>();

        public static List<string> b_num = new List<string>();

        public static string startDate;

        public static string endDate;

        public static string AParty;

        public static string a_numForAnalysis = null;

        public static string project_Name = null;

        public const string callIn = "In";
        public const string callOut = "Out";
        public const string inSMS = "inSMS";
        public const string outSMS = "outSMS";
        public const string Total = "Total";

        public const string BTSTABLE = "BTS_Analyzer";




        public static List<AllRecordA_Num> allRecordA_Nums = null;

        public static List<string> jazzCDR = new List<string>(){
            "Sr #"
            , "Call Type"
        ,"A-Party"
        ,"B-Party"
        ,"Date & Time"
        ,"Duration"
        ,"Cell ID"
        ,"IMEI"
        ,"IMSI"
        ,"Site"
        ,"Longitude and Latitude"
        ,"Node ID"
        ,"IP"
        ,"Port"};

        public static List<string> jazzCDR2 = new List<string>(){
            "Sr #"
            , "Call Type"
        ,"A-Party"
        ,"B-Party"
        ,"Date & Time"
        ,"Duration"
        ,"Cell ID"
        ,"IMEI"
        ,"IMSI"
        ,"Site"};

        public static List<string> jazzCDR1 = new List<string>(){
            "CallType"
            , "Aparty"
        ,"BParty"
        ,"Datetime"
        ,"Duration"
        ,"cellid"
        ,"Imei"
        ,"Imsi"
        ,"SiteLocation"};

        public static List<string> ufoneCDR = new List<string>(){
            "IMEI"
            , "IMSI"
        ,"A Number"
        ,"B Number"
        ,"Start Time"
        ,"End Time"
        ,"Service Provider"
        ,"Type"
        ,"Direction"
        ,"Location"
        ,"Cell Id"
        ,"Cell Sector"
        ,"Latitude"
        ,"Longitude"
        ,"Duration"};

        public static List<string> telenorCDR = new List<string>(){
            "MSISDN"
            , "CALL_ORIG_NUM"
        ,"CALL_DIALED_NUM"
        ,"IMSI"
        ,"IMEI"
        ,"CALL_START_DT_TM"
        ,"CALL_END_DT_TM"
        ,"INBOUND_OUTBOUND_IND"
        ,"Call_Network_Volume"
        ,"Cell_Lac_Id"
        ,"Cell_Site_Id"
        ,"LAT"
        ,"LONGITUDE"
        ,"CALL_TYPE"
        ,"Location"};


        public static List<string> telenorCDR1 = new List<string>(){
            "MSISDN"
            , "call_org_num"
        ,"CALL_DIALED_NUM"
        ,"IMSI"
        ,"IMEI"
        ,"CALL_START_DT_TM"
        ,"CALL_END_DT_TM"
        ,"INBOUND_OUTBOUND_IND"
        ,"Call_Network_Volume"
        ,"Lac_Id"
        ,"Site_Id"
        ,"Cell_SITE_ID"
        ,"lat"
        ,"longitude"
        ,"CALL_TYPE"
        ,"location"};

        public static List<string> zongCDR = new List<string>(){
            "CALL_TYPE"
            , "MSISDN_ID"
        ,"STRT_TM"
        ,"BNUMBER"
        ,"MINS"
        ,"SECS"
        ,"LAC_ID"
        ,"CELL_ID"
        ,"IMEI"
        ,"SITE_ADDRESS"
        ,"LNG"
        ,"LAT"};


        public static List<string> customCDR = new List<string>(){
            "A_Num"
            , "B_Num"
        ,"IMEI"
        ,"Date & Time"
        ,"Call_Dur"
        ,"Call_Dir"
        ,"Call_Type"
        ,"Lac_No"
        ,"Cell_ID"
        ,"Loc"
        ,"Lat"
        ,"Lng"
        ,"Network"};

    }
}
