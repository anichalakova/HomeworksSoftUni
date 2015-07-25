namespace Theatre
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines database to hold information about performances and the theaters they are held in
    /// and a set of commands to add/list performances/theatres.
    /// </summary>
    internal interface IPerformanceDatabase
    {
        /// <summary>
        /// Creates a sorted set of performances in the database under the theatre name or
        /// throws exception if theatre already exists in the database 
        /// </summary>
        /// <param name="theatreName">The name of the theatre to add</param>
        /// <exception cref="System.InvalidOperationException">"Duplicate theatre"</exception>
        void AddTheatre(string theatreName);

        /// <summary>
        /// Lists all theaters existing in database
        /// </summary>
        /// <returns>A collection of the string keys of the theatre-performances sorted dictionary, ordered by name</returns>
        IEnumerable<string> ListTheatres();

        /// <summary>
        /// Adds new performance to the sorted set of performances,
        ///  listed by theatre name in the database or throws and exception if theatre does not exist in database, 
        /// or if time overlaps with another performance in same theatre
        /// </summary>
        /// <param name="theatreName">The name of the theatre to hold the performance</param>
        /// <param name="performanceTitle">The title of the performance</param>
        /// <param name="startDateTime">The starting date and time of the performance</param>
        /// <param name="duration">The duration of the performance as TimeSpan</param>
        /// <param name="price">The price of the ticket for the performance</param>
        /// <exception cref="System.InvalidOperationException">"Theatre does not exist!"</exception>
        /// <exception cref="System.InvalidOperationException">"Time/duration overlap"</exception>
        void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price);

        /// <summary>
        /// List all performances in database ordered by theatre and then by date and then by name
        /// </summary>
        /// <returns> List of performances ordered by theater and then by time</returns>
        IEnumerable<Performance> ListAllPerformances();

        /// <summary>
        /// Lists all performances included in database under given theatre name
        /// </summary>
        /// <param name="theatreName">The name of the theatre to hold the performances</param>
        /// <returns>List of performances ordered by date and then by name</returns>
        /// <exception cref="System.InvalidOperationException">"Theatre does not exist!"</exception>
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}
