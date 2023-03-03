using System;

namespace ReadExcelApp.Classes
{
    public class BtsStandCDR
    {
        public string A_Num { get; set; }
        public string statusLabel { get; set; }
        public string B_Num { get; set; }
        public string bpStatusLable { get; set; }
        public int In { get; set; }
        public int Out { get; set; }
        public int inSMS { get; set; }
        public int outSMS { get; set; }
        public int Total { get; set; }
        public string IMEI { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Call_Dur { get; set; }
        public string Call_Dir { get; set; }
        public string Call_Type { get; set; }
        public string Lac_No { get; set; }
        public string Cell_ID { get; set; }
        public string Network { get; set; }


    }
}
