using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula_Movil
{
    public partial class Admin_StudentMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.verEstudiantes();
        }

        protected void verEstudiantes()
        {
            string apiURL = Application["apiURL"].ToString() + "estudiantes";
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
            GR_Students.DataSource = (new JavaScriptSerializer()).Deserialize<List<Usuario>>(apiResponse);
            GR_Students.DataBind();
        }

        protected void GrCourses_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GR_Students.EditIndex = e.NewEditIndex;
            this.verEstudiantes();
        }

        protected void GrCourses_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GR_Students.EditIndex = -1;
            this.verEstudiantes();
        }


        protected void agregarEstdiantes(object sender, EventArgs e)
        {
            string apiURL = Application["apiURL"].ToString() + "nuevoAlumno/";
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
            this.verEstudiantes();
        }

        protected void editarEstdiantes(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GR_Students.Rows[e.RowIndex];
            string apiURL = Application["apiURL"].ToString() + "updateAlumno/";
            string cedulaOriginal = (row.FindControl("lbl_OrigCed") as Label).Text;
            string cedula = (row.FindControl("txt_cedula") as TextBox).Text;
            string nombre = (row.FindControl("txt_nombre") as TextBox).Text;
            string apellido = (row.FindControl("txt_Apellido") as TextBox).Text;
            string correo = (row.FindControl("txt_correo") as TextBox).Text;
            string contrasenna = (row.FindControl("txt_contrasenna") as TextBox).Text;
            apiURL = apiURL + cedulaOriginal + "/" + cedula + "/" + nombre + "/" + correo + "/" + contrasenna + "/" + apellido;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
            GR_Students.EditIndex = -1;
            this.verEstudiantes();
        }

        protected void eliminarEstdiantes(object sender, GridViewEditEventArgs e)
        {
            string apiURL = Application["apiURL"].ToString() + "elimAlumno/";
            // string ced = GridView1.Rows[i].FindControl("cedula"); //Probablemente malo
            // apiURL = apiURL + ced;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

    }
}