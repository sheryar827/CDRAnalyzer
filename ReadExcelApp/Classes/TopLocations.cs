namespace ReadExcelApp
{
    class TopLocations
    {
        public string Loc { get; set; }
        public int In { get; set; }
        public int Out { get; set; }
        public int inSMS { get; set; }
        public int outSMS { get; set; }
        public int Total { get; set; }

        public TopLocations(string Loc
            , int In
            , int Out
            , int inSMS
            , int outSMS
            , int Total)
        {
            this.Loc = Loc;
            this.In = In;
            this.Out = Out;
            this.inSMS = inSMS;
            this.outSMS = outSMS;
            this.Total = Total;
        }

    }
}
