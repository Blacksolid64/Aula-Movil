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
            string apiURL = "http://nodejsclusters-55543-0.cloudclusters.net/usuarios";
            WebClient client = new WebClient();
            string respuesta = client.DownloadString(apiURL);
            GridView1.DataSource = (new JavaScriptSerializer()).Deserialize<List<Usuario>>(respuesta);
            GridView1.DataBind();
        }
        class Usuario
        {

            public string nombre { set; get; }
            public string apellido { set; get; }
            public string contrasenna { set; get; }
            public string cedula { set; get; }
            public string correo { set; get; }
        }
    }
}