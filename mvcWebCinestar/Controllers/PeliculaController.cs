using Microsoft.AspNetCore.Mvc;
using mvcWebCinestar.Controllers.dao;

namespace mvcWebCinestar.Controllers
{
    public class PeliculaController : Controller
    {
        private readonly daoPelicula _dao;
        public PeliculaController(daoPelicula dao)
        {
            _dao = dao;
        }
        public IActionResult verPeliculas(int id)
        {
            var lista = _dao.getVerPeliculas(id);
            return View(lista);
        }
        public IActionResult verPelicula(int idPelicula)
        {
            var lista = _dao.getVerPelicula(idPelicula);
            return View(lista);
        }
    }
}
