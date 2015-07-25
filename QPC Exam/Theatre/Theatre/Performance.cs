namespace Theatre
{
    using System;
    public class Performance : IComparable<Performance>
    {
        public Performance(string theatre, string performanceName, DateTime dateAndTime, TimeSpan duration, decimal price)
        {
            this.Theatre = theatre;
            this.PerformanceName = performanceName;
            this.DateAndTime = dateAndTime;
            this.Duration = duration;
            this.Price = price;
        }

        public string Theatre { get; protected internal set; }
        public string PerformanceName { get; private set; }
        public DateTime DateAndTime { get; set; }
        public TimeSpan Duration { get; private set; }
        public decimal Price { get; protected internal set; }
        int IComparable<Performance>.CompareTo(Performance otherPerformance)
        {
            return this.DateAndTime.CompareTo(otherPerformance.DateAndTime); 
        }
        public override string ToString()
        {
            string result = string.Format(
                                        "Performance(theatre: {0}; performance: {1}; dateAndTime: {2}, duration: {3}, price: {4})",
                                        this.Theatre,
                                        this.PerformanceName,
                                        this.DateAndTime.ToString("dd.MM.yyyy HH:mm"),
                                        this.Duration.ToString("hh':'mm"),
                                        this.Price.ToString("f2"));
            return result;
        }
    }
}
