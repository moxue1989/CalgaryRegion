using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CalgaryHacks.DatabaseModel;

namespace CalgaryHacks.Controllers
{
    public class EventController : ApiController
    {
//        DataModel db = new DataModel();

        // GET: api/Event
        public IEnumerable<Event> Get()
        {
            return EventCache.GetEventBag();
        }

        // GET: api/Event/5
        public Event Get(int id)
        {
            return EventCache.GetEventBag().Find(x => x.Id == id);
        }

        // POST: api/Event
        public void Post([FromBody]Event eventObject)
        {
//            db.Events.Add(eventObject);
//            db.SaveChanges();
//            EventCache.UpdateEventsFromDb();
        }

        // DELETE: api/Event/5
        public void Delete(int id)
        {
//            Event eventObject = db.Events.Find(id);
//            if (eventObject != null)
//            {
//                db.Events.Remove(eventObject);
//                db.SaveChanges();
//            }
//            EventCache.UpdateEventsFromDb();
        }
    }
}
