using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        [Display(Name = "Event Date")]
        [Required]
        public DateTime EventDate { get; set; }

        [Display(Name = "Event End")]
        [Required]
        public DateTime EventDateEnd { get; set; }

        [Display(Name = "Event Name")]
        [Required]
        public string EventName { get; set; }

        public List<User> users { get; set; }
    }
}