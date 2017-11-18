using System.ComponentModel.DataAnnotations;

namespace CalgaryHacks.DatabaseModel
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        public string Longitude { get; set; }

        [Required]
        public string Latitude { get; set; }
    }
}
