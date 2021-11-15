using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula_Movil
{
    public partial class Admin_CourseMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    this.verCursos();
                }
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }
        protected void verCursos()
        {
            try
            {
                string apiURL = Application["apiURL"].ToString() + "cursos";
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                GR_Courses.DataSource = (new JavaScriptSerializer()).Deserialize<List<Curso>>(apiResponse);
                GR_Courses.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
                
            }
        }

        protected void GrCourses_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GR_Courses.EditIndex = e.NewEditIndex;
            this.verCursos();
        }

        protected void GrCourses_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GR_Courses.EditIndex = -1;
            this.verCursos();
        }


        protected void agregarCursos(object sender, EventArgs e)
        {
            try
            {
                string apiURL = Application["apiURL"].ToString() + "nuevoCurso/";
                string cod = txt_nuevoCodigo.Text;
                string nom = txt_nuevoNombre.Text;
                string gra = txt_nuevaClase.Text;
                string dia = txt_nuevoDiaSem.Text;
                string ini = txt_nuevaHoraInicio.Text;
                string fin = txt_nuevaHoraFinal.Text;
                apiURL = apiURL + cod + "/" + nom + "/" + gra + "/" + dia + "/" + ini + "/" + fin;
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                this.verCursos();
                txt_nuevaClase.Text = "";
                txt_nuevaHoraFinal.Text = "";
                txt_nuevaHoraInicio.Text = "";
                txt_nuevoCodigo.Text = "";
                txt_nuevoDiaSem.Text = "";
                txt_nuevoNombre.Text = "";
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }

        protected void editarCursos(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GR_Courses.Rows[e.RowIndex];
                string apiURL = Application["apiURL"].ToString() + "updateCurso/";
                string codv = (row.FindControl("lbl_OrigCod") as Label).Text;
                string grav = (row.FindControl("lbl_OrigCls") as Label).Text;
                string cod = (row.FindControl("txt_Codigo") as TextBox).Text;
                string nom = (row.FindControl("txt_Nombre") as TextBox).Text;
                string gra = (row.FindControl("txt_Clase") as TextBox).Text;
                string dia = (row.FindControl("txt_DiaSem") as TextBox).Text;
                string ini = (row.FindControl("txt_HoraInicio") as TextBox).Text;
                string fin = (row.FindControl("txt_HoraFinal") as TextBox).Text;
                apiURL = apiURL + codv + "/" + grav + "/" + nom + "/" + cod + "/" + dia + "/" + ini + "/" + fin + "/" + gra;
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                GR_Courses.EditIndex = -1;
                this.verCursos();
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }


        protected void eliminarCursos(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GR_Courses.Rows[e.RowIndex];
                string apiURL = Application["apiURL"].ToString() + "elimCurso/";
                string cod = (row.FindControl("lbl_OrigCod") as Label).Text;
                string gra = (row.FindControl("lbl_OrigCls") as Label).Text;
                apiURL = apiURL + cod + "/" + gra;
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                this.verCursos();
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }

    }
}