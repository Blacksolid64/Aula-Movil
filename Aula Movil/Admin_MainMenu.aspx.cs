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
            try
            {
                if (!this.IsPostBack)
                {
                    this.verMaestros();
                }
            }
            catch (Exception ex)
            {

                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }

        private void populateGridview()
        {
            try
            {
                string apiURL = Application["apiURL"].ToString() + "profesores"; // Definición de la URL para el request
                WebClient client = new WebClient();
                string apiResponse = client.DownloadString(apiURL);
                GridView1.DataSource = (new JavaScriptSerializer()).Deserialize<List<Usuario>>(apiResponse);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
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
            try
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
            catch (Exception ex)
            {

                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }

        private void verMaestros()
        {
            try
            {
                string apiURL = Application["apiURL"].ToString() + "profesores";
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                GridView1.DataSource = (new JavaScriptSerializer()).Deserialize<List<Usuario>>(apiResponse);
                GridView1.DataBind();
            }
            catch (Exception ex) { Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString())); }

        }

        protected void agregarMaestros(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex) { Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString())); }

        }

        protected void editarMaestros(object sender, GridViewUpdateEventArgs e)
        { //Edición de maestros
            try
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
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }

        protected void eliminarMaestros(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                GridViewRow row = GridView1.Rows[e.RowIndex];
                string apiURL = Application["apiURL"].ToString() + "elimDocente/";
                string ced = (row.FindControl("lbl_OrigCed") as Label).Text;
                apiURL = apiURL + ced;
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                this.populateGridview();
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }
    }
}