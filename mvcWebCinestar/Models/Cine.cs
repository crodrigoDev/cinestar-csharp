
using Microsoft.Identity.Client;
using System.Reflection.Metadata.Ecma335;

namespace mvcWebCinestar.Models
{
    public class Cine
    {
        public int idCine { get; set; }
        public string RazonSocial { get; set; }
        public int Salas { get; set; }
        public int idDistrito { get; set; }
        public string Direccion { get; set; }
        public string Telefonos { get; set; }
        public string Detalle { get; set; }
        public bool Valido { get; set; }

        public Cine() { }

        public Cine(string[] aRegistro)
        {
            setRegistro(aRegistro);
        }

        internal void setRegistro(string[] aRegistro)
        {
            Valido = aRegistro != null;

            if (!Valido) return;

            idCine = int.Parse(aRegistro[0]);
            RazonSocial = aRegistro[1];
            Salas = int.Parse(aRegistro[2]);
            idDistrito = int.Parse(aRegistro[3]);
            Direccion = aRegistro[4];
            Telefonos = aRegistro[5];
            Detalle = aRegistro[6];
        }
        internal List<Cine> getList(string[][] mRegistros)
        {
            if (mRegistros == null) return new List<Cine>();
            List<Cine> lstCine = new List<Cine>();
            foreach (string[] aRegistro in mRegistros)
                lstCine.Add(new Cine(aRegistro));

            return lstCine;
        }
    }
}
