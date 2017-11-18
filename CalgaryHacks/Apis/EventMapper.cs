using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CalgaryHacks.CalgaryQuandrants;
using CalgaryHacks.DatabaseModel;
using CalgaryHacks.EventDtos;
using CalgaryHacks.EventDtos.LocationDTOs;

namespace CalgaryHacks.Apis
{
    public class EventMapper
    {
        public static Task UpdateEventsFromTicketMaster(TicketMasterDto ticketMasterEvents)
        {
            DataModel db = new DataModel();
            List<Event> events = db.Events.ToList();

            foreach (var ticketMasterEvent in ticketMasterEvents.Embedded.Events)
            {
                Event existingEvent = events.FirstOrDefault(x => x.TicketMasterUniqueId == ticketMasterEvent.Id);
                if (existingEvent == null)
                {
                    Event eventModel = new Event();
                    TicketMasterDtoVenue ticketMasterDtoVenue = ticketMasterEvent.Embedded.Venues[0];
                    TicketMasterDtoPromoter promoter = ticketMasterEvent.Promoter;
                    if (promoter != null)
                    {
                        eventModel.Description = promoter.Description;
                    }
                    eventModel.Latitude = ticketMasterDtoVenue.Location.Latitude;
                    eventModel.Longitude = ticketMasterDtoVenue.Location.Longitude;
                    eventModel.Address = ticketMasterDtoVenue.Address.Line1;
                    eventModel.URL = ticketMasterEvent.Url;
                    eventModel.TicketMasterUniqueId = ticketMasterEvent.Id;
                    eventModel.Name = ticketMasterEvent.Name;
                    eventModel.EventDate = Convert.ToDateTime(ticketMasterEvent.Dates.Start.DateTime);
                    addQuadrantToEvent(eventModel);
                    db.Events.Add(eventModel);
                }
            }
            db.SaveChanges();

            return Task.FromResult(0);
        }

        private static void addQuadrantToEvent(Event eventModel)
        {
            double lat, lng;
            if (Double.TryParse(eventModel.Latitude, out lat) && Double.TryParse(eventModel.Longitude, out lng))
            {
                eventModel.Quadrant = QuadrantIdentifier.getLocationInCalgary(new Loc(lat, lng));
            }
        }

        public static Task UpdateEventsFromEventful(Eventful eventfulEvent)
        {
            DataModel db = new DataModel();
            List<Event> events = db.Events.ToList();
            foreach (var eventfulEventEvent in eventfulEvent.Events.Event)
            {
                Event existingEvent = events.FirstOrDefault(x => x.EventfulUniqueId == eventfulEventEvent.Id);
                if (existingEvent == null)
                {
                    Event eventModel = new Event();

                    eventModel.Latitude = eventfulEventEvent.Latitude;
                    eventModel.Longitude = eventfulEventEvent.Longitude;
                    eventModel.Address = eventfulEventEvent.VenueAddress;
                    eventModel.URL = eventfulEventEvent.Url;
                    eventModel.EventfulUniqueId = eventfulEventEvent.Id;
                    eventModel.Name = eventfulEventEvent.Title;
                    eventModel.EventDate = DateTime.ParseExact(eventfulEventEvent.StartTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    eventModel.Description = eventfulEventEvent.Description;
                    addQuadrantToEvent(eventModel);
                    db.Events.Add(eventModel);
                }
            }
            db.SaveChanges();

            return Task.FromResult(0);
        }

        public static Task UpdateEventsFromTrumba(Trumba trumbaEvents)
        {
            DataModel db = new DataModel();
            List<Event> events = db.Events.ToList();
            foreach (var trumbaEvent in trumbaEvents.Results)
            {
                var attributes = trumbaEvent.Attributes;
                string trumbaId = attributes.MoreInfoUrl + attributes.NextDateDtfmt;

                Event existingEvent = events.FirstOrDefault(x => x.TrumbaUniqueId == trumbaId);
                if (existingEvent == null)
                {
                    string lat;
                    string lng;
                    GoogleMaps.GetLatAndLongFromAddress(attributes.Address, out lat, out lng);

                    if (lat == null || lng == null)
                    {
                        continue;
                    }

                    var eventModel = new Event();

                    eventModel.Latitude = lat;
                    eventModel.Longitude = lng;
                    eventModel.Address = attributes.Address;
                    eventModel.URL = attributes.MoreInfoUrl;
                    eventModel.TrumbaUniqueId = trumbaId;
                    eventModel.Name = attributes.Title;
                    eventModel.EventDate = DateTime.ParseExact(attributes.NextDateDtfmt, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    eventModel.Description = attributes.Notes;
                    addQuadrantToEvent(eventModel);
                    db.Events.Add(eventModel);
                }
            }
            db.SaveChanges();

            return Task.FromResult(0);
        }

        public static Task UpdateEventsFromMeetup(List<MeetupEventsDTOResult> meetupEventDtos)
        {
            DataModel db = new DataModel();
            List<Event> events = db.Events.ToList();
            foreach (MeetupEventsDTOResult meetupEvent in meetupEventDtos)
            {
                Event existingEvent = events.FirstOrDefault(x => x.MeetupUniqueId == meetupEvent.Id);
                if (existingEvent == null)
                {
                    var eventModel = new Event();

                    MeetupEventsDTOVenue eventVenue = meetupEvent.Venue;
                    if (eventVenue == null)
                    {
                        continue;
                    }
                    eventModel.Latitude = eventVenue.Lat.ToString();
                    eventModel.Longitude = eventVenue.Lon.ToString();
                    eventModel.Address = eventVenue.Address1;
                    eventModel.URL = meetupEvent.EventUrl;
                    eventModel.MeetupUniqueId = meetupEvent.Id;
                    eventModel.Name = meetupEvent.Name;
                    eventModel.EventDate = GetDateTimeFromEpoch(meetupEvent.Time);
                    eventModel.Description = meetupEvent.Description;
                    addQuadrantToEvent(eventModel);
                    db.Events.Add(eventModel);
                }
            }
            db.SaveChanges();

            return Task.FromResult(0);
        }

        private static DateTime GetDateTimeFromEpoch(long time)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(time);
        }
    }
}