using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafologiaAC.Datos
{
    class ClsConexion
    {
        public string strCon = "";
        public SqlConnection xcon;
        public SqlCommand xcmd;
        public void conectar()
        {
            try
            {
                //strCon= "Data Source=ANTHONY-PC;";
                strCon = "Data Source=(local);";
                //strCon += "Initial Catalog=empresaDB;User ID=sa;Password=shania";
                strCon += "Integrated Security = SSPI; Initial Catalog = empresaDB";
               
                xcon = new SqlConnection(strCon);
                xcon.Open();
            }
            catch (Exception ex)
            { }
        }
        public int contar(string consulta)
        {
            try
            {
                xcmd = new SqlCommand();
                xcmd.Connection = xcon;
                xcmd.CommandText = consulta;
                int rpta = Convert.ToInt32(xcmd.ExecuteScalar());

                return rpta;
            }
            catch (Exception ex)
            { return 0; }

        }
        public System.Data.DataSet llenardg(string consulta, string tabla)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(consulta, xcon);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds, tabla);
                return ds;
            }
            catch (Exception ex)
            { return null; }

        }
        public System.Data.DataTable llenarcombo(string consulta, string tabla)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(consulta, xcon);
                System.Data.DataTable dt = new System.Data.DataTable(tabla);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            { return null; }

        }
        public Boolean insertarvariante(int letra, string referencia, Byte[] imagen, int peso)
        {
            //int letra,string referencia,Byte[] imagen,int peso
            try
            {

                // SqlConnection con = new SqlConnection("Data Source=ANTHONY-PC;Initial Catalog=empresaDB;User ID=sa;Password=shania");
                SqlConnection con = new SqlConnection("Data Source=(local);Integrated Security = SSPI; Initial Catalog = empresaDB");

                SqlCommand com = new SqlCommand("insert into variantes(idletra,referencia,imagen,peso) values(@letra,@referen,@pic,@pes)", con);


                com.Parameters.AddWithValue("@Pic", imagen);
                com.Parameters.AddWithValue("@letra", letra);
                com.Parameters.AddWithValue("@referen", referencia);
                com.Parameters.AddWithValue("@pes", peso);
                con.Open();
                //Ejecuta una instrucción SQL en la conexión y devuelve el número de filas afectadas.
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public Boolean actualizarvariante(int id,int letra, string referencia, Byte[] imagen, int peso)
        {
            //int letra,string referencia,Byte[] imagen,int peso
            try
            {

                //SqlConnection con = new SqlConnection("Data Source=ANTHONY-PC;Initial Catalog=empresaDB;User ID=sa;Password=shania");
                SqlConnection con = new SqlConnection("Data Source=(local);Integrated Security = SSPI; Initial Catalog = empresaDB");
                SqlCommand com = new SqlCommand("update variantes set idletra=@letra, referencia=@referen, imagen=@pic, peso=@pes where id=@id", con);
                //update cultivo set estado = 'DESACTIVADO' where id =

                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@Pic", imagen);
                com.Parameters.AddWithValue("@letra", letra);
                com.Parameters.AddWithValue("@referen", referencia);
                com.Parameters.AddWithValue("@pes", peso);
                con.Open();
                //Ejecuta una instrucción SQL en la conexión y devuelve el número de filas afectadas.
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public Boolean ejecutarquery(string consulta)
        {
            try
            {
                xcmd = new SqlCommand();
                xcmd.Connection = xcon;
                xcmd.CommandText = consulta;
                xcmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            { return false; }

        }
    }
}
