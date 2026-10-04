using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalServicesApp
{
    // Custom Priority Queue (Rubric Requirement)
    public class CustomPriorityQueue<T> where T : MunicipalEvent
    {
        private List<T> items = new List<T>();

        public void Enqueue(T item)
        {
            items.Add(item);
            items.Sort((x, y) => x.Priority.CompareTo(y.Priority)); // 1 is highest priority
        }

        public T Dequeue()
        {
            if (items.Count == 0) throw new InvalidOperationException("Queue is empty");
            T item = items[0];
            items.RemoveAt(0);
            return item;
        }

        public void RemoveById(int id) { items.RemoveAll(x => x.EventID == id); }
        public List<T> GetAll() { return items; }
        public void Clear() { items.Clear(); }
    }

    public class EventManager
    {
        public SortedDictionary<DateTime, List<MunicipalEvent>> EventsByDate { get; set; }
        public Dictionary<string, List<MunicipalEvent>> EventsByCategory { get; set; }
        public HashSet<string> UniqueCategories { get; set; }
        public Stack<MunicipalEvent> RecentlyViewed { get; set; }
        public Queue<MunicipalEvent> UpcomingEventsQueue { get; set; }
        public CustomPriorityQueue<MunicipalEvent> UrgentAlertsQueue { get; set; }

        public EventManager()
        {
            EventsByDate = new SortedDictionary<DateTime, List<MunicipalEvent>>();
            EventsByCategory = new Dictionary<string, List<MunicipalEvent>>();
            UniqueCategories = new HashSet<string>();
            RecentlyViewed = new Stack<MunicipalEvent>();
            UpcomingEventsQueue = new Queue<MunicipalEvent>();
            UrgentAlertsQueue = new CustomPriorityQueue<MunicipalEvent>();
        }

        public void AddEvent(MunicipalEvent evt)
        {
            if (!EventsByDate.ContainsKey(evt.EventDate))
                EventsByDate[evt.EventDate] = new List<MunicipalEvent>();
            EventsByDate[evt.EventDate].Add(evt);

            if (!EventsByCategory.ContainsKey(evt.Category))
                EventsByCategory[evt.Category] = new List<MunicipalEvent>();
            EventsByCategory[evt.Category].Add(evt);

            UniqueCategories.Add(evt.Category);
            UpcomingEventsQueue.Enqueue(evt);

            if (evt.Priority == 1)
                UrgentAlertsQueue.Enqueue(evt);
        }

        public void DeleteEvent(int eventId)
        {
            foreach (var kvp in EventsByDate.ToList())
            {
                kvp.Value.RemoveAll(e => e.EventID == eventId);
                if (kvp.Value.Count == 0) EventsByDate.Remove(kvp.Key);
            }
            foreach (var kvp in EventsByCategory.ToList())
            {
                kvp.Value.RemoveAll(e => e.EventID == eventId);
                if (kvp.Value.Count == 0) EventsByCategory.Remove(kvp.Key);
            }

            UpcomingEventsQueue.Clear();
            UrgentAlertsQueue.Clear();
            foreach (var list in EventsByDate.Values)
            {
                foreach (var evt in list)
                {
                    UpcomingEventsQueue.Enqueue(evt);
                    if (evt.Priority == 1) UrgentAlertsQueue.Enqueue(evt);
                }
            }
        }

        public void UpdateEvent(MunicipalEvent updatedEvent)
        {
            DeleteEvent(updatedEvent.EventID);
            AddEvent(updatedEvent);
        }

        public void RecordView(MunicipalEvent evt) { RecentlyViewed.Push(evt); }
    }
}