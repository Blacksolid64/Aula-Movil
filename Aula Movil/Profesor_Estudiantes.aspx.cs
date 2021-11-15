using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula_Movil
{
    public partial class Profesor_Estudiantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    this.estudiantesXcursos();
                }
                catch (Exception ex)
                {
                    Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
                }
            }
        }

        protected void estudiantesXcursos()
        {
            try
            {
                string apiURL = Application["apiURL"].ToString() + "estudiantesCur/";
                string codigo = Session["codigo"].ToString(); //codigo del curso
                string grado = Session["clase"].ToString(); //grado del curso
                apiURL = apiURL + codigo + "/" + grado;
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                GR_Est.DataSource = (new JavaScriptSerializer()).Deserialize<List<Usuario>>(apiResponse);
                GR_Est.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }
    }
}