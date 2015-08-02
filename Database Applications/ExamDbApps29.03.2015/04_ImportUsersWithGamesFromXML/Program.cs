using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using DbAppsExam;

namespace _04_ImportUsersWithGamesFromXML
{
    class Program
    {
        private static void Main()
        {
            var inputXml = XDocument.Load("../../users-and-games.xml");
            var xUsers = inputXml.XPathSelectElements("/users/user");
            var context = new DiabloContext();
            foreach (var xUser in xUsers)
            {
                var username = xUser.Attribute("username").Value;

                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var isExistingUser = CreateUserIfNotExists(xUser, context, username);
                        if (!isExistingUser)
                        {
                            AddGamesToUser(xUser, context, username);
                        }
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

        private static bool CreateUserIfNotExists(XElement xUser, DiabloContext context, string username)
        {
            User user = null;

            if (context.Users.Any(u => u.Username == username))
            {
                user = context.Users.First(u => u.Username == username);
                Console.WriteLine("User {0} already exists", user.Username);
                return true;
            }
            else
            {
                var isDeleted = (xUser.Attribute("is-deleted").Value == "1") ? true : false;
                var ipAddress = xUser.Attribute("ip-address").Value;
                var registrationDate = DateTime.Parse(xUser.Attribute("registration-date").Value);

                user = new User()
                {
                    Username = username,
                    IsDeleted = isDeleted,
                    IpAddress = ipAddress,
                    RegistrationDate = registrationDate
                };

                if (xUser.Attribute("first-name") != null)
                {
                    var firstName = xUser.Attribute("first-name").Value;
                    user.FirstName = firstName;
                }

                if (xUser.Attribute("last-name") != null)
                {
                    var lastName = xUser.Attribute("last-name").Value;
                    user.LastName = lastName;
                }

                if (xUser.Attribute("email") != null)
                {
                    var email = xUser.Attribute("email").Value;
                    user.Email = email;
                }
                context.Users.Add(user);
                context.SaveChanges();
                return false;
            }
        }

        private static void AddGamesToUser(XElement xUser, DiabloContext context, string username)
        {
            var dbUser = context.Users.First(u => u.Username == username);
            var xGames = xUser.Elements("games");
            
            foreach (var element in xGames)
            {
                var xGame = element.Element("game");

                var gameName = xGame.Element("game-name").Value;
                var character = xGame.Element("character");
                var characterName = character.Attribute("name").Value;
                var cash = decimal.Parse(character.Attribute("cash").Value);
                var level = int.Parse(character.Attribute("level").Value);
                var joinedOn = DateTime.Parse(xGame.Element("joined-on").Value);

                var dbGame = context.Games.First(g => g.Name == gameName);
                var dbCharacter = context.Characters.First(ch => ch.Name == characterName);
                context.UsersGames.Add(new UsersGame()
                {
                    Game = dbGame,
                    User = dbUser,
                    Character = dbCharacter,
                    JoinedOn = joinedOn,
                    Cash = cash,
                    Level = level
                });

                context.SaveChanges();

                Console.WriteLine("Successfully added user {0}", dbUser.Username);
                Console.WriteLine("User {0} successfully added to game {1}", dbUser.Username, dbGame.Name);
            }
        }
    }
}
