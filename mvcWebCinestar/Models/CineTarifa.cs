namespace mvcWebCinestar.Models
{
    public class CineTarifa
    {
        public string DiasSemana { get; set; }
        public string Precio { get; set; }
        
        public CineTarifa() { }
        public CineTarifa(string diasSemana, string precio)
        {
            this.DiasSemana = diasSemana;
            this.Precio = precio;
        }
        internal dynamic getList(string[][] mRegistros)
        {
            if (mRegistros == null) return null;

            List<CineTarifa> lstLista = new List<CineTarifa>();
            foreach (string[] aRegistro in mRegistros)
                lstLista.Add(new CineTarifa(aRegistro[0], aRegistro[1]));

            return lstLista;
        }
    }
}
