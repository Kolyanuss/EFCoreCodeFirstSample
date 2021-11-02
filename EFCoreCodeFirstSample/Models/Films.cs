using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirstSample.Models
{
    public class Films
    {
        public int Id { get; set; }
        [Required]
        public string NameFilm { get; set; }
        public DateTime ReleaseData { get; set; }
        public string Country { get; set; }
        public int DescriptionId { get; set; }
        [ForeignKey("FKDescriptionId")]
        public Description Description { get; set; }
        public List<ListFilms> ListFilms { get; set; }
    }
}
