using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula_Movil
{
    public partial class Estudiante_MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    this.estudiantesXcursos();
                }
            }
            catch (Exception ex) { Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString())); }
        }

        protected void estudiantesXcursos()
        {
            try
            {
                string apiURL = Application["apiURL"].ToString() + "cursos/estudiante/";
                string ced = Session["UserCedula"].ToString();
                apiURL = apiURL + ced;
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                GR_Std.DataSource = (new JavaScriptSerializer()).Deserialize<List<Curso>>(apiResponse);
                GR_Std.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }

        protected void GR_Std_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                GridViewRow row = GR_Std.Rows[e.NewSelectedIndex];
                Session["nombre"] = (row.FindControl("lbl_Nombre") as Label).Text;
                Session["clase"] = (row.FindControl("lbl_Clase") as Label).Text;
                Session["codigo"] = (row.FindControl("lbl_Codigo") as Label).Text;
                Response.Write(MessageBox.CreateMessageBox("Usted seleccionó el curso " + Session["nombre"].ToString()));
                (Master.FindControl("lbl_selectedCourse") as Label).Text = Session["nombre"].ToString();
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }
    }
}