using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models.DataTransferObjects
{
    public class FilmsDetailUsersIdDTO
    {
        public FilmsDTO Films { get; set; }
        public int IdUser { get; set; }
    }
}
