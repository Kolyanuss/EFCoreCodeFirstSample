using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models
{
    public class Genres
    {
        public int Id { get; set; }
        [Required]
        public string GenreName { get; set; }
        public List<FilmsGenres> FilmsGenres { get; set; }
    }
}
