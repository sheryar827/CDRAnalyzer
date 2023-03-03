namespace ReadExcelApp
{
    class SubInfo
    {
        public string Mobile { get; set; }
        public string Name { get; set; }
        public string CNIC { get; set; }
        public string Address { get; set; }


        public SubInfo(string Mobile, string Name, string CNIC, string Address)
        {
            this.Mobile = Mobile;
            this.Name = Name;
            this.CNIC = CNIC;
            this.Address = Address;

        }
    }
}
