using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalgaryHacks.CalgaryQuandrants;
using CalgaryHacks.DatabaseModel;
using CalgaryHacks.EventDtos.LocationDTOs;

namespace CalgaryHacks.Apis
{
    public class PointsOfInterestsMapper
    {
        public static Task UpdateTransitLRTStations(List<TransitLRTStationsDTO> transitLRTStations)
        {
            DataModel db = new DataModel();
            List<PointsOfInterest> pointsOfInterests = db.PointsOfInterest.ToList();

            foreach (var transitLRTStation in transitLRTStations)
            {
                PointsOfInterest existingPointsOfInterest =
                    pointsOfInterests.FirstOrDefault(x => x.Name == transitLRTStation.Stationnam);

                if (existingPointsOfInterest == null)
                {
                    PointsOfInterest pointsOfInterestModel = new PointsOfInterest();
                    pointsOfInterestModel.Name = transitLRTStation.Stationnam;
                    pointsOfInterestModel.Latitude = transitLRTStation.Latitude;
                    pointsOfInterestModel.Longitude = transitLRTStation.Longitude;
                    pointsOfInterestModel.Type = "CTrain";

                    var latLongLocation = new Loc(Convert.ToDouble(transitLRTStation.Latitude), Convert.ToDouble(transitLRTStation.Longitude));
                    pointsOfInterestModel.Location = QuadrantIdentifier.getLocationInCalgary(latLongLocation);

                    db.PointsOfInterest.Add(pointsOfInterestModel);

                }

            }
            db.SaveChanges();
            return Task.FromResult(0);
        }
    }
}