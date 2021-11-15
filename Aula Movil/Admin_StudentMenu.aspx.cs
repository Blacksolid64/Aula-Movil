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
            try
            {
                if (!this.IsPostBack)
                {
                    this.verEstudiantes();
                }
            }
            catch (Exception ex) { Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString())); }
            
        }

        protected void verEstudiantes()
        {
            try
            {
                string apiURL = Application["apiURL"].ToString() + "estudiantes";
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                GR_Students.DataSource = (new JavaScriptSerializer()).Deserialize<List<Usuario>>(apiResponse);
                GR_Students.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }

        protected void GR_Students_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GR_Students.EditIndex = e.NewEditIndex;
            this.verEstudiantes();
        }

        protected void GR_Students_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GR_Students.EditIndex = -1;
            this.verEstudiantes();
        }


        protected void agregarEstdiantes(object sender, EventArgs e)
        {
            try
            {
                string apiURL = Application["apiURL"].ToString() + "nuevoAlumno/";
                string ced = txt_nuevaCedula.Text;
                string nom = txt_nuevoNombre.Text;
                string cor = txt_nuevoCorreo.Text;
                string con = txt_nuevaContrasenna.Text;
                string ape = txt_nuevoApellido.Text;
                string grd = txt_nuevoGrado.Text;
                apiURL = apiURL + ced + "/" + nom + "/" + cor + "/" + con + "/" + ape + "/" + grd;
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                txt_nuevaCedula.Text = "";
                txt_nuevoNombre.Text = "";
                txt_nuevoCorreo.Text = "";
                txt_nuevaContrasenna.Text = "";
                txt_nuevoApellido.Text = "";
                txt_nuevoGrado.Text = "";
                this.verEstudiantes();
            }
            catch (Exception ex )
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }

        protected void editarEstdiantes(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GR_Students.Rows[e.RowIndex];
                string apiURL = Application["apiURL"].ToString() + "updateAlumno/";
                string nombreOriginal = (row.FindControl("lbl_OrigNombre") as Label).Text;
                string apellidoOriginal = (row.FindControl("lbl_OrigApellido") as Label).Text;
                string cedula = (row.FindControl("txt_cedula") as TextBox).Text;
                string nombre = (row.FindControl("txt_nombre") as TextBox).Text;
                string apellido = (row.FindControl("txt_Apellido") as TextBox).Text;
                string correo = (row.FindControl("txt_correo") as TextBox).Text;
                string contrasenna = (row.FindControl("txt_contrasenna") as TextBox).Text;
                string clase = (row.FindControl("txt_clase") as TextBox).Text;
                apiURL = apiURL + nombreOriginal + "/" + apellidoOriginal + "/" + cedula + "/" + nombre + "/" + correo + "/" + contrasenna + "/" + apellido + "/" + clase;
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                GR_Students.EditIndex = -1;
                this.verEstudiantes();
            }
            catch (Exception ex) { Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString())); }
        }

        protected void eliminarEstdiantes(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GR_Students.Rows[e.RowIndex];
                string apiURL = Application["apiURL"].ToString() + "elimAlumno/";
                string ced = (row.FindControl("lbl_Cedula") as Label).Text;
                apiURL = apiURL + ced;
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                this.verEstudiantes();
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }

    }
}