using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using XCore.Client.Models;
using XCore.Client.Models.ViewModels;

namespace XCore.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Crews()
        {
            var httpClient = _httpClientFactory.CreateClient("ApiClient");

            var response = await httpClient.GetAsync("api/crews").ConfigureAwait(false);

            response.EnsureSuccessStatusCode(); 
            if (response.IsSuccessStatusCode)
            {
                var crewsString = await response.Content.ReadAsStringAsync();
                var crews = JsonSerializer.Deserialize<List<CrewsViewModel>>(crewsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return View(crews);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                return RedirectToAction("AccessDenied", "Auth");
            }
            throw new Exception("There is a problem accessing the Api");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
