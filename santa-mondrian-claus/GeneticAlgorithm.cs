using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace santa_mondrian_claus
{
    public static class GeneticAlgorithm
    {

        public static void RunRepositions(Route plan, int steps)
        {
            double bestScore = double.MaxValue;
            Random rnd = new Random(0);
            string oldDump = "";
            for (int i = 0; i < steps; i++)
            {
                plan.ShuffleOneTrajectory(1 + rnd.Next(plan.NTrajectories - 1));
                if (i % 1000000 == 0)
                {
                    double currentScore = plan.WRW();
                    Console.WriteLine(currentScore.ToString("### ### ### ###.000"));
                    if (currentScore < bestScore)
                    {
                        bestScore = currentScore;
                        string dump = plan.Dump(currentScore.ToString());
                        Console.WriteLine("dumped!");
                        if (oldDump != "")
                        {
                            File.Delete(oldDump);
                        }
                        oldDump = dump;
                    }
                }
            }
        }
    }
}
