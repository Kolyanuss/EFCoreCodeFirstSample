using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models
{
    public class Description
    {
        public int Id { get; set; }
        [Required]
        public string DescriptionText { get; set; }
        public string Author { get; set; }
    }
}
