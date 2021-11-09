using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public List<FilmsUsers> FilmsUsers { get; set; }

        public User()
        {
            FilmsUsers = new List<FilmsUsers>();
        }
    }
}
