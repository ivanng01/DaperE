using Azure;
using Dapper;
using DapperE.Entidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperE
{
    public class UsuarioManager : UsuarioDao
    {
        public void ListadoPorEdad()
        {
            string connection = @"Server=localhost;Port=3306;Database=usuarios;Uid=root;Pwd=ivandg01";
            using (var db = new MySqlConnection(connection))
            {
                var sql = @"SELECT Id,Nombre,Edad,Estado 
                          FROM usuarios AS u1 WHERE u1.Estado = 'activo'";
                var marks = db.Query<Usuario>(sql).ToList();

                var pp=marks.OrderBy(x => x.Edad).ToList();

                Console.WriteLine("Listado de Usuarios Activos Ordenado por Edad");
                foreach (var Usuario in pp)
                {
                    Console.Write($"{Usuario.Nombre}, ");
                }
            }
            Console.WriteLine();
        }

        public IUDao ObjUsuarioManager = null;
        
        //injection through constructor  
        public void NotificationSender(IUDao tmpService)
        {
            ObjUsuarioManager = tmpService;
        }
        
        //Injection through property  
        public IUDao SetUsuarioManager
        {
            set { ObjUsuarioManager = value; }
        }

    }
}

