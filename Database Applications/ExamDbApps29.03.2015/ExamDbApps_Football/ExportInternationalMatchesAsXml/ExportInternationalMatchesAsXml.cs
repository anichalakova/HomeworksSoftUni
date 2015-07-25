namespace ExportInternationalMatchesAsXml
{
    using System.Linq;
    using System.Xml.Linq;
    using ExamDbApps_Football;
    class ExportInternationalMatchesAsXml
    {
        static void Main()
        {
            var context = new FootballEntities();

            var xDoc = new XDocument();
            var xmlRoot = new XElement("matches");

            var internationalMatchesQuery = context.InternationalMatches
                .Select(m => new
                {
                    HomeCountry = new {Name = m.HomeCountry.CountryName, Code = m.HomeCountry.CountryCode},
                    AwayCountry = new {Name = m.AwayCountry.CountryName, Code = m.AwayCountry.CountryCode},
                    m.League,
                    m.MatchDate,
                    m.AwayGoals,
                    m.HomeGoals
                })
                .OrderBy(m => m.MatchDate)
                .ThenBy(m => m.HomeCountry)
                .ThenBy(m => m.AwayCountry);

            foreach (var match in internationalMatchesQuery)
            {
                var matchElement = new XElement("match");

                if (match.MatchDate != null)
                {
                    if (match.MatchDate.Value.TimeOfDay.TotalSeconds != 0)
                    {
                        matchElement.SetAttributeValue("date-time", match.MatchDate.Value.ToString("dd-MMM-yyyy HH:mm"));    
                    }
                    else
                    {
                        matchElement.SetAttributeValue("date", match.MatchDate.Value.ToString("dd-MMM-yyyy")); 
                    }
                }
                
                var homeCountryElement = new XElement("home-country", match.HomeCountry);
                homeCountryElement.SetAttributeValue("code", match.HomeCountry.Code);
                var awayCountryElement = new XElement("away-country", match.AwayCountry.Name);
                awayCountryElement.SetAttributeValue("code", match.AwayCountry.Code);
                matchElement.Add(homeCountryElement);
                matchElement.Add(awayCountryElement);

                if ((match.HomeGoals != null) && (match.AwayGoals != null))
                {
                    var matchScoreElement = new XElement("score", string.Format("{0}-{1}", match.HomeGoals, match.AwayGoals));
                    matchElement.Add(matchScoreElement);
                }


                if (match.League != null)
                {
                    var matchLeagueElement = new XElement("league", match.League.LeagueName);
                    matchElement.Add(matchLeagueElement);
                }

                xmlRoot.Add(matchElement);
            }

            xDoc.Add(xmlRoot);
            xDoc.Save("../../international-matches.xml ");
        }
    }
}
