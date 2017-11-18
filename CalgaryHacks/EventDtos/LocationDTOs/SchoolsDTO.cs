using System.Collections.Generic;
using Newtonsoft.Json;

namespace CalgaryHacks.EventDtos.LocationDTOs
{
    public partial class SchoolsDTO
    {
        [JsonProperty("address_ab")]
        public string AddressAb { get; set; }

        [JsonProperty("board")]
        public string Board { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty(":@computed_region_4b54_tmc4")]
        public string ComputedRegion4b54Tmc4 { get; set; }

        [JsonProperty(":@computed_region_hq2j_w7j9")]
        public string ComputedRegionHq2jW7j9 { get; set; }

        [JsonProperty(":@computed_region_kxmf_bzkv")]
        public string ComputedRegionKxmfBzkv { get; set; }

        [JsonProperty("data_source")]
        public string DataSource { get; set; }

        [JsonProperty("ecs")]
        public string Ecs { get; set; }

        [JsonProperty("elem")]
        public string Elem { get; set; }

        [JsonProperty("grades")]
        public string Grades { get; set; }

        [JsonProperty("junior_h")]
        public string JuniorH { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("location")]
        public SchoolsDTOLocation Location { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_ab")]
        public string NameAb { get; set; }

        [JsonProperty("postal_cod")]
        public string PostalCod { get; set; }

        [JsonProperty("postsecond")]
        public string Postsecond { get; set; }

        [JsonProperty("process_dt")]
        public string ProcessDt { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("provincial_code_num")]
        public string ProvincialCodeNum { get; set; }

        [JsonProperty("senior_h")]
        public string SeniorH { get; set; }

        [JsonProperty("structure_id")]
        public string StructureId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class SchoolsDTOLocation
    {
        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class SchoolsDTO
    {
        public static List<SchoolsDTO> FromJson(string json) => JsonConvert.DeserializeObject<List<SchoolsDTO>>(json, Converter.Settings);
    }

}