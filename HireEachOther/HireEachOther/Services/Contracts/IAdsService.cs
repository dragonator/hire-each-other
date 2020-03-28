using HireEachOther.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HireEachOther.Services.Contracts
{
    public interface IAdsService
    {
        Ad GetAdById(string id);
        bool CreateAd(Ad ad);

    }
}
