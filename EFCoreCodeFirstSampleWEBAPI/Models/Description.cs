using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models
{
    public class Description : IBaseEntity
    {
        public int _Id { get { return Id; } }
        public int Id { get; set; }
        [Required]
        public string DescriptionText { get; set; }
        public string Author { get; set; }
    }
}
