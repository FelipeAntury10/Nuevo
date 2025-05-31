
using Lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Categorias Categoria()
        {
            return new Categorias
            {
                Nombre = "Tecnología"
            };
        }

        public static Clientes Cliente()
        {
            return new Clientes
            {
                Nombre = "Carlos Ruiz",
                Email = "carlosruiz@test.com",
                Telefono = "3201234567"
            };
        }

        public static Estados Estado()
        {
            return new Estados
            {
                Nombre = "Activo"
            };
        }

        public static MetodosPagos MetodoPago()
        {
            return new MetodosPagos
            {
                Nombre = "Nequi"
            };
        }

        public static Pagos Pago()
        {
            return new Pagos
            {
                ClientesID = 1,
                MetodosPagosID = 1,
                Monto = 85000,
                Fecha = DateTime.Now
            };
        }

        public static Productos Producto()
        {
            return new Productos
            {
                Nombre = "Silla de Oficina",
                PrecioInicial = 150000,
                Stock = 12,
                CategoriasID = 1,
                VendedoresID = 1
            };
        }

        public static Pujas Puja()
        {
            return new Pujas
            {
                ClientesID = 1,
                SubastasID = 1,
                Monto = 95000,
                Fecha = DateTime.Now
            };
        }

        public static Subastas Subasta()
        {
            return new Subastas
            {
                ProductosID = 1,
                FechaInicio = DateTime.Now,
                FechaFin = DateTime.Now.AddDays(7),
                ValorIncial = 50000
            };
        }

        public static Vendedores Vendedor()
        {
            return new Vendedores
            {
                Nombre = "Diana López",
                Email = "diana@test.com",
                Telefono = "3107654321"
            };
        }
    }
}
