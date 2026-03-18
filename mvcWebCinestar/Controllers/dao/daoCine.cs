using mvcWebCinestar.Controllers.bd;
using mvcWebCinestar.Models;

namespace mvcWebCinestar.Controllers.dao
{
    public class daoCine
    {
        private readonly clsBD _db;

        public daoCine(clsBD db)
        {
            _db = db;
        }

        internal dynamic getCinePeliculas(int idCine)
        {
            _db.Sentencia($"EXEC sp_getCinePeliculas {idCine}");
            return new CinePelicula().getList(_db.getRegistros());
        }

        internal dynamic getCineTarifas(int idCine)
        {
            _db.Sentencia($"EXEC sp_getCineTarifas {idCine}");
            return new CineTarifa().getList(_db.getRegistros());
        }

        internal Cine getVerCine(int idCine)
        {
            _db.Sentencia($"EXEC sp_getCine {idCine}");
            Cine cine = new();
            cine.setRegistro(_db.getRegistro());
            return cine;
        }

        internal List<Cine> getVerCines()
        {
            _db.Sentencia($"EXEC sp_getCines");
            return new Cine().getList(_db.getRegistros());
        }
    }
}
