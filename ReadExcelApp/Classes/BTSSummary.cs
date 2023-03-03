namespace ReadExcelApp.Classes
{
    public class BTSSummary
    {
        public string AParty { get; set; }
        public string AStatus { get; set; }
        public string BParty { get; set; }
        public string BStatus { get; set; }
        public int In { get; set; }
        public int Out { get; set; }
        public int inSMS { get; set; }
        public int outSMS { get; set; }
        public int Total { get; set; }
        public BTSSummary(string aparty, string astatus, string bparty, string bstatus, int In, int inSMS,
            int Out, int outSMS, int Total)
        {
            this.AParty = aparty;
            this.AStatus = astatus;
            this.BParty = bparty;
            this.BStatus = bstatus;
            this.In = In;
            this.Out = Out;
            this.inSMS = inSMS;
            this.outSMS = outSMS;
            this.Total = Total;
        }
    }
}

