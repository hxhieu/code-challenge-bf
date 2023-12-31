﻿using CodeChallengeBF.Data.Contract;
using CodeChallengeBF.Data.Entity;
using System.Text.Json;

namespace CodeChallengeBF.Data
{
    public class TestFormJsonFile : ITestFormRepository
    {
        public const string FILE_NAME = "./test-form.json";
        // Only 1 thread can enter the code, if this is locked
        private static readonly SemaphoreSlim _lock = new( 1, 1 );

        public string RepoType => string.Format( "JSON FILE: '{0}'", Path.GetFullPath( FILE_NAME ) );

        public Task<List<TestFormEntity>> All()
        {
            var formValues = new List<TestFormEntity>();
            try
            {
                // Read the current file
                var json = File.ReadAllText( FILE_NAME );
                formValues = JsonSerializer.Deserialize<List<TestFormEntity>>( json ) ?? new List<TestFormEntity>();
            }
            catch {/* Could not parse the file then just do nothing and just reset it */}

            return Task.FromResult( formValues );
        }

        public Task Delete( TestFormEntity entity )
        {
            throw new NotImplementedException( "Not required for this challenge" );
        }

        public async Task<TestFormEntity> Upsert( TestFormEntity entity )
        {
            // Lock file writing
            // We need a semaphore because we also doing some async inside the lock
            await _lock.WaitAsync();
            try
            {
                var formValues = await All();
                if (!formValues.Exists( x => x.Id == entity.Id ))
                {
                    formValues.Add( entity );
                    File.WriteAllText( FILE_NAME, JsonSerializer.Serialize( formValues ) );
                }
                return entity;
            }
            finally
            {
                _lock.Release();
            }
        }
    }
}
