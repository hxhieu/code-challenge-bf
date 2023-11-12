using CodeChallengeBF.Service.Models;

namespace CodeChallengeBF.Service.Contract
{
    public interface ITestFormService : IGenericService<TestFormModel>
    {
        string RepoType { get; }
        Task InitCache();
    }
}
