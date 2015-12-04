using System;
using System.Collections.Generic;

namespace santa_mondrian_claus.FilesUtils
{
    public static class DataEnumerator
    {
        public static IEnumerable<T> Enumerate<T>(string filePath, bool header, Func<string, T> translator)
        {
            foreach (string line in LinesEnumerator.YieldLines(filePath, header))
                yield return translator(line);
        }
    }
}
