using mvcWebCinestar.Controllers.bd;
using mvcWebCinestar.Models;
namespace mvcWebCinestar.Controllers.dao
{
    public class daoPelicula
    {
        private readonly clsBD _db;
        public daoPelicula(clsBD bd)
        {
            _db = bd;
        }

        internal List<Pelicula> getVerPeliculas(int id)
        {
            _db.Sentencia($"EXEC sp_getPeliculas {id}");
            return new Pelicula().getList(_db.getRegistros());
        }
        internal Pelicula getVerPelicula(int idPelicula)
        {
            _db.Sentencia($"EXEC sp_getPelicula {idPelicula}");
            Pelicula pelicula = new();
            pelicula.setRegistro(_db.getRegistro());
            return pelicula;
        }

        
    }
}
