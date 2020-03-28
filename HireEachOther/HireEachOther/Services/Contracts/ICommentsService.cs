using HireEachOther.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HireEachOther.Services.Contracts
{
    public interface ICommentsService
    {
        void AddCommentToAd(AdComment comment);
        void AddCommentToUser(UserComment comment);
        List<UserComment> GetUserComments(string userId);
    }
}
