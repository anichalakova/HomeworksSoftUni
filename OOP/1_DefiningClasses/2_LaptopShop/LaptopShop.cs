using System;

namespace LaptopShop
{
    class LaptopShop
    {

        static void Main()
        {
            Battery bat = new Battery("Li-Ion, 4-cells, 2550 mAh", 4.5f);
            Laptop lenYoga2 = new Laptop("Lenovo Yoga 2 Pro", 2259.00m, "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", 8, "Intel HD Graphics 4400", "128GB SSD", 13.3f, bat);
            Laptop hp250 = new Laptop("HP 250 G2", 699m);
            Console.WriteLine(lenYoga2.ToString());
            Console.WriteLine(hp250.ToString());
        }
    }
}