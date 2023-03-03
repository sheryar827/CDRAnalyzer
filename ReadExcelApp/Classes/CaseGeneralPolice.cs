namespace ReadExcelApp
{
    class CaseGeneralPolice
    {
        public int Case_ID { get; set; }
        public string Fir_No { get; set; }
        public string Dated { get; set; }
        public string U_S { get; set; }
        public string PS { get; set; }
        public string District { get; set; }
        public string Any_Detail { get; set; }


        public CaseGeneralPolice(int Case_ID, string Fir_No, string Dated, string U_S, string PS, string District, string Any_Detail)
        {
            this.Case_ID = Case_ID;
            this.Fir_No = Fir_No; this.Dated = Dated; this.U_S = U_S; this.PS = PS; this.District = District;
            this.Any_Detail = Any_Detail;
        }

    }
}
