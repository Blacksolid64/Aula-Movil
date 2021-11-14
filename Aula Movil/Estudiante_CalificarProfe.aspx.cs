using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula_Movil
{
    public partial class Estudiante_CalificarProfe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.profesorXcurso();
            }
        }

        protected void profesorXcurso()
        {
            string apiURL = Application["apiURL"].ToString() + "profesoresCur/";
            string codigo = Session["codigo"].ToString(); //codigo del curso
            string grado = Session["clase"].ToString(); //grado del curso
            apiURL = apiURL + codigo + "/" + grado;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
            GR_Cal.DataSource = (new JavaScriptSerializer()).Deserialize<List<Usuario>>(apiResponse);
            GR_Cal.DataBind();
        }

        protected void calificarDocente(object sender, EventArgs e)
        {
    
            string apiURL = Application["apiURL"].ToString() + "votarNota/";
            string cedula = (GR_Cal.Rows[0].FindControl("lbl_Cedula") as Label).Text;// cedula del maestro
            string nota = txt_nuevaCalificacion.Text; //nota nueva
            apiURL = apiURL + cedula + "/" + nota;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
            this.profesorXcurso();
        }
    }
}