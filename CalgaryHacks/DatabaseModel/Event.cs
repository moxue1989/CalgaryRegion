using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CalgaryHacks.DatabaseModel
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string TrumbaUniqueId { get; set; }

        public string EventfulUniqueId { get; set; }

        public string MeetupUniqueId { get; set; }

        public string TicketMasterUniqueId { get; set; }

        public string URL { get; set; }

        public DateTime? EventDate { get; set; }

        //sporting event, food event, drink event, music show..etc
        public string Type { get; set; }

        //Description of the event
        public string Description { get; set; }

        public string Quadrant { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}