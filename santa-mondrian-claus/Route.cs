using System;
using System.Collections.Generic;
using System.Linq;
using santa_mondrian_claus.FilesUtils;
using System.IO;

namespace santa_mondrian_claus
{
    public class Route
    {
        private Dictionary<int, List<int>> _indexedTrips;
        private Random _rnd = new Random(0);
        private Gift[] _gifts;

        public int NTrajectories
        {
            get { return _indexedTrips.Count; }
        }

        private static Dictionary<int, List<int>> indexTrips(int[] giftIds, int[] tripIds)
        {
            Dictionary<int, List<int>> indexed = new Dictionary<int, List<int>>();
            int n = giftIds.Length;
            for (int i = 0; i < n; i++)
            {
                int tripId = tripIds[i];
                if (indexed.ContainsKey(tripId))
                    indexed[tripId].Add(giftIds[i]);
                else
                    indexed.Add(tripId, new List<int>() { giftIds[i] });
            }
            return indexed;
        }

        private Tuple<int, int> csvTranslator(string input)
        {
            string[] lineData = input.Split(',');
            return new Tuple<int, int>(Convert.ToInt32(lineData[0]) - 1, Convert.ToInt32(lineData[1]));
        }

        public Route(string filePath, Gift[] gifts)
        {
            int index = 0;
            int[] giftIds = new int[ProblemConstants.NbGifts];
            int[] tripIds = new int[ProblemConstants.NbGifts];
            foreach (Tuple<int, int> element in DataEnumerator.Enumerate<Tuple<int, int>>(filePath, true, csvTranslator))
            {
                giftIds[index] = element.Item1;
                tripIds[index] = element.Item2;
                index++;
            }
            _indexedTrips = indexTrips(giftIds, tripIds);
            _gifts = gifts;
        }

        private double TrajectoryWeight(List<int> giftToDeliverIndexes)
        {
            double totalWeight = ProblemConstants.SleighWeight + giftToDeliverIndexes.Select(c => _gifts[c].Weight).Sum();
            Gift firstGift = _gifts[giftToDeliverIndexes[0]];
            double res = totalWeight * Distances.Haversine(ProblemConstants.NorthPoleLat, firstGift.Lat, ProblemConstants.NorthPoleLon, firstGift.Lon);
            totalWeight -= firstGift.Weight;

            for (int i = 1; i < giftToDeliverIndexes.Count; i++)
            {
                Gift previousGift = _gifts[giftToDeliverIndexes[i - 1]],
                    currentGift = _gifts[giftToDeliverIndexes[i]];

                double distanceToPoint = Distances.Haversine(previousGift.Lat, currentGift.Lat, previousGift.Lon, currentGift.Lon);

                res += totalWeight * distanceToPoint;
                totalWeight -= currentGift.Weight;
            }

            Gift lastGift = _gifts[giftToDeliverIndexes.Last()];
            res += totalWeight * Distances.Haversine(ProblemConstants.NorthPoleLat, lastGift.Lat, ProblemConstants.NorthPoleLon, lastGift.Lon);

            return res;
        }

        public double WRW()
        {
            double res = 0;
            foreach (int tripId in _indexedTrips.Keys)
                res += TrajectoryWeight(_indexedTrips[tripId]);
            return res;
        }

        public bool ShuffleOneTrajectory(int trajectoryId)
        {
            int n = _indexedTrips[trajectoryId].Count;
            int idx1 = _rnd.Next(n);
            int idx2 = _rnd.Next(n);

            double initialTrajectoryWeight = TrajectoryWeight(_indexedTrips[trajectoryId]);

            Reposition<int>(_indexedTrips[trajectoryId], idx1, idx2);

            double newTrajectoryWeight = TrajectoryWeight(_indexedTrips[trajectoryId]);

            if (newTrajectoryWeight < initialTrajectoryWeight)
                return true;
            else
            {
                Reposition<int>(_indexedTrips[trajectoryId], idx1, idx2);
                return false;
            }
        }

        private static void Reposition<T>(List<T> list, int idx1, int idx2)
        {
            T temp = list[idx1];
            list[idx1] = list[idx2];
            list[idx2] = temp;
        }

        public void Dump(string name)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + name + ".csv";

            File.WriteAllText(filePath, "GiftId,TripId\n");
            List<Tuple<int, int>> res = new List<Tuple<int, int>>();
            foreach (int tripKey in _indexedTrips.Keys)
            {
                foreach (int giftKey in _indexedTrips[tripKey])
                {
                    res.Add(new Tuple<int, int>(giftKey + 1, tripKey));
                }

            }

            File.AppendAllLines(filePath, res./*OrderBy(c => c.Item1)*/Select(d => d.Item1.ToString() + "," + d.Item2.ToString()));

        }

    }
}
