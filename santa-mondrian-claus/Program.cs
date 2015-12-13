using santa_mondrian_claus.FilesUtils;
using System;
using System.Linq;

namespace santa_mondrian_claus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Distances.Haversine(90, 88, 0, 88));

            string mainFolder = @"C:\Users\JUJulien\Desktop\KAGGLE\Competitions\santa-mondrian-claus\";

            string filePath = mainFolder + "gifts.csv";
            Gift[] myGifts = DataEnumerator.Enumerate<Gift>(filePath, true, Gift.FromString).ToArray();

            Route myRoute = new Route(mainFolder + "submission.csv", myGifts);

            GeneticAlgorithm.RunRepositions(myRoute, 100000000);

            Console.ReadKey();

        }
    }
}
