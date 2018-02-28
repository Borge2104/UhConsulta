using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace WebAppUHConsultas.Models
{

    public class Create_Usuario
    {
        public int id { get; set; }
        public string email { get; set; }
        public int tipo { get; set; }
        //------Contraseña--------------
        private int usuario_id { get; set; }
        public string pass { get; set; }


        public void ingreso()
        {
            SqlConnection cn = new SqlConnection("Data Source = uhclinica.database.windows.net; Initial Catalog = UHConsulta; Integrated Security = False; User ID = db_root; Password = Uhispano2018; Connect Timeout = 60; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            SqlCommand cmd = new SqlCommand();
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            string sql = "";
            sql = "Insert into usuario Values " +
            "(@email,@tipo);"+ "SELECT @id = SCOPE_IDENTITY() FROM usuario";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@email", SqlDbType.VarChar);
            cmd.Parameters.Add("@tipo", SqlDbType.VarChar);
            cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters["@email"].Value = email;
            cmd.Parameters["@tipo"].Value = tipo;
            cmd.ExecuteNonQuery();
            id = (int)cmd.Parameters["@id"].Value;
            cn.Close();
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            sql = "Insert into contraseña(usuario_id,pass) Values " + 
                "(@usuario,@pass)";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@usuario", SqlDbType.Int);
            cmd.Parameters.Add("@pass", SqlDbType.VarChar);
            cmd.Parameters["@usuario"].Value = id;
            cmd.Parameters["@pass"].Value = pass;
            cmd.ExecuteNonQuery();
            cn.Close();

        }
    }
}