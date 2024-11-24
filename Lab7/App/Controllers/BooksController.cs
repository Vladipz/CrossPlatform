using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace App.Controllers
{
    public class BooksController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;

        public BooksController(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings.Value;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync(_apiSettings.BaseUrl + "/api/books");
                if (!response.IsSuccessStatusCode)
                {
                    return View(new List<Book>());
                }

                var books = await response.Content.ReadFromJsonAsync<List<Book>>();
                return View(books);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(new List<Book>());
            }
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var response = await _httpClient.GetAsync(_apiSettings.BaseUrl + $"/api/books/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    return NotFound();
                }
                var book = await response.Content.ReadFromJsonAsync<Book>();
                return View(book);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }
        }
    }
}
