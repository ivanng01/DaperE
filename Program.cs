using Dapper;
using DapperE.Entidad;
using ConexBD;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using DapperE;
using System.Text.RegularExpressions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Autofac;

UsuarioDao datosUsuarios = new UsuarioDao();

//Listar todos los registros
//datosUsuarios.GetListadoUsuarios();

//Buscar un registro por id
//var consultaID = datosUsuarios.ConsultaUsuariosId(7);
//Console.WriteLine($"El registro con ID {consultaID.Id} se llama {consultaID.Nombre} tiene {consultaID.Edad} años y su estado es: {consultaID.Estado}");

//Insertar un registro en la base de datos
//var nUsuario = new Usuario(8, "Jose", 50, "activo");
/*{
    Id = 8,
    Nombre = "Jose",
    Edad = 50,
    Estado = "activo",
};*/
//datosUsuarios.CrearUsuario(nUsuario);

//Actualizar un registro en la base de datos
//datosUsuarios.ModifUsuarios("Agustina",33,"activo");

//Borrar registro de base de datos!
//datosUsuarios.BorrarUsuario("Ana");


//UsuarioManager um1 = new UsuarioManager();
//um1.ListadoPorEdad();


var builder = new ContainerBuilder();
builder.RegisterType<UsuarioManager>().As<IUDao>();
var container = builder.Build();
var cons=container.Resolve<IUDao>().ConsultaUsuariosId(3);
//Console.WriteLine($"Registro con ID {cons.Id}, Nombre: {cons.Nombre}");
//container.Resolve<IUDao>().ModifUsuarios("Jose",103,"inactivo");
container.Resolve<IUDao>().GetListadoUsuarios();

Console.ReadLine();