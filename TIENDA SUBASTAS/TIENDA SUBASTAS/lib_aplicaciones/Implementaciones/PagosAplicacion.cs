using lib_aplicaciones.Interfaces;
using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class PagosAplicacion : IPagosAplicacion
    {
        private IConexion? IConexion = null;

        public PagosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Pagos? Guardar(Pagos? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID != 0)
                throw new Exception("El pago ya fue guardado");

            this.IConexion!.Pagos!.Add(entidad);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Pagos? Modificar(Pagos? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID == 0)
                throw new Exception("El pago no existe para modificar");

            var entry = this.IConexion!.Entry<Pagos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Pagos? Borrar(Pagos? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.ID == 0)
                throw new Exception("El pago no fue guardado");

            this.IConexion!.Pagos!.Remove(entidad);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public List<Pagos> Listar()
        {
            return this.IConexion!.Pagos!.Take(20).ToList();
        }

        public List<Pagos> PorNombre(Pagos? entidad)
        {
            return this.IConexion!.Pagos!
                .Where(x => x.Referencia!.Contains(entidad!.Referencia!))
                .ToList();
        }
    }
}
