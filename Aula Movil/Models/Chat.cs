using System;

namespace Aula_Movil
{
    class Chat
    {
        public string nombre { set; get; }
        public string apellido { set; get; }
        public string texto { set; get; }

        public List<Chat> parseAsignacion(String respuesta)
        {
            return (new JavaScriptSerializer()).Deserialize<List<Chat>>(respuesta);
        }
    }
}