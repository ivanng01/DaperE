using Dapper;
using DapperE.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ConexBD;

namespace DapperE.Servicio
{
    public class ServicioCons
    {
        public static List<ClaseS>ListadoUsuarios()
        {
            ConBD conexion = new ConBD();
            //SQL que ejecutara Dapper, aquí puedes jugar con los orders que quieras.
            string sql = @"SELECT [Id]
                              ,[Nombre]
                              ,[Edad]
                              ,[Estado]
                          FROM [Users] 
                          WHERE [Estado] = 'activo'
                          ORDER BY Nombre";

            //Iniciar la conexión con la base de datos
            var db = (conexion.AbrirConexion());

            //Ejecutar la consulta SQL y almacenar las líneas en nuestro modelo. 
            var marks = db.Query<ClaseS>(sql);

            //Dapper devuelve un IEnumerable para trabajar más cómodos lo convertimos a listas. 
            return marks.ToList();
        }

        public static ClaseS ConsultaUsuariosId(int id)
        {
            ConBD conexion = new ConBD();
            //En este caso tenemos que introducir un parametro para el Id,
            //NUNCA concatenes directamente la variable en el SQL porque puedes padecer inyecciones SQL
            string sql = @"SELECT [Id]
                              ,[Nombre]
                              ,[Edad]
                              ,[Estado]
                          FROM [Users] 
                          WHERE Id = @id";

            //Iniciar la conexión con la base de datos
            var db = conexion.AbrirConexion();

            //Ejecutar la consulta SQL y pasar los parametros en un objeto, como id se llama igual
            //en la variable que en el parametro no hace falta escribir id = id. 
            //Agregamos first para que solo nos devuelva una línea (obviamente solo va a haber una al buscar por id)
            var mark = db.QueryFirst<ClaseS>(sql, new { id });

            //Devolvemos el objeto.
            return mark;
        }


        public static void CrearUsuario(ClaseS us1)
        {
            ConBD conexion = new ConBD();
            //Generamos la consulta con sus correspondientes parametros, agregamos
            //OUTPUT para que nos devuelva el id del registro insertado.
            string sql = @"INSERT INTO [Users] ([Id], [Nombre], [Edad], [Estado])
                            
                           VALUES (@id, @nombre, @edad, @estado);";

            //Iniciar la conexión con la base de datos
            var db = conexion.AbrirConexion();

            //Mapeamos los parametros y ejecutamos la consulta.
            db.Query(sql, new
            {
                id = us1.Id,
                nombre = us1.Nombre,
                edad = us1.Edad,
                estado = us1.Estado,
            });

        }

        public static void ModifUsuarios(string nombre, byte edad, string estado)
        {
            ConBD conexion = new ConBD();
            //Console.WriteLine($"Actualizar EDAD del empleado {nombre}");
            //string sqlquery = "UPDATE Users SET Edad = @edad,  WHERE Nombre = @nombre";
            //Generamos la consulta con sus correspondientes parametros
            string sql = @"UPDATE [Users] 
                           SET
                                [Edad] = @edad,
                                [Estado] = @estado
                                   
                           WHERE 
                                [Nombre] = @nombre";

            //Iniciar la conexión con la base de datos
            var db = conexion.AbrirConexion();

            //Mapeamos los parametros y ejecutamos la consulta.
            db.Query(sql, new { nombre, edad, estado });

        }


        public static void BorrarUsuarios(string nombre)
        {
            ConBD conexion = new ConBD();
            //Generamos la consulta con sus correspondientes parametros
            //string sql = @"DELETE FROM [Users]       
            //               WHERE [Id] = @id";
            string sql = @"UPDATE [Users] 
                           SET
                                
                                [Estado] = 'inactivo'
                                   
                           WHERE 
                                [Nombre] = @nombre";

            //Iniciar la conexión con la base de datos
            var db = conexion.AbrirConexion();

            //Mapeamos los parametros y ejecutamos la consulta.
            db.Query(sql, new { nombre });
            Console.WriteLine("ID Borrado OK");
        }


    }
}