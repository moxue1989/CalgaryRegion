using Newtonsoft.Json;
using System.Collections.Generic;

namespace CalgaryHacks.EventDtos
{

    public partial class GoogleLocation
    {
        [JsonProperty("results")]
        public List<GoogleLocationResult> Results { get; set; }
    }

    public class GoogleLocationResult
    {
        [JsonProperty("geometry")]
        public GoogleLocationGeometry Geometry { get; set; }
    }

    public class GoogleLocationGeometry
    {
        [JsonProperty("location")]
        public GoogleLocationLocation Location { get; set; }
    }

    public class GoogleLocationLocation
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }

    public partial class GoogleLocation
    {
        public static GoogleLocation FromJson(string json) => JsonConvert.DeserializeObject<GoogleLocation>(json, Converter.Settings);
    }
}


