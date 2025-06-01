
using Lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IMetodosPagosAplicacion
    {
        void Configurar(string StringConexion);
        List<MetodosPagos> PorNombre(MetodosPagos? entidad);
        List<MetodosPagos> Listar();
        MetodosPagos? Guardar(MetodosPagos? entidad);
        MetodosPagos? Modificar(MetodosPagos? entidad);
        MetodosPagos? Borrar(MetodosPagos? entidad);
    }
}
