using Newtonsoft.Json;
using System.Collections.Generic;

namespace CalgaryHacks.EventDtos
{
    public partial class TicketMasterDto
    {
        [JsonProperty("_embedded")]
        public TicketMasterDtoPurpleEmbedded Embedded { get; set; }
    }

    public class TicketMasterDtoPurpleEmbedded
    {
        [JsonProperty("events")]
        public List<TicketMasterDtoEvent> Events { get; set; }
    }

    public class TicketMasterDtoEvent
    {
        [JsonProperty("dates")]
        public TicketMasterDtoDates Dates { get; set; }

        [JsonProperty("_embedded")]
        public TicketMasterDtoFluffyEmbedded Embedded { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("info")]
        public string Info { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("promoter")]
        public TicketMasterDtoPromoter Promoter { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class TicketMasterDtoDates
    {
        [JsonProperty("start")]
        public TicketMasterDtoStart Start { get; set; }
    }

    public class TicketMasterDtoStart
    {

        [JsonProperty("dateTime")]
        public string DateTime { get; set; }

    }

    public class TicketMasterDtoPromoter
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class TicketMasterDtoFluffyEmbedded
    {
        [JsonProperty("venues")]
        public List<TicketMasterDtoVenue> Venues { get; set; }
    }

    public class TicketMasterDtoVenue
    {
        [JsonProperty("address")]
        public TicketMasterDtoAddress Address { get; set; }

        [JsonProperty("location")]
        public TicketMasterDtoLocation Location { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class TicketMasterDtoAddress
    {
        [JsonProperty("line1")]
        public string Line1 { get; set; }
    }

    public class TicketMasterDtoLocation
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }

    public partial class TicketMasterDto
    {
        public static TicketMasterDto FromJson(string json) => JsonConvert.DeserializeObject<TicketMasterDto>(json, Converter.Settings);
    }

}
