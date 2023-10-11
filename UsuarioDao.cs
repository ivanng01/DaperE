using Dapper;
using DapperE.Entidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperE
{
    public class UsuarioDao : IUDao
    {
        public void GetListadoUsuarios()
        {
            //ConexionBD connection = new ConexionBD();
            //using (var db = new MySqlConnection(connection.Abrir()))
            string connection = @"Server=localhost;Port=3306;Database=usuarios;Uid=root;Pwd=ivandg01";
            using (var db = new MySqlConnection(connection))
            {

                //Ejecutar la consulta SQL y almacenar las líneas en nuestro modelo. 

                var sql = @"SELECT Id,Nombre,Edad,Estado 
                          FROM usuarios AS u1 WHERE u1.Estado = 'activo'";
                //var result = db.Query<ClaseS>(sql);
                var marks = db.Query<Usuario>(sql);

                //Dapper devuelve un IEnumerable para trabajar más cómodos lo convertimos a listas. 
                //return marks.ToList();

                var pp = marks.ToList();
                Console.WriteLine("ID    NOMBRE        EDAD   ESTADO");
                Console.WriteLine("___________________________");
                foreach (var Usuario in pp)
                {
                    Console.WriteLine($"{Usuario.Id}    {Usuario.Nombre}         {Usuario.Edad}     {Usuario.Estado} ");
                }
            }
        }

        public Usuario ConsultaUsuariosId(int id)
        {
            //ConexionBD connection = new ConexionBD();
            //using (var db = new MySqlConnection(connection.Abrir()))
            string connection = @"Server=localhost;Port=3306;Database=usuarios;Uid=root;Pwd=ivandg01";
            using (var db = new MySqlConnection(connection))
            {
                //En este caso tenemos que introducir un parametro para el Id,
                //NUNCA concatenes directamente la variable en el SQL porque puedes padecer inyecciones SQL
                var sql = @"SELECT Id,Nombre,Edad,Estado
                          FROM usuarios 
                          WHERE Id = @id";

                //Iniciar la conexión con la base de datos


                //Ejecutar la consulta SQL y pasar los parametros en un objeto, como id se llama igual
                //en la variable que en el parametro no hace falta escribir id = id. 
                //Agregamos first para que solo nos devuelva una línea (obviamente solo va a haber una al buscar por id)
                var mark = db.QueryFirst<Usuario>(sql, new { id });

                //Devolvemos el objeto.
                return mark;
            }
        }

        public void CrearUsuario(Usuario users)
        {
                //ConexionBD connection = new ConexionBD();
                //using (var db = new MySqlConnection(connection.Abrir()))
                string connection = @"Server=localhost;Port=3306;Database=usuarios;Uid=root;Pwd=ivandg01";
                using (var db = new MySqlConnection(connection))
                {
                    var sql = @"INSERT INTO usuarios (Id, Nombre, Edad, Estado)
                            
                           VALUES (@id, @nombre, @edad, @estado);";

                    //Iniciar la conexión con la base de datos


                    //Mapeamos los parametros y ejecutamos la consulta.
                    var result = db.Execute(sql, new
                    {
                        id = users.Id,
                        nombre = users.Nombre,
                        edad = users.Edad,
                        estado = users.Estado,
                    });
                }
                Console.WriteLine("Usuario creado correctamente.");
        }

        public void ModifUsuarios(string nombre, byte edad, string estado)
        {
            //ConexionBD connection = new ConexionBD();
            //using (var db = new MySqlConnection(connection.Abrir()))
            string connection = @"Server=localhost;Port=3306;Database=usuarios;Uid=root;Pwd=ivandg01";
            using (var db = new MySqlConnection(connection))
            {
                string sql = @"UPDATE usuarios 
                           SET
                                Edad = @edad,
                                Estado = @estado
                                   
                           WHERE 
                                Nombre = @nombre";

                //Iniciar la conexión con la base de datos


                //Mapeamos los parametros y ejecutamos la consulta.
                var result = db.Execute(sql, new { nombre, edad, estado });
                Console.WriteLine($"¡{nombre} ha sido modificado correctamente en BD!");
            }
        }

        public void BorrarUsuario(string nombre)
        {
            //ConexionBD connection = new ConexionBD();
            //using (var db = new MySqlConnection(connection.Abrir()))
            string connection = @"Server=localhost;Port=3306;Database=usuarios;Uid=root;Pwd=ivandg01";
            using (var db = new MySqlConnection(connection))
            {
                string sql = @"UPDATE usuarios 
                           SET  
                                Estado = 'inactivo'
                           WHERE 
                                Nombre = @nombre";

                //Mapeamos los parametros y ejecutamos la consulta.
                var results = db.Execute(sql, new { nombre });
                Console.WriteLine($"¡{nombre} ha sido borrado/a exitosamente de BD!");
            }
        }
    }
}
