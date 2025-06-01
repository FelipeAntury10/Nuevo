using lib_aplicaciones.Interfaces;
using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class PujasAplicacion : IPujasAplicacion
    {
        private IConexion? IConexion = null;

        public PujasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Pujas? Guardar(Pujas? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID != 0)
                throw new Exception("Esta puja ya fue guardada");

            this.IConexion!.Pujas!.Add(entidad);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Pujas? Modificar(Pujas? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID == 0)
                throw new Exception("Esta puja no existe para modificar");

            var entry = this.IConexion!.Entry<Pujas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Pujas? Borrar(Pujas? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID == 0)
                throw new Exception("La puja no fue guardado");

            this.IConexion!.Pujas!.Remove(entidad);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public List<Pujas> Listar()
        {
            return this.IConexion!.Pujas!.Take(20).ToList();
        }

        public List<Pujas> PorNombre(Pujas? entidad)
        {
            return this.IConexion!.Pujas!
                .Where(x => x.SubastasID == entidad!.SubastasID)
                .ToList();
        }
    }
}