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
            string respuesta = client.DownloadString(apiURL);
            GridView1.DataSource = (new JavaScriptSerializer()).Deserialize<List<Usuario>>(respuesta);
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
    }
}