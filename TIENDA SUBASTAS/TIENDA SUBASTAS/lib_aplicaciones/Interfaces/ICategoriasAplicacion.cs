
using Lib_dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface ICategoriasAplicacion
    {
        void Configurar(string StringConexion);
        List<Categorias> PorNombre(Categorias? entidad);  // Búsqueda opcional si se requiere
        List<Categorias> Listar();
        Categorias? Guardar(Categorias? entidad);
        Categorias? Modificar(Categorias? entidad);
        Categorias? Borrar(Categorias? entidad);
    }
}
