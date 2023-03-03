using System;

namespace ReadExcelApp
{
    class SPDateLoc
    {
        public DateTime dateTime { get; set; }
        public string location { get; set; }

        public string callType { get; set; }

        public string bparty { get; set; }

        public SPDateLoc(DateTime dt, string loc, string callType, string bparty)
        {
            this.dateTime = dt;
            this.location = loc;
            this.callType = callType;
            this.bparty = bparty;
        }
    }
}
