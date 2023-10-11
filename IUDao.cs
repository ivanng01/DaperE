using DapperE.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperE
{
    public interface IUDao
    {
        //public List<Usuario> GetListadoUsuarios();
        public void GetListadoUsuarios();
        public void CrearUsuario(Usuario usuario);
        public Usuario ConsultaUsuariosId(int id);
        public void ModifUsuarios(string nombre, byte edad, string estado);
        public void BorrarUsuario(string nombre);   
    }
}
