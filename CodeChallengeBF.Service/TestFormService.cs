using AutoMapper;
using CodeChallengeBF.Data.Contract;
using CodeChallengeBF.Data.Entity;
using CodeChallengeBF.Service.Contract;
using CodeChallengeBF.Service.Models;

namespace CodeChallengeBF.Service
{
    public class TestFormService : ITestFormService
    {
        private readonly ICache _cache;
        private readonly ITestFormRepository _repo;
        private readonly IMapper _mapper;

        public TestFormService( ICache cache, ITestFormRepository repo, IMapper mapper )
        {
            _cache = cache;
            _repo = repo;
            _mapper = mapper;
        }

        public string RepoType => _repo.RepoType ?? string.Empty;

        public Task Delete( params TestFormModel[] values )
        {
            throw new NotImplementedException( "Not required for this challenge" );
        }

        public async Task Upsert( params TestFormModel[] values )
        {
            // Rebuild the cache first, from persistent storage
            if (_cache.Count() <= 0)
            {
                try
                {
                    var all = _mapper.Map<List<TestFormModel>>( await _repo.All() );
                    foreach (var item in all)
                    {
                        await _cache.Upsert( item.Id, item );
                    }
                }
                catch { /* Do nothing if cache init failed */}
            }

            // Check values against cache
            foreach (var value in values)
            {
                if (await _cache.Get<TestFormModel>( value.Id ) != null)
                {
                    continue;
                }
                await _cache.Upsert( value.Id, value );
                await _repo.Insert( _mapper.Map<TestFormEntity>( value ) );
            }
        }
    }
}
