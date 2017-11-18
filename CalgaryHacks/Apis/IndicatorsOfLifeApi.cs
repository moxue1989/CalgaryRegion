using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using CalgaryHacks.EventDtos.IndicatorDTOs;

namespace CalgaryHacks.Apis
{
    public static class IndicatorsOfLifeApi
    {
        private static HttpClient GetNewClient()
        {
            return new HttpClient();
        }


        public static List<QualityOfLifeDTO> GetQualityOfLifeDTO()
        {
            HttpClient client = GetNewClient();

            string url = "https://data.calgary.ca/resource/p83r-pk65.json";

            client.BaseAddress = new Uri(url);

            //Configuring Data.Calgary
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls11 |
                                                   SecurityProtocolType.Tls12;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;

            var qualityOfLifestring = response.Content.ReadAsStringAsync().Result;

            var qualityOfLifeDto = QualityOfLifeDTO.FromJson(qualityOfLifestring);

            return qualityOfLifeDto;

        }

        public static List<AirQualityDTO> GetAirQualityDto()
        {
            HttpClient client = GetNewClient();

            string url = "https://data.calgary.ca/resource/88iq-yi9x.json";

            client.BaseAddress = new Uri(url);

            //Configuring Data.Calgary
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls11 |
                                                   SecurityProtocolType.Tls12;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;

            var airQualityString = response.Content.ReadAsStringAsync().Result;

            var airQualityDto = AirQualityDTO.FromJson(airQualityString);

            return airQualityDto;

        }


    }
}