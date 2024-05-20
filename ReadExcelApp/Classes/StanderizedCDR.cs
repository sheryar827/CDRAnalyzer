namespace ReadExcelApp
{
    public class StanderizedCDR
    {
        public string A_Num { get; set; } = "0";
        public string B_Num { get; set; } = "0";
        public string IMEI { get; set; } = "0";
        public string Date { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public string Call_Dur { get; set; } = "0";
        public string Call_Dir { get; set; } = string.Empty;

        public string Call_Type { get; set; } = string.Empty;

        public string Lac_No { get; set; } = "0";
        public string Cell_ID { get; set; } = "0";
        public string Loc { get; set; } = "Nil";
        public string Lat { get; set; } = "0";
        public string Lng { get; set; } = "0";
        public string Network { get; set; } = string.Empty;

        public string Weekday { get; set; } = string.Empty;
    }
}
