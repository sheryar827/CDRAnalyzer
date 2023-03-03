using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadExcelApp.Classes
{
    class YearMonthDay
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }

        public YearMonthDay(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }
    }
}
