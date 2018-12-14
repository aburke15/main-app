using System;
using System.Collections.Generic;
using AppData.Dtos;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Websites.Services.Github
{
    public class GithubApiService : IGithubApiService
    {
        private const string GITHUB_API_REPOS = "GithubApiUrl";
        private readonly IConfiguration Configuration;

        public GithubApiService(IConfiguration configuration) 
            => Configuration = configuration;

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