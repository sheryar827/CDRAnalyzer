namespace ReadExcelApp
{
    class TopB_NumCallSec
    {
        public string B_Num { get; set; }
        public string B_NumCallMin { get; set; }
        public int B_NumCallSec { get; set; }


        public TopB_NumCallSec(string B_Num, string B_NumCallMin, int B_NumCallSec)
        {
            this.B_Num = B_Num;
            this.B_NumCallMin = B_NumCallMin;
            this.B_NumCallSec = B_NumCallSec;
        }
    }
}
