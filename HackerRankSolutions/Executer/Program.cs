using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Solutions.DynamicProgramming;

namespace Executer
{
    class Program
    {
        static void Main(string[] args)
        {
            //int q = Convert.ToInt32(Console.ReadLine());
            //for (int a0 = 0; a0 < q; a0++)
            //{
            //    var length = Convert.ToInt32(Console.ReadLine());
            //    var arrayTemp = Console.ReadLine().Split(' ');
            //    int[] array = Array.ConvertAll(arrayTemp, Int32.Parse);
            //    // your code goes here
            //    PrintChocolates(array, length);
            //}

            //int[] arr = { 55, 77, 52, 61, 39, 6, 25, 60, 49, 47 };
            //int n = arr.Length;
            //int target = 10;

            //Console.WriteLine("Minimum adjustment cost is " + MinAdjustmentCost(arr, n, target));

            int[] arr = { 15100, 2, 100, 2, 100 };
            //int[] arr = { 2, 4, 3 };
            int n = arr.Length;

            var result = LargestCost(arr, n);

            Console.ReadKey();
        }


        static int LargestCost(int[] array, int n)
        {
            int[][] dp = new int[n][]; //stores the largest possible value on when changing B --->J
            // handle first element of array seperately
            for (int j = 0; j <= array[0]; j++)
            {
                if (j == 0)
                {
                    dp[0] = new int[array[0] + 1];
                    continue;
                }

                dp[0][j] = j;

            }

            // do for rest elements of the array
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j <= array[i]; j++)
                {
                    if (j == 0)
                    {
                        dp[i] = new int[array[i] + 1];
                        continue;
                    }

                    //store largest possible value when changing B(i) --> j
                    for (int k = 1; k <= array[i - 1]; k++)
                    {
                        dp[i][j] = Math.Max(dp[i][j], Math.Abs(j - k));
                    }
                }
            }

            int result = 0;

            for (int i = 1; i < n; i++)
            {
                result += dp[i].Max();
            }

            return result;
        }


        //public static int M = 100;
        //// Function to find minimum adjustment cost of an array
        //static int MinAdjustmentCost(int[] array, int n, int target)
        //{
        //    // dp[i][j] stores minimal adjustment cost on changing
        //    // A[i] to j
        //    int[][] dp = new int[n][];

        //    // handle first element of array seperately
        //    for (int j = 0; j <= M; j++)
        //    {
        //        if (j == 0)
        //            dp[0] = new int[M + 1];

        //        dp[0][j] = Math.Abs(j - array[0]);
        //    }

        //    // do for rest elements of the array
        //    for (int i = 1; i < n; i++)
        //    {
        //        // replace A[i] to j and calculate minimal adjustment
        //        // cost dp[i][j]
        //        for (int j = 0; j <= M; j++)
        //        {
        //            if (j == 0)
        //                dp[i] = new int[M + 1];

        //            // initialize minimal adjustment cost to INT_MAX
        //            dp[i][j] = int.MaxValue ;

        //            // consider all k such that k >= max(j - target, 0) and
        //            // k <= min(M, j + target) and take minimum
        //            int k = Math.Max(j - target, 0);
        //            for (; k <= Math.Min(M, j + target); k++)
        //                dp[i][j] = Math.Min(dp[i][j], dp[i - 1][k] + Math.Abs(array[i] - j));
        //        }
        //    }

        //    // return minimum value from last row of dp table
        //    int res = int.MaxValue;
        //    for (int j = 0; j <= M; j++)
        //        res = Math.Min(res, dp[n - 1][j]);

        //    return res;
        //}

    }


}

