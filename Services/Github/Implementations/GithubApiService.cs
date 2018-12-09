using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AppData;
using AppData.Dtos;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Websites.Services.Github
{
    public class GithubApiService : IGithubApiService
    {
        private const string GITHUB_API_REPOS = "GithubApiUrl";

        private readonly IConfiguration Configuration;
        private readonly WebsitesContext Context;

        public GithubApiService(WebsitesContext context, IConfiguration configuration)
        {
            Configuration = configuration;
            Context = context;
        }

        public IEnumerable<GithubRepoDto> GetRepositories()
        {
            var client = new RestClient(new Uri(
                Configuration.GetValue<string>(GITHUB_API_REPOS)
            ));

            var response = client.Get<List<GithubRepoDto>>(new RestRequest());

            return response.Data;
        }
    }
}