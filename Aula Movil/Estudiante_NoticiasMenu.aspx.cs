using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula_Movil
{
    public partial class Estudiante_NoticiasMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    this.verNoticias();
                }
            }
            catch (Exception ex) { Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString())); }
        }

        protected void verNoticias()
        {

            try
            {
                string apiURL = Application["apiURL"].ToString() + "noticias/";
                string codigo = Session["codigo"].ToString(); //codigo del curso
                string grado = Session["clase"].ToString(); //grado del curso
                apiURL = apiURL + codigo + "/" + grado;
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                GR_nws.DataSource = (new JavaScriptSerializer()).Deserialize<List<Noticia>>(apiResponse);
                GR_nws.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }


    }
}