using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classlesson
{
    public static class StackExtensions
    {
        public static Stack Merge(this Stack s1, Stack s2)
        {
            for (var i = 1; i <= (s2.Size); i++)
            {
                s1.Add(s2.Pop());
            }
            s1.Add(s2.Show());
            return s1;
        }
    }
}
