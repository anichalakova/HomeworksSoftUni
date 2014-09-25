using System;

namespace Problem2_EnterNumbers
{
    class EnterNumbers
    {
        public static int ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());
            if ((number < start)||(number>end))
            {
                Console.WriteLine("The number must be in the range {0}-{1}. Please try again:", start, end);
                throw new ArgumentOutOfRangeException();                           
            }
            return number;
        }
        static void Main()
        {
            Console.WriteLine("Please enter 10 ascending integer numbers in the range 1-100:");
            int correctNumbers = 0;
            int lastNumber = Int32.MinValue;
            int newNumber = Int32.MinValue;
            while (correctNumbers < 10)
            {
                try
                {
                    newNumber = ReadNumber(1, 100);
                    if (newNumber > lastNumber)
                    {
                        correctNumbers++;
                        lastNumber = newNumber;                        
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number which is bigger than the last valid number:");
                    }                                      
                }
                catch (ArgumentOutOfRangeException)
                {
                }
                catch (Exception)
                {
                    Console.WriteLine("The number you have entered is invalid. Please, try again:");                    
                }
                if (lastNumber == 100)
                {
                    break;
                }
            }            
        }
    }
}
