using System.Collections.Generic;
using CalgaryHacks.EventDtos.IndicatorDTOs;
using CalgaryHacks.EventDtos.LocationDTOs;
using CalgaryMapsApi.DTOs;
using Newtonsoft.Json;

namespace CalgaryHacks.EventDtos
{
    public static class Serialize
    {
        public static string ToJson(this Eventful self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this Trumba self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this GoogleLocation self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this TicketMasterDto self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<CommunityPointsDTO> self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<FireStationServicesDTO> self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<PublicLibraryDTO> self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<SchoolsDTO> self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<TransitLRTStationsDTO> self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<RecreationFacilitiesDTO> self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<ParksSportEquipmentDTO> self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<PlaygroundEquipmentDTO> self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<QualityOfLifeDTO> self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<AirQualityDTO> self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this MeetupEventsDTO self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<PoliceServiceOfficesDTO> self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this List<OtherQOLIndicatorsDTO> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }

}