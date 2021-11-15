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
            try
            {
                if (!this.IsPostBack)
                {
                    this.verDatos();
                }
            }
            catch (Exception ex)
            {

                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }

        private void verDatos()
        {
            try
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
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }

        protected void GR_Asignation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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
            catch (Exception ex)
            {

                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }


        protected void asignarMaestros(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                GridViewRow row = GR_AsignationTeacher.Rows[e.NewSelectedIndex];
                string apiURL = Application["apiURL"].ToString() + "asignarProfe/";
                string cod = (row.FindControl("Drp_Cursos") as DropDownList).SelectedValue.ToString();
                string ced = (row.FindControl("lbl_Cedula") as Label).Text;
                string gra = (row.FindControl("txt_Grados") as TextBox).Text;
                apiURL = apiURL + ced + "/" + cod + "/" + gra;
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                this.verDatos();
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }

        protected void asignarEstdiantes(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                GridViewRow row = GR_AsignationStudent.Rows[e.NewSelectedIndex];
                string apiURL = Application["apiURL"].ToString() + "asignarAlumno/";
                string nom = (row.FindControl("lbl_NombreEst") as Label).Text; //Probablemente malo
                string ape = (row.FindControl("lbl_ApellidoEst") as Label).Text;
                string cod = (row.FindControl("Drp_Cursos") as DropDownList).SelectedValue.ToString();
                string gra = (row.FindControl("txt_GradosEst") as TextBox).Text;
                apiURL = apiURL + nom + "/" + ape + "/" + cod + "/" + gra;
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                this.verDatos();
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }
    }
}