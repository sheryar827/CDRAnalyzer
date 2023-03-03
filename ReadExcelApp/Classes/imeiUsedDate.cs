namespace ReadExcelApp
{
    class imeiUsedDate
    {
        public string imei { get; set; }
        public string dateTime { get; set; }

        public imeiUsedDate(string imei, string dateTime)
        {
            this.imei = imei;
            this.dateTime = dateTime;
        }
    }
}
