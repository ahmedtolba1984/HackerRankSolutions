using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.DynamicProgramming
{
    public class PowerSet
    {
        static IList<IList<int>> GetSubsets(IList<int> set, int index)
        {
            IList<IList<int>> allsubsets;
            if (set.Count == index)
            {
                allsubsets = new List<IList<int>> { new List<int>() };
            }
            else
            {
                allsubsets = GetSubsets(set, index + 1);
                var item = set[index];
                IList<IList<int>> moresubsets = new List<IList<int>>();
                foreach (var subset in allsubsets)
                {
                    IList<int> newsubset = new List<int>(subset);
                    newsubset.Add(item);
                    moresubsets.Add(newsubset);
                }
                for (int i = 0; i < moresubsets.Count; i++)
                    allsubsets.Add(moresubsets[i]);
            }
            return allsubsets;
        }
    }
}
