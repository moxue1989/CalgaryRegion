using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using CalgaryHacks.EventDtos;

namespace CalgaryHacks.Apis
{
    public class EventsApi
    {

        private static HttpClient GetNewClient()
        {
            return new HttpClient();
        }

        public static void UpdateEvents()
        {
            GetMeetupEvents();
            GetEventfulEvents();
            GetTicketMasterEvents();
            GetTrumbaEvents();
        }

        public static async Task GetMeetupEvents()
        {
            HttpClient client = GetNewClient();
            foreach (String groupUrlname in MeetupGroupsToSig.GroupUrlNameToSigDict.Keys)
            {
                string path = "https://api.meetup.com/2/events?offset=0&format=json&limited_events=False&group_urlname="
                       + groupUrlname
                       + "&photo-host=public&time=0m%2C1m&page=200&fields=&order=time&desc=false&status=upcoming&sig_id="
                       + MeetupGroupsToSig.SIG_ID
                       + "&sig=" + MeetupGroupsToSig.GroupUrlNameToSigDict[groupUrlname];

                HttpResponseMessage response = client.GetAsync(path).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                MeetupEventsDTO meetupEventsDto = MeetupEventsDTO.FromJson(result);
                await EventMapper.UpdateEventsFromMeetup(meetupEventsDto.Results);
                Thread.Sleep(1000);
            }
        }

        public static async Task GetTicketMasterEvents()
        {
            HttpClient client = GetNewClient();

            string url =
                "https://app.ticketmaster.com/discovery/v2/events.json?" +
                "countryCode=CA" +
                "&city=calgary" +
                "&endDateTime=" + DateTime.Now.AddDays(7).ToString("s") + "Z" +
                "&apikey=8yyoUh2T8jcZaUXipIgAetTsgBbYCbhz";
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;

            var ticketMasterString = response.Content.ReadAsStringAsync().Result;

            TicketMasterDto ticketMaster = TicketMasterDto.FromJson(ticketMasterString);

            await EventMapper.UpdateEventsFromTicketMaster(ticketMaster);
        }

        public static async Task GetEventfulEvents()
        {
            HttpClient client = GetNewClient();
            string url = @"http://api.eventful.com/json/events/search?location=Calgary&app_key=H3hfv9tXr8PRXLTf";
            client.BaseAddress = new Uri(url);

            //add an accept header over here JSON format
            //comes back as text/javascript
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;

            var eventfulString = response.Content.ReadAsStringAsync().Result;

            Eventful eventful = Eventful.FromJson(eventfulString);

            await EventMapper.UpdateEventsFromEventful(eventful);
        }

        public static async Task GetTrumbaEvents()
        {
            HttpClient client = GetNewClient();
            string url = @"https://gis.calgary.ca/arcgis/rest/services/pub_CalgaryDotCa/Events/MapServer/find?searchText=e&contains=true&searchFields=&sr=&layers=2&layerDefs=&returnGeometry=true&maxAllowableOffset=&geometryPrecision=&dynamicLayers=&returnZ=false&returnM=false&gdbVersion=&f=pjson";

            client.BaseAddress = new Uri(url);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ;
            HttpResponseMessage response = client.GetAsync("").Result;

            var trumbaString = response.Content.ReadAsStringAsync().Result;

            Trumba trumba = Trumba.FromJson(trumbaString);

            await EventMapper.UpdateEventsFromTrumba(trumba);
        }
    }
}