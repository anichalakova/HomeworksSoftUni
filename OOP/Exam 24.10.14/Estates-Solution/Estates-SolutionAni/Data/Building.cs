using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Data
{
    internal abstract class Building : Estate, IBuildingEstate, IEstate
    {
        private const int minRoomsNumber = 0;
        private const int maxRoomsNumber = 20;

        private int rooms;
        private bool hasElevator;

        public Building()
        {
        }

        public Building(string name, EstateType type, double area, string location, bool isFurnished, int rooms, bool hasElevator) : base(name, type, area ,location, isFurnished)
        {
            this.Rooms = rooms;
            this.HasElevator = hasElevator;
        }

        public int Rooms
        {
            get
            {
                return this.rooms;
            }
            set
            {
                if ((value < minRoomsNumber) || (value > maxRoomsNumber))
                {
                    throw new ArgumentOutOfRangeException(string.Format("Rooms must be in the interval {0}-{1}", minRoomsNumber, maxRoomsNumber));
                }
                this.rooms = value;
            }
        }

        public bool HasElevator
        {
            get
            {
                return this.hasElevator;
            }
            set
            {
                this.hasElevator = value;
            }
        }

        public override string ToString()
        {
            string elevatorString;

            if (this.HasElevator)
            {
                elevatorString = "Yes";
            }
            else
            {
                elevatorString = "No";
            }
            return base.ToString() + string.Format(", Rooms: {0}, Elevator: {1}", this.Rooms, elevatorString);
        }
    }
}
