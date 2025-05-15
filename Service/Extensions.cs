using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static  class Extensions
    {
        public static void AddGitHubIntegration(this IServiceCollection service,Action<GitHubIntegrationOptions> configureOption)
        {
            service.Configure(configureOption);
            service.AddScoped<IGitHubService, GitHubService>();
        }
    }
}
