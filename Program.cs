using Dapper;
using DapperE.Entidad;
using DapperE.Servicio;
using ConexBD;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;

//Listar todos los registros 
var u1 = ServicioCons.ListadoUsuarios();
Console.WriteLine("ID    NOMBRE        EDAD   ESTADO");
Console.WriteLine("_________________________________");
foreach (var claseS in u1)
{
    Console.WriteLine($"{claseS.Id}    {claseS.Nombre}     {claseS.Edad}     {claseS.Estado}");
}

//Buscar un registro por id
//var consultaID = ServicioCons.ConsultaUsuariosId(5);
//Console.WriteLine($"El registro se llama {consultaID.Nombre}{consultaID.Id}");

//Insertar un registro en la base de datos
/*var nUsuario = new ClaseS()
{ 
    Id = 8,
    Nombre = "Agustina",
    Edad = 31,
    Estado = "activa",
};
ServicioCons.CrearUsuario(nUsuario);*/

//Actualizar un registro en la base de datos
//ServicioCons.ModifUsuarios("Agustina",31,"activo");

//Borrar registro de base de datos!
//ServicioCons.BorrarUsuarios("Ana");


Console.ReadKey();