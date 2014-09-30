using System;
using System.Text.RegularExpressions;

namespace Persons
{
    class Person
    {
        private string name;
        private int age;
        private string email;
        public Person(string name, int age, string email)
        {
            this.name = name;
            this.Age = age;
            this.Email = email;
        }
        public Person(string name, int age) : this(name, age, null) { }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {                    
                    throw new ArgumentNullException("Name must not be empty!");                    
                }
                this.name = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if ((value < 1)||(value > 100))
                {
                    throw new ArgumentOutOfRangeException("Age must be in the interval between 1 and 100!");
                }
                this.age = value;
            }
        }
        public string Email
        {
            get { return this.email; }
            set
            {
                if (value!= null)
                {
                    Regex pattern = new Regex("\\b([\\S]+@[a-z\\d-]+([.]+\\w+)+)\\b");
                    Match m = pattern.Match(value);
                    if (!m.Success)
                    {
                        throw new FormatException("Invalid e-mail!");
                    }
                    this.email = value;                    
                } 
            }
        }
        public override string ToString()
        {
            string result = "Person: " + this.Name + "\nAge: " + this.age;
            if (email != null)
            {
                result += "\nE-mail: " + this.Email;
            }
            return result;
        }
    }
}
