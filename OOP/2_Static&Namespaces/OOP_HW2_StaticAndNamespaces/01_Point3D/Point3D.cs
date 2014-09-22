using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Point3D
{
    public class Point3D
    {
        private string name;
        private float[] coordinates;
        public Point3D(string name, float xCoord, float yCoord, float zCoord)
        {
            this.Name = name;
            this.Coordinates = new float[3]{xCoord, yCoord, zCoord};
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new FormatException("Name can not be empty!");
                }
                this.name = value;
            }
        }
        public float[] Coordinates
        {
            get {return this.coordinates;}
            set {this.coordinates = value;}
        }
        public static Point3D StartPoint = new Point3D("Oxyz", 0f, 0f, 0f);        

        public override string ToString()
        {
            string result = this.name + ": (" + string.Join(", ", this.coordinates) + ")";
            return result;
        }
    }
}