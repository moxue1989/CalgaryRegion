using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CalgaryHacks.DatabaseModel;
using CalgaryHacks.EventDtos;

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
                    eventModel.Latitude = ticketMasterDtoVenue.Location.Latitude;
                    eventModel.Longitude = ticketMasterDtoVenue.Location.Longitude;
                    eventModel.Address = ticketMasterDtoVenue.Address.Line1;
                    eventModel.URL = ticketMasterEvent.Url;
                    eventModel.TicketMasterUniqueId = ticketMasterEvent.Id;
                    eventModel.Name = ticketMasterEvent.Name;
                    eventModel.EventDate = Convert.ToDateTime(ticketMasterEvent.Dates.Start.DateTime);

                    db.Events.Add(eventModel);
                }
            }
            db.SaveChanges();

            return Task.FromResult(0);
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

                    db.Events.Add(eventModel);
                }
            }
            db.SaveChanges();

            return Task.FromResult(0);
        }

        public static Task UpdateEventsFromMeetup(List<MeetupEventDto> meetupEventDtos)
        {
            DataModel db = new DataModel();
            List<Event> events = db.Events.ToList();
            foreach (MeetupEventDto meetupEvent in meetupEventDtos)
            {
                Event existingEvent = events.FirstOrDefault(x => x.MeetupUniqueId == meetupEvent.id);
                if (existingEvent == null)
                {

                    var eventModel = new Event();

                    MeetupEventDtoVenue eventVenue = meetupEvent.venue;
                    if (eventVenue == null)
                    {
                        continue;
                    }
                    eventModel.Latitude = eventVenue.lat.ToString();
                    eventModel.Longitude = eventVenue.lon.ToString();
                    eventModel.Address = eventVenue.address_1;
                    eventModel.URL = meetupEvent.link;
                    eventModel.MeetupUniqueId = meetupEvent.id;
                    eventModel.Name = meetupEvent.name;
                    eventModel.EventDate = GetDateTimeFromEpoch(meetupEvent.time);
                    eventModel.Description = meetupEvent.description;

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