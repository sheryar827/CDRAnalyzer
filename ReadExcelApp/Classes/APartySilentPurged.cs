namespace ReadExcelApp
{
    class APartySilentPurged
    {

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string DateTimeDiff { get; set; }

        public string SilentPurged { get; set; }

        public APartySilentPurged(string StartDate, string EndDate, string DateTimeDiff, string SilentPurged)
        {
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.DateTimeDiff = DateTimeDiff;
            this.SilentPurged = SilentPurged;
        }
    }

}
