using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Problem1_StringBuilderExtensions;

namespace Problem3_ClassStudent
{
    class TestClassStudent
    {        

        static void PrintResults(IOrderedEnumerable<Student> results)
        {
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        static void Main()
        {
            List<Student> studentsList = new List<Student>();            
            
            studentsList.Add(new Student("Filipa", "Xavier", 32, 125590, "0895752140", "ani.chalakova@gmail.com", new List<int> { 5, 6, 5, 5, 4 }, 2));
            studentsList.Add(new Student("Filipa", "Cholcheva", 109, 125014, "0895752123", "penka.cholch@gmail.com", new List<int> { 3, 4, 5, 6, 2}, 1));
            studentsList.Add(new Student("Chayka", "Belejkova", 22, 124014, "0895752198", "chayka.belejkova@abv.bg", new List<int> { 3, 2, 3, 2, 3}, 2));

            // Problem 4 - print students in given group, order by first name.

            var subset4 = studentsList.Where(s => s.GroupNumber == 2).OrderBy(s => s.FirstName);
            Console.WriteLine("By group:");
            PrintResults(subset4);

            //Problem 5 - print all students whose first name is before their last name alphabetically. 

            var subset5 = studentsList.Where(s => s.FirstName.ElementAt(0) < s.LastName.ElementAt(0)).OrderBy(s=>s.FirstName);
            Console.WriteLine("First name < last name ");
            PrintResults(subset5);

            // Problem 6 - find and print first name, last name and age of all students with age between 18 and 24. 

            //var subset6 = studentsList.Where(s => (s.Age < 25) && (s.Age > 18));

            var subset6 =
                from student in studentsList
                where student.Age < 25 && student.Age > 18
                select student;

            Console.WriteLine("With age between 18 and 24: ");
            foreach (var item in subset6)
            {
                Console.WriteLine(string.Format("{0} {1}, Age: {2}", item.FirstName, item.LastName, item.Age));
            }

            // Problem 7 - order by first and last name and print using OrderBy() and ThenBy() + lambda expressions.

            var subset7 = studentsList.OrderBy(s => s.FirstName).ThenBy(s => s.LastName);

            Console.WriteLine("\nOrdered by first and last name:");
            foreach (var item in subset7)
            {
                Console.WriteLine(item);
            }

            //same task using LINQ query

            var querySubset7 =
                from student in studentsList
                orderby student.FirstName
                orderby student.LastName
                select student;

            Console.WriteLine("\r\n...ordered using query: ");
            PrintResults(querySubset7);

            // Problem 8 - filter and print all students who have e-mail at abv.bg. 

            var subset8 =
                from student in studentsList
                where student.Email.Contains("abv.bg")
                select student;

            Console.WriteLine("E-mail at abv.bg: ");
            foreach (var item in subset8)
            {
                Console.WriteLine(item);
            }

            // Problem 10 - extract al lstudents who have at least one mark "6". Put them in an anonymous type holding FullName and Marks.           

            var subset10 = studentsList.Where(s => s.Marks.Contains(6)).Select(s => new { FullName = s.FirstName + " " + s.LastName, Marks = string.Join(", ", s.Marks) });
            Console.WriteLine("Excellent students:");
            foreach (var item in subset10)
            {                
                Console.WriteLine(item);
            }

            // Problem 11 - extract all students with more than 2 grades of "2" using extension methods. 

            var subset11 =
                studentsList.Where(s => s.CheckIfPoor(2)).Select(s => new { FullName = s.FirstName + " " + s.LastName, Marks = string.Join(", ", s.Marks) });
                //from student in studentsList
                //where student.CheckIfPoor(2)
                //select student;

            Console.WriteLine("\r\nPoor students: ");
            foreach (var item in subset11)
            {
                Console.WriteLine(item);
            }

            // Problem 12 - extract and print the marks of the students enrolled in 2014 (their faculty number's 5th and 6th digits are 14). 

            var subset12 =
                from student in studentsList
                where student.FacultyNumber.ToString().Substring(4, 2).Equals("14")
                select student;

            Console.WriteLine("\r\nEnrolled in 2014's marks: ");

            foreach (var item in subset12)
            {
                Console.WriteLine(string.Join(", ", item.Marks));
            }            
        }
    }
}
