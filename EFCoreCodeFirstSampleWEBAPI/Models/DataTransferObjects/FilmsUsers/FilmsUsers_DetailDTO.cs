using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models.DataTransferObjects
{
    public class FilmsUsers_DetailDTO
    {
        public FilmsDTO Films { get; set; }
        public UserDTO User { get; set; }
    }
}
