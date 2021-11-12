using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula_Movil
{
    public partial class Admin_AsignationMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.verDatos();
            }
        }

        private void verDatos()
        {
            string apiURL = Application["apiURL"].ToString() + "profesores";
            APICaller apiCaller = new APICaller();
            string apiResponseTeacher = apiCaller.RequestAPIData(apiURL);
            apiURL = Application["apiURL"].ToString() + "estudiantes";
            string apiResponseStudent = apiCaller.RequestAPIData(apiURL);
            GR_AsignationStudent.DataSource = (new JavaScriptSerializer()).Deserialize<List<Usuario>>(apiResponseStudent);
            GR_AsignationStudent.DataBind();
            GR_AsignationTeacher.DataSource = (new JavaScriptSerializer()).Deserialize<List<Usuario>>(apiResponseTeacher);
            GR_AsignationTeacher.DataBind();
        }

        protected void GR_Asignation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList drplst = (e.Row.FindControl("Drp_Cursos") as DropDownList);
                string apiURL = Application["apiURL"].ToString() + "cursos";
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                drplst.DataSource = (new JavaScriptSerializer()).Deserialize<List<Curso>>(apiResponse);

                drplst.DataTextField = "Nombre";
                drplst.DataValueField = "Codigo";
                drplst.DataBind();
                drplst.Items.Insert(0, new ListItem("Seleccione el curso", "0"));
            }
        }


        protected void asignarMaestros(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = GR_AsignationTeacher.Rows[e.NewSelectedIndex];
            string apiURL = Application["apiURL"].ToString() + "asignarProfe/";
            string cod = (row.FindControl("Drp_Cursos") as DropDownList).SelectedValue.ToString();
            string ced = (row.FindControl("lbl_Cedula") as Label).Text; //Probablemente malo
            string gra = (row.FindControl("txt_Grados") as TextBox).Text;
            apiURL = apiURL + ced + "/" + cod + "/" + gra;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
            Response.Write(apiResponse);
            this.verDatos();
        }

        protected void asignarEstdiantes(object sender, GridViewEditEventArgs e)
        {
            /*string apiURL = Application["apiURL"].ToString() + "asignarAlumno/";
            string nom = GridView1.Rows[i].FindControl("nombre"); //Probablemente malo
            string ape = GridView1.Rows[i].FindControl("apellido"); 
            string cod = GridView1.Rows[i].FindControl("codigo"); 
            string gra = GridView1.Rows[i].FindControl("grado");
            apiURL = apiURL + nom + "/" + ape + "/" + cod + "/" + gra;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);*/
        }
    }
}