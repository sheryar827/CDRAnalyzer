namespace ReadExcelApp
{
    class SilentPurgedLocationDate
    {
        public string startloc { get; set; }
        public string startdate { get; set; }
        public string endloc { get; set; }
        public string enddate { get; set; }

        public string duration { get; set; }

        public string silentPurged { get; set; }

        public string bIn { get; set; }

        public string bOut { get; set; }

        public string aIn { get; set; }

        public string aOut { get; set; }

        public SilentPurgedLocationDate(string startlocation
            , string startdate
            , string endlocation
            , string enddate
            , string duration
            , string sp
            , string bIn
            , string bOut
            , string aIn
            , string aOut)
        {
            this.startloc = startlocation;
            this.startdate = startdate;
            this.endloc = endlocation;
            this.enddate = enddate;
            this.duration = duration;
            this.silentPurged = sp;
            this.bIn = bIn;
            this.bOut = bOut;
            this.aIn = aIn;
            this.aOut = aOut;
        }
    }
}
