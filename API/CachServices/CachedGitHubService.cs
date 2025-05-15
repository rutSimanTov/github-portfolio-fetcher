using Microsoft.Extensions.Caching.Memory;
using Octokit;
using Service;

namespace API.CachServices
{
    public class CachedGitHubService:IGitHubService
    {
        private readonly IGitHubService _gitHubService;
        private readonly IMemoryCache _memoryCache;
        private const string UserPortfolioKey = "UserPortfolioKey";

        public CachedGitHubService(IGitHubService gitHubService ,IMemoryCache memoryCache)
        {
            _gitHubService = gitHubService;
            _memoryCache = memoryCache;
        }
        public Task<List<Repository>> SearchRepositoriesInCSharp(string repo_name)
        {
            return _gitHubService.SearchRepositoriesInCSharp(repo_name);
        }

        public async Task<List<Portfolio>> GetPortfolio()
        {
            if(_memoryCache.TryGetValue(UserPortfolioKey, out List<Portfolio> portfolio))
                return portfolio;
           
            var cacheOption=new MemoryCacheEntryOptions().
                SetAbsoluteExpiration(TimeSpan.FromSeconds(30))
                .SetSlidingExpiration(TimeSpan.FromSeconds(10));

            portfolio= await _gitHubService.GetPortfolio();
            _memoryCache.Set(UserPortfolioKey, portfolio);

            return portfolio;
        }

        public Task<List<Repository>> SearchRepositories(string repoName, string userName, string language)
        {
           return _gitHubService.SearchRepositories(repoName, userName, language);
        }

       
    }
}
