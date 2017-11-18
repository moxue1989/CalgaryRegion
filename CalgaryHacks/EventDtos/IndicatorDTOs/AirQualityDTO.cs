using Newtonsoft.Json;
using System.Collections.Generic;

namespace CalgaryHacks.EventDtos.IndicatorDTOs
{
    public partial class AirQualityDTO
    {
        [JsonProperty("average_daily_value")]
        public string AverageDailyValue { get; set; }

        [JsonProperty(":@computed_region_4a3i_ccfj")]
        public string ComputedRegion4a3iCcfj { get; set; }

        [JsonProperty(":@computed_region_4b54_tmc4")]
        public string ComputedRegion4b54Tmc4 { get; set; }

        [JsonProperty(":@computed_region_kxmf_bzkv")]
        public string ComputedRegionKxmfBzkv { get; set; }

        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("parameter")]
        public string Parameter { get; set; }

        [JsonProperty("station_name")]
        public string StationName { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class AirQualityDTO
    {
        public static List<AirQualityDTO> FromJson(string json) => JsonConvert.DeserializeObject<List<AirQualityDTO>>(json, Converter.Settings);
    }
  
}