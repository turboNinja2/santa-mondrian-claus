using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuadTree;
using santa_mondrian_claus.FilesUtils;
using System.Diagnostics;
using santa_mondrian_claus.Geometry.QuadTree;

namespace santa_mondrian_claus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Distances.Haversine(90, 88, 0, 88));

            string filePath = @"C:\Users\Windows\Desktop\R\santa-mondrian-claus\gifts.csv";
            Gift[] myGifts = DataEnumerator.Enumerate<Gift>(filePath, true, Gift.FromString).ToArray();

            Route myRoute = new Route(@"C:\Users\Windows\Desktop\R\santa-mondrian-claus\submission.csv",myGifts);

            GeneticAlgorithm.RunRepositions(myRoute, 10000000);

            Console.ReadKey();

        }
    }
}
