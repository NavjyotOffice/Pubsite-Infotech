using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfotechVision.Models.IRepository
{
    public interface IEventsRepository : IRepository<Event>
    {
        IEnumerable<Event> GetAllConferences();
        IEnumerable<Event> GetAllOnDemandWebinar();
        IEnumerable<Event> GetAllLiveWebinar();
        IEnumerable<Event> GetEventsForAdmin();
        IEnumerable<Event> GetEventsForUser(string userEmail);
        Event GetEventsByIDForAdmin(int? Id);
        Event GetEventsByIDForUser(int? Id, string userEmail);
    }
}
