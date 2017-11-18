using System.Collections.Generic;
using Newtonsoft.Json;

namespace CalgaryHacks.EventDtos.LocationDTOs
{
    public partial class TransitLRTStationsDTO
    {


        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("leg")]
        public string Leg { get; set; }

        [JsonProperty("location")]
        public TransitLRTStationsDTOLocation Location { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("route")]
        public string Route { get; set; }

        [JsonProperty("stationnam")]
        public string Stationnam { get; set; }


    }

    public partial class TransitLRTStationsDTOLocation
        {
            [JsonProperty("coordinates")]
            public List<double> Coordinates { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }

        public partial class TransitLRTStationsDTO
        {
            public static List<TransitLRTStationsDTO> FromJson(string json) =>
                JsonConvert.DeserializeObject<List<TransitLRTStationsDTO>>(json, Converter.Settings);
        }

    
}