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
            string apiURL = Application["apiURL"].ToString() + "nuevoAlumno/";
            /* string ced = GR_Students.Rows[i].FindControl("cedula"); //Probablemente malo
             string nom = GR_Students.Rows[i].FindControl("nombre");
             string cor = GR_Students.Rows[i].FindControl("correo");
             string con = GR_Students.Rows[i].FindControl("contraseña");
             string ape = GR_Students.Rows[i].FindControl("apellido");
             string gra = GR_Students.Rows[i].FindControl("grado");
             apiURL = apiURL + ced + "/" + nom + "/" + cor + "/" + con + "/" + ape + "/" + gra;
             APICaller apiCaller = new APICaller();
             string apiResponse = apiCaller.RequestAPIData(apiURL);*/
        }

        protected void editarEstdiantes(object sender, GridViewEditEventArgs e)
        {
            string apiURL = Application["apiURL"].ToString() + "updateAlumno/";
            /* string nomv = GR_Students.Rows[i].FindControl("nombre"); //Agarrar item viejo
             string apev = GR_Students.Rows[i].FindControl("apellido"); //Agarrar item viejo
             string ced = GR_Students.Rows[i].FindControl("cedula"); //Probablemente malo
             string nom = GR_Students.Rows[i].FindControl("nombre");
             string cor = GR_Students.Rows[i].FindControl("correo");
             string con = GR_Students.Rows[i].FindControl("contraseña");
             string ape = GR_Students.Rows[i].FindControl("apellido");
             string gra = GR_Students.Rows[i].FindControl("grado");
             apiURL = apiURL + nomv + "/" + apev+ "/" + ced + "/" + nom + "/" + cor + "/" + con + "/" + ape + "/" + gra;
             APICaller apiCaller = new APICaller();
             string apiResponse = apiCaller.RequestAPIData(apiURL); */
        }

        protected void eliminarEstdiantes(object sender, GridViewEditEventArgs e)
        {
            string apiURL = Application["apiURL"].ToString() + "elimAlumno/";
            // string ced = GR_Students.Rows[i].FindControl("cedula"); //Probablemente malo
            // apiURL = apiURL + ced;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

    }
}