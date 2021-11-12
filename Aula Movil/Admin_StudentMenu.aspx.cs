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

        protected void agregarEstdiantes(object sender, EventArgs e)
        {
            string apiURL = Application["apiURL"].ToString() + "nuevoAlumno/";
            /* string ced = GridView1.Rows[i].FindControl("cedula"); //Probablemente malo
             string nom = GridView1.Rows[i].FindControl("nombre");
             string cor = GridView1.Rows[i].FindControl("correo");
             string con = GridView1.Rows[i].FindControl("contraseña");
             string ape = GridView1.Rows[i].FindControl("apellido");
             string gra = GridView1.Rows[i].FindControl("grado");
             apiURL = apiURL + ced + "/" + nom + "/" + cor + "/" + con + "/" + ape + "/" + gra;
             APICaller apiCaller = new APICaller();
             string apiResponse = apiCaller.RequestAPIData(apiURL);*/
        }

        protected void editarEstdiantes(object sender, GridViewEditEventArgs e)
        {
            string apiURL = Application["apiURL"].ToString() + "updateAlumno/";
            /* string nomv = GridView1.Rows[i].FindControl("nombre"); //Agarrar item viejo
             string apev = GridView1.Rows[i].FindControl("apellido"); //Agarrar item viejo
             string ced = GridView1.Rows[i].FindControl("cedula"); //Probablemente malo
             string nom = GridView1.Rows[i].FindControl("nombre");
             string cor = GridView1.Rows[i].FindControl("correo");
             string con = GridView1.Rows[i].FindControl("contraseña");
             string ape = GridView1.Rows[i].FindControl("apellido");
             string gra = GridView1.Rows[i].FindControl("grado");
             apiURL = apiURL + nomv + "/" + apev+ "/" + ced + "/" + nom + "/" + cor + "/" + con + "/" + ape + "/" + gra;
             APICaller apiCaller = new APICaller();
             string apiResponse = apiCaller.RequestAPIData(apiURL); */
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