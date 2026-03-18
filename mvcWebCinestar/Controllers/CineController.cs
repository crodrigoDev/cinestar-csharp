using Microsoft.AspNetCore.Mvc;
using mvcWebCinestar.Controllers.dao;

namespace mvcWebCinestar.Controllers
{
    public class CineController : Controller
    {
        private readonly daoCine _dao;

        public CineController(daoCine dao)
        {
            _dao = dao;
        }
            public IActionResult Inicio()
        {
            return View();
        }
        public IActionResult verCines()
        {
            var lista = _dao.getVerCines();
            return View(lista);
        }
        public IActionResult verCine(int idCine)
        {
            var lista = _dao.getVerCine(idCine);
            ViewBag.Tarifas = _dao.getCineTarifas(idCine);
            ViewBag.CinePeliculas = _dao.getCinePeliculas(idCine);
            return View(lista);
        }
    }
}
