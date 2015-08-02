using System;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using DbAppsExam;

namespace _02_ExportCharactersPlayersToJson
{
    class Program
    {
        //Add Entity Framework from NuGet - otherwise this project fails to build. All the other projects are fine.
        static void Main()
        {
            var context = new DiabloContext();

            var characters = context.Characters.OrderBy(ch => ch.Name).Select(ch => new
            {
                name = ch.Name,
                playedBy = ch.UsersGames.Select(ug => ug.User.Username)
            }).ToList();

            var jsSerializer = new JavaScriptSerializer();
            var json = jsSerializer.Serialize(characters);
            
            File.WriteAllText("../../characters.json", json);
            Console.WriteLine("File characters.json exported.");
        }
    }
}
