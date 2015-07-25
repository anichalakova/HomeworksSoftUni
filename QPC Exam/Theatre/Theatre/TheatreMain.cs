namespace Theatre
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    
    internal class TheatreMain
    {
        public static IPerformanceDatabase PerformancesDatabase = new PerformanceDatabase();
        static void Main()
        {

            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == null)
                {
                    return;
                }

                if (commandLine != string.Empty)
                {
                    string[] commandParts = commandLine.Split('(');
                    string commandName = commandParts[0];
                    var commandArguments = ExtractCommandArguments(commandLine);
                    string commandResult = ProcessCommand(commandName, commandArguments);
                    Console.WriteLine(commandResult);
                }
            }
        }

        private static string ProcessCommand(string commandName, string[] commandArguments)
        {
            string commandResult;
            try
            {
                switch (commandName)
                {
                    case "AddTheatre":
                        commandResult = ExecuteAddTheatreCommand(commandArguments);
                        break;
                    case "PrintAllTheatres":
                        commandResult = ExecutePrintAllTheatresCommand();
                        break;
                    case "AddPerformance":
                        commandResult = ExecuteAddPerformanceCommand(commandArguments);
                        break;
                    case "PrintAllPerformances":
                        commandResult = ExecutePrintAllPerformancesCommand();
                        break;
                    case "PrintPerformances":
                        commandResult = ExecutePrintPerformancesCommand(commandArguments);
                        break;
                    default:
                        commandResult = "Invalid command.";
                        break;
                }
            }
            catch (Exception ex)
            {
                commandResult = "Error: " + ex.Message;
            }
            return commandResult;
        }

        private static string[] ExtractCommandArguments(string commandLine)
        {
            string[] commandArguments = commandLine
                .Split(new[] {'(', ',', ')'}, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(param => param.Trim())
                .ToArray();
            return commandArguments;
        }

        private static string ExecutePrintAllPerformancesCommand()
        {
            var performances = Enumerable.ToList<Performance>(PerformancesDatabase.ListAllPerformances());
            var result = new StringBuilder();
            if (performances.Any())
            {
                for (int i = 0; i < performances.Count; i++)
                {
                    if (i > 0)
                    {
                        result.Append(", ");
                    }

                    result.AppendFormat(
                        "({0}, {1}, {2})",
                        performances[i].PerformanceName,
                        performances[i].Theatre,
                        performances[i].DateAndTime.ToString("dd.MM.yyyy HH:mm"));
                }

                return result.ToString();
            }

            return "No performances";
        }

        private static string ExecuteAddTheatreCommand(string[] commandArguments)
        {
            string theatreName = commandArguments[0];
            PerformancesDatabase.AddTheatre(theatreName);
            return "Theatre added";
        }

        private static string ExecutePrintAllTheatresCommand()
        {
            
            var theatresCount = Enumerable.Count<string>(PerformancesDatabase.ListTheatres());
            if (theatresCount > 0)
            {
                var resultTheatres = new LinkedList<string>();
                for (int i = 0; i < theatresCount; i++)
                {
                    Enumerable.Skip<string>(PerformancesDatabase
                            .ListTheatres(), i)
                        .ToList()
                        .ForEach(t => resultTheatres.AddLast(t));
                    foreach (var t in Enumerable.Skip<string>(PerformancesDatabase.ListTheatres(), i + 1))
                    {
                        resultTheatres.Remove(t);
                    }
                }
                return String.Join(", ", resultTheatres);
            }

            return "No theatres";
        }
        private static string ExecutePrintPerformancesCommand(string[] commandArguments)
        {
            string theatre = commandArguments[0];

            var performances = PerformancesDatabase
                .ListPerformances(theatre)
                .Select(performance => String.Format("({0}, {1})", 
                        performance.PerformanceName, 
                        performance.DateAndTime.ToString("dd.MM.yyyy HH:mm")))
                .ToList();

            string commandResult;
            if (performances.Any())
            {
                commandResult = string.Join(", ", performances);
            }
            else
            {
                commandResult = "No performances";
            }

            return commandResult;
        }

        private static string ExecuteAddPerformanceCommand(string[] commandArguments)
        {
            string theatreName = commandArguments[0];
            string performanceTitle = commandArguments[1];
            DateTime result = DateTime.ParseExact(commandArguments[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            DateTime startDateTime = result;
            TimeSpan duration = TimeSpan.Parse(commandArguments[3]);
            decimal price = Decimal.Parse(commandArguments[4], CultureInfo.InvariantCulture);
            PerformancesDatabase.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);
            string commandResult = "Performance added";
            return commandResult;
        }
    }
}
