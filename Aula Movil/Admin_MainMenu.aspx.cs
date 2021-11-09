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
                this.populateGridview();
            }
            //await program.getUsuarios("http://nodejsclusters-55543-0.cloudclusters.net/usuarios");

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
            string Ced = Convert.ToString(e.OldValues["cedula"]);
            GridViewRow row = GridView1.Rows[e.RowIndex];
            TextBox nombre = (TextBox)row.Cells[1].Controls[0];
            Response.Write(nombre.Text);
        }

        protected void verMaestros()
        {
            string apiURL = Application["apiURL"].ToString() + "profesores";
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);            
            GridView1.DataSource = (new JavaScriptSerializer()).Deserialize<List<Usuario>>(apiResponse);
            GridView1.DataBind();

        }

        protected void verEstdiantes()
        {
            string apiURL = Application["apiURL"].ToString() + "estudiantes";
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
            GridView1.DataSource = (new JavaScriptSerializer()).Deserialize<List<Usuario>>(apiResponse);
            GridView1.DataBind();
        }

        protected void verCursos()
        {
            string apiURL = Application["apiURL"].ToString() + "cursos";
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
            GridView1.DataSource = (new JavaScriptSerializer()).Deserialize<List<Curso>>(apiResponse);
            GridView1.DataBind();
        }

        protected void agregarMaestros()
        {
            string apiURL = Application["apiURL"].ToString() + "nuevoDocente/";
            string ced = GridView1.Rows[i].FindControl("cedula"); //Probablemente malo
            string nom = GridView1.Rows[i].FindControl("nombre"); 
            string cor = GridView1.Rows[i].FindControl("correo"); 
            string con = GridView1.Rows[i].FindControl("contraseña"); 
            string ape = GridView1.Rows[i].FindControl("apellido");
            apiURL = apiURL + ced + "/" + nom+ "/" + cor + "/" + con+ "/" + ape;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);

        }

        protected void agregarEstdiantes()
        {
            string apiURL = Application["apiURL"].ToString() + "nuevoAlumno/";
            string ced = GridView1.Rows[i].FindControl("cedula"); //Probablemente malo
            string nom = GridView1.Rows[i].FindControl("nombre");
            string cor = GridView1.Rows[i].FindControl("correo");
            string con = GridView1.Rows[i].FindControl("contraseña");
            string ape = GridView1.Rows[i].FindControl("apellido");
            string gra = GridView1.Rows[i].FindControl("grado");
            apiURL = apiURL + ced + "/" + nom + "/" + cor + "/" + con + "/" + ape + "/" + gra;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

        protected void agregarCursos()
        {
            string apiURL = Application["apiURL"].ToString() + "nuevoCurso/";
            string cod = GridView1.Rows[i].FindControl("codigo"); //Probablemente malo
            string nom = GridView1.Rows[i].FindControl("nombre");
            string gra = GridView1.Rows[i].FindControl("grado");
            string dia = GridView1.Rows[i].FindControl("dia de Semana");
            string ini = GridView1.Rows[i].FindControl("hora de Inicio");
            string fin = GridView1.Rows[i].FindControl("hora de Final");
            apiURL = apiURL + cod + "/" + nom + "/" + gra + "/" + dia + "/" + ini + "/" + fin;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

        protected void editarMaestros()
        {
            string apiURL = Application["apiURL"].ToString() + "updateDocente/";
            string cedv = GridView1.Rows[i].FindControl("cedula"); //Agarrar item viejo!
            string ced = GridView1.Rows[i].FindControl("cedula"); //Probablemente malo
            string nom = GridView1.Rows[i].FindControl("nombre");
            string cor = GridView1.Rows[i].FindControl("correo");
            string con = GridView1.Rows[i].FindControl("contraseña");
            string ape = GridView1.Rows[i].FindControl("apellido");
            apiURL = apiURL + cedv + "/" + ced + "/" + nom + "/" + cor + "/" + con + "/" + ape;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

        protected void editarEstdiantes()
        {
            string apiURL = Application["apiURL"].ToString() + "updateAlumno/";
            string nomv = GridView1.Rows[i].FindControl("nombre"); //Agarrar item viejo
            string apev = GridView1.Rows[i].FindControl("apellido"); //Agarrar item viejo
            string ced = GridView1.Rows[i].FindControl("cedula"); //Probablemente malo
            string nom = GridView1.Rows[i].FindControl("nombre");
            string cor = GridView1.Rows[i].FindControl("correo");
            string con = GridView1.Rows[i].FindControl("contraseña");
            string ape = GridView1.Rows[i].FindControl("apellido");
            string gra = GridView1.Rows[i].FindControl("grado");
            apiURL = apiURL + nomv + "/" + apev+ "/" + ced + "/" + nom + "/" + cor + "/" + con + "/" + ape + "/" + gra;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

        protected void editarCursos()
        {
            string apiURL = Application["apiURL"].ToString() + "updateCurso/";
            string codv = GridView1.Rows[i].FindControl("codigo"); //Agarrar item viejo
            string grav = GridView1.Rows[i].FindControl("grado"); //Agarrar item viejo
            string cod = GridView1.Rows[i].FindControl("codigo"); //Probablemente malo
            string nom = GridView1.Rows[i].FindControl("nombre");
            string gra = GridView1.Rows[i].FindControl("grado");
            string dia = GridView1.Rows[i].FindControl("dia de Semana");
            string ini = GridView1.Rows[i].FindControl("hora de Inicio");
            string fin = GridView1.Rows[i].FindControl("hora de Final");
            //apiURL = apiURL + codv + "/" +grav + "/" cod + "/" + nom + "/" + gra + "/" + dia + "/" + ini + "/" + fin;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

        protected void eliminarMaestros()
        {
            string apiURL = Application["apiURL"].ToString() + "elimDocente/";
            string ced = GridView1.Rows[i].FindControl("cedula"); //Probablemente malo
            apiURL = apiURL + ced;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

        protected void eliminarEstdiantes()
        {
            string apiURL = Application["apiURL"].ToString() + "elimAlumno/";
            string ced = GridView1.Rows[i].FindControl("cedula"); //Probablemente malo
            apiURL = apiURL + ced;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

        protected void eliminarCursos()
        {
            string apiURL = Application["apiURL"].ToString() + "elimCurso/";
            string cod = GridView1.Rows[i].FindControl("codigo"); //Probablemente malo
            string gra = GridView1.Rows[i].FindControl("grado"); 
            apiURL = apiURL + cod + "/" + gra;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

        protected void asignarMaestros()
        {
            string apiURL = Application["apiURL"].ToString() + "asignarProfe/";
            string ced = GridView1.Rows[i].FindControl("cedula"); //Probablemente malo
            string cod = GridView1.Rows[i].FindControl("codigo");
            string gra = GridView1.Rows[i].FindControl("grado");
            apiURL = apiURL + ced + "/" + cod + "/" + gra;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }

        protected void asignarEstdiantes()
        {
            string apiURL = Application["apiURL"].ToString() + "asignarAlumno/";
            string nom = GridView1.Rows[i].FindControl("nombre"); //Probablemente malo
            string ape = GridView1.Rows[i].FindControl("aoellido"); 
            string cod = GridView1.Rows[i].FindControl("codigo"); 
            string gra = GridView1.Rows[i].FindControl("grado");
            apiURL = apiURL + nom + "/" + ape + "/" + cod + "/" + gra;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
        }


    }
}