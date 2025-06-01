
using Lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IClientesAplicacion
    {
        void Configurar(string StringConexion);
        List<Clientes> PorNombre (Clientes? entidad);  // Opción válida si existe por nombre
        List<Clientes> Listar();
        Clientes? Guardar(Clientes? entidad);
        Clientes? Modificar(Clientes? entidad);
        Clientes? Borrar(Clientes? entidad);
    }
}
