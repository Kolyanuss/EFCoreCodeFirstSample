using EFCoreCodeFirstSampleWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models
{
    public class FilmsGenres
    {
        public int IdFilms { get; set; }
        public Films Films { get; set; }

        public int IdGenres { get; set; }
        public Genres Genres { get; set; }

    }
}
