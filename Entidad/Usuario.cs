using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperE.Entidad
{
    public class Usuario
    {
        public Usuario(int Id, string Nombre, int Edad, string Estado)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Edad = Edad;
            this.Estado = Estado;
        }
        public int Id { get; set; }
        public string Nombre { get; set; } = String.Empty;
        public int Edad { get; set; }
        public string Estado { get; set; } = String.Empty;        
    }
}

