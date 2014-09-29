using System;

namespace Problem2_fractionCalculation
{
    class FractionCalculator
    {
        static void Main()
        {
            Fraction fraction1 = new Fraction(22, 7);
            Fraction fraction2 = new Fraction(40, 4);
            Fraction result1 = fraction1 + fraction2;
            Console.WriteLine (result1.Numerator);
            Console.WriteLine(result1.Denominator);
            Console.WriteLine(result1);

            Fraction Fraction3 = new Fraction(14, 16); // substraction test
            Fraction Fraction4 = new Fraction(2, 72);
            Fraction result2 = Fraction3 - Fraction4;
            Console.WriteLine(result2.Numerator);
            Console.WriteLine(result2.Denominator);
            Console.WriteLine(result2);
        }
    }
}
