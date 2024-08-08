using System.Collections.Concurrent;

namespace MiddlewarePOC
{
    public class ResponseTimeTracker
    {
        private readonly ConcurrentDictionary<string, long> _responseTimes = new ConcurrentDictionary<string, long>();

        public void AddOrUpdate(string requestId, long responseTime)
        {
            _responseTimes[requestId] = responseTime;
        }

        public long? Get(string requestId)
        {
            _responseTimes.TryGetValue(requestId, out var responseTime);
            return responseTime;
        }
    }

}
