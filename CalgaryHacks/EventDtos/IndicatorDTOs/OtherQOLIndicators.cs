using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CalgaryHacks.EventDtos.IndicatorDTOs
{
    public partial class OtherQOLIndicators
    {
        [JsonProperty("access_to_daily_needs_and_services")]
        public string AccessToDailyNeedsAndServices { get; set; }

        [JsonProperty("accessibility_to_transit")]
        public string AccessibilityToTransit { get; set; }

        [JsonProperty("active_adults")]
        public string ActiveAdults { get; set; }

        [JsonProperty("community_belonging")]
        public string CommunityBelonging { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("drive_alone_to_work")]
        public string DriveAloneToWork { get; set; }

        [JsonProperty("greenhouse_gas_emissions_ktco2e")]
        public string GreenhouseGasEmissionsKtco2e { get; set; }

        [JsonProperty("river_withdrawals_ml_year")]
        public string RiverWithdrawalsMlYear { get; set; }

        [JsonProperty("urban_canopy_coverage")]
        public string UrbanCanopyCoverage { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }
    }

    public partial class OtherQOLIndicators
    {
        public static List<OtherQOLIndicators> FromJson(string json) => JsonConvert.DeserializeObject<List<OtherQOLIndicators>>(json, Converter.Settings);
    }


 
}
