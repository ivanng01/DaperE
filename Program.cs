using Dapper;
using DapperE.Entidades;
using DapperE.Servicios;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;

Console.WriteLine("Listado del Registro Usuarios");
var p1 = UsuariosCons.GetListado();
 foreach (var p in p1)
 {
     Console.WriteLine($"{p.Id} {p.Nombre} {p.Edad}");
 }

Console.WriteLine("**************************");

Console.WriteLine("Buscar Registro por ID");
var personaId = UsuariosCons.GetId(3);
    Console.WriteLine($"El registro se llama {personaId.Nombre} tiene {personaId.Edad} años");

Console.ReadKey();

