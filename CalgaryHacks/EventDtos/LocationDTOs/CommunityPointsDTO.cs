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

  

        [JsonProperty("comm_structure")]
        public string CommStructure { get; set; }

        [JsonProperty("community_code")]
        public string CommunityCode { get; set; }


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