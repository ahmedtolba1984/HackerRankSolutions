using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.DynamicProgramming
{
    public class MagicIndex
    {
        public static int MagicFastA(int [] array)
        {
            return MagicFastA(array, 0, array.Length - 1);
        }

        private static int MagicFastA(int[] array, int start, int end)
        {
            if (end < start)
                return -1;

            var mid = (start + end) / 2; //get the middle point
            if (array[mid] == mid)
                return mid;

            if (array[mid] < mid) //search the right direction
                return MagicFastA(array, mid + 1, end);

            return MagicFastA(array, start, mid - 1);
        }

        public static int MagicFastB(int[] array)
        {
            return MagicFastB(array, 0, array.Length - 1);
        }

        private static int MagicFastB(int[] array, int start, int end)
        {
            if (end < start)
                return -1;

            var midIndex = (start + end) / 2; //get the middle point
            var midValue = array[midIndex];
            if (midValue == midIndex)
                return midIndex;

            //we always search the left direction
            var leftIndex = Math.Min(midIndex - 1, midValue);
            var leftResult = MagicFastB(array, start, leftIndex);
            if (leftResult >= 0)
                return leftResult;

            //we always search the right direction
            var rightIndex = Math.Max(midIndex + 1, midValue);
            var rightResult = MagicFastB(array, rightIndex, end);
            return rightResult;
        }
    }
}
