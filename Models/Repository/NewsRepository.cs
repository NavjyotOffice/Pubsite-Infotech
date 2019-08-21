using InfotechVision.Data;
using InfotechVision.Models.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InfotechVision.Models.Repository
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        private readonly DbContext context;

        public NewsRepository(DbContext dbContext)
            : base(dbContext)
        {
            this.context = dbContext;
        }

        public IEnumerable<News> GetAllFeaturedNews()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<News> GetAllTrendingNews()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<News> GetNewsForAdmin()
        {
            return context.Set<News>().Include(n => n.ContentDetail);
        }

        public IEnumerable<News> GetNewsForUser(string userEmail)
        {
            return context.Set<News>().Include(n => n.ContentDetail).Where(n => n.ContentDetail.CreatedBy.Email.Contains(userEmail));
        }
        public News GetNewsByIDForAdmin(int? Id)
        {
            return context.Set<News>().Include(n => n.ContentDetail).Include(n => n.ContentDetail.CreatedBy).Include(n => n.ContentDetail.UpdatedBy).SingleOrDefault(n => n.NewsID == Id);
        }
        public News GetNewsByIDForUser(int? Id, string userEmail)
        {
            return context.Set<News>().Include(n => n.ContentDetail).Where(n => n.ContentDetail.CreatedBy.Email == userEmail).SingleOrDefault(n => n.NewsID == Id);
        }
    }
}
