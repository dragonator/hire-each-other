using HireEachOther.Data;
using HireEachOther.Models;
using HireEachOther.Services.Contracts;
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
    }
}
