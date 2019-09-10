using InfotechVision.Models.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfotechVision.Models.Repository
{
    public class EventsRepository : Repository<Event>, IEventsRepository
    {
        private readonly DbContext context;

        public EventsRepository(DbContext dbContext): base(dbContext)
        {
            this.context = dbContext;
        }

        public IEnumerable<Event> GetAllConferences()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAllLiveWebinar()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAllOnDemandWebinar()
        {
            throw new NotImplementedException();
        }

        public Event GetEventsByIDForAdmin(int? Id)
        {
            return context.Set<Event>().Include(e => e.ContentDetail).Include(e => e.Address).Include(e => e.ContentDetail.CreatedBy).Include(e => e.ContentDetail.UpdatedBy).SingleOrDefault(e => e.EventID == Id);
        }

        public Event GetEventsByIDForUser(int? Id, string userEmail)
        {
            return context.Set<Event>().Include(e => e.ContentDetail).Include(e => e.Address).Where(e=>e.ContentDetail.CreatedBy.Email.Contains(userEmail.Trim())).SingleOrDefault(e => e.EventID == Id);
        }

        public IEnumerable<Event> GetEventsForAdmin()
        {
            return context.Set<Event>().Include(e => e.ContentDetail).Include(e => e.Address);
        }

        public IEnumerable<Event> GetEventsForUser(string userEmail)
        {
            return context.Set<Event>().Include(e => e.ContentDetail).Include(e => e.Address).Where(e=>e.ContentDetail.CreatedBy.Email.Contains(userEmail));
        }
    }
}
