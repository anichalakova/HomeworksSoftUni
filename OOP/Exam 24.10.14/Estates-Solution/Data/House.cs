using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Data
{
    class House : Estate, IHouse, IEstate
    {
        private const int minFloorsNumber = 0;
        private const int maxFloorsNumber = 10;

        private int floors;

        public House()
        {
            this.Type = EstateType.House;
        }

        public House(string name, EstateType type, double area, string location, bool isFurnished, int floors)
            : base(name, type, area, location, isFurnished)
        {
            this.Floors = floors;
        }

        public int Floors
        {
            get
            {
                return this.floors;
            }
            set
            {
                if ((value < minFloorsNumber)||(value > maxFloorsNumber))
                {
                    throw new ArgumentOutOfRangeException(string.Format("Floors must be in the range {0}-{1}.", minFloorsNumber, maxFloorsNumber));
                }
                this.floors = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Floors: {0}", this.Floors);
        }
    }
}
