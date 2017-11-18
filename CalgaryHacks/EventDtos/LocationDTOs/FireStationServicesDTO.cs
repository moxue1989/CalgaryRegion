using System.Collections.Generic;
using Newtonsoft.Json;

namespace CalgaryHacks.EventDtos.LocationDTOs
{
    public partial class FireStationServicesDTO
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("community")]
        public string Community { get; set; }


        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("location")]
        public FireStationServicesDTOLocation Location { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

    }

    public partial class FireStationServicesDTOLocation
    {
        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class FireStationServicesDTO
    {
        public static List<FireStationServicesDTO> FromJson(string json) => JsonConvert.DeserializeObject<List<FireStationServicesDTO>>(json, Converter.Settings);
    }


}