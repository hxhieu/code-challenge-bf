namespace CodeChallengeBF.Service.Contract
{
    public interface IGenericService<T>
    {
        Task Upsert(Func<T,bool> predicate, params T[] values);
        Task Delete(Func<T, bool> predicate);
    }
}
