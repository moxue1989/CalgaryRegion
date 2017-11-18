using Newtonsoft.Json;

namespace CalgaryHacks.EventDtos
{
    public static class Serialize
    {
        public static string ToJson(this Eventful self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this Trumba self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this GoogleLocation self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this TicketMasterDto self) => JsonConvert.SerializeObject(self, Converter.Settings);


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