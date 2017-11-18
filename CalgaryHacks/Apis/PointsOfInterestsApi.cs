using CalgaryHacks.EventDtos.LocationDTOs;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CalgaryHacks.Apis
{
    public static class PointsOfInterestsApi
    {

        private static HttpClient GetNewClient()
        {
            return new HttpClient();
        }


        public static string GetLibraries()
        {
            HttpClient client = GetNewClient();

            string url = "https://data.calgary.ca/resource/j5v6-8bqr.json";

            client.BaseAddress = new Uri(url);

            //Configuring Data.Calgary
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;

            var libraryCRPstring = response.Content.ReadAsStringAsync().Result;

           //var librariesDTO = LibrariesDTO.FromJson(libraryCRPstring);

            return libraryCRPstring;

        }


        public static List<CommunityPointsDTO> GetCommunities()
        {
            HttpClient client = GetNewClient();

            string url = "https://data.calgary.ca/resource/kzbm-mn66.json";

            client.BaseAddress = new Uri(url);

            //Configuring Data.Calgary
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;

            var communitiesCRPstring = response.Content.ReadAsStringAsync().Result;

            var communitiesDto = CommunityPointsDTO.FromJson(communitiesCRPstring);

            return communitiesDto;

        }

        public static List<FireStationServicesDTO> GetFireStationLocations()
        {
            HttpClient client = GetNewClient();

            string url = "https://data.calgary.ca/resource/fsqf-xw5a.json";

            client.BaseAddress = new Uri(url);

            //Configuring Data.Calgary
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;

            var fireStationCRPstring = response.Content.ReadAsStringAsync().Result;

            var fireStationDto = FireStationServicesDTO.FromJson(fireStationCRPstring);

            return fireStationDto;

        }



        public static List<PublicLibraryDTO> GetPublicLibraryLocations()
        {
            HttpClient client = GetNewClient();

            string url = "https://data.calgary.ca/resource/j5v6-8bqr.json";

            client.BaseAddress = new Uri(url);

            //Configuring Data.Calgary
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;

            var publicLibraryCRPstring = response.Content.ReadAsStringAsync().Result;

            var publicLibraryDto = PublicLibraryDTO.FromJson(publicLibraryCRPstring);

            return publicLibraryDto;

        }


        public static List<SchoolsDTO> GetSchoolLocations()
        {
            HttpClient client = GetNewClient();

            string url = "https://data.calgary.ca/resource/j5v6-8bqr.json";

            client.BaseAddress = new Uri(url);

            //Configuring Data.Calgary
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;

            var schoolLocationCRPstring = response.Content.ReadAsStringAsync().Result;

            var schoolLocationDto = SchoolsDTO.FromJson(schoolLocationCRPstring);

            return schoolLocationDto;

        }



        public static List<TransitLRTStationsDTO> GetTransitLRTLocations()
        {
            HttpClient client = GetNewClient();

            string url = "https://data.calgary.ca/resource/5cvt-rikk.json";

            client.BaseAddress = new Uri(url);

            //Configuring Data.Calgary
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;

            var transitLRTLocationString = response.Content.ReadAsStringAsync().Result;

            var transitLRTDto = TransitLRTStationsDTO.FromJson(transitLRTLocationString);

            return transitLRTDto;

        }


        public static List<RecreationFacilitiesDTO> GetRecreationalFacilities()
        {
            HttpClient client = GetNewClient();

            string url = "https://data.calgary.ca/resource/cedp-v9s9.json";

            client.BaseAddress = new Uri(url);

            //Configuring Data.Calgary
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;

            var recreationalFacilitiesDtoString = response.Content.ReadAsStringAsync().Result;

            var recreationalFacilitiesDto = RecreationFacilitiesDTO.FromJson(recreationalFacilitiesDtoString);

            return recreationalFacilitiesDto;

        }


        public static List<ParksSportEquipmentDTO> GetSportingEquipmentLocations()
        {
            HttpClient client = GetNewClient();

            string url = "https://data.calgary.ca/resource/3ktt-g7vu.json";

            client.BaseAddress = new Uri(url);

            //Configuring Data.Calgary
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;

            var sportingEquipmentDtoString = response.Content.ReadAsStringAsync().Result;

            var sportingEquipmentDto = ParksSportEquipmentDTO.FromJson(sportingEquipmentDtoString);

            return sportingEquipmentDto;

        }


        public static List<PlaygroundEquipmentDTO> GetPlayGroundEquipment()
        {
            HttpClient client = GetNewClient();

            string url = "https://data.calgary.ca/resource/4amj-k662.json";

            client.BaseAddress = new Uri(url);

            //Configuring Data.Calgary
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;

            var playgroundEquipmentDtoString = response.Content.ReadAsStringAsync().Result;

            var playgroundEquipmentDto = PlaygroundEquipmentDTO.FromJson(playgroundEquipmentDtoString);

            return playgroundEquipmentDto;

        }


    }
}