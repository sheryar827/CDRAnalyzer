namespace ReadExcelApp
{
    class LacCellID
    {
        public string Lac { get; set; }

        public string Cell_ID { get; set; }



        public LacCellID(string Lac, string Cell_ID)
        {
            this.Lac = Lac;
            this.Cell_ID = Cell_ID;
        }
    }
}
