using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Data
{
    internal abstract class Estate : IEstate
    {
        private const double minArea = 0;
        private const double maxArea = 10000;

        private string name;
        private EstateType type;
        private double area;
        private string location;
        private bool isFurnished;

        public Estate()
        {
        }
        
        public Estate(string name, EstateType type, double area, string location, bool isFurnished)
        {
            this.Name = name;
            this.Type = type;
            this.Area = area;
            this.Location = location;
            this.IsFurnished = isFurnished;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public EstateType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;   
            }
        }

        public double Area
        {
            get
            {
                return this.area;
            }
            set
            {
                if ((value < minArea)||(value > maxArea))
                {
                    throw new ArgumentOutOfRangeException(string.Format("Area must be in the interval {0}-{1}", minArea, maxArea));
                }
                this.area = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
            }
        }

        public bool IsFurnished
        {
            get
            {
                return this.isFurnished;
            }
            set
            {
                this.isFurnished = value;
            }
        }

        public override string ToString()
        {
            string furnishedString;

            if (isFurnished)
            {
                furnishedString = "Yes";
            }
            else
            {
                furnishedString = "No";
            }

            return string.Format("{0}: Name = {1}, Area = {2}, Location = {3}, Furnitured = {4}", this.Type, this.Name, this.Area, this.Location, furnishedString);
        }
    }
}
