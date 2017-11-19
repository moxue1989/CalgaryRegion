using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CalgaryHacks.DatabaseModel;

namespace CalgaryHacks.Models
{
    public class ViewModels
    {
        public class ChooseChatModel
        {
            public IEnumerable<Event> EventChats { get; set; }
        }

        public class EventViewModel
        {
            public List<Event> Events { get; set; }
        }

        public class QuadrantModel
        {
            public List<PointsOfInterest> PointsOfInterests { get; set; }

            public List<Event> Events { get; set; }

            public string Lat { get; set; }

            public string Lng { get; set; }
        }

        public class LoginModel
        {
            [Required(ErrorMessage = "Email is required.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            public string Password { get; set; }
        }

        public class RegisterModel
        {
            [Required(ErrorMessage = "Name is required.")]
            public string Name { get; set; }
            [Required(ErrorMessage = "Phone is required.")]
            public string Phone { get; set; }
            [Required(ErrorMessage = "Email is required.")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Password is required.")]
            public string Password { get; set; }
            [DisplayName("Confirm Password")]
            [Required(ErrorMessage = "Confirm Password is required.")]
            [Compare("Password", ErrorMessage = "Password and Confirm Password must match.")]
            public string ConfirmPassword { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
        }
    }
}