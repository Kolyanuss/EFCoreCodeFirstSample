using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models.DataTransferObjects
{
    public class FilmsDTO
    {
        public int Id { get; set; }
        public string NameFilm { get; set; }
        public DateTime ReleaseData { get; set; }
        public string Country { get; set; }
        public int FKDescriptionId { get; set; }
    }
}
