using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InfotechVision.Models.IRepository
{
    public interface INewsRepository : IRepository<News>
    {
        IEnumerable<News> GetAllFeaturedNews();
        IEnumerable<News> GetAllTrendingNews();
        IEnumerable<News> GetNewsForAdmin();
        IEnumerable<News> GetNewsForUser(string userEmail);
        News GetNewsByIDForAdmin(int? Id);
        News GetNewsByIDForUser(int? Id, string userEmail);
    }
}
