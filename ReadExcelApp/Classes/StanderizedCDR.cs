namespace ReadExcelApp
{
    public class StanderizedCDR
    {
        public string A_Num { get; set; } = string.Empty;
        public string B_Num { get; set; } = string.Empty;
        public string IMEI { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public string Call_Dur { get; set; } = string.Empty;
        public string Call_Dir { get; set; } = string.Empty;

        public string Call_Type { get; set; } = string.Empty;

        public string Lac_No { get; set; } = string.Empty;
        public string Cell_ID { get; set; } = string.Empty;
        public string Loc { get; set; } = string.Empty;
        public string Lat { get; set; } = "0";
        public string Lng { get; set; } = "0";
        public string Network { get; set; } = string.Empty;

        public string Weekday { get; set; } = string.Empty;
    }
}
