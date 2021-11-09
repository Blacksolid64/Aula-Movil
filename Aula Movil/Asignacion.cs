using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;


namespace Aula_Movil
{
    class Asignacion
    {
        public string titulo { set; get; }
        public string clase { set; get; }
        public string descripcion { set; get; }
        public string codigo { set; get; }
        public string fecha { set; get; }

        public List<Asignacion> parseAsignacion(String respuesta)
        {
            return (new JavaScriptSerializer()).Deserialize<List<Asignacion>>(respuesta);
        }
    }
}