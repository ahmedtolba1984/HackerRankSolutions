using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.DynamicProgramming
{
    public class Coins
    {
        public static int MakeChanges(int amount, int[] denoms)
        {
            //Array.Sort(denoms, (i1, i2) => i2.CompareTo(i1));
            return MakeChanges(amount, denoms, index: 0);
        }

        private static int MakeChanges(int amount, int[] denoms, int index)
        {
            if (index >= denoms.Length - 1)
            {
                return 1;
            }

            int denomAmount = denoms[index];
            int ways = 0;
            for (int i = 0;  i * denomAmount <= amount; i++)
            {
                int amountRemaining = amount - i * denomAmount;
                ways += MakeChanges(amountRemaining, denoms, index + 1);
            }
            return ways;
        }
    }
}
