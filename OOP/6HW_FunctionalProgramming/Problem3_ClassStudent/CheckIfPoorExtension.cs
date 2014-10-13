using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3_ClassStudent
{
    public static class CheckIfPoorExtension
    {
        public static bool CheckIfPoor(this Student student, int numberOfPoorGrades)
        {
            int count = 0;
            List<int> grades = new List<int>();
            grades = student.Marks;

            while (grades.Contains(2))
            {
                count++;
                int firstIndex = grades.IndexOf(2);
                grades.RemoveAt(firstIndex);
            }

            if (count == numberOfPoorGrades)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
