using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface ISubastasAplicacion
    {
        void Configurar(string StringConexion);
        List<Subastas> PorNombre(Subastas? entidad);
        List<Subastas> Listar();
        Subastas? Guardar(Subastas? entidad);
        Subastas? Modificar(Subastas? entidad);
        Subastas? Borrar(Subastas? entidad);
    }
}
