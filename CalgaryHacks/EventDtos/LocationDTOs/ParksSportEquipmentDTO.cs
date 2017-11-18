using System.Collections.Generic;
using Newtonsoft.Json;

namespace CalgaryHacks.EventDtos.LocationDTOs
{
    public partial class ParksSportEquipmentDTO
    {
        [JsonProperty("asset_cd")]
        public string AssetCd { get; set; }

        [JsonProperty("asset_class")]
        public string AssetClass { get; set; }

        [JsonProperty("asset_type")]
        public string AssetType { get; set; }

        [JsonProperty("booking_code")]
        public string BookingCode { get; set; }

        [JsonProperty(":@computed_region_hq2j_w7j9")]
        public string ComputedRegionHq2jW7j9 { get; set; }

        [JsonProperty(":@computed_region_kxmf_bzkv")]
        public string ComputedRegionKxmfBzkv { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("life_cycle_status")]
        public string LifeCycleStatus { get; set; }

        [JsonProperty("location")]
        public ParksSportEquipmentDTOLocation Location { get; set; }

        [JsonProperty("location_detail")]
        public string LocationDetail { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("maint_info")]
        public string MaintInfo { get; set; }

        [JsonProperty("maintained_by")]
        public string MaintainedBy { get; set; }

        [JsonProperty("minortype")]
        public string Minortype { get; set; }

        [JsonProperty("steward")]
        public string Steward { get; set; }

        [JsonProperty("type_description")]
        public string TypeDescription { get; set; }
    }

    public partial class ParksSportEquipmentDTOLocation
    {
        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class ParksSportEquipmentDTO
    {
        public static List<ParksSportEquipmentDTO> FromJson(string json) => JsonConvert.DeserializeObject<List<ParksSportEquipmentDTO>>(json, Converter.Settings);
    }

  
}