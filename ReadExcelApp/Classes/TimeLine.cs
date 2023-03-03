using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadExcelApp.Classes
{
    class TimeLine
    {
        public string year { get; set; }
        public string month { get; set; }
        public string day { get; set; }
        public string hour { get; set; }
        public string minute { get; set; }
        public string b_party { get; set; }
        public string call_type { get; set; }
        public string duration { get; set; }
        public string location { get; set; }
        public string cell_id { get; set; }
        public string imei { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string a_party { get; set; }
        public string date_time { get; set; }
        public string lac { get; set; }
        public string b_party_type { get; set; }
        public string b_party_country { get; set; }
        public string dur { get; set; }

        public TimeLine(string year, string month, string day, string hour, string minute,
            string b_party, string call_type, string duration, string location,
            string cell_id, string imei, string lat, string lng, string a_party,
            string date_time, string lac, string b_party_type, string b_party_country, string dur)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.minute = minute;
            this.b_party = b_party;
            this.call_type = call_type;
            this.duration = duration;
            this.location = location;
            this.cell_id = cell_id;
            this.imei = imei;
            this.lat = lat;
            this.lng = lng;
            this.a_party = a_party;
            this.date_time = date_time;
            this.lac = lac;
            this.b_party_type = b_party_type;
            this.b_party_country = b_party_country;
            this.dur = dur;
        }
    }
}
