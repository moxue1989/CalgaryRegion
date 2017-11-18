using System.Collections.Generic;
using Newtonsoft.Json;

namespace CalgaryHacks.EventDtos.LocationDTOs
{
public partial class PublicLibraryDTO
    {
       
        [JsonProperty("library")]
        public string Library { get; set; }

        [JsonProperty("location")]
        public PublicLibraryDTOLocation Location { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

    }

    public partial class PublicLibraryDTOLocation
    {
        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class PublicLibraryDTO
    {
        public static List<PublicLibraryDTO> FromJson(string json) => JsonConvert.DeserializeObject<List<PublicLibraryDTO>>(json, Converter.Settings);
    }

  
}