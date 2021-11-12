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
            if (!this.IsPostBack)
            {
                this.verCursos();
            }
        }
        protected void verCursos()
        {
            string apiURL = Application["apiURL"].ToString() + "cursos";
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
            GR_Courses.DataSource = (new JavaScriptSerializer()).Deserialize<List<Curso>>(apiResponse);
            GR_Courses.DataBind();
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
            string apiURL = Application["apiURL"].ToString() + "nuevoCurso/";
            /* string cod = GridView1.Rows[i].FindControl("codigo"); //Probablemente malo
             string nom = GridView1.Rows[i].FindControl("nombre");
             string gra = GridView1.Rows[i].FindControl("grado");
             string dia = GridView1.Rows[i].FindControl("dia de Semana");
             string ini = GridView1.Rows[i].FindControl("hora de Inicio");
             string fin = GridView1.Rows[i].FindControl("hora de Final");
             apiURL = apiURL + cod + "/" + nom + "/" + gra + "/" + dia + "/" + ini + "/" + fin;
             APICaller apiCaller = new APICaller();
             string apiResponse = apiCaller.RequestAPIData(apiURL);*/
        }

        protected void editarCursos(object sender, GridViewEditEventArgs e)
        {
            string apiURL = Application["apiURL"].ToString() + "updateCurso/";
            /* string codv = GridView1.Rows[i].FindControl("codigo"); //Agarrar item viejo
             string grav = GridView1.Rows[i].FindControl("grado"); //Agarrar item viejo
             string cod = GridView1.Rows[i].FindControl("codigo"); //Probablemente malo
             string nom = GridView1.Rows[i].FindControl("nombre");
             string gra = GridView1.Rows[i].FindControl("grado");
             string dia = GridView1.Rows[i].FindControl("dia de Semana");
             string ini = GridView1.Rows[i].FindControl("hora de Inicio");
             string fin = GridView1.Rows[i].FindControl("hora de Final");
             //apiURL = apiURL + codv + "/" +grav + "/" cod + "/" + nom + "/" + gra + "/" + dia + "/" + ini + "/" + fin;
             APICaller apiCaller = new APICaller();
             string apiResponse = apiCaller.RequestAPIData(apiURL); */
        }


        protected void eliminarCursos(object sender, GridViewEditEventArgs e)
        {
            string apiURL = Application["apiURL"].ToString() + "elimCurso/";
            // string cod = GridView1.Rows[i].FindControl("codigo"); //Probablemente malo
            // string gra = GridView1.Rows[i].FindControl("grado"); 
            // apiURL = apiURL + cod + "/" + gra;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

    }
}