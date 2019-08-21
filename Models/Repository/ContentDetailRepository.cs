using InfotechVision.Models.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfotechVision.Models.Repository
{
    public class ContentDetailRepository : Repository<ContentDetail>, IContentDetailRepository
    {
        private readonly DbContext dbContext;

        public ContentDetailRepository(DbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
