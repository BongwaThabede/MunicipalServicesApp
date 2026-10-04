using System.Collections.Generic;
using System.Linq;

namespace MunicipalServicesApp
{
    public class RecommendationEngine
    {
        private Dictionary<string, int> SearchPatternHistory { get; set; }

        public RecommendationEngine() { SearchPatternHistory = new Dictionary<string, int>(); }

        public void RecordSearch(string category)
        {
            if (string.IsNullOrEmpty(category)) return;
            if (SearchPatternHistory.ContainsKey(category)) SearchPatternHistory[category]++;
            else SearchPatternHistory[category] = 1;
        }

        public List<MunicipalEvent> GetRecommendations(EventManager manager)
        {
            List<MunicipalEvent> recommendations = new List<MunicipalEvent>();
            if (SearchPatternHistory.Count == 0) return recommendations;

            var topCategory = SearchPatternHistory.OrderByDescending(x => x.Value).First().Key;
            if (manager.EventsByCategory.ContainsKey(topCategory))
                recommendations = manager.EventsByCategory[topCategory];

            return recommendations;
        }
    }
}