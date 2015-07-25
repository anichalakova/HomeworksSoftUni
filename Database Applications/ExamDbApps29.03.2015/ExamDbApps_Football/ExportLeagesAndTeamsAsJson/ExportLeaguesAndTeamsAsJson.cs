namespace ExportLeagesAndTeamsAsJson
{
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using ExamDbApps_Football;
    class ExportLeaguesAndTeamsAsJson
    {
        static void Main()
        {
            var context = new FootballEntities();
            JavaScriptSerializer ser = new JavaScriptSerializer();

            var leaguesQuery = context.Leagues
                .Select(l => new
                {
                    leagueName = l.LeagueName,
                    teams = l.Teams.OrderBy(t => t.TeamName).Select(t => t.TeamName).ToList()
                })
                .OrderBy(l => l.leagueName);

            var json = ser.Serialize(leaguesQuery);

            File.WriteAllText("../../leagues-and-teams.json", json);
        }
    }
}
