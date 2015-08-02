using System;
using System.Linq;
using System.Xml.Linq;
using DbAppsExam;

namespace _03_ExportFinishedGamesToXML
{
    class Program
    {
        static void Main()
        {
            var context = new DiabloContext();

            var gamesWithPlayers = context.Games
                .Where(g => g.IsFinished == true)
                .OrderBy(g =>g.Name)
                .ThenBy(g=>g.Duration)
                .Select(g => new
                {
                    Name = g.Name,
                    Duration = g.Duration,
                    Users = g.UsersGames.Select(ug => new
                    {
                        Username = ug.User.Username,
                        IpAddress = ug.User.IpAddress
                    })
                })
                .ToList();

            var resultXml = new XElement("games");
            foreach (var game in gamesWithPlayers)
            {
                var gameXml = new XElement("game");
                gameXml.Add(new XAttribute("name", game.Name));
                if (game.Duration != null)
                {
                    gameXml.Add(new XAttribute("duration", game.Duration));
                }

                var usersXml = new XElement("users");
                foreach (var user in game.Users)
                {
                    var userXml = new XElement("user");
                    userXml.Add(new XAttribute("username", user.Username));
                    userXml.Add(new XAttribute("ip-address", user.IpAddress));
                    usersXml.Add(userXml);
                }
                gameXml.Add(usersXml);
                resultXml.Add(gameXml);
            }

            var resultXmlDoc = new XDocument();
            resultXmlDoc.Add(resultXml);
            resultXmlDoc.Save("../../finished-games.xml");

            Console.WriteLine("Finished games exported to finished-games.xml");
        }
    }
}
