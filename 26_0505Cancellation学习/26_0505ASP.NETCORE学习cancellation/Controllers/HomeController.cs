using _26_0505ASP.NETCORE学习cancellation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _26_0505ASP.NETCORE学习cancellation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            await DownloadAsync("https://www.bing.com/",1000,cancellationToken);
            return View();
        }

        static private async Task DownloadAsync(string url, int n, CancellationToken cancellationToken)
        {
            using (var client = new HttpClient())
            {
                for (int i = 0; i < n; i++)
                {
                    var resp = await client.GetAsync(url, cancellationToken);
                    string html = await resp.Content.ReadAsStringAsync();
                    Debug.WriteLine($"{DateTime.Now}:{html}");

                }
            }

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
