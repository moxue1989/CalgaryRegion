using System.Collections.Generic;
using Newtonsoft.Json;

namespace CalgaryHacks.EventDtos.LocationDTOs
{
public partial class RecreationFacilitiesDTO
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("artf_turf_outdr")]
        public string ArtfTurfOutdr { get; set; }

        [JsonProperty("badmint_crts")]
        public string BadmintCrts { get; set; }

        [JsonProperty("climb_wall")]
        public string ClimbWall { get; set; }

        [JsonProperty("complex_name")]
        public string ComplexName { get; set; }

        [JsonProperty(":@computed_region_4b54_tmc4")]
        public string ComputedRegion4b54Tmc4 { get; set; }

        [JsonProperty(":@computed_region_kxmf_bzkv")]
        public string ComputedRegionKxmfBzkv { get; set; }

        [JsonProperty("curl_rnk")]
        public string CurlRnk { get; set; }

        [JsonProperty("curl_sheets")]
        public string CurlSheets { get; set; }

        [JsonProperty("diam_fac_outdr")]
        public string DiamFacOutdr { get; set; }

        [JsonProperty("dive_slide")]
        public string DiveSlide { get; set; }

        [JsonProperty("diving_tank")]
        public string DivingTank { get; set; }

        [JsonProperty("driverang_indr")]
        public string DriverangIndr { get; set; }

        [JsonProperty("driverang_outdr")]
        public string DriverangOutdr { get; set; }

        [JsonProperty("dry_pad")]
        public string DryPad { get; set; }

        [JsonProperty("facility_type")]
        public string FacilityType { get; set; }

        [JsonProperty("fig_skating")]
        public string FigSkating { get; set; }

        [JsonProperty("fit_studio")]
        public string FitStudio { get; set; }

        [JsonProperty("fitnss_wght")]
        public string FitnssWght { get; set; }

        [JsonProperty("fw_18m")]
        public string Fw18m { get; set; }

        [JsonProperty("fw_25m")]
        public string Fw25m { get; set; }

        [JsonProperty("fw_50m")]
        public string Fw50m { get; set; }

        [JsonProperty("gym")]
        public string Gym { get; set; }

        [JsonProperty("gymnast_fac")]
        public string GymnastFac { get; set; }

        [JsonProperty("hole_18")]
        public string Hole18 { get; set; }

        [JsonProperty("hole_9")]
        public string Hole9 { get; set; }

        [JsonProperty("hot_tub")]
        public string HotTub { get; set; }

        [JsonProperty("ice_indr")]
        public string IceIndr { get; set; }

        [JsonProperty("indr_pool")]
        public string IndrPool { get; set; }

        [JsonProperty("indr_surface")]
        public string IndrSurface { get; set; }

        [JsonProperty("indr_turf")]
        public string IndrTurf { get; set; }

        [JsonProperty("indr_wad_pool")]
        public string IndrWadPool { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("lanes_pool")]
        public string LanesPool { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("location")]
        public RecreationFacilitiesDTOLocation Location { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("meet_rooms")]
        public string MeetRooms { get; set; }

        [JsonProperty("multi_purp_rooms")]
        public string MultiPurpRooms { get; set; }

        [JsonProperty("municpal_op")]
        public string MunicpalOp { get; set; }

        [JsonProperty("nhl_ice")]
        public string NhlIce { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("notprofit_op")]
        public string NotprofitOp { get; set; }

        [JsonProperty("olymp_ice")]
        public string OlympIce { get; set; }

        [JsonProperty("oper")]
        public string Oper { get; set; }

        [JsonProperty("org")]
        public string Org { get; set; }

        [JsonProperty("other_pool")]
        public string OtherPool { get; set; }

        [JsonProperty("outdr_field")]
        public string OutdrField { get; set; }

        [JsonProperty("outdr_pool")]
        public string OutdrPool { get; set; }

        [JsonProperty("outdr_wad_pool")]
        public string OutdrWadPool { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("play_slide")]
        public string PlaySlide { get; set; }

        [JsonProperty("private_op")]
        public string PrivateOp { get; set; }

        [JsonProperty("profit_op")]
        public string ProfitOp { get; set; }

        [JsonProperty("public_glf")]
        public string PublicGlf { get; set; }

        [JsonProperty("racqfac_indr")]
        public string RacqfacIndr { get; set; }

        [JsonProperty("raqball_crts")]
        public string RaqballCrts { get; set; }

        [JsonProperty("rope_swing")]
        public string RopeSwing { get; set; }

        [JsonProperty("sauna")]
        public string Sauna { get; set; }

        [JsonProperty("semi_priv_glf")]
        public string SemiPrivGlf { get; set; }

        [JsonProperty("ski_nordictrck")]
        public string SkiNordictrck { get; set; }

        [JsonProperty("spray_park")]
        public string SprayPark { get; set; }

        [JsonProperty("springboard")]
        public string Springboard { get; set; }

        [JsonProperty("squash_crts")]
        public string SquashCrts { get; set; }

        [JsonProperty("stand_ice")]
        public string StandIce { get; set; }

        [JsonProperty("steam")]
        public string Steam { get; set; }

        [JsonProperty("steward")]
        public string Steward { get; set; }

        [JsonProperty("teach_pool")]
        public string TeachPool { get; set; }

        [JsonProperty("tennis_crt")]
        public string TennisCrt { get; set; }

        [JsonProperty("tier")]
        public string Tier { get; set; }

        [JsonProperty("track_indr")]
        public string TrackIndr { get; set; }

        [JsonProperty("track_outdr")]
        public string TrackOutdr { get; set; }

        [JsonProperty("typ_of_org")]
        public string TypOfOrg { get; set; }

        [JsonProperty("wave_pool")]
        public string WavePool { get; set; }

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