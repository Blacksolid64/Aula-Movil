using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula_Movil
{
    public partial class Profesor_MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.cursosXProfesor();
            }
        }

        protected void cursosXProfesor()
        {
            string apiURL = Application["apiURL"].ToString() + "cursos/profesor/";
            string correo = Session["UserEmail"].ToString();
            apiURL = apiURL + correo;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
            GR_Tch.DataSource = (new JavaScriptSerializer()).Deserialize<List<Curso>>(apiResponse);
            GR_Tch.DataBind();
        }

        protected void GR_Tch_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GR_Tch.Rows[e.NewSelectedIndex];
            Session["nombre"] = (row.FindControl("lbl_Nombre") as Label).Text;
            Session["clase"] = (row.FindControl("lbl_Clase") as Label).Text;
            Session["codigo"] = (row.FindControl("lbl_Codigo") as Label).Text;
            Response.Write(MessageBox.CreateMessageBox("Usted seleccionó el curso " + Session["nombre"].ToString()));
        }
    }
}