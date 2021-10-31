using System;

namespace Aula_Movil
{
    class Usuario
    {
        public string nombre { set; get; }
        public string apellido { set; get; }
        public string contrasenna { set; get; }
        public string cedula { set; get; }
        public string correo { set; get; }
        public string calificacion { set; get; }

        public List<Usuario> parseUsuario(String respuesta)
        {
            return (new JavaScriptSerializer()).Deserialize<List<Usuario>>(respuesta);
        }
    }
}