using System;

namespace DelegatesAndEvents
{
    class TestInterestCalculator
    {
        public static decimal GetSimpleInterest(decimal sum, double interest, int years)
        {
            decimal sumWithInterest = sum * (1 + years * (decimal)interest / 100);
            return sumWithInterest;
        }

        public static decimal GetCompoundInterest(decimal sum, double interest, int years)
        {
            decimal sumWithInterest = sum * (decimal)Math.Pow((1 + interest / (100 * 12)), (double)(years * 12));
            return sumWithInterest;
        }

        static void Main()
        {   

            IntCalcDeleg simpleCalc = new IntCalcDeleg(GetSimpleInterest);
            IntCalcDeleg compoundCalc = new IntCalcDeleg(GetCompoundInterest);

            InterestCalculator test1 = new InterestCalculator(500m, 5.6d, 10, compoundCalc);
            Console.WriteLine(test1);
            InterestCalculator test2 = new InterestCalculator(2500m, 7.2d, 15, simpleCalc);
            Console.WriteLine(test2); 
        }
    }
}
