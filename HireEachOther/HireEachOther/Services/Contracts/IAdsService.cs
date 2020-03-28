using HireEachOther.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HireEachOther.Services.Contracts
{
    public interface IAdsService
    {
        Ad GetAdById(Guid id);
        List<Ad> GetAdsByUserId(string id);
        void UpdateAdd(Ad ad);
        bool CreateAdAsync(Ad ad);

    }
}
