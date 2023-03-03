using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class CDRFormatForm : Form
    {
        public CDRFormatForm()
        {
            InitializeComponent();
        }

        private void btnJazz_Click(object sender, EventArgs e)
        {
            gvFormatCDR.Columns.Clear();
            gvFormatCDR.Rows.Clear();
            gvFormatCDR.Refresh();
            gvFormatCDR.Columns.Add("Sr#", "Sr#");
            gvFormatCDR.Columns.Add("Call Type", "Call Type");
            gvFormatCDR.Columns.Add("", "");
            gvFormatCDR.Columns.Add("A-Party", "A-Party");
            gvFormatCDR.Columns.Add("", "");
            gvFormatCDR.Columns.Add("B-Party", "B-Party");
            gvFormatCDR.Columns.Add("", "");
            gvFormatCDR.Columns.Add("Date & Time", "Date & Time");
            gvFormatCDR.Columns.Add("", "");
            gvFormatCDR.Columns.Add("", "");
            gvFormatCDR.Columns.Add("Duration", "Duration");
            gvFormatCDR.Columns.Add("", "");
            gvFormatCDR.Columns.Add("Cell ID", "Cell ID");
            gvFormatCDR.Columns.Add("", "");
            gvFormatCDR.Columns.Add("IMEI", "IMEI");
            gvFormatCDR.Columns.Add("", "");
            gvFormatCDR.Columns.Add("IMSI", "IMSI");
            gvFormatCDR.Columns.Add("", "");
            gvFormatCDR.Columns.Add("Site", "Site");
            gvFormatCDR.Rows.Add("1", "Outgoing SMS", "", "923069605136", "", "923339838605", "", "07/02/15 8:15:00 PM", "", "",
                "0", "", "20301F74", "", "359285044845980","", "410010072386946","", "UTLG2129__S_Sadiqabad_Chowk_Talagang warid_MDTG3268");
        }

        private void btnWarid_Click(object sender, EventArgs e)
        {
            gvFormatCDR.Columns.Clear();
            gvFormatCDR.Rows.Clear();
            gvFormatCDR.Refresh();

            gvFormatCDR.ColumnCount = 16;

            gvFormatCDR.Columns[0].Name = "Sr#";
            gvFormatCDR.Columns[1].Name = "Call Type";
            gvFormatCDR.Columns[2].Name = "";
            gvFormatCDR.Columns[3].Name = "A-Party";
            gvFormatCDR.Columns[4].Name = "";
            gvFormatCDR.Columns[5].Name = "B-Party";
            gvFormatCDR.Columns[6].Name = "";
            gvFormatCDR.Columns[7].Name = "Date & Time";
            gvFormatCDR.Columns[8].Name = "";
            gvFormatCDR.Columns[9].Name = "";
            gvFormatCDR.Columns[10].Name = "Duration";
            gvFormatCDR.Columns[11].Name = "";
            gvFormatCDR.Columns[12].Name = "Cell ID";
            gvFormatCDR.Columns[13].Name = "";
            gvFormatCDR.Columns[14].Name = "IMEI";
            gvFormatCDR.Columns[15].Name = "";

            gvFormatCDR.Rows.Add("1", "Outgoing SMS", "", "923219605136", "", "923339838605", "", "07/02/15 8:15:00 PM", "", "",
                "0", "", "20301F74", "", "359285044845980", "");

        }

        private void btnZong_Click(object sender, EventArgs e)
        {
            gvFormatCDR.Columns.Clear();
            gvFormatCDR.Rows.Clear();
            gvFormatCDR.Refresh();

            gvFormatCDR.ColumnCount = 12;

            gvFormatCDR.Columns[0].Name = "CALL_TYPE";
            gvFormatCDR.Columns[1].Name = "MSISDN_ID";
            gvFormatCDR.Columns[2].Name = "STRT_TM";
            gvFormatCDR.Columns[3].Name = "BNUMBER";
            gvFormatCDR.Columns[4].Name = "MINS";
            gvFormatCDR.Columns[5].Name = "SECS";
            gvFormatCDR.Columns[6].Name = "LAC_ID";
            gvFormatCDR.Columns[7].Name = "CELL_ID";
            gvFormatCDR.Columns[8].Name = "IMEI";
            gvFormatCDR.Columns[9].Name = "SITE_ADDRESS";
            gvFormatCDR.Columns[10].Name = "LNG";
            gvFormatCDR.Columns[11].Name = "LAT";


            gvFormatCDR.Rows.Add("Incoming Call", "3115443426", "17/09/13 12:53:08 PM", "3115065660", "0", "29", "1C8F", "D5F4", "352562027733740", "Main Bazar Jhanda Cheechi, ",
                "73.0725", "33.5893");
        }

        private void btnUfone_Click(object sender, EventArgs e)
        {
            gvFormatCDR.Columns.Clear();
            gvFormatCDR.Rows.Clear();
            gvFormatCDR.Refresh();

            gvFormatCDR.ColumnCount = 15;

            gvFormatCDR.Columns[0].Name = "IMEI";
            gvFormatCDR.Columns[1].Name = "IMSI";
            gvFormatCDR.Columns[2].Name = "A Number";
            gvFormatCDR.Columns[3].Name = "B Number";
            gvFormatCDR.Columns[4].Name = "Start Time";
            gvFormatCDR.Columns[5].Name = "End Time";
            gvFormatCDR.Columns[6].Name = "Service Provider";
            gvFormatCDR.Columns[7].Name = "Type";
            gvFormatCDR.Columns[8].Name = "Direction";
            gvFormatCDR.Columns[9].Name = "Location";
            gvFormatCDR.Columns[10].Name = "Cell Id";
            gvFormatCDR.Columns[11].Name = "Cell Sector";
            gvFormatCDR.Columns[12].Name = "Latitude";
            gvFormatCDR.Columns[13].Name = "Longitude";
            gvFormatCDR.Columns[14].Name = "Duration";


            gvFormatCDR.Rows.Add("355415107599740", "410035124076631", "923319514555", "923008352613", "6/6/2021 16:11", "6/6/2021 16:12",
                "mobilink", "VOICE", "OUTGOING", "Mengan - MENGAN", "3201829640", "1", "32.67627", "72.67541", "2");
        }

        private void btnTelenor_Click(object sender, EventArgs e)
        {
            gvFormatCDR.Columns.Clear();
            gvFormatCDR.Rows.Clear();
            gvFormatCDR.Refresh();

            gvFormatCDR.ColumnCount = 15;

            gvFormatCDR.Columns[0].Name = "MSISDN";
            gvFormatCDR.Columns[1].Name = "CALL_ORIG_NUM";
            gvFormatCDR.Columns[2].Name = "CALL_DIALED_NUM";
            gvFormatCDR.Columns[3].Name = "IMSI";
            gvFormatCDR.Columns[4].Name = "IMEI";
            gvFormatCDR.Columns[5].Name = "CALL_START_DT_TM";
            gvFormatCDR.Columns[6].Name = "CALL_END_DT_TM";
            gvFormatCDR.Columns[7].Name = "INBOUND_OUTBOUND_IND";
            gvFormatCDR.Columns[8].Name = "Call_Network_Volume";
            gvFormatCDR.Columns[9].Name = "Cell_Lac_Id";
            gvFormatCDR.Columns[10].Name = "Cell_Site_Id";
            gvFormatCDR.Columns[11].Name = "LAT";
            gvFormatCDR.Columns[12].Name = "LONGITUDE";
            gvFormatCDR.Columns[13].Name = "CALL_TYPE";
            gvFormatCDR.Columns[14].Name = "Location";


            gvFormatCDR.Rows.Add("923480917244", "923480917244", "923000000000", "410000000000000", "86100000000000", "5/29/2021 1:59",
                "5/29/2021 3:58", "OUTGOING", "7142", "0", "217890051", "34.7311", "72.0671", "GPRS", "Village Tazagram, Tehsil Chakdara , Dist, Lower Dir");
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            gvFormatCDR.Columns.Clear();
            gvFormatCDR.Rows.Clear();
            gvFormatCDR.Refresh();

            gvFormatCDR.ColumnCount = 13;

            gvFormatCDR.Columns[0].Name = "A_Num";
            gvFormatCDR.Columns[1].Name = "B_Num";
            gvFormatCDR.Columns[2].Name = "IMEI";
            gvFormatCDR.Columns[3].Name = "Date & Time";
            gvFormatCDR.Columns[4].Name = "Call_Dur";
            gvFormatCDR.Columns[5].Name = "Call_Dir";
            gvFormatCDR.Columns[6].Name = "Call_Type";
            gvFormatCDR.Columns[7].Name = "Lac_No";
            gvFormatCDR.Columns[8].Name = "Cell_ID";
            gvFormatCDR.Columns[9].Name = "Loc";
            gvFormatCDR.Columns[10].Name = "Lat";
            gvFormatCDR.Columns[11].Name = "Lng";
            gvFormatCDR.Columns[12].Name = "Network";

            gvFormatCDR.Rows.Add("923005781557", "923229208358", "86957904268925", "9/6/2021  9:05:16", "0",
                "incoming", "sms", "3243", "2411", "UKHI9909__S_Sec D Bhitai Colony warid_MDKA2627, Plot no.428:sector D bhittai colony:korangi KARACHI (3G)|24.81170000|67.10840000", "24.8117", "67.1084", "jazz");
            gvFormatCDR.Rows.Add("923005781557", "923229208358", "86957904268925", "9/6/2021  9:05:16", "0",
                "outgoing", "sms", "3243", "2411", "UKHI9909__S_Sec D Bhitai Colony warid_MDKA2627, Plot no.428:sector D bhittai colony:korangi KARACHI (3G)|24.81170000|67.10840000", "24.8117", "67.1084", "jazz");
            gvFormatCDR.Rows.Add("923005781557", "923229208358", "86957904268925", "9/6/2021  9:05:16", "100",
                "incoming", "voice", "3243", "2411", "UKHI9909__S_Sec D Bhitai Colony warid_MDKA2627, Plot no.428:sector D bhittai colony:korangi KARACHI (3G)|24.81170000|67.10840000", "24.8117", "67.1084", "jazz");
            gvFormatCDR.Rows.Add("923005781557", "923229208358", "86957904268925", "9/6/2021  9:05:16", "67",
                "outgoing", "voice", "3243", "2411", "UKHI9909__S_Sec D Bhitai Colony warid_MDKA2627, Plot no.428:sector D bhittai colony:korangi KARACHI (3G)|24.81170000|67.10840000", "24.8117", "67.1084", "jazz");
        }

        private void btnBTS_Click(object sender, EventArgs e)
        {
            gvFormatCDR.Columns.Clear();
            gvFormatCDR.Rows.Clear();
            gvFormatCDR.Refresh();

            gvFormatCDR.ColumnCount = 11;

            gvFormatCDR.Columns[0].Name = "A_Num";
            gvFormatCDR.Columns[1].Name = "B_Num";
            gvFormatCDR.Columns[2].Name = "IMEI";
            gvFormatCDR.Columns[3].Name = "Date";
            gvFormatCDR.Columns[4].Name = "Time";
            gvFormatCDR.Columns[5].Name = "Call_Dur";
            gvFormatCDR.Columns[6].Name = "Call_Dir";
            gvFormatCDR.Columns[7].Name = "Call_Type";
            gvFormatCDR.Columns[8].Name = "Lac_No";
            gvFormatCDR.Columns[9].Name = "Cell_ID";
            gvFormatCDR.Columns[10].Name = "Network";

            gvFormatCDR.Rows.Add("3495151504", "3405184687", "35913004501308", "08/06/2020", "0:00:00",
                "143", "outgoing", "gsm", "348", "59034", "telenor");
            gvFormatCDR.Rows.Add("3495151504", "3405184687", "35913004501308", "08/06/2020", "0:00:00",
                "143", "incoming", "gsm", "348", "59034", "telenor");
            gvFormatCDR.Rows.Add("3495151504", "3405184687", "35913004501308", "08/06/2020", "0:00:00",
                "0", "outgoing", "sms", "348", "59034", "telenor");
            gvFormatCDR.Rows.Add("3495151504", "3405184687", "35913004501308", "08/06/2020", "0:00:00",
                "0", "incoming", "sms", "348", "59034", "telenor");
            gvFormatCDR.Rows.Add("3495151504", "3405184687", "35913004501308", "08/06/2020", "0:00:00",
                "143", "outgoing", "gprs", "348", "59034", "telenor");
            gvFormatCDR.Rows.Add("3495151504", "3405184687", "35913004501308", "08/06/2020", "0:00:00",
                "143", "incoming", "gprs", "348", "59034", "telenor");
        }

        private void lbSampleDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://drive.google.com/file/d/1cSFMC8ggfb2EmbAUbGoBU8mZzrWot2V1/view?usp=sharing");
        }

        private void lbVideoLecture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://drive.google.com/file/d/1T8EDmUwyhGimN-9eWvDc7N3XHBaLWVoT/view?usp=sharing");
        }
    }
}
