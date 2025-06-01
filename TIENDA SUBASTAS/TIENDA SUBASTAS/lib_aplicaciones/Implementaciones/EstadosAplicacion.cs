using lib_aplicaciones.Interfaces;
using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class EstadosAplicacion : IEstadosAplicacion
    {
        private IConexion? IConexion = null;

        public EstadosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Estados? Guardar(Estados? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID != 0)
                throw new Exception("El estado ya fue guardado");

            this.IConexion!.Estados!.Add(entidad);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Estados? Modificar(Estados? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID == 0)
                throw new Exception("El estado no existe para modificar");

            var entry = this.IConexion!.Entry<Estados>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Estados? Borrar(Estados? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID == 0)
                throw new Exception("El estado no fue guardado");

            this.IConexion!.Estados!.Remove(entidad);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public List<Estados> Listar()
        {
            return this.IConexion!.Estados!.Take(20).ToList();
        }

        public List<Estados> PorNombre(Estados? entidad)
        {
            return this.IConexion!.Estados!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .ToList();
        }
    }
}
