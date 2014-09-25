using System;

namespace Problem1_SquareRoot
{
    class SquareRoot
    {
        static void Main()
        {
            Console.WriteLine("Please, enter a number:");
            string input = Console.ReadLine();
            try
            {
                int number = int.Parse(input);
                if (number<0)
                {                    
                    throw new ArgumentOutOfRangeException();                    
                }
                double sqrt = Math.Sqrt((double)number);
                Console.WriteLine("Square root is: {0:0.00}", sqrt);
            }
            catch (ArgumentException)
            {
                Console.Error.WriteLine("The number you have entered is invalid!");
                throw;
            }
            catch (Exception)
            {
                Console.Error.WriteLine("The number you have entered is invalid!");
                throw;
            }
            finally
            {
                Console.WriteLine("Goodbye!");
            }
        }
    }
}
