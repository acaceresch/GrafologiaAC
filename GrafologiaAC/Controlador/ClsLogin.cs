using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrafologiaAC.Datos;
namespace GrafologiaAC.Controlador
{
    class ClsLogin
    {
        public ClsConexion objconexion = new ClsConexion();

        public int validar(string usuario, string password)
        {
            objconexion.conectar();
            string consulta = "select count(*) from usuario where usuario='" + usuario + "' and password='" + password + "'";
            return objconexion.contar(consulta);
        }
    }
}
