﻿using System;
using System.Collections.Generic;
using System.IO;

namespace santa_mondrian_claus.FilesUtils
{
    public static class LinesEnumerator
    {
        /// <summary>
        /// Enumerates the lines of a file.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        /// <param name="maxLines">The maximum number of lines to read.</param>
        /// <returns>The lines of a file, as a IEnumerable</returns>
        public static IEnumerable<string> YieldLines(string path, bool header = true, int maxLines = Int32.MaxValue)
        {
            string line;
            int lineNumber = 0;
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader sr = new StreamReader(fs))
            {
                while ((line = sr.ReadLine()) != null && lineNumber < maxLines)
                {
                    if (header)
                    {
                        header = false;
                        continue;
                    }
                    lineNumber++;
                    yield return line;
                }
            }
        }
    }
}