using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HireEachOther.Models
{
    public enum ApplicationStatus
    {
        Pending,
        Rejected,
        Accepted
    }

    public enum AdType
    {
        None,
        Courier,
        Medical,
        Law,
        Heavy
    }
}

