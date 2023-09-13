using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiTest.Models;

namespace RapidApiConsume.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ResultMovieModel> movieList = new List<ResultMovieModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "d8d8aeb313msh31e7a2be4c5c1dbp159996jsn2a13d442fda9" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                movieList = JsonConvert.DeserializeObject<List<ResultMovieModel>>(body);
                return View(movieList);
            }
        }
    }
}
