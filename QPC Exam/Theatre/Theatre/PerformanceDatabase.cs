namespace Theatre
{
    using System;
    using System.Collections.Generic;

    public class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> performances 
            = new SortedDictionary<string, SortedSet<Performance>>();

        public void AddTheatre(string theatreName)
        {
            if (this.performances.ContainsKey(theatreName))
            {
                throw new InvalidOperationException("Duplicate theatre");
            }

            this.performances[theatreName] = new SortedSet<Performance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            return this.performances.Keys;
        }

        public void AddPerformance(string theatre, string performanceName, DateTime startDateAndTime, TimeSpan duration, decimal price)
        {
            if (!this.performances.ContainsKey(theatre))
            {
                throw new InvalidOperationException("Theatre does not exist");
            }

            var performancesInCurrentTheatre = this.performances[theatre];
            var endDateAndTime = startDateAndTime + duration; 

            if (hasOverlapTime(performancesInCurrentTheatre, startDateAndTime, endDateAndTime))
            {
                throw new InvalidOperationException("Time/duration overlap");
            }

            var newPerformance = new Performance(theatre, performanceName, startDateAndTime, duration, price); 
            performancesInCurrentTheatre.Add(newPerformance);
        }

        public IEnumerable<Performance> ListAllPerformances() 
        {
            var theatres = this.performances.Keys;
            var performancesList = new List<Performance>(); 
            foreach (var t in theatres)
            {
                var performancesInCurrentTheater = this.performances[t];
                performancesList.AddRange(performancesInCurrentTheater);
            }

            return performancesList;
        }

        public IEnumerable<Performance> ListPerformances(string theatreName)
        {
            if (!this.performances.ContainsKey(theatreName))
            {
                throw new InvalidOperationException("Theatre does not exist");
            }
            
            return this.performances[theatreName];
        }
        protected internal static bool hasOverlapTime(IEnumerable<Performance>performances, DateTime startTime, DateTime endTime)
        {
            foreach (var p in performances)
            {
                var performanceStart = p.DateAndTime;
                var performanceEnd = p.DateAndTime + p.Duration; 
                if ((performanceStart <= startTime && startTime <= performanceEnd) 
                    || (performanceStart <= endTime && endTime <= performanceEnd) 
                    || (startTime <= performanceStart && performanceStart <= endTime) 
                    || (startTime <= performanceEnd && performanceEnd <= endTime)) 
                {
                    return true;
                }
            }
            return false;
        }
    }
}
