using System.Collections.Generic;
using Newtonsoft.Json;

namespace CalgaryHacks.EventDtos.LocationDTOs
{
    public partial class PlaygroundEquipmentDTO
    {
        [JsonProperty("asset_cd")]
        public string AssetCd { get; set; }

        [JsonProperty("asset_class")]
        public string AssetClass { get; set; }

        [JsonProperty("asset_type")]
        public string AssetType { get; set; }

        [JsonProperty(":@computed_region_4b54_tmc4")]
        public string ComputedRegion4b54Tmc4 { get; set; }

        [JsonProperty(":@computed_region_kxmf_bzkv")]
        public string ComputedRegionKxmfBzkv { get; set; }

        [JsonProperty("count_baby_swing")]
        public string CountBabySwing { get; set; }

        [JsonProperty("count_handicap_swing")]
        public string CountHandicapSwing { get; set; }

        [JsonProperty("count_pony_swing")]
        public string CountPonySwing { get; set; }

        [JsonProperty("count_saucer_swing")]
        public string CountSaucerSwing { get; set; }

        [JsonProperty("count_sr_swing")]
        public string CountSrSwing { get; set; }

        [JsonProperty("count_tire_swing")]
        public string CountTireSwing { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("life_cycle_status")]
        public string LifeCycleStatus { get; set; }

        [JsonProperty("location")]
        public PlaygroundEquipmentDTOLocation Location { get; set; }

        [JsonProperty("location_detail")]
        public string LocationDetail { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("maint_info")]
        public string MaintInfo { get; set; }

        [JsonProperty("maintained_by")]
        public string MaintainedBy { get; set; }

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("mgmt_num")]
        public string MgmtNum { get; set; }

        [JsonProperty("minortype")]
        public string Minortype { get; set; }

        [JsonProperty("steward")]
        public string Steward { get; set; }

        [JsonProperty("type_description")]
        public string TypeDescription { get; set; }
    }

    public partial class PlaygroundEquipmentDTOLocation
    {
        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class PlaygroundEquipmentDTO
    {
        public static List<PlaygroundEquipmentDTO> FromJson(string json) => JsonConvert.DeserializeObject<List<PlaygroundEquipmentDTO>>(json, Converter.Settings);
    }

}