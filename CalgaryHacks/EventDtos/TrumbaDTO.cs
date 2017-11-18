using Newtonsoft.Json;
using System.Collections.Generic;

namespace CalgaryHacks.EventDtos
{
    public partial class Trumba
    {
        [JsonProperty("results")]
        public List<TrumbaResult> Results { get; set; }
    }

    public partial class TrumbaResult
    {
        [JsonProperty("attributes")]
        public TrumbaAttributes Attributes { get; set; }
    }

    public partial class TrumbaAttributes
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("event_group")]
        public string EventGroup { get; set; }

        [JsonProperty("eventtype_list")]
        public string EventtypeList { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("more_info_url")]
        public string MoreInfoUrl { get; set; }

        [JsonProperty("next_date_dtfmt")]
        public string NextDateDtfmt { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("OBJECTID")]
        public string OBJECTID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }


    public partial class Trumba
    {
        public static Trumba FromJson(string json) => JsonConvert.DeserializeObject<Trumba>(json, Converter.Settings);
    }



}