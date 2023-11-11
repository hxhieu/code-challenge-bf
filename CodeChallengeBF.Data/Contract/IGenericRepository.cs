namespace CodeChallengeBF.Data.Contract
{
    public interface IGenericRepository<T>
    {
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
        Task<List<T>> All(); 
    }
}
