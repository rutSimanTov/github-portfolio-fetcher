using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections;

namespace Service
{
    public class GitHubService : IGitHubService
    {
        private readonly GitHubClient _client;
        private readonly GitHubIntegrationOptions _options;

        public GitHubService(IOptions<GitHubIntegrationOptions> options )
        {
            _client = new GitHubClient(new ProductHeaderValue("my-github-site"));
            _options = options.Value;
        }

        public async Task<List<Repository>> SearchRepositoriesInCSharp(string repo_name)
        {
            var request = new SearchRepositoriesRequest(repo_name) { Language = Language.CSharp };
            var result = await _client.Search.SearchRepo(request);
            return result.Items.ToList();
        }

            public async Task<List<Portfolio>> GetPortfolio()
             {
            var repositories = await _client.Repository.GetAllForUser(_options.UserName);
            var repositoryDetailsList = new List<Portfolio>();
            foreach (var repo in repositories)
            {
                var languages = await _client.Repository.GetAllLanguages(_options.UserName, repo.Name);
                var pullRequest=await _client.PullRequest.GetAllForRepository(_options.UserName, repo.Name);
                var pullRequestCount=pullRequest.Count();

                repositoryDetailsList.Add(new Portfolio
                {
                    RpoName=repo.Name,
                    Url=repo.Url,
                    Stars=repo.StargazersCount,
                    LastCommit=repo.PushedAt?.ToString("yyyy-MM-dd HH:mm:ss")??"No commits",
                    PullRequests= pullRequestCount,
                    Languages= languages.Select(l=>l.Name).ToList(),
                });    
            }
            return repositoryDetailsList;  
        }

        public async Task<List<Repository>> SearchRepositories(string repoName,string userName,string language)
        {
            var query= $"{repoName} user:{userName} language:{language}";
            var request = new SearchRepositoriesRequest(query);
            var result = await _client.Search.SearchRepo(request);
            return result.Items.ToList();

        }





    }
}
