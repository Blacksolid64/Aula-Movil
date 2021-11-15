using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula_Movil
{
    public partial class Profesor_TareasMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    this.verTareas();
                }
                catch (Exception ex)
                {
                    Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
                }
            }
        }
        protected void verTareas()
        {

            string apiURL = Application["apiURL"].ToString() + "tareas/";
            string codigo = Session["codigo"].ToString(); //codigo del curso
            string grado = Session["clase"].ToString(); //grado del curso
            apiURL = apiURL + codigo + "/" + grado;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
            GR_tr.DataSource = (new JavaScriptSerializer()).Deserialize<List<Asignacion>>(apiResponse);
            GR_tr.DataBind();
        }
        protected void agregarTarea(object sender, EventArgs e)
        {
            string apiURL = Application["apiURL"].ToString() + "nuevaTarea/";
            string codigo = Session["codigo"].ToString(); //codigo del curso
            string grado = Session["clase"].ToString(); //grado del curso
            string codigoTarea = txt_nuevoCodigo.Text; //codigo de la tarea
            string titulo = txt_nuevoTitulo.Text; //titulo de la tarea
            string contenido = txt_nuevaDecripcion.Text;
            string fechaEntrega = txt_nuevaFecha.Text;
            apiURL = apiURL + codigo + "/" +grado + "/" + codigoTarea + "/" + titulo + "/" + contenido + "/" + fechaEntrega;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
            this.verTareas();
        }
    }
}