using CodeChallengeBF.Service.Models;

namespace CodeChallengeBF.Service.Tests
{
    [TestClass]
    public class TestFormServiceUnitTest
    {
        [TestMethod]
        public async Task It_Should_Upsert_Values()
        {
            var service = new TestFormService();
            await service.Upsert(
                new TestFormModel { FirstName = "bob", LastName = "dotnet" },
                new TestFormModel { FirstName = "alice", LastName = "dotnet" }
            );
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public async Task It_Should_Not_Allow_Delete_Yet()
        {
            var service = new TestFormService();
            await service.Delete(
                new TestFormModel { FirstName = "bob", LastName = "dotnet" },
                new TestFormModel { FirstName = "alice", LastName = "dotnet" }
            );
        }
    }
}
