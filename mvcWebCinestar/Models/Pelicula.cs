
namespace mvcWebCinestar.Models
{
    public class Pelicula
    {
        public int idPelicula { get; set; }
        public string Titulo { get; set; }
        public string FechaEstreno { get; set; }
        public string Director { get; set; }
        public string Generos { get; set; }
        public int idClasificacion { get; set; }
        public int idEstado { get; set; }
        public string Duracion { get; set; }
        public string Link { get; set; }
        public string Reparto { get; set; }
        public string Sipnosis { get; set; }
        public string Geneross { get; set; }
        public bool Valido { get; set; }

        public Pelicula() { }

        public Pelicula(string[] aRegistro)
        {
            setRegistro(aRegistro);
        }

        internal void setRegistro(string[] aRegistro)
        {
            Valido = aRegistro != null;
            if (!Valido) return;

            idPelicula = int.Parse(aRegistro[0]);
            Titulo = aRegistro[1];
            if(aRegistro.Length == 4)
            {
                Link = aRegistro[2];
                Sipnosis = aRegistro[3];
            }
            else
            {
                FechaEstreno = aRegistro[2];
                Director = aRegistro[3];
                Generos = aRegistro[4];
                idClasificacion = int.Parse(aRegistro[5]);
                idEstado = int.Parse(aRegistro[6]);
                Duracion = aRegistro[7];
                Link = aRegistro[8];
                Reparto  = aRegistro[9];
                Sipnosis = aRegistro[10];
                Geneross = aRegistro[11];
            }
        }

        internal List<Pelicula> getList(string[][] mRegistros)
        {
            if (mRegistros == null) return new List<Pelicula>();
            List<Pelicula> lstPelicula = new List<Pelicula>();
            foreach (string[] aRegistro in mRegistros)
                lstPelicula.Add(new Pelicula(aRegistro));
            return lstPelicula;
        }

        
    }
}
