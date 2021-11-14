﻿using System;
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
                switch (Session["UserType"])
                {
                    case "profesor":
                        Response.Redirect("Profesor_MainMenue");
                        break;
                    case "estudiante":
                        Response.Redirect("Estudiante_MainMenu");
                        break;
                    case "admin":
                        Response.Redirect("Admin_MainMenu");
                        break;
                    default:
                        Response.Redirect("Login");
                        break;
                }
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
            string apiURL = Application["apiURL"].ToString() + "logIn/" + email;
            WebClient client = new WebClient();
            try
            {
                string respuesta = client.DownloadString(apiURL);
                List<Usuario> Respuesta_deserealizada = (new JavaScriptSerializer()).Deserialize<List<Usuario>>(respuesta);
                Session["UserCedula"] = Respuesta_deserealizada[0].cedula;
                Session["UserEmail"] = email;
                Session["UserType"] = tipoUsuario(Respuesta_deserealizada[0].ID);
                if (Respuesta_deserealizada[0].contrasenna == pw)
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

        protected string tipoUsuario(string id)
        {
            string apiURL = Application["apiURL"].ToString() + "tipoUsuario/";
            apiURL = apiURL + id;
            APICaller apiCaller = new APICaller();
            string apiResponse = apiCaller.RequestAPIData(apiURL);
            List<Usuario> tipoUsuario = (new JavaScriptSerializer()).Deserialize<List<Usuario>>(apiResponse);
            string TU = tipoUsuario[0].tipousuario;
            return TU;
        }

    }
}