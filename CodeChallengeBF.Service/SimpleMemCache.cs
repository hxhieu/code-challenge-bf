using CodeChallengeBF.Service.Contract;
using MemoryPack;
using System.Collections.Concurrent;

namespace CodeChallengeBF.Service
{
    public class SimpleMemCache : ICache
    {
        private readonly ConcurrentDictionary<string, byte[]> _cache = new();

        public int Count()
        {
            return _cache.Count;
        }

        public Task<T?> Get<T>( string key ) where T : class
        {
            if (_cache.TryGetValue( key, out byte[] buf ))
            {
                return Task.FromResult( MemoryPackSerializer.Deserialize<T>( buf ) );
            }
            return Task.FromResult( default( T ) );
        }

        public Task Upsert<T>( string key, T value ) where T : class
        {
            _cache.TryAdd( key, MemoryPackSerializer.Serialize( value ) );
            return Task.CompletedTask;
        }
    }
}
