using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula_Movil
{
    public partial class Profesor_NoticiasMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    this.verNoticias();
                }
                catch (Exception ex)
                {
                    Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
                }
            }
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

        protected void agregarNoticia(object sender, EventArgs e)
        {
            try
            {
                string apiURL = Application["apiURL"].ToString() + "nuevaNoticia/";
                string codigo = Session["codigo"].ToString(); //codigo del curso
                string grado = Session["clase"].ToString(); //grado del curso
                string titulo = txt_nuevoTitulo.Text;
                string descripcion = txt_nuevaDecripcion.Text;
                string fecha = txt_nuevaFecha.Text;
                apiURL = apiURL + codigo + "/" + grado + "/" + titulo + "/" + descripcion + "/" + fecha;
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                this.verNoticias();
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }
    }
}