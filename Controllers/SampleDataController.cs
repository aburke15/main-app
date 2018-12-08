using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppData;
using AppData.Models;
using Websites.Services;
using Websites.Services.Github;
using AppData.Interfaces;

namespace Websites.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly IGithubApiService GithubApi;
        private readonly ITestRepository TestRepository;

        public SampleDataController(IGithubApiService githubApi, ITestRepository testRepository) 
        {
            GithubApi = githubApi;
            TestRepository = testRepository;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRepositories()
        {
            var githubRepositories = await GithubApi.GetRepositories();

            if (!githubRepositories.Any())
                return BadRequest();

            return Ok(githubRepositories);
        }

        [HttpPost("[action]")]
        public IActionResult AddTest([FromBody]CreateTestRequest request)
        {
            var test = new Test
            {
                Body = request.Body,
                CreatedBy = request.CreatedBy
            };

            TestRepository.Add(test);
            TestRepository.SaveChangesAsync();

            return Ok();
        }

        public class CreateTestRequest
        {
            public string Body { get; set; }

            public string CreatedBy { get; set; }
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
