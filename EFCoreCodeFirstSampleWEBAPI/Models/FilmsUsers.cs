using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models
{
    public class FilmsUsers
    {
        public int IdFilms { get; set; }
        public Films Films { get; set; }

        public int IdUser { get; set; }
        public User User { get; set; }
    }
}
