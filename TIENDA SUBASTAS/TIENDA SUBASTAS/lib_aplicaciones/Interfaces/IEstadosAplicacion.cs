using Lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IEstadosAplicacion
    {
        void Configurar(string StringConexion);
        List<Estados> PorNombre(Estados? entidad);
        List<Estados> Listar();
        Estados? Guardar(Estados? entidad);
        Estados? Modificar(Estados? entidad);
        Estados? Borrar(Estados? entidad);
    }
}
