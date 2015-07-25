using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Data
{
    internal class RentOffer: Offer, IRentOffer, IOffer
    {
        private decimal pricePerMonth;

        public RentOffer()
        {
            this.Type = OfferType.Rent;
        }

        public RentOffer(OfferType type, IEstate estate, decimal pricePerMonth)
            : base(type, estate)
        {
            this.Type = OfferType.Rent;
            this.PricePerMonth = pricePerMonth;
        }

        public decimal PricePerMonth
        {
            get
            {
                return this.pricePerMonth;
            }
            set
            {
                this.pricePerMonth = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Price = {0}", string.Format("{0:0.00}", this.PricePerMonth));
        }
    }
}
