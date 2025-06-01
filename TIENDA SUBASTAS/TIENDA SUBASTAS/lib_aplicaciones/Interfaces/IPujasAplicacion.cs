using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IPujasAplicacion
    {
        void Configurar(string StringConexion);
        List<Pujas> PorNombre(Pujas? entidad);
        List<Pujas> Listar();
        Pujas? Guardar(Pujas? entidad);
        Pujas? Modificar(Pujas? entidad);
        Pujas? Borrar(Pujas? entidad);
    }
}
