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
                plan.TryToShuffleOneTrajectory(plan.TrajectoriesIds[rnd.Next(plan.NTrajectories)]);

                plan.TryToShuffleNTrajectories(plan.TrajectoriesIds[rnd.Next(plan.NTrajectories)], 3);
                plan.TryToShuffleNTrajectories(plan.TrajectoriesIds[rnd.Next(plan.NTrajectories)], 5, ConsoleColor.Cyan);

                //plan.TryToSplitTrajectory(plan.TrajectoriesIds[rnd.Next(plan.NTrajectories)]);
                //plan.TryToMergeTrajectories(plan.TrajectoriesIds[rnd.Next(plan.NTrajectories)],
                //        plan.TrajectoriesIds[rnd.Next(plan.NTrajectories)]);

                if (i % 10000 == 0)
                {
                    double currentScore = plan.WRW();
                    Console.WriteLine("\n" + currentScore.ToString("### ### ### ###.000"));
                }

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
