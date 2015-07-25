using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estates.Engine;
using Estates.Interfaces;


namespace Estates.Data
{
    internal class EstateEngineExtension : EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "find-rents-by-location":
                    {
                        return this.ExecuteFindRentsByLocationCommand(cmdArgs[0]);
                    }
                case "find-rents-by-price":
                    {
                        return this.ExecuteFindRentsByPriceCommand(cmdArgs[0], cmdArgs[1]);
                    }
                default:
                    {
                        return base.ExecuteCommand(cmdName, cmdArgs);
                    }
            }

        }

        private string ExecuteFindRentsByLocationCommand(string location)
        {
            var offers = this.Offers
                .Where(o => o.Estate.Location == location && o.Type == OfferType.Rent)
                .OrderBy(o => o.Estate.Name);
            return FormatQueryResults(offers);
        }

        private string ExecuteFindRentsByPriceCommand(string minPriceString, string maxPriceString)
        {
            int minPrice = int.Parse(minPriceString);
            int maxPrice = int.Parse(maxPriceString);

            var rentOffers = this.Offers.Where(o => o.Type == OfferType.Rent);
                    
            List<IOffer> offers = new List<IOffer>();

            foreach (var offer in rentOffers)
            {
                var newTypeOffer = offer as RentOffer;

                if ((newTypeOffer.PricePerMonth <= maxPrice)&&(newTypeOffer.PricePerMonth >= minPrice))
                {
                    offers.Add(offer);
                }
            }

            return FormatQueryResults(offers);
        }
    }
}
