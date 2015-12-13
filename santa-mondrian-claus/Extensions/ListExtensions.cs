using System;
using System.Collections.Generic;

namespace santa_mondrian_claus
{
    public static class ListExtensions
    {
        public static void Reposition<T>(this List<T> list, int idx1, int idx2)
        {
            T temp = list[idx1];
            list[idx1] = list[idx2];
            list[idx2] = temp;
        }

        public static Tuple<List<T>, List<T>> SplitInTwo<T>(this List<T> list)
        {
            List<T> res1 = new List<T>(),
                res2 = new List<T>();
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 0)
                    res1.Add(list[i]);
                else
                    res2.Add(list[i]);
            }
            return new Tuple<List<T>,List<T>>(res1,res2);
        }
    }
}
