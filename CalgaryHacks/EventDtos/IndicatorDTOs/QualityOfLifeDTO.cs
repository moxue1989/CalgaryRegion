using System.Collections.Generic;
using Newtonsoft.Json;

namespace CalgaryHacks.EventDtos.IndicatorDTOs
{
    public partial class QualityOfLifeDTO
    {
        [JsonProperty("datelavel")]
        public string Datelavel { get; set; }

        [JsonProperty("datestart")]
        public string Datestart { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("indicator")]
        public string Indicator { get; set; }

        [JsonProperty("qol")]
        public string Qol { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("value1")]
        public string Value1 { get; set; }

        [JsonProperty("valueper")]
        public string Valueper { get; set; }
    }

    public partial class QualityOfLifeDTO
    {
        public static List<QualityOfLifeDTO> FromJson(string json) => JsonConvert.DeserializeObject<List<QualityOfLifeDTO>>(json, Converter.Settings);
    }

}