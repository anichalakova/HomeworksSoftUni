using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Catalog
{
    class PC_Catalog
    {
        static void Main()
        {
            Component comp = new Component();            
            Component comp1 = new Component("component1", 12);            
            Component comp2 = new Component("component2", 1090, "some details");           
            List<Component> components = new List<Component>();
            components.Add(comp1);
            components.Add(comp2);            
            Computer pc1 = new Computer("Best PC", components);
            Console.WriteLine(pc1.ToString());
        }
    }
}
