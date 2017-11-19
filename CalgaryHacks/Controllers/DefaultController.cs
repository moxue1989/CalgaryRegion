using CalgaryHacks.Apis;
using System.Collections.Generic;
using System.Web.Http;

namespace CalgaryHacks.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        public string Get(int id)
        {
//            EmailSender.SendEmail("mo_xue1989@yahoo.ca", "test email", "this is a test");
//            EventsApi.UpdateEvents();
//            PointsOfInterestsMapper.UpdateTransitLRTStations(PointsOfInterestsApi.GetTransitLRTLocations());
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
