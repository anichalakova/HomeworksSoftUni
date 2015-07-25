using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Data
{
    internal class Office : Building, IOffice, IBuildingEstate
    {
        public Office()
        {
            this.Type = EstateType.Office; 
        }

          public Office(string name, EstateType type, double area, string location, bool isFurnished, int rooms, bool hasElevator)
            : base(name, type, area ,location, isFurnished, rooms, hasElevator)
        {
            this.Type = EstateType.Office; 
        }
    }
}
