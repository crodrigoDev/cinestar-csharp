using Microsoft.Data.SqlClient;
using System.Data;

namespace mvcWebCinestar.Controllers.bd
{
    public class clsBD
    {
        private readonly string _cadenaConexion;
        private string _query = "";

        public clsBD(IConfiguration configuration)
        {
            _cadenaConexion = configuration.GetConnectionString("AzureConnection");
        }

        internal void Sentencia(string query)
        {
            _query = query;
        }

        internal DataTable getDataTable()
        {
            DataTable dt = new DataTable();
            if (string.IsNullOrEmpty(_query)) {
                return dt;
            }

            using SqlConnection cn = new SqlConnection(_cadenaConexion);
            using SqlCommand cmd = new SqlCommand(_query, cn);
            cmd.CommandTimeout = 200;
            using SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        internal string[] getRegistro()
        {
            DataTable dt = getDataTable();
            if (dt.Rows.Count == 0) return null;

            return System.Array.ConvertAll(dt.Rows[0].ItemArray, x => x?.ToString().Trim() ?? "");
        }

        internal string[][] getRegistros()
        {
            DataTable dt = getDataTable();
            if (dt.Rows.Count == 0) return null;
            int i = 0;
            string[][] mRegistros = new string[dt.Rows.Count][];
            foreach (DataRow dr in dt.Rows)
            {
                mRegistros[i++] = System.Array.ConvertAll(dr.ItemArray, x => x?.ToString().Trim() ?? "");
            }
            return mRegistros;
        }
    }
}
