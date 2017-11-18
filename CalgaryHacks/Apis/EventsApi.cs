using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
            string SIG_ID = "240809776";//Tethered to account


            HttpClient client = GetNewClient();
            string SIG = "8beaca3c1807ceb9bd04b402d538e5eb4de6ccaa"; //For this particular API
            string path = "https://api.meetup.com/self/calendar?photo-host=public&page=200&sig_id=" + SIG_ID +
                          "&sig=" + SIG;

            HttpResponseMessage response = client.GetAsync(path).Result;

            List<MeetupEventDto> meetupEventDtos = response.Content.ReadAsAsync<List<MeetupEventDto>>().Result;
            await EventMapper.UpdateEventsFromMeetup(meetupEventDtos);
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