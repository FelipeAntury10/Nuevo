using lib_aplicaciones.Interfaces;
using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class MetodosPagosAplicacion : IMetodosPagosAplicacion
    {
        private IConexion? IConexion = null;

        public MetodosPagosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public MetodosPagos? Guardar(MetodosPagos? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID != 0)
                throw new Exception("El método de pago ya fue guardado");

            this.IConexion!.MetodosPagos!.Add(entidad);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public MetodosPagos? Modificar(MetodosPagos? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID == 0)
                throw new Exception("El método de pago no existe para modificar");

            var entry = this.IConexion!.Entry<MetodosPagos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();

            return entidad;
        }

        public MetodosPagos? Borrar(MetodosPagos? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID == 0)
                throw new Exception("El método de pago no fue guardado");

            this.IConexion!.MetodosPagos!.Remove(entidad);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public List<MetodosPagos> Listar()
        {
            return this.IConexion!.MetodosPagos!.Take(20).ToList();
        }

        public List<MetodosPagos> PorNombre(MetodosPagos? entidad)
        {
            return this.IConexion!.MetodosPagos!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .ToList();
        }
    }
}
