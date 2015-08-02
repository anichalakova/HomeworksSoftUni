using System;
using System.Linq;

namespace DbAppsExam
{
    class EFMapping
    {
        static void Main()
        {
            var context = new DiabloContext();

            var characters = context.Characters.Select(ch => ch.Name).ToList();

            foreach (var character in characters)
            {
                Console.WriteLine(character);
            }
        }
    }
}
