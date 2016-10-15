using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Data
{
    public static class DataBaseClass
    {
        public static List<User> Users { get; set; }

        static DataBaseClass()
        {
            Users = new List<User>();
        }
    }
}