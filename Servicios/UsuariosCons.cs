using DapperE.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace DapperE.Servicios
{
    public class UsuariosCons
    {
        private static string _conect = @"Data Source=DESKTOP-LD9U44S\SQLEXPRESS;Initial Catalog=Usuarios;Integrated Security=True; TrustServerCertificate=True";
        public static List<Usuarios> GetListado()
        {
            string sql = @"Select * from users 
                          Order by Nombre";
            //Inicio BD
            var db = new SqlConnection(_conect);

            //Ejecuto consulta SQL y almaceno las líneas en modelo. 
            var p1 = db.Query<Usuarios>(sql).ToList();

            return p1;
        }

        public static Usuarios GetId(int Id)
        {
            string sql = @"Select * from users  
                          Where Id = @id";

            var db = new SqlConnection(_conect);

            //Agrego first para que devuelva una sola línea
            var persid = db.QueryFirst<Usuarios>(sql, new { Id });

            //Devuelvo el objeto.
            return persid;
        }
    }
}

