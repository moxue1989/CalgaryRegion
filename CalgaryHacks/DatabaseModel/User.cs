using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CalgaryHacks.DatabaseModel
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public virtual ICollection<Event> Events { get; set; }

        [JsonProperty("Password")]
        [NotMapped]
        public string PasswordSetter
        {
            set { Password = value; }
        }
        public virtual Location Location { get; set; }
    }
}
