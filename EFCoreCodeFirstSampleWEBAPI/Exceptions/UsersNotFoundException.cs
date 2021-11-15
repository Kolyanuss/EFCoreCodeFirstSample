using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Exceptions
{
    public sealed class UsersNotFoundException : NotFoundException
    {
        public UsersNotFoundException(int Id)
            : base($"The user with the identifier {Id} was not found.")
        {
        }
    }
}
