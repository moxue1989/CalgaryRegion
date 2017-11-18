using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using CalgaryHacks.EventDtos;

namespace CalgaryHacks.Apis
{
    public class GoogleMaps
    {
        public static string Endpoint = "https://maps.googleapis.com/maps/api/geocode/json?address=";
        public static HttpClient Client = GetNewClient();

        private static HttpClient GetNewClient()
        {
            Client = new HttpClient();
            return Client;
        }

        public static void GetLatAndLongFromAddress(string addressString, out string latitude, out string longitude)
        {
            Client = GetNewClient();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string addressQuery = addressString.Replace(' ', '+');
            int tryCount = 0;
            do
            {
                HttpResponseMessage response = Client.GetAsync(Endpoint + addressQuery + "+Calgary").Result;

                var googleString = response.Content.ReadAsStringAsync().Result;
                GoogleLocation googleLocation = GoogleLocation.FromJson(googleString);
                List<GoogleLocationResult> results = googleLocation.Results;
                if (results.Count == 0)
                {
                    tryCount++;
                }
                else
                {
                    latitude = results[0].Geometry.Location.Lat + "";
                    longitude = results[0].Geometry.Location.Lng + "";
                    return;
                }
            } while (tryCount < 3);
            latitude = null;
            longitude = null;

        }
    }
}