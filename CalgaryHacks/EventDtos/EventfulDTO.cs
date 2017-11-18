using Newtonsoft.Json;
using System.Collections.Generic;

namespace CalgaryHacks.EventDtos
{
    public partial class Eventful
    {
        [JsonProperty("events")]
        public EventfulEvents Events { get; set; }
    }

    public class EventfulEvents
    {
        [JsonProperty("event")]
        public List<EventfulEvent> Event { get; set; }
    }

    public class EventfulEvent
    {
        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("going")]
        public object Going { get; set; }

        [JsonProperty("going_count")]
        public object GoingCount { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        [JsonProperty("stop_time")]
        public string StopTime { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("venue_address")]
        public string VenueAddress { get; set; }
    }

    public partial class Eventful
    {
        public static Eventful FromJson(string json) => JsonConvert.DeserializeObject<Eventful>(json, Converter.Settings);
    }


}