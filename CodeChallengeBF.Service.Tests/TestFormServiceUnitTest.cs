using AutoMapper;
using CodeChallengeBF.Data;
using CodeChallengeBF.Service.Models;

namespace CodeChallengeBF.Service.Tests
{
    [TestClass]
    public class TestFormServiceUnitTest
    {
        private static TestFormService BuildTestService()
        {
            var testCache = new SimpleMemCache();
            var testRepo = new TestFormJsonFile();
            var testMapper = new MapperConfiguration( cfg =>
            {
                cfg.AddProfile( new MapperProfile() ); 
            } );
            var mapper = testMapper.CreateMapper();
            return new TestFormService( testCache, testRepo, mapper );
        }

        [TestMethod]
        public async Task It_Should_Upsert_Values()
        {
            var service = BuildTestService();
            await service.Upsert(
                new TestFormModel { FirstName = "bob", LastName = "dotnet" },
                new TestFormModel { FirstName = "alice", LastName = "dotnet" }
            );
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public async Task It_Should_Not_Allow_Delete_Yet()
        {
            var service = BuildTestService();
            await service.Delete(
                new TestFormModel { FirstName = "bob", LastName = "dotnet" },
                new TestFormModel { FirstName = "alice", LastName = "dotnet" }
            );
        }
    }
}
