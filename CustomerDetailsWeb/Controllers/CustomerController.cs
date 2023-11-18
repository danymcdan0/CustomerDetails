using CustomerDetailsWeb.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using CustomerDetailsWeb.Models;
using System.Net.Http;

namespace CustomerDetailsWeb.Controllers
{
    public class CustomerController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = new List<CustomerDTO>();

            var client = _httpClientFactory.CreateClient();

            var httpResponseMessage = await client.GetAsync("https://localhost:7291/api/customer");

            httpResponseMessage.EnsureSuccessStatusCode();

            response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<CustomerDTO>>());

            return View(response);
        }

        [HttpGet]
        public IActionResult Create() {

            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Create(CustomerViewModel customerViewModel)
		{
			var httpRequestMessage = new HttpRequestMessage()
			{
				Method = HttpMethod.Post,
				RequestUri = new Uri("https://localhost:7291/api/customer"),
				Content = new StringContent(JsonSerializer.Serialize(customerViewModel), Encoding.UTF8, "application/json")
			};

			var client = _httpClientFactory.CreateClient();

			await client.SendAsync(httpRequestMessage);

			return RedirectToAction("Index");
		}

		[HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<CustomerDTO>($"https://localhost:7291/api/customer/{Id}");
            return View(response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(CustomerDTO customerDTO)
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7291/api/customer/{customerDTO.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(customerDTO), Encoding.UTF8, "application/json")
            };

            var client = _httpClientFactory.CreateClient();

            await client.SendAsync(httpRequestMessage);

            return RedirectToAction("Index");
        }
    }
}
