namespace CodeChallengeBF.Service.Contract
{
    internal interface ICache
    {
        Task<T> Get<T>(string key);
        Task Upsert<T>(string key, T value);
    }
}
