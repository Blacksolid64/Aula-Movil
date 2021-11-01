using System;

namespace Aula_Movil
{
    class Curso
    {
        public string nombre { set; get; }
        public string clase { set; get; }
        public string codigo { set; get; }
        public string horaInicio { set; get; }
        public string horaFinal { set; get; }
        public string diaSemana { set; get; }

        public List<Curso> parseCurso(String respuesta)
        {
            return (new JavaScriptSerializer()).Deserialize<List<Curso>>(respuesta);
        }
    }
}