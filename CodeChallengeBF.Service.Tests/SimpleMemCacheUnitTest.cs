using CodeChallengeBF.Service.Models;

namespace CodeChallengeBF.Service.Tests
{
    [TestClass]
    public class SimpleMemCacheUnitTest
    {
        [TestMethod]
        public async Task It_Should_Get_Correct_Cache()
        {
            var cache = new SimpleMemCache();
            var expected = new TestFormModel
            {
                FirstName = "hello",
                LastName = "world"
            };
            var key = expected.GetHashCode().ToString();
            await cache.Upsert( key, expected );
            var result = await cache.Get<TestFormModel>( key );
            Assert.IsNotNull( result );
            Assert.AreEqual( expected.FirstName, result.FirstName );
            Assert.AreEqual( expected.LastName, result.LastName );
        }

        [TestMethod]
        public async Task It_Should_Return_Empty_Cache()
        {
            var cache = new SimpleMemCache();
            var expected = new TestFormModel
            {
                FirstName = "hello",
                LastName = "world"
            };
            var key = expected.GetHashCode().ToString();
            var value = await cache.Get<TestFormModel>(key );
            Assert.IsNull( value );
        }
    }
}