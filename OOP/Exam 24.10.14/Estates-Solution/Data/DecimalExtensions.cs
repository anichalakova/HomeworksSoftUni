using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Estates.Data
{

    public static class DecimalExtensions
    {
        public static string ToString(this decimal some)
        {
            return string.Format("{0:0.00}", some);
        }
    }
}
