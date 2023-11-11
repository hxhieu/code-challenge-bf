namespace CodeChallengeBF.Service.Contract
{
    public interface ICache
    {
        Task<T?> Get<T>( string key ) where T : class;
        Task Upsert<T>( string key, T value ) where T : class;
        int Count();
    }
}
