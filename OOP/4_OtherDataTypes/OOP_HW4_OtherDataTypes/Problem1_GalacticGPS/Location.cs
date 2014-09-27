using System;

namespace Problem1_GalacticGPS
{
    struct Location
    {
        private double latitude;
        private double longitude;
        private Planet planet;
        
        public Location(double latitude, double longitude, Planet planet) : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }
        public double Latitude 
        {
            get { return this.latitude; }
            set 
            {
                if (value < 0 )
                {
                    Console.WriteLine("Latitude must be positive!");
                    throw new ArgumentOutOfRangeException();
                }
                this.latitude = value;
            }
        }
        public double Longitude
        {
            get { return this.longitude; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Longitude must be positive!");
                    throw new ArgumentOutOfRangeException();
                }
                this.longitude = value;
            }
        }
        public Planet Planet
        {
            get { return this.planet; }
            set { this.planet = value;  }
        }
        public override string ToString()
        {
            return String.Format("{0}, {1} - {2}", this.Latitude, this.Longitude, this.Planet);
        }       
    }
}