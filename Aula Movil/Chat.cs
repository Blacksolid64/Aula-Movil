using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;


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