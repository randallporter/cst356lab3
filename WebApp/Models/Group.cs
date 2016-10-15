using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Group
    {
        [Key]
        public int GroupID { get; set; }
        [Required]
        public string Name { get; set; }

        public List<User> users { get; set; }
    }
}