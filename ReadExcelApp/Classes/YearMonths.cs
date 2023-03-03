using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadExcelApp.Classes
{
    class YearMonths
    {
        public int year { get; set; }
        public int month { get; set; }

        public YearMonths (int year, int month)
        {
            this.year = year;
            this.month = month;
        }
    }
}
