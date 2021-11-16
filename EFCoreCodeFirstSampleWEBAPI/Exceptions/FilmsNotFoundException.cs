using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Exceptions
{
    public sealed class FilmsNotFoundException : NotFoundException
    {
        public FilmsNotFoundException(int Id)
            : base($"The film with the identifier {Id} was not found.")
        {
        }
    }
}
