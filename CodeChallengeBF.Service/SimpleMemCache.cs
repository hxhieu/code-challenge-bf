using CodeChallengeBF.Service.Contract;

namespace CodeChallengeBF.Service
{
    public class SimpleMemCache : ICache
    {
        public Task<T> Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public Task Upsert<T>(string key, T value)
        {
            throw new NotImplementedException();
        }
    }
}
