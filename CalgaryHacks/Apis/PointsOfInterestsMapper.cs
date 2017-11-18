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

        //For the Community Center Points 
        public static Task UpdateCommunityCenterLocations(List<CommunityPointsDTO> communityCenters)
        {
            DataModel db = new DataModel();
            List<PointsOfInterest> pointsOfInterests = db.PointsOfInterest.ToList();

            foreach (var communityCenter in communityCenters)
            {
                PointsOfInterest existingPointsOfInterest =
                    pointsOfInterests.FirstOrDefault(x => x.Name == communityCenter.Name);

                if (existingPointsOfInterest == null)
                {
                    PointsOfInterest pointsOfInterestModel = new PointsOfInterest();
                    pointsOfInterestModel.Name = communityCenter.Name;
                    pointsOfInterestModel.Latitude = communityCenter.Location.Coordinates[1].ToString();
                    pointsOfInterestModel.Longitude = communityCenter.Location.Coordinates[0].ToString();
                    pointsOfInterestModel.Type = "Community Center";

                    var latLongLocation = new Loc(Convert.ToDouble(pointsOfInterestModel.Latitude), Convert.ToDouble(pointsOfInterestModel.Longitude));
                    pointsOfInterestModel.Location = QuadrantIdentifier.getLocationInCalgary(latLongLocation);

                    db.PointsOfInterest.Add(pointsOfInterestModel);

                }

            }
            db.SaveChanges();
            return Task.FromResult(0);
        }


        //For the Fire Station Points 
        public static Task UpdateFireStationLocations(List<FireStationServicesDTO> fireStations)
        {
            DataModel db = new DataModel();
            List<PointsOfInterest> pointsOfInterests = db.PointsOfInterest.ToList();

            foreach (var fireStation in fireStations)
            {
                PointsOfInterest existingPointsOfInterest =
                    pointsOfInterests.FirstOrDefault(x => x.Name == fireStation.Name);

                if (existingPointsOfInterest == null)
                {
                    PointsOfInterest pointsOfInterestModel = new PointsOfInterest();
                    pointsOfInterestModel.Name = fireStation.Name;
                    pointsOfInterestModel.Latitude = fireStation.Location.Coordinates[1].ToString();
                    pointsOfInterestModel.Longitude = fireStation.Location.Coordinates[0].ToString();
                    pointsOfInterestModel.Type = "Fire Station";

                    var latLongLocation = new Loc(Convert.ToDouble(pointsOfInterestModel.Latitude), Convert.ToDouble(pointsOfInterestModel.Longitude));
                    pointsOfInterestModel.Location = QuadrantIdentifier.getLocationInCalgary(latLongLocation);

                    db.PointsOfInterest.Add(pointsOfInterestModel);

                }

            }
            db.SaveChanges();
            return Task.FromResult(0);
        }


        //For the Public Library
        public static Task UpdatePublicLibraryLocations(List<PublicLibraryDTO> publicLibraries)
        {
            DataModel db = new DataModel();
            List<PointsOfInterest> pointsOfInterests = db.PointsOfInterest.ToList();

            foreach (var library in publicLibraries)
            {
                PointsOfInterest existingPointsOfInterest =
                    pointsOfInterests.FirstOrDefault(x => x.Name == library.Library);

                if (existingPointsOfInterest == null)
                {
                    PointsOfInterest pointsOfInterestModel = new PointsOfInterest();
                    pointsOfInterestModel.Name = library.Library;
                    pointsOfInterestModel.Latitude = library.Location.Coordinates[1].ToString();
                    pointsOfInterestModel.Longitude = library.Location.Coordinates[0].ToString();
                    pointsOfInterestModel.Type = "Library";

                    var latLongLocation = new Loc(Convert.ToDouble(pointsOfInterestModel.Latitude), Convert.ToDouble(pointsOfInterestModel.Longitude));
                    pointsOfInterestModel.Location = QuadrantIdentifier.getLocationInCalgary(latLongLocation);

                    db.PointsOfInterest.Add(pointsOfInterestModel);

                }

            }
            db.SaveChanges();
            return Task.FromResult(0);
        }


        //For the Recreational Facilities
        public static Task UpdateRecreationalLocations(List<RecreationFacilitiesDTO> recreationFacilities)
        {
            DataModel db = new DataModel();
            List<PointsOfInterest> pointsOfInterests = db.PointsOfInterest.ToList();

            foreach (var recreationFacility in recreationFacilities)
            {
                PointsOfInterest existingPointsOfInterest =
                    pointsOfInterests.FirstOrDefault(x => x.Name == recreationFacility.ComplexName);

                if (existingPointsOfInterest == null)
                {
                    PointsOfInterest pointsOfInterestModel = new PointsOfInterest();
                    pointsOfInterestModel.Name = recreationFacility.ComplexName;
                    pointsOfInterestModel.Latitude = recreationFacility.Latitude.ToString();
                    pointsOfInterestModel.Longitude = recreationFacility.Longitude.ToString();
                    pointsOfInterestModel.Type = recreationFacility.FacilityType;

                    var latLongLocation = new Loc(Convert.ToDouble(pointsOfInterestModel.Latitude), Convert.ToDouble(pointsOfInterestModel.Longitude));
                    pointsOfInterestModel.Location = QuadrantIdentifier.getLocationInCalgary(latLongLocation);

                    db.PointsOfInterest.Add(pointsOfInterestModel);

                }

            }
            db.SaveChanges();
            return Task.FromResult(0);
        }


    }
}