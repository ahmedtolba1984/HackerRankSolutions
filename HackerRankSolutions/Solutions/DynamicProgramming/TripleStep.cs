using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.DynamicProgramming
{
    /// <summary>
    /// A child is running up a staircase with n steps and can hop either 1 step, 2 steps, or 3
    /// steps at a time. Implement a method to count how many possible ways the child can run up the
    /// stairs.
    /// </summary>
    public class TripleStep
    {

        public static int CountWays(int n)
        {
            var memo = new int[n + 1];
            return CountWays(n, memo);
        }

        private static int CountWays(int n, int[] memo)
        {
            if (n < 0)
                return 0;
            if (n == 0)
                return 1;
            if (memo[n] > 0)
                return memo[n];
            
            memo[n] = CountWays(n - 1, memo) + CountWays(n - 2, memo) + CountWays(n - 3, memo);
            return memo[n];
        }
    }
}
