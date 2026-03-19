using Microsoft.AspNetCore.Mvc;
using mvcWebCinestar.Models;

namespace mvcWebCinestar.Controllers
{
    [Route("Cinestar")]
    public class CinestarapiController : Controller
    {
        private readonly HttpClient _client;

        public CinestarapiController(HttpClient client)
        {
            _client = client;
            _client.BaseAddress ??= new Uri("https://localhost:44345/api/");
        }

        [HttpGet("Cines")]
        public async Task<IActionResult> verCines()
        {
            List<Cine> cines = new();
            HttpResponseMessage res = await _client.GetAsync("Cinestar/GetCines");

            if (res.IsSuccessStatusCode) cines = await res.Content.ReadFromJsonAsync<List<Cine>>() ?? new();
            return View("~/Views/Cine/verCines.cshtml", cines);
        }

        [HttpGet("Cines/{idCine}")]
        public async Task<IActionResult> verCine(int idCine)
        {
            var tCine = _client.GetAsync($"Cinestar/GetCine/{idCine}");
            var tCineTarifas = _client.GetAsync($"Cinestar/GetCineTarifas/{idCine}");
            var tCinePeliculas = _client.GetAsync($"Cinestar/GetCinePeliculas/{idCine}");

            await Task.WhenAll(tCine, tCineTarifas, tCinePeliculas);

            Cine cine = new();
            ViewBag.Tarifas = new List<CineTarifa>();
            ViewBag.CinePeliculas = new List<CinePelicula>();

            if (tCine.Result.IsSuccessStatusCode && tCineTarifas.Result.IsSuccessStatusCode && tCinePeliculas.Result.IsSuccessStatusCode)
            {
                cine = await tCine.Result.Content.ReadFromJsonAsync<Cine>();
                ViewBag.Tarifas = await tCineTarifas.Result.Content.ReadFromJsonAsync<List<CineTarifa>>();
                ViewBag.CinePeliculas = await tCinePeliculas.Result.Content.ReadFromJsonAsync<List<CinePelicula>>();
            }

            return View("~/Views/Cine/verCine.cshtml", cine);
        }

        [HttpGet("Peliculas/Listado/{id}")]
        public async Task<IActionResult> verPeliculas(int id)
        {
            List<Pelicula> peliculas = new();
            HttpResponseMessage res = await _client.GetAsync($"Cinestar/GetPeliculas/{id}");

            if(res.IsSuccessStatusCode) peliculas = await res.Content.ReadFromJsonAsync<List<Pelicula>>() ?? new();

            return View("~/Views/Pelicula/verPeliculas.cshtml", peliculas);
        }

        [HttpGet("Peliculas/Detalle/{idPelicula}")]
        public async Task<IActionResult> verPelicula(int idPelicula)
        {
            Pelicula peliculas = new();
            HttpResponseMessage res = await _client.GetAsync($"Cinestar/GetPelicula/{idPelicula}");

            if (res.IsSuccessStatusCode) peliculas = await res.Content.ReadFromJsonAsync<Pelicula>() ?? new();

            return View("~/Views/Pelicula/verPelicula.cshtml", peliculas);
        }
    }
}