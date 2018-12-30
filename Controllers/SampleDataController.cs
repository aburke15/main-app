using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Websites.AppData.Interfaces;
using Websites.AppData.Models;
using Websites.Services.Github;
using Websites.Services.Github.Interfaces;

namespace Websites.Controllers
{
    [Route("api/samples")]
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
        public IActionResult GetRepositories()
        {
            var githubRepositories = GithubApi.GetRepositories();

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
