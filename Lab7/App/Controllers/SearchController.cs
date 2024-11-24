using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace App.Controllers
{
    public class SearchController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;

        public SearchController(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings.Value;
        }

        // GET: Search/ByOrderDate
        public async Task<IActionResult> ByOrderDate(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null || endDate == null)
            {
                return View(new List<Order>());
            }

            try
            {
                var url = $"/api/search/byorderdate?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}";
                var response = await _httpClient.GetAsync(_apiSettings.BaseUrl + url);
                if (!response.IsSuccessStatusCode)
                {
                    return View(new List<Order>());
                }
                var orders = await response.Content.ReadFromJsonAsync<List<Order>>();
                return View(orders);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(new List<Order>());
            }
        }
    }
}
