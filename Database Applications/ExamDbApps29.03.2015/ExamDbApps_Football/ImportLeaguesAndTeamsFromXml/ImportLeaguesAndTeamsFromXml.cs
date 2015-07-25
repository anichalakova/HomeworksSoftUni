namespace ImportLeaguesAndTeamsFromXml
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using ExamDbApps_Football;
    class ImportLeaguesAndTeamsFromXml
    {
        static void Main()
        {
            var xDoc = XDocument.Load("../../leagues-and-teams.xml");
            var context = new FootballEntities();
            int leagueElementsCounter = 0;

            foreach (var leagueElement in xDoc.Descendants("league"))
            {
                leagueElementsCounter++;
                Console.WriteLine(string.Format("Processing league #{0} ...", leagueElementsCounter));
                var league = new League();

                ProcessLeagueElement(leagueElement, league, context);

                var teams = leagueElement.Descendants("team").ToList();

                foreach (var teamElement in teams)
                {
                    var team = ProcessTeamElement(teamElement, context, league);
                }
                Console.WriteLine();
            }
        }

        private static Team ProcessTeamElement(XElement teamElement, FootballEntities context, League league)
        {
            var team = new Team();
            string name = teamElement.Attribute("name").Value;
            team.TeamName = name;
            string country = "no country";
            if (teamElement.Attribute("country") != null)
            {
                country = teamElement.Attribute("country").Value;

                if (context.Countries.Any(c => c.CountryName == country))
                {
                    team.CountryCode =
                        context.Countries.Where(c => c.CountryName == country).Select(c => c.CountryCode).First();
                }
                else
                {
                    team.Country = new Country
                    {
                        CountryName = country,
                        CountryCode = "XX"
                    };
                }
            }

            if(!context.Teams.Any(t => t.TeamName == team.TeamName && (country == t.Country.CountryName)))
            {
                context.Teams.Add(team);
                context.SaveChanges();
                Console.WriteLine(string.Format("Created team: {0} ({1})", team.TeamName, country));
            }
            else
            {
                Console.WriteLine(string.Format("Existing team: {0} ({1})", team.TeamName, country));
            }

            if (league.LeagueName != null)
            {
                var leagueInContext = context.Leagues.First(l => l.LeagueName == league.LeagueName);

                if (leagueInContext.Teams.Any(t => t.TeamName == team.TeamName && t.CountryCode == team.CountryCode))
                {
                    Console.WriteLine(string.Format("Existing team in league: {0} belongs to {1}", team.TeamName,
                        league.LeagueName));
                }
                else
                {
                    leagueInContext.Teams.Add(team);
                    context.SaveChanges();
                    Console.WriteLine(string.Format("Added team to league: {0} to {1}", team.TeamName, league.LeagueName));
                }
            }
            return team;
        }

        private static void ProcessLeagueElement(XElement leagueElement, League league, FootballEntities context)
        {
            if (leagueElement.Descendants("league-name").Any())
            {
                league.LeagueName = leagueElement.Descendants("league-name").First().Value;
            }

            if (!context.Leagues.Any(l => l.LeagueName == league.LeagueName)&&(league.LeagueName != null ))
            {
                context.Leagues.Add(league);
                context.SaveChanges();
                Console.WriteLine(string.Format("Created league: {0}", league.LeagueName));
            }
            else if (context.Leagues.Any(l => l.LeagueName == league.LeagueName))
            {
                Console.WriteLine(string.Format("Existing league: {0}", league.LeagueName));
            }
        }
    }
}
