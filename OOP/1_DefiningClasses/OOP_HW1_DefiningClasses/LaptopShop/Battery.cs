using System;

namespace LaptopShop
{
    public class Battery
    {
        private string batteryType;
        private float batteryLife;

        public Battery(string batteryType, float batteryLife)
        {
            this.BatType = batteryType;
            this.BatLife = batteryLife;
        }
        public string BatType
        {
            get
            {
                return this.batteryType;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Battery type can not be empty!");
                }
                this.batteryType = value;
            }
        }
        public float BatLife
        {
            get
            {
                return this.batteryLife;
            }
            set
            {
                if (value <= 0)
                {
                    throw new FormatException("Battery life must be > zero!");
                }
                this.batteryLife = value;
            }
        }
    }
}
