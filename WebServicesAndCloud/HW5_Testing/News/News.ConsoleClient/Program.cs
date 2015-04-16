using System;
using System.Linq;
using News.Data;

namespace News.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new NewsDbContext();
            
            Console.WriteLine(context.News.FirstOrDefault().Title);
        }
    }
}
