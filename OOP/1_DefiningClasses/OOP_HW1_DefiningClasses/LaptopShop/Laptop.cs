using System;

namespace LaptopShop
{
    public class Laptop
    {
        private string model;
        private decimal price;
        private string manufacturer;
        private string processor;
        private int ram;
        private string graphicsCard;
        private string hdd;
        private float screenSize;
        private Battery battery;


        public Laptop(string model, decimal price, string manufacturer = null, string processor = null, int ram = 0, string graphicsCard = null, string hdd = null, float screenSize = 0, Battery bat = null)
        {
            this.Model = model;
            this.Price = price;
            this.manufacturer = manufacturer;
            this.processor = processor;
            this.RAM = ram;
            this.graphicsCard = graphicsCard;
            this.hdd = hdd;
            this.ScreenSize = screenSize;
            this.battery = bat;
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Model can not be empty!");
                }
                this.model = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new FormatException("Price must be > zero!");
                }
                this.price = value;
            }
        }

        public int RAM
        {
            get { return this.ram; }
            set
            {
                if (value < 0)
                {
                    throw new FormatException("Price must be > zero!");
                }
                this.ram = value;
            }
        }
        public float ScreenSize
        {
            get { return this.screenSize; }
            set
            {
                if (value < 0)
                {
                    throw new FormatException("Screen size must be > zero!");
                }
                this.screenSize = value;
            }
        }

        public override string ToString()
        {
            string result = "Laptop characteristics:\nmodel: " + this.model + "\nprice: " + this.price + " lv\n";
            if (manufacturer != null) { result += "manufacturer: " + this.manufacturer + "\n"; }
            if (processor != null) { result += "processor: " + this.processor + "\n"; }
            if (ram != 0) { result += "RAM: " + this.ram + " GB\n"; }
            if (graphicsCard != null) { result += "GPU: " + this.graphicsCard + "\n"; }
            if (hdd != null) { result += "HDD: " + this.hdd + "\n"; }
            if (screenSize != 0) { result += "screen: " + this.screenSize + "\"\n"; }
            if (battery != null) { result += "battery: " + this.battery.BatType + "\n" + "battery life: " + this.battery.BatLife + " hr\n"; }
            return result;
        }
    }
}
