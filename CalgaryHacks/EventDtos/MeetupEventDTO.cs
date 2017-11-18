using System;

namespace CalgaryHacks.EventDtos
{
    public class MeetupEventDto
    {
        //Filtered out what I think is relevant data
        public long created { get; set; }
        public String id { get; set; }
        public String name { get; set; }
        public long time { get; set; }
        public String local_date { get; set; }
        public String local_time { get; set; }
        public long utc_offset { get; set; }
        public MeetupEventDtoVenue venue { get; set; }
        public MeetupEventDtoGroup group { get; set; }
        public string link { get; set; }
        public string description { get; set; }

    }
    public class MeetupEventDtoVenue
    {
        public long id { get; set; }
        public string name { get; set; }
        public decimal lat { get; set; }
        public decimal lon { get; set; }
        public String address_1 { get; set; }
        public String city { get; set; }
        public String country { get; set; }
        public string zip { get; set; }
        public string state { get; set; }

    }

    public class MeetupEventDtoGroup
    {
        public long created { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string urlname { get; set; }

    }
}