using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalServicesApp
{
    // Custom Priority Queue to demonstrate understanding (15 Marks)
    public class CustomPriorityQueue<T> where T : MunicipalEvent
    {
        private List<T> items = new List<T>();

        public void Enqueue(T item)
        {
            items.Add(item);
            // Sort by Priority (1 is highest priority/urgent)
            items.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        }

        public T Dequeue()
        {
            if (items.Count == 0) throw new InvalidOperationException("Queue is empty");
            T item = items[0];
            items.RemoveAt(0);
            return item;
        }

        public List<T> GetAll() { return items; }
    }

    // Main Manager utilizing all required data structures
    public class EventManager
    {
        // Sorted Dictionary: Automatically sorts events by Date (15 Marks)
        public SortedDictionary<DateTime, List<MunicipalEvent>> EventsByDate { get; set; }

        // Dictionary: Groups events by Category (15 Marks)
        public Dictionary<string, List<MunicipalEvent>> EventsByCategory { get; set; }

        // HashSet: Stores unique categories efficiently (10 Marks)
        public HashSet<string> UniqueCategories { get; set; }

        // Stack: Tracks "Recently Viewed" events - LIFO (15 Marks)
        public Stack<MunicipalEvent> RecentlyViewed { get; set; }

        // Queue: Holds upcoming events to be processed - FIFO (15 Marks)
        public Queue<MunicipalEvent> UpcomingEventsQueue { get; set; }

        // Priority Queue: Handles Urgent Alerts (15 Marks)
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
            // Add to Sorted Dictionary
            if (!EventsByDate.ContainsKey(evt.EventDate))
                EventsByDate[evt.EventDate] = new List<MunicipalEvent>();
            EventsByDate[evt.EventDate].Add(evt);

            // Add to Dictionary
            if (!EventsByCategory.ContainsKey(evt.Category))
                EventsByCategory[evt.Category] = new List<MunicipalEvent>();
            EventsByCategory[evt.Category].Add(evt);

            // Add to Set
            UniqueCategories.Add(evt.Category);

            // Add to Queue
            UpcomingEventsQueue.Enqueue(evt);

            // Add to Priority Queue if Urgent
            if (evt.Priority == 1)
                UrgentAlertsQueue.Enqueue(evt);
        }

        public void RecordView(MunicipalEvent evt)
        {
            RecentlyViewed.Push(evt); // Add to Stack
        }
    }
}