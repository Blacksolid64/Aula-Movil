using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Aula_Movil
{
    public class Noticia
    {
        public string titulo { set; get; }
        public string descripcion { set; get; }
        public string fecha { set; get; }

        public List<Noticia> parseAsignacion(String respuesta)
        {
            return (new JavaScriptSerializer()).Deserialize<List<Noticia>>(respuesta);
        }
    }
}