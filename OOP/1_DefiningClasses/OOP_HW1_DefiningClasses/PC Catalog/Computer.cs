using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Catalog
{
    class Computer
    {
        private string name;            
        private List<Component> components;
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
        public List<Component> Components
        {
            get { return this.components; }
            set
            {
                if (components == null)
                {
                    this.components = new List<Component>();  
                }
                this.components = value;
            }
        }
        public decimal Price
        {            
            get
            {
                if (this.Components.Count == 0)
                {
                    return this.price = 0M;
                }                               
                return this.Components.Sum(x => x.Price);                                
            }
        }  
        public Computer(string name, List<Component> components)
        {
            this.Name = name;            
            this.Components = components;
        }
        public override string ToString()
        {
            string result = this.Name + "\nPrice: " + this.Price + " lv.\nComponents:\n";
            foreach (var component in components)
            {
                result += component.Name + " / " + component.Price + " lv.";
                if (component.Details != null)
                {
                    result += " / " + component.Details + "\n";
                }
                else
                {
                    result += "\n";
                }
            }            
            return result;
        }
    }
}
