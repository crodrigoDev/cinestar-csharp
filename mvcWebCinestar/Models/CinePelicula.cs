namespace mvcWebCinestar.Models
{
    public class CinePelicula
    {
        public string Titulos { get; set; }
        public string Horarios { get; set; }

        public CinePelicula() { }
        public CinePelicula(string titulo, string horarios) 
        {
            this.Titulos = titulo;
            this.Horarios = horarios;
        }
        internal dynamic getList(string[][] mRegistros)
        {
            if (mRegistros == null) return null;

            List<CinePelicula> lstLista = new List<CinePelicula>();
            foreach (string[] aRegistro in mRegistros)
                lstLista.Add(new CinePelicula(aRegistro[0], aRegistro[1]));
            return lstLista;
        }
    }
}
