namespace Theatre.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IPerformanceDatabaseTests
    {
        [TestMethod]
        public void AddTheatreShouldAddSingleTheatre()
        {
            PerformanceDatabase sampleDatabase = new PerformanceDatabase();
            sampleDatabase.AddTheatre("Theater 199");
            int theatersCount = sampleDatabase.ListTheatres().Count();
            Assert.AreEqual(
                1, 
                theatersCount, 
                string.Format("Database shoud contain one theater, but instead contains {0}",theatersCount) );
        }

        [TestMethod]
        public void AddTheatreShouldAddMultipleTheatres()
        {
            PerformanceDatabase sampleDatabase = new PerformanceDatabase();
            sampleDatabase.AddTheatre("Theater 199");
            sampleDatabase.AddTheatre("Sylza i smyah");
            sampleDatabase.AddTheatre("Zad Kanala");
            int theatersCount = sampleDatabase.ListTheatres().Count();
            Assert.AreEqual(
                3, 
                theatersCount, 
                string.Format("Database shoud contain three theaters, but instead contains {0}",theatersCount) );
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), 
            "Attempt to add duplicate theatre doesn't throw Invalid Operation Exception!.")]
        public void AddDuplicateTheatreShouldThrowInvalidOperationException()
        {
            PerformanceDatabase sampleDatabase = new PerformanceDatabase();
            sampleDatabase.AddTheatre("Sylza i smyah");
            sampleDatabase.AddTheatre("Sylza i smyah");
        }

        [TestMethod]
        public void ListTheatresShouldListTheatresInCorrectOrder()
        {
            PerformanceDatabase sampleDatabase = new PerformanceDatabase();
            sampleDatabase.AddTheatre("Theater Sofia");
            sampleDatabase.AddTheatre("Sylza i smyah");
            sampleDatabase.AddTheatre("Zad Kanala");
            
            var listedTheatres = sampleDatabase.ListTheatres().ToArray();
            var result = string.Join(", ", listedTheatres);

            Assert.AreEqual(
                "Sylza i smyah, Theater Sofia, Zad Kanala",
                result,
                "Theatres are not listed correctly!");
        }

        [TestMethod]
        public void AddPerformanceShouldAddPerformance()
        {
            PerformanceDatabase sampleDatabase = new PerformanceDatabase();
            sampleDatabase.AddTheatre("Zad Kanala");
            sampleDatabase.AddPerformance("Zad Kanala", "Duende", new DateTime(2015, 1, 20, 20, 0, 0), new TimeSpan( 0, 1, 30, 0), 14.50M);
            var performancesCount = sampleDatabase.ListAllPerformances().Count();
         

            Assert.AreEqual(
                1,
                performancesCount,
                string.Format("Database shoud contain one performance, but instead contains {0}", performancesCount));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
            "Attempt to add performance for non-existing theatre doesn't throw Invalid Operation Exception!.")]
        public void AddPerformanceInNonExistingTheatreShouldThrowInvalidOperationException()
        {
            PerformanceDatabase sampleDatabase = new PerformanceDatabase();
            sampleDatabase.AddPerformance("Zad Kanala", "Duende", new DateTime(2015, 1, 20, 20, 0, 0), new TimeSpan(0, 1, 30, 0), 14.50M);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
            "Attempt to add performance with overlapping time doesn't throw Invalid Operation Exception!.")]
        public void AddPerformanceWithOverlappingTimeShouldThrowInvalidOperationException()
        {
            PerformanceDatabase sampleDatabase = new PerformanceDatabase();
            sampleDatabase.AddTheatre("Zad Kanala");
            sampleDatabase.AddPerformance("Zad Kanala", "Duende", new DateTime(2015, 1, 20, 20, 0, 0), new TimeSpan(0, 1, 30, 0), 14.50M);
            // time overlaps with one second
            sampleDatabase.AddPerformance("Zad Kanala", "Bella Donna", new DateTime(2015, 1, 20, 21 , 30, 0), new TimeSpan(0, 1, 30, 0), 14.50M); 
        }

        [TestMethod]
        public void ListAllPerformancesShouldListPerformancesInCorrectOrder()
        {
            PerformanceDatabase sampleDatabase = new PerformanceDatabase();
            sampleDatabase.AddTheatre("Theater Sofia");
            sampleDatabase.AddTheatre("Zad Kanala");

            sampleDatabase.AddPerformance("Zad Kanala", "Don Kihot", new DateTime(2015, 1, 21, 20, 0, 0), new TimeSpan(0, 1, 30, 0), 14.50M);
            sampleDatabase.AddPerformance("Theater Sofia", "Duende", new DateTime(2015, 1, 21, 20, 0, 0), new TimeSpan(0, 1, 30, 0), 14.50M);
            sampleDatabase.AddPerformance("Zad Kanala", "Bella Donna", new DateTime(2015, 1, 20, 21, 30, 0), new TimeSpan(0, 1, 30, 0), 14.50M); 

            var listedPerformances = sampleDatabase.ListAllPerformances().ToArray();
            var listedPerformancesNames = listedPerformances.Select(p => p.PerformanceName).ToArray();
            var result = string.Join(", ", listedPerformancesNames);

            Assert.AreEqual("Duende, Bella Donna, Don Kihot", result, "Performances are not listed correctly!");

        }

        [TestMethod]
        public void ListPerformancesShouldListPerformancesInCorrectOrder()
        {
            PerformanceDatabase sampleDatabase = new PerformanceDatabase();
            
            sampleDatabase.AddTheatre("Zad Kanala");
            sampleDatabase.AddPerformance("Zad Kanala", "Don Kihot", new DateTime(2015, 1, 21, 20, 0, 0), new TimeSpan(0, 1, 30, 0), 14.50M);
            sampleDatabase.AddPerformance("Zad Kanala", "Duende", new DateTime(2015, 1, 19, 20, 0, 0), new TimeSpan(0, 1, 30, 0), 14.50M);
            sampleDatabase.AddPerformance("Zad Kanala", "Bella Donna", new DateTime(2015, 1, 20, 21, 30, 0), new TimeSpan(0, 1, 30, 0), 14.50M);

            var listedPerformances = sampleDatabase.ListPerformances("Zad Kanala").ToArray();
            var listedPerformancesNames = listedPerformances.Select(p => p.PerformanceName).ToArray();
            var result = string.Join(", ", listedPerformancesNames);

            Assert.AreEqual("Duende, Bella Donna, Don Kihot", result, "Performances are not listed correctly!");

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),
            "Attempt to list performance from non-existing theatre doesn't throw Invalid Operation Exception!.")]
        public void ListPerformancesInNonExistingTheatreShouldThrowInvalidOperationException()
        {
            PerformanceDatabase sampleDatabase = new PerformanceDatabase();
            sampleDatabase.AddTheatre("Zad Kanala");
            sampleDatabase.AddPerformance("Zad Kanala", "Duende", new DateTime(2015, 1, 20, 20, 0, 0), new TimeSpan(0, 1, 30, 0), 14.50M);
            sampleDatabase.ListPerformances("Non existing theatre");
        }

    }
}
