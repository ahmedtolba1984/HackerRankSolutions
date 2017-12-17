using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.DynamicProgramming
{
    public class Parens
    {
        public  static HashSet<string> GenerateParens(int remaining)
        {
            var set = new HashSet<string>();

            if (remaining <= 0)
            {
                set.Add("");
            }
            else
            {
                var previous = GenerateParens(remaining - 1);

                foreach (var word in previous)
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == '(')
                        {
                            var result = InsertAfter(word, i);
                            set.Add(result);
                        }
                    }
                    //Add one at the beginning
                    set.Add('(' + ')'.ToString() + word);
                }
            }
            return set;
        }

        private static string InsertAfter(string str, int i)
        {
            var before = str.Substring(0, i + 1);
            var end = str.Substring(i + 1);
            return before + '(' + ')' + end;
        }
    }
}
