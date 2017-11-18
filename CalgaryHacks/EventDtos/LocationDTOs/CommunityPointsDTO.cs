using System.Collections.Generic;
using Newtonsoft.Json;

namespace CalgaryHacks.EventDtos.LocationDTOs
{
    public partial class CommunityPointsDTO
    {
        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("class_code")]
        public string ClassCode { get; set; }

        [JsonProperty("comm_code")]
        public string CommCode { get; set; }

        [JsonProperty("comm_structure")]
        public string CommStructure { get; set; }

        [JsonProperty("community_code")]
        public string CommunityCode { get; set; }

        [JsonProperty(":@computed_region_4b54_tmc4")]
        public string ComputedRegion4b54Tmc4 { get; set; }

        [JsonProperty(":@computed_region_dyj4_ed5g")]
        public string ComputedRegionDyj4Ed5g { get; set; }

        [JsonProperty(":@computed_region_kxmf_bzkv")]
        public string ComputedRegionKxmfBzkv { get; set; }

        [JsonProperty("location")]
        public CommunityPointsDTOLocation Location { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sector")]
        public string Sector { get; set; }

        [JsonProperty("srg")]
        public string Srg { get; set; }
    }

    public partial class CommunityPointsDTOLocation
    {
        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class CommunityPointsDTO
    {
        public static List<CommunityPointsDTO> FromJson(string json) => JsonConvert.DeserializeObject<List<CommunityPointsDTO>>(json, Converter.Settings);
    }



  


}