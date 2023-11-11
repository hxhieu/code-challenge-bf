namespace CodeChallengeBF.Service.Contract
{
    internal interface ICache<T>
    {
        Task<T> Get(string key);
        Task Upsert(string key, T value);
    }
}
