using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula_Movil
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
           
          
            if (ValidateUser())
            {
               Response.Redirect("Admin_MainMenu");
            }
            else
            {
                Response.Redirect("Login");
            }
        }

        protected bool ValidateUser()
        {
            String email = txt_Username.Text;
            String pw = txt_password.Text;
            string apiURL = Application["apiURL"].ToString() +"logIn/"+email;
            WebClient client = new WebClient();
            try
            {
                string respuesta = client.DownloadString(apiURL);
                List<Usuario> otraRespuesta = (new JavaScriptSerializer()).Deserialize<List<Usuario>>(respuesta);
                if (otraRespuesta[0].contrasenna == pw)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            { 
                Response.Write("Oh");
            }
         
            return false;
        }

    }
}