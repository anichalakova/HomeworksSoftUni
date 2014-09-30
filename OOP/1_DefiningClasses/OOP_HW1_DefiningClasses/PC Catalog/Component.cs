using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Catalog
{
    class Component
    {
        private string name;
        private string details;
        private decimal price;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name must not be empty!");
                }
                this.name = value;
            }
        }
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Price must be > zero !");
                }
                this.price = value;
            }
        }
        public string Details { get; set; }
        public Component()
        { }
        public Component(string name, decimal price, string details = null)
        {
            this.name = name;            
            this.price = price;
            this.details = details;
        }
    }
}
