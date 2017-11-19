
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using CalgaryHacks.Apis;

namespace CalgaryHacks.DatabaseModel
{
    public static class EventCache
    {
        private const int UpdateTimeInMinutes = 30;
        private static readonly DataModel Db = new DataModel();
        private static ConcurrentBag<Event> _eventBag = new ConcurrentBag<Event>();
        private static DateTime _lastUpdateTime = DateTime.Now;

        public static void UpdateEventsFromDb()
        {
            _eventBag = new ConcurrentBag<Event>();
            DateTime yesterday = DateTime.Now.AddDays(-1);
            List<Event> events = Db.Events.Where(x => x.EventDate > yesterday)
                .OrderBy(y => y.EventDate)
                .ToList();
            foreach (Event eventObject in events)
            {
                _eventBag.Add(eventObject);
            }
        }

        public static List<Event> GetEventBag()
        {
            if ((DateTime.Now - _lastUpdateTime).Minutes > UpdateTimeInMinutes)
            {
                EventsApi.UpdateEvents();
                _eventBag = new ConcurrentBag<Event>();
                _lastUpdateTime = DateTime.Now;
            }
            if (_eventBag.IsEmpty)
            {
                UpdateEventsFromDb();

            }
            return _eventBag.ToList();
        }
    }
}