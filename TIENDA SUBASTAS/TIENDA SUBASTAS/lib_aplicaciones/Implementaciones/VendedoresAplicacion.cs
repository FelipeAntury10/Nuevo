using lib_aplicaciones.Interfaces;
using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class VendedoresAplicacion : IVendedoresAplicacion
    {
        private IConexion? IConexion = null;

        public VendedoresAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Vendedores? Guardar(Vendedores? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID != 0)
                throw new Exception("El vendedor ya fue guardado");

            this.IConexion!.Vendedores!.Add(entidad);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Vendedores? Modificar(Vendedores? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID == 0)
                throw new Exception("El vendedor no existe para modificar");

            var entry = this.IConexion!.Entry<Vendedores>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Vendedores? Borrar(Vendedores? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID == 0)
                throw new Exception("El vendedor no fue guardado");

            this.IConexion!.Vendedores!.Remove(entidad);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public List<Vendedores> Listar()
        {
            return this.IConexion!.Vendedores!.Take(20).ToList();
        }

        public List<Vendedores> PorNombre(Vendedores? entidad)
        {
            return this.IConexion!.Vendedores!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .ToList();
        }
    }
}