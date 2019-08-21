using InfotechVision.Data;
using InfotechVision.Models.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfotechVision.Models.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;


        public INewsRepository News { get; private set; }
        public IContentDetailRepository ContentDetail { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            News = new NewsRepository(context);
            ContentDetail = new ContentDetailRepository(context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
