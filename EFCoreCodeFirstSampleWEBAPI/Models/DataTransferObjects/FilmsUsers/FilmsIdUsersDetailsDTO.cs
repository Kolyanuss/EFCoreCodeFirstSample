using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models.DataTransferObjects
{
    public class FilmsIdUsersDetailsDTO
    {
        public int IdFilms { get; set; }
        public UserDTO User { get; set; }
    }
}
