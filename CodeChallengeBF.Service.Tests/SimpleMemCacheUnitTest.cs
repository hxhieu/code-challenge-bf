namespace CodeChallengeBF.Service.Tests
{
    [TestClass]
    public class SimpleMemCacheUnitTest
    {
        [TestMethod]
        public async Task It_Should_Get_Correct_Cache()
        {
            var cache = new SimpleMemCache();
            await cache.Upsert("hello", "world");
            var value = await cache.Get<string>("hello");
            Assert.IsNotNull(value);
            Assert.AreEqual("world", value);
        }

        [TestMethod]
        public async Task It_Should_Return_Empty_Cache()
        {
            var cache = new SimpleMemCache();
            var value = await cache.Get<string>("hello");
            Assert.IsNull(value);
        }
    }
}