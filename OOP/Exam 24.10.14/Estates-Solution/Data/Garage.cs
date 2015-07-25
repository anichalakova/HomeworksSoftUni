using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Data
{
    internal class Garage : Estate, IGarage, IEstate
    {
        private const int minWidth = 0;
        private const int maxWidth = 500;
        private const int minHeight = 0;
        private const int maxHeight = 500;

        private int width;
        private int height;

        public Garage()
        {
            this.Type = EstateType.Garage;
        }

        public Garage(string name, EstateType type, double area, string location, bool isFurnished, int width, int height)
            : base(name, type, area, location, isFurnished)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if ((value < minWidth)||(value > maxWidth))
                {
                    throw new ArgumentOutOfRangeException(string.Format("Width should be in the interval {0}-{1} m.", minWidth, maxWidth));
                }
                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if ((value < minHeight) || (value > maxHeight))
                {
                    throw new ArgumentOutOfRangeException(string.Format("Height should be in the interval {0}-{1} m.", minHeight, maxHeight));
                }
                this.height = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Width: {0}, Height: {1}", this.Width, this.Height);
        }
    }
}
