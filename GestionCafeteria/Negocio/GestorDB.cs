using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace GestionCafeteria.Negocio
{
     internal class GestorDB
    {
        
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = ..\\..\\..\\Datos\\DBCafeteria.accdb;Persist Security Info=True");

        public void PruebaDeConexion(int id)
        {
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "SELECT i.NombreIngrediente," +
                " ip.cantidadIngrediente * i.Cantidad AS cantidad," +
                " i.UnidadMedida " +
                "FROM (IngredientesProducto ip " +
                "INNER JOIN Ingrediente i ON ip.IdIngrediente = i.IdIngrediente)" +
                "WHERE        (ip.IdProducto = "+id+")";
            cmd.Connection = con;
            //cmd.ExecuteNonQuery();
            OleDbDataReader result= cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(result);
            //cmd.ExecuteScalar();
            con.Close();
        }
        public DataTable QueryReader(string query)
        {
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = query;
            cmd.Connection = con;
            //cmd.ExecuteNonQuery();
            OleDbDataReader result = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(result);
            //cmd.ExecuteScalar();
            con.Close();
            return dt;

        }
        public int QueryNonQuery(string query)
        {
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = query;
            cmd.Connection = con;
            //cmd.ExecuteNonQuery();
            int result = cmd.ExecuteNonQuery();
            
            //cmd.ExecuteScalar();
            con.Close();

            return result;
        }
        public object QueryScalar(string query)
        {
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = query;
            cmd.Connection = con;
            var result = cmd.ExecuteScalar();
            con.Close();
            return result;
        }





    }
}
