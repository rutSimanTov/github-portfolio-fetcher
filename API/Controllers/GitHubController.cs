using Microsoft.AspNetCore.Mvc;
using Octokit;
using Service;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        public readonly IGitHubService _gitHubService;

        public GitHubController(IGitHubService gitHubService)
        {
            _gitHubService=gitHubService;
        }

        [HttpGet("{repo_name}")]
        public  Task<List<Repository>> SearchRepInCSharp(string repo_name)
        {

            return _gitHubService.SearchRepositoriesInCSharp(repo_name);
        }

        [HttpGet]
        public Task<List<Portfolio>> GetPortfolio()
        {
            return _gitHubService.GetPortfolio();
        }

        [HttpGet("{repoName}/{userName}/{language}")]

        //public Task<List<Repository>> SearchRepositories(string repoName, string userName, string language)
        public  Task<List<Repository>> SearchRepositories(string repoName, string userName, string language)

        {
            return _gitHubService.SearchRepositories(repoName, userName, language);
        }
    }

}
