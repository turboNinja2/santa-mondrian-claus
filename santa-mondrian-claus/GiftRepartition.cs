using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using santa_mondrian_claus.Geometry.QuadTree;

namespace santa_mondrian_claus
{
    public class GiftRepartition
    {
        private Dictionary<Quad, Gift> _repartition;

        public Dictionary<Quad, Gift> FirstHeuristic(Gift[] gifts, int initialNumberQuads)
        {
            Quad mainQuad = GiftHelper.MinimumEnclosingQuad(gifts);
            

            Dictionary<Quad, Gift> result = new Dictionary<Quad, Gift>();



            return result;
        }

    }
}
