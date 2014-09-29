using System;

namespace Problem2_fractionCalculation
{
    struct Fraction
    {
        private long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator)
            : this()
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public long Numerator
        {
            get { return this.numerator; }
            set { this.Numerator = value; }
        }

        public long Denominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Denominator can not be zero!");
                    throw new ArgumentOutOfRangeException();
                }
                this.Denominator = value;
            }
        }

        public override string ToString()
        {
            decimal result = this.Numerator / (decimal)this.Denominator;
            return String.Format("{0}", result);
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {            
            Fraction f3 =  new Fraction(f1.Numerator*f2.Denominator + f1.Denominator*f2.Numerator, f1.Denominator*f2.Denominator);
            return f3;
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            Fraction f3 = new Fraction(f1.Numerator * f2.Denominator - f1.Denominator * f2.Numerator, f1.Denominator * f2.Denominator);
            return f3;
        }
    }
}
