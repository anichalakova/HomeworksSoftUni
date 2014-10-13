using System;
using System.Collections.Generic;
using System.Text;

namespace Problem3_ClassStudent
{
    // Create a class Student with properties FirstName, LastName,
    //Age, FacultyNumber, Phone, Email, Marks (IList<int>), GroupNumber. Create a List<Student> with sample students. 
    public class Student
    {
        public Student(string firstName, string lastName, int age, int facultyNumber, string phone, string email, List<int> marks, int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int FacultyNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<int> Marks { get; set; }
        public int GroupNumber { get; set; }

        public override string ToString()
        {
            return String.Format(
                "{0} {1} --- Age: {2} --- Fac.No: {3} --- {4}\r\n{5} --- {6} --- Group: {7} \r\n", 
                this.FirstName, this.LastName, this.Age, this.FacultyNumber, this.Phone, this.Email, String.Join(", ", this.Marks), this.GroupNumber);
        }
    }
}
