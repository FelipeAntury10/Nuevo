using lib_aplicaciones.Interfaces;
using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class SubastasAplicacion : ISubastasAplicacion
    {
        private IConexion? IConexion = null;

        public SubastasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Subastas? Guardar(Subastas? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID != 0)
                throw new Exception("Esta subasta ya fue guardada");

            this.IConexion!.Subastas!.Add(entidad);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Subastas? Modificar(Subastas? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID == 0)
                throw new Exception("Esta subasta no existe para modificar");

            var entry = this.IConexion!.Entry<Subastas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Subastas? Borrar(Subastas? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID == 0)
                throw new Exception("La subasta no fue guardada");

            this.IConexion!.Subastas!.Remove(entidad);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public List<Subastas> Listar()
        {
            return this.IConexion!.Subastas!.Take(20).ToList();
        }

        public List<Subastas> PorNombre(Subastas? entidad)
        {
            return this.IConexion!.Subastas!
                .Where(x => x.ProductosID == entidad!.ProductosID)
                .ToList();
        }
    }
}