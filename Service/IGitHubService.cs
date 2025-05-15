using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IGitHubService
    {
        public  Task<List<Repository>> SearchRepositoriesInCSharp(string repo_name);
       
        public Task<List<Portfolio>> GetPortfolio();

        public Task<List<Repository>> SearchRepositories(string repoName, string userName, string language);



    }
}
