using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using httpRequests.cs;

namespace Aula_Movil
{
    public partial class Admin_MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Program program;
            Program program = new Program();
            await program.getUsuarios("http://nodejsclusters-55543-0.cloudclusters.net/usuarios");

        }
    }
}