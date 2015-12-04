using System;

namespace santa_mondrian_claus
{
    /// <summary>
    /// Implementation of metrics over points.
    /// </summary>
    public static class Distances
    {
        private const double REarth = 6371f;
        private const double _pi180 = Math.PI / 180f;

        /// <summary>
        /// Returns the Haversine distance between two weighted points.
        /// </summary>
        /// <param name="p1">First point</param>
        /// <param name="p2">Second point</param>
        /// <returns>Haversine's (geodesic) distance</returns>
        public static double Haversine(double lat1, double lat2, double lon1, double lon2)
        {
            double dLat = ToRad(lat2 - lat1);
            double dLon = ToRad(lon2 - lon1);

            double a = Math.Pow(Math.Sin(dLat / 2), 2) +
                       Math.Cos(ToRad(lat1)) * Math.Cos(ToRad(lat2)) *
                       Math.Pow(Math.Sin(dLon / 2), 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = REarth * c;
            return distance;
        }

        private static double ToRad(double input)
        {
            return input * (Math.PI / 180);
        }

    }
}