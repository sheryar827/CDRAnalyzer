using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadExcelApp.Classes
{
    class YearMonthNewBNum
    {
        public string year { get; set; }
        public string month { get; set; }

        public string count { get; set; }

        public string name { get; set; }

        public string cnic { get; set; }
        public string bnum { get; set; }

        public int inCall { get; set; }

        public int outCall { get; set; }

        public int inSMS { get; set; }

        public int outSMS { get; set; }

        public int total { get; set; }

        public string address { get; set; }

        public string b_party_type { get; set; }
        public string b_party_country { get; set; }

        public YearMonthNewBNum(string year
            , string month
            , string count
            , string name
            , string cnic
            , string bnum
            , int inCall
            , int outCall
            , int inSMS
            , int outSMS
            , int total
            , string address
            , string b_party_type
            , string b_party_country)
        {
            this.year = year;
            this.month = month;
            this.count = count;
            this.name = name;
            this.cnic = cnic;
            this.bnum = bnum;
            this.inCall = inCall;
            this.outCall = outCall;
            this.inSMS = inSMS;
            this.outSMS = outSMS;
            this.total = total;
            this.address = address;
            this.b_party_type = b_party_type;
            this.b_party_country = b_party_country;
        }
    }
}
