using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Data
{
    internal class Offer : IOffer
    {
        private OfferType type;
        private IEstate estate;

        public Offer()
        {
        }

        public Offer(OfferType type, IEstate estate)
        {
            this.Type = type;
            this.Estate = estate;
        }

        public OfferType Type
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

        public IEstate Estate
        {
            get
            {
                return this.estate;
            }
            set
            {
                this.estate = value;
            }
        }
        
        public override string ToString()
        {
            return string.Format("{0}: Estate = {1}, Location = {2}", this.Type, this.Estate.Name, this.Estate.Location);
        }
    }
}
