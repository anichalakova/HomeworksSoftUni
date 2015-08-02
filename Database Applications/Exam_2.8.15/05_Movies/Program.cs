using System;
using System.Linq;

namespace _05_Movies
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MoviesContext();
            Console.WriteLine("Users in database: " + context.Users.Count());
        }
    }
}
