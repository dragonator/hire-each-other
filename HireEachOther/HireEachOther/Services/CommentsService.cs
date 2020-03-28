using HireEachOther.Data;
using HireEachOther.Models;
using HireEachOther.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HireEachOther.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ApplicationDbContext _dbContext;
        public CommentsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddCommentToAd(AdComment comment)
        {
            _dbContext.AdComments.Add(comment);
            _dbContext.SaveChanges();
        }
        public void AddCommentToUser(UserComment comment)
        {
            _dbContext.UserComments.Add(comment);
            _dbContext.SaveChanges();
        }
        public List<UserComment> GetUserComments(string userId)
        {
            var result = _dbContext.UserComments
                            .Where(uc => uc.TargetId == userId)
                            .Include(uc => uc.Owner)
                            .OrderBy(uc => uc.DateAdded)
                            .ToList();
            return result;
        }
    }
}
