using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models
{
    public abstract class IBaseEntity
    {
        public int _Id { get; }
    }
}
