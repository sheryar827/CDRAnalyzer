namespace ReadExcelApp
{
    class GetLatLngForMap
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }



        public GetLatLngForMap(double Latitude, double Longitude)
        {
            this.Latitude = Latitude;
            this.Longitude = Longitude;

        }
    }
}
