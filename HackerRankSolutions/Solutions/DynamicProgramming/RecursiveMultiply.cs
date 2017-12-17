using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.DynamicProgramming
{
    public class RecursiveMultiply
    {
        public static int MinProduct(int a, int b)
        {
            var bigger = a < b ? b : a;
            var smaller = a < b ? a : b;

            return MinProductHelper(smaller, bigger);


        }

        static int MinProductHelper(int smaller, int bigger)
        {
            if (smaller == 0)
                return 0;

            if (smaller == 1)
                return bigger;

            //Let us divide the smaller by 2
            var s = smaller / 2;
            var side1 = MinProductHelper(s, bigger);
            var side2 = side1;
            if (smaller % 2 == 1)
            {
                side2 = MinProductHelper(smaller - s, bigger);
            }
            return side1 + side2;
        }
    }
}
