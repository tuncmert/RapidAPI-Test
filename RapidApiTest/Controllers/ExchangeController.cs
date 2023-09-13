using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiTest.Models;

namespace RapidApiConsume.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task <IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
                Headers =
    {
        { "X-RapidAPI-Key", "d8d8aeb313msh31e7a2be4c5c1dbp159996jsn2a13d442fda9" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultExchangeModel> (body);
                return View(values);
            }
            
        }
    }
}
