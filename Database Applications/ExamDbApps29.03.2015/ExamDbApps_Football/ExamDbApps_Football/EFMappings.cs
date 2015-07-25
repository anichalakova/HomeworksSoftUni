namespace ExamDbApps_Football
{
    using System;
    class EFMappings
    {
        static void Main()
        {
            var context = new FootballEntities();

            foreach (var team in context.Teams)
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }
}
