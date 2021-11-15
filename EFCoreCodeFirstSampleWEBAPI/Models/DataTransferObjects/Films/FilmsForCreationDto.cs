using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models.DataTransferObjects
{
    public class FilmsForCreationDto
    {
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string NameFilm { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime ReleaseData { get; set; }

        [StringLength(50, ErrorMessage = "Name country can't be longer than 50 characters")]
        public string Country { get; set; }
        public int FKDescriptionId { get; set; }
    }
}
