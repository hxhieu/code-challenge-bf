namespace CodeChallengeBF.Service.Contract
{
    public interface IGenericService<T>
    {
        Task Upsert(params T[] values);
        Task Delete(params T[] values);
    }
}
