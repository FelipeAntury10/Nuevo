using asp_servicios.Nucleo;
using lib_aplicaciones.Interfaces;
using lib_dominio.Nucleo;
using Lib_dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasAplicacion iAplicacion;
        private readonly TokenController tokenController;

        public CategoriasController(ICategoriasAplicacion iAplicacion, TokenController tokenController)
        {
            this.iAplicacion = iAplicacion;
            this.tokenController = tokenController;
        }

        private Dictionary<string, object> ObtenerDatos()
        {
            var datos = new StreamReader(Request.Body).ReadToEnd();
            if (string.IsNullOrEmpty(datos))
                datos = "{}";

            return JsonConversor.ConvertirAObjeto(datos);
        }

        [HttpPost]
        public string Listar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var conexion = Configuracion.ObtenerValor("StringConexion");
                if (string.IsNullOrWhiteSpace(conexion))
                {
                    respuesta["Error"] = "lbCadenaConexionNoDefinida";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                iAplicacion.Configurar(conexion);
                respuesta["Entidades"] = iAplicacion.Listar();
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message;
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Guardar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Categorias>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                var conexion = Configuracion.ObtenerValor("StringConexion");
                if (string.IsNullOrWhiteSpace(conexion))
                {
                    respuesta["Error"] = "lbCadenaConexionNoDefinida";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                iAplicacion.Configurar(conexion);
                entidad = iAplicacion.Guardar(entidad);

                respuesta["Entidad"] = entidad;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message;
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Modificar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Categorias>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                var conexion = Configuracion.ObtenerValor("StringConexion");
                if (string.IsNullOrWhiteSpace(conexion))
                {
                    respuesta["Error"] = "lbCadenaConexionNoDefinida";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                iAplicacion.Configurar(conexion);
                entidad = iAplicacion.Modificar(entidad);

                respuesta["Entidad"] = entidad;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message;
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Borrar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Categorias>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                var conexion = Configuracion.ObtenerValor("StringConexion");
                if (string.IsNullOrWhiteSpace(conexion))
                {
                    respuesta["Error"] = "lbCadenaConexionNoDefinida";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                iAplicacion.Configurar(conexion);
                entidad = iAplicacion.Borrar(entidad);

                respuesta["Entidad"] = entidad;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message;
                return JsonConversor.ConvertirAString(respuesta);
            }
        }
    }
}
