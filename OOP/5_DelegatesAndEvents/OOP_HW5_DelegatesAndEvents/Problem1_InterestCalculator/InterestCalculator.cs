using System;

namespace DelegatesAndEvents
{
    public delegate decimal IntCalcDeleg(decimal sum, double interest, int years);

    class InterestCalculator
    {
        private decimal sum = 0;
        private double interest = 0;
        private int years = 0;
        private decimal deleg = 0;     

        public InterestCalculator(decimal sum, double interest, int years, IntCalcDeleg deleg)
        {
            this.sum = sum;
            this.interest = interest;
            this.years = years;
            this.deleg = deleg(sum, interest, years);
        }

        public override string ToString()
        {
            return String.Format("{0:0.0000}", this.deleg);
        }
        public decimal Sum
        {
            get
            {
                return this.sum;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Sum must be > 0");
                }
                this.sum = value;
            }
        }

        public double Interest
        {
            get
            {
                return this.interest;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Interest must be > 0");
                }
                this.interest = value;
            }
        }

        public int Years
        {
            get
            {
                return this.years;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Years must be > 0");
                }
                this.years = value;
            }
        }

        public decimal Deleg
        {
            get
            {
                return this.deleg;
            }
            set
            {
                this.deleg = value;
            }
        }        
    }
}
