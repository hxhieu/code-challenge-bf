using CodeChallengeBF.Data.Contract;
using CodeChallengeBF.Data.Entity;
using System.Text.Json;

namespace CodeChallengeBF.Data
{
    public class TestFormJsonFile : ITestFormRepository
    {
        public const string FILE_NAME = "./test-form.json";
        // Only 1 thread can enter the code, if this is locked
        private static readonly SemaphoreSlim _lock = new( 1, 1 );

        public Task<List<TestFormEntity>> All()
        {
            var formValues = new List<TestFormEntity>();
            try
            {
                // Read the current file
                var json = File.ReadAllText( FILE_NAME );
                formValues = JsonSerializer.Deserialize<List<TestFormEntity>>( json ) ?? new List<TestFormEntity>();
            }
            catch {/* Could not parse the file then just do nothing and reset it */}

            return Task.FromResult( formValues );
        }

        public Task Delete( TestFormEntity entity )
        {
            throw new NotImplementedException( "Not required for this challenge" );
        }

        public async Task<TestFormEntity> Insert( TestFormEntity entity )
        {
            await _lock.WaitAsync();
            try
            {
                var formValues = await All();
                formValues.Add( entity );
                File.WriteAllText( FILE_NAME, JsonSerializer.Serialize( formValues ) );
                return entity;
            }
            finally
            {
                _lock.Release();
            }
        }

        public Task<TestFormEntity> Update( TestFormEntity entity )
        {
            throw new NotImplementedException( "Not required for this challenge" );
        }
    }
}
