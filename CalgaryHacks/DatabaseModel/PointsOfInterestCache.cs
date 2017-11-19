using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalgaryHacks.DatabaseModel
{
    public class PointsOfInterestCache
    {
        private static ConcurrentBag<PointsOfInterest> _pointsOfInterestBag = new ConcurrentBag<PointsOfInterest>();

        public static void UpdateFromDatabase()
        {
            DataModel db = new DataModel();
            List<PointsOfInterest> pointsOfInterests = db.PointsOfInterest.ToList();
            _pointsOfInterestBag = new ConcurrentBag<PointsOfInterest>();
            foreach (PointsOfInterest pointsOfInterest in pointsOfInterests)
            {
                _pointsOfInterestBag.Add(pointsOfInterest);
            }
        }

        public static List<PointsOfInterest> GetPointsOfInterestBag()
        {
            if (_pointsOfInterestBag.IsEmpty)
            {
                UpdateFromDatabase();
            }
            return _pointsOfInterestBag.ToList();
        }
    }
}