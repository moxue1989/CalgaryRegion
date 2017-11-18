using System.Collections.Generic;
using CalgaryHacks.EventDtos;
using Newtonsoft.Json;

namespace CalgaryMapsApi.DTOs
{
    public partial class PoliceServiceOfficesDTO
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("info")]
        public string Info { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("station_ty")]
        public string StationTy { get; set; }
    }

  
    public partial class PoliceServiceOfficesDTO
    {
        public static List<PoliceServiceOfficesDTO> FromJson(string json) => JsonConvert.DeserializeObject<List<PoliceServiceOfficesDTO>>(json, Converter.Settings);
    }

   

}