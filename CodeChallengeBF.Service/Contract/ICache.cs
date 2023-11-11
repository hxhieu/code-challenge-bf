namespace CodeChallengeBF.Service.Contract
{
    internal interface ICache
    {
        Task<T?> Get<T>( string key ) where T : class;
        Task Upsert<T>( string key, T value ) where T : class;
    }
}
