using System.Linq;
using santa_mondrian_claus.Geometry.QuadTree;

namespace santa_mondrian_claus
{
    class GiftHelper
    {
        public static Quad MinimumEnclosingQuad(Gift[] myGifts)
        {
            float minLat = myGifts.Select(c => c.Lat).Min(),
                maxLat = myGifts.Select(c => c.Lat).Max(),
                minLon = myGifts.Select(c => c.Lon).Min(),
                maxLon = myGifts.Select(c => c.Lon).Max();
            return new Quad(minLat, minLon, maxLat, maxLon);
        }
    }
}
