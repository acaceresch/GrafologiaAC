using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrafologiaAC.Datos;
using System.IO;

namespace GrafologiaAC.Controlador
{
    class ClsMantenimiento
    {
        ClsConexion objconexion = new ClsConexion();
        public System.Data.DataSet llenardatagrid(int letra, string bus)
        {
            objconexion.conectar();

            string consulta = "select v.id,l.nombre,v.peso,v.imagen from letra l, variantes v where l.id=v.idletra and l.id=" + letra + " and v.referencia like '%" + bus + "%'";

            return objconexion.llenardg(consulta, "letra");
        }

        public System.Data.DataTable llenarcombo()
        {
            objconexion.conectar();
            string consulta = "select * from letra";

            return objconexion.llenarcombo(consulta, "letra");
        }
        public Boolean insertar(int letra, string referencia, Byte[] imagen, int peso)
        {
            return objconexion.insertarvariante(letra,referencia,imagen,peso);
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        public Boolean eliminarvariante(int id)
        {
            objconexion.conectar();
            string consulta = "delete from variantes where id=" + id;
            return objconexion.ejecutarquery(consulta);

        }
        public Boolean actualizar(int id,int letra, string referencia, Byte[] imagen, int peso)
        {
            return objconexion.actualizarvariante(id, letra, referencia, imagen, peso);
        }
    }
}
