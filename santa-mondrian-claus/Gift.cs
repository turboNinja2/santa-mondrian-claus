using System;
using System.Globalization;

namespace santa_mondrian_claus
{
    public class Gift
    {
        private int _giftId;
        private float _lat;
        private float _lon;
        private float _weight;

        public Gift(int giftId, float lat, float lon, float weight)
        {
            _giftId = giftId;
            _lat = lat;
            _lon = lon;
            _weight = weight;
        }

        public float Lat
        {
            get { return _lat; }
        }

        public float Lon
        {
            get { return _lon; }
        }

        public int Id
        {
            get { return _giftId; }
        }

        public float Weight
        {
            get { return _weight; }
        }

        public static Gift FromString(string line)
        {
            string[] elements = line.Split(',');
            return new Gift(
                Convert.ToInt32(elements[0], CultureInfo.GetCultureInfo("en-US")) - 1,
                Convert.ToSingle(elements[1], CultureInfo.GetCultureInfo("en-US")),
                Convert.ToSingle(elements[2], CultureInfo.GetCultureInfo("en-US")),
                Convert.ToSingle(elements[3], CultureInfo.GetCultureInfo("en-US")));
        }

        public override string ToString()
        {
            return _giftId.ToString();
        }
    }
}
