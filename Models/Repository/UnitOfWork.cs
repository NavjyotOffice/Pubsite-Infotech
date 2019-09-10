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

        public IContentDetailRepository ContentDetail { get; private set; }
        public INewsRepository News { get; private set; }
        public IEventsRepository Events { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            this.ContentDetail = new ContentDetailRepository(context);
            this.News = new NewsRepository(context);
            this.Events = new EventsRepository(context);
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
