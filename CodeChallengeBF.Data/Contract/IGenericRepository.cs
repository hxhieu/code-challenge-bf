namespace CodeChallengeBF.Data.Contract
{
    public interface IGenericRepository<T>
    {
        string RepoType { get; }
        Task<T> Upsert(T entity);
        Task Delete(T entity);
        Task<List<T>> All(); 
    }
}
