using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Exceptions
{
    public sealed class FilmsUsersNotFoundException : NotFoundException
    {
        public FilmsUsersNotFoundException(int Id)
            : base($"The filmsusers with the identifier {Id} was not found.")
        {
        }
        public FilmsUsersNotFoundException(int Id, int Id2)
            : base($"The filmsusers with the identifier ({Id};{Id2}) was not found.")
        {
        }
    }
}
