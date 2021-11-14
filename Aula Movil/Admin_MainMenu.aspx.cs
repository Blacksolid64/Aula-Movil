using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;


namespace Aula_Movil
{
    public partial class Admin_MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.verMaestros();
            }
        }

        private void populateGridview()
        {
            string apiURL = Application["apiURL"].ToString() + "profesores"; // Definición de la URL para el request
            WebClient client = new WebClient();
            string apiResponse = client.DownloadString(apiURL);
            GridView1.DataSource = (new JavaScriptSerializer()).Deserialize<List<Usuario>>(apiResponse);
            GridView1.DataBind();
        }

        protected void Gr1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.populateGridview();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            this.populateGridview();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string cedulaOriginal = (row.FindControl("lbl_OrigCed") as Label).Text;
            string cedula = (row.FindControl("txt_cedula") as TextBox).Text;
            string nombre = (row.FindControl("txt_nombre") as TextBox).Text;
            string apellido = (row.FindControl("txt_Apellido") as TextBox).Text;
            string correo = (row.FindControl("txt_correo") as TextBox).Text;
            string contrasenna = (row.FindControl("txt_contrasenna") as TextBox).Text;
            string apiURL = Application["apiURL"].ToString() + "updateDocente/";
            apiURL = apiURL + cedulaOriginal + "/" + cedula + "/" + nombre + "/" + correo + "/" + contrasenna + "/" + apellido;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
            GridView1.EditIndex = -1;
            this.populateGridview();
        }

        private void verMaestros()
        {
            string apiURL = Application["apiURL"].ToString() + "profesores";
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
            GridView1.DataSource = (new JavaScriptSerializer()).Deserialize<List<Usuario>>(apiResponse);
            GridView1.DataBind();

        }

        protected void agregarMaestros(object sender, EventArgs e)
        {
            string apiURL = Application["apiURL"].ToString() + "nuevoDocente/";
            string ced = txt_nuevaCedula.Text;
            string nom = txt_nuevoNombre.Text;
            string cor = txt_nuevoCorreo.Text;
            string con = txt_nuevaContrasenna.Text;
            string ape = txt_nuevoApellido.Text;
            apiURL = apiURL + ced + "/" + nom + "/" + cor + "/" + con + "/" + ape;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
            txt_nuevaCedula.Text = "";
            txt_nuevoNombre.Text = "";
            txt_nuevoCorreo.Text = "";
            txt_nuevaContrasenna.Text = "";
            txt_nuevoApellido.Text = "";
            this.populateGridview();

        }

        protected void editarMaestros(object sender, GridViewUpdateEventArgs e)
        { //Edición de maestros
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string cedulaOriginal = (row.FindControl("lbl_OrigCed") as Label).Text;
            string cedula = (row.FindControl("txt_cedula") as TextBox).Text;
            string nombre = (row.FindControl("txt_nombre") as TextBox).Text;
            string apellido = (row.FindControl("txt_Apellido") as TextBox).Text;
            string correo = (row.FindControl("txt_correo") as TextBox).Text;
            string contrasenna = (row.FindControl("txt_contrasenna") as TextBox).Text;
            string apiURL = Application["apiURL"].ToString() + "updateDocente/";
            apiURL = apiURL + cedulaOriginal + "/" + cedula + "/" + nombre + "/" + correo + "/" + contrasenna + "/" + apellido;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
            GridView1.EditIndex = -1;
            this.populateGridview();
        }

        protected void eliminarMaestros(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string apiURL = Application["apiURL"].ToString() + "elimDocente/";
            string ced = (row.FindControl("lbl_OrigCed") as Label).Text;
            apiURL = apiURL + ced;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
            this.populateGridview();
        }

        protected void cursosXProfesor(object sender, GridViewEditEventArgs e)
        {
            //GridViewRow row = GridView1.Rows[e.RowIndex];
            string apiURL = Application["apiURL"].ToString() + "cursos/profesor/";
            //string correo = (row.FindControl() as Label).Text; //correo del profesor
            //apiURL = apiURL + correo;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

        protected void profesorXcurso(object sender, GridViewEditEventArgs e)
        {
            //GridViewRow row = GridView1.Rows[e.RowIndex];
            string apiURL = Application["apiURL"].ToString() + "profesoresCur/";
            //string codigo = (row.FindControl() as Label).Text; //codigo del curso
            //string grado = (row.FindControl() as Label).Text; //grado del curso
            // apiURL = apiURL + codigo + "/" + clase;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

        protected void estudiantesXcursos(object sender, GridViewEditEventArgs e)
        {
            //GridViewRow row = GridView1.Rows[e.RowIndex];
            string apiURL = Application["apiURL"].ToString() + "estudiantesCur/";
            //string codigo = (row.FindControl() as Label).Text; //codigo del curso
            //string grado = (row.FindControl() as Label).Text; //grado del curso
            //apiURL = apiURL + codigo + "/" + clase;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

        protected void nuevaTarea(object sender, GridViewEditEventArgs e)
        {
            //GridViewRow row = GridView1.Rows[e.RowIndex];
            string apiURL = Application["apiURL"].ToString() + "nuevaTarea/";
            //string codigo = (row.FindControl() as Label).Text; //codigo del curso
            //string grado = (row.FindControl() as Label).Text; //grado del curso
            //string codigoTarea = (row.FindControl() as Label).Text; //codigo de la tarea
            //string titulo = (row.FindControl() as Label).Text; //titulo de la tarea
            //string contenido = (row.FindControl() as Label).Text;
            //string fechaEntrega = (row.FindControl() as Label).Text;
            //apiURL = apiURL + codigo + +grado + +codigoTarea + +titulo + +contenido + +fechaEntrega;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

        protected void nuevaNoticia(object sender, GridViewEditEventArgs e)
        {
            //GridViewRow row = GridView1.Rows[e.RowIndex];
            string apiURL = Application["apiURL"].ToString() + "nuevaNoticia/";
            //string codigo = (row.FindControl() as Label).Text; //codigo del curso
            //string grado = (row.FindControl() as Label).Text; //grado del curso
            //apiURL = apiURL + codigo + +grado;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

        protected void verTareas(object sender, GridViewEditEventArgs e)
        {
            //GridViewRow row = GridView1.Rows[e.RowIndex];
            string apiURL = Application["apiURL"].ToString() + "tareas/";
            //string codigo = (row.FindControl() as Label).Text; //codigo del curso
            //string grado = (row.FindControl() as Label).Text; //grado del curso
            //apiURL = apiURL + codigo + +grado;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

        protected void verNoticias(object sender, GridViewEditEventArgs e)
        {
            //GridViewRow row = GridView1.Rows[e.RowIndex];
            string apiURL = Application["apiURL"].ToString() + "noticias/";
            //string codigo = (row.FindControl() as Label).Text; //codigo del curso
            //string grado = (row.FindControl() as Label).Text; //grado del curso
            //string titulo = (row.FindControl() as Label).Text; //titulo de la tarea
            //string contenido = (row.FindControl() as Label).Text;
            //string fechaEntrega = (row.FindControl() as Label).Text;
            //apiURL = apiURL + codigo + +grado + +titulo + +contenido + +fechaEntrega;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

        protected void verChat(object sender, GridViewEditEventArgs e)
        {
            //GridViewRow row = GridView1.Rows[e.RowIndex];
            string apiURL = Application["apiURL"].ToString() + "chat/";
            //string codigo = (row.FindControl() as Label).Text; //codigo del curso
            //string grado = (row.FindControl() as Label).Text; //grado del curso
            //apiURL = apiURL + codigo + +grado;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

        protected void publicarMensaje(object sender, GridViewEditEventArgs e)
        {
            //GridViewRow row = GridView1.Rows[e.RowIndex];
            string apiURL = Application["apiURL"].ToString() + "publicaMsg/";
            //string codigo = (row.FindControl() as Label).Text; //codigo del curso
            //string grado = (row.FindControl() as Label).Text; //grado del curso
            //string correo = (row.FindControl() as Label).Text; //correo del escritor
            //string mensaje = (row.FindControl() as Label).Text; //mensaje para el chat
            //apiURL = apiURL + codigo + +grado + +correo + +mensaje;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

        protected void calificarDocente(object sender, GridViewEditEventArgs e)
        {
            //GridViewRow row = GridView1.Rows[e.RowIndex];
            string apiURL = Application["apiURL"].ToString() + "votarNota/";
            //string cedula = (row.FindControl() as Label).Text;// cedula del maestro
            //string nota = (row.FindControl() as Label).Text; //nota nueva
            //apiURL = apiURL + codigo + +grado;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

    }
}