namespace ReadExcelApp
{
    class CDRSummary
    {
        public string Name { get; set; }
        public string CNIC { get; set; }
        public string BParty { get; set; }
        public int In { get; set; }
        public int Out { get; set; }
        public int inSMS { get; set; }
        public int outSMS { get; set; }
        public int Total { get; set; }

        public string Address { get; set; }

        public CDRSummary(string Name, string CNIC, string BParty, int In, int inSMS,
            int Out, int outSMS, int Total, string Address)
        {
            this.Name = Name;
            this.CNIC = CNIC;
            this.BParty = BParty;
            this.In = In;
            this.Out = Out;
            this.inSMS = inSMS;
            this.outSMS = outSMS;
            this.Total = Total;
            this.Address = Address;
        }
    }
}
