using System.Collections.Generic;
using Newtonsoft.Json;

namespace CalgaryHacks.EventDtos.LocationDTOs
{
public partial class RecreationFacilitiesDTO
    {
   
        [JsonProperty("complex_name")]
        public string ComplexName { get; set; }

      
        [JsonProperty("facility_type")]
        public string FacilityType { get; set; }
   

        [JsonProperty("label")]
        public string Label { get; set; }


        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("location")]
        public RecreationFacilitiesDTOLocation Location { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

    
        [JsonProperty("notes")]
        public string Notes { get; set; }
 

        [JsonProperty("phone")]
        public string Phone { get; set; }

      

        [JsonProperty("typ_of_org")]
        public string TypOfOrg { get; set; }


        [JsonProperty("website")]
        public string Website { get; set; }
    }

    public partial class RecreationFacilitiesDTOLocation
    {
        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class RecreationFacilitiesDTO
    {
        public static List<RecreationFacilitiesDTO> FromJson(string json) => JsonConvert.DeserializeObject<List<RecreationFacilitiesDTO>>(json, Converter.Settings);
    }

}