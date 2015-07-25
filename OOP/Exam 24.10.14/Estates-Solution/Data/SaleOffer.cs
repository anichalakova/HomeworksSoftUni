using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Data
{
    class SaleOffer : Offer, ISaleOffer, IOffer
    {
        private decimal price;

        public SaleOffer()
        {
            this.Type = OfferType.Sale;
        }

        public SaleOffer(OfferType type, IEstate estate, decimal price)
            : base(type, estate)
        {
            this.Type = OfferType.Sale;
            this.Price = price;
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }            
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Price = {0}", this.Price);
        }
    }
}
