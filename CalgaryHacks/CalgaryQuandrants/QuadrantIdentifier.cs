using CalgaryHacks.EventDtos.LocationDTOs;
using System.Collections.Generic;

namespace CalgaryHacks.CalgaryQuandrants
{
    public static class QuadrantIdentifier
    {
        public static bool IsPointInPolygon(List<Loc> poly, Loc point)
        {
            int i, j;
            bool c = false;
            for (i = 0, j = poly.Count - 1; i < poly.Count; j = i++)
            {
                if ((((poly[i].Lt <= point.Lt) && (point.Lt < poly[j].Lt))
                     || ((poly[j].Lt <= point.Lt) && (point.Lt < poly[i].Lt)))
                    && (point.Lg < (poly[j].Lg - poly[i].Lg) * (point.Lt - poly[i].Lt)
                        / (poly[j].Lt - poly[i].Lt) + poly[i].Lg))

                    c = !c;
            }
            return c;
        }

        public static string getLocationInCalgary(Loc latLongLocation)
        {
            if (QuadrantIdentifier.IsPointInPolygon(Quadrants.calgaryNWCoordinatesList, latLongLocation))
            {
                return "NW";
            }
            else if (QuadrantIdentifier.IsPointInPolygon(Quadrants.calgaryNECoordinatesList, latLongLocation))
            {
                return "NE";
            }
            else if (QuadrantIdentifier.IsPointInPolygon(Quadrants.calgarySECoordinatesList, latLongLocation))
            {
                return "SE";

            }
            else if (QuadrantIdentifier.IsPointInPolygon(Quadrants.calgarySWCoordinatesList, latLongLocation))
            {
                return "SW";
            }
            else
            {
                return "Unknown Location";
            }
        }
    }
}