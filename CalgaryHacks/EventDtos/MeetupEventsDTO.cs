using System.Collections.Generic;
using Newtonsoft.Json;

namespace CalgaryHacks.EventDtos
{
    public partial class MeetupEventsDTO
    {

        [JsonProperty("results")]
        public List<MeetupEventsDTOResult> Results { get; set; }
    }

    public class MeetupEventsDTOResult
    {
        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("event_url")]
        public string EventUrl { get; set; }

        [JsonProperty("headcount")]
        public long Headcount { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("maybe_rsvp_count")]
        public long MaybeRsvpCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }

        [JsonProperty("utc_offset")]
        public double UtcOffset { get; set; }

        [JsonProperty("venue")]
        public MeetupEventsDTOVenue Venue { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("waitlist_count")]
        public long WaitlistCount { get; set; }

        [JsonProperty("yes_rsvp_count")]
        public long YesRsvpCount { get; set; }
    }

    public class MeetupEventsDTOVenue
    {
        [JsonProperty("address_1")]
        public string Address1 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("localized_country_name")]
        public string LocalizedCountryName { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("repinned")]
        public bool Repinned { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }

    public partial class MeetupEventsDTO
    {
        public static MeetupEventsDTO FromJson(string json) => JsonConvert.DeserializeObject<MeetupEventsDTO>(json, Converter.Settings);
    }
}