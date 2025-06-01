using lib_aplicaciones.Interfaces;
using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class CategoriasAplicacion : ICategoriasAplicacion
    {
        private IConexion? IConexion = null;

        public CategoriasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Categorias? Guardar(Categorias? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID != 0)
                throw new Exception("La categoría ya fue guardada");

            this.IConexion!.Categorias!.Add(entidad);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Categorias? Modificar(Categorias? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID == 0)
                throw new Exception("La categoría no existe para modificar");

            var entry = this.IConexion!.Entry<Categorias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Categorias? Borrar(Categorias? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID == 0)
                throw new Exception("La categoría no fue guardada");

            this.IConexion!.Categorias!.Remove(entidad);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public List<Categorias> Listar()
        {
            return this.IConexion!.Categorias!.Take(20).ToList();
        }

        public List<Categorias> PorNombre(Categorias? entidad)
        {
            return this.IConexion!.Categorias!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .ToList();
        }
    }
}
