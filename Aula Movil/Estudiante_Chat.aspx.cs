using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula_Movil
{
    public partial class Estudiante_Chat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    this.verChat();
                }
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }

        protected void verChat()
        {
            try
            {
                string apiURL = Application["apiURL"].ToString() + "chat/";
                string codigo = Session["codigo"].ToString();
                string grado = Session["clase"].ToString();
                apiURL = apiURL + codigo + "/" + grado;
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                GR_Chat.DataSource = (new JavaScriptSerializer()).Deserialize<List<Chat>>(apiResponse);
                GR_Chat.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }

        }

        protected void publicarMensaje(object sender, EventArgs e) //Si el chat no tiene nada, se queda pegadisimo
        {
            try
            {
                string apiURL = Application["apiURL"].ToString() + "publicaMsg/";
                string codigo = Session["codigo"].ToString(); //codigo del curso
                string grado = Session["clase"].ToString(); //grado del curso
                string correo = Session["UserEmail"].ToString(); //correo del escritor
                string mensaje = txt_mensajeNuevo.Text; //mensaje para el chat
                apiURL = apiURL + codigo + "/" + grado + "/" + correo + "/" + mensaje;
                APICaller apiCaller = new APICaller();
                string apiResponse = apiCaller.RequestAPIData(apiURL);
                txt_mensajeNuevo.Text = " ";
                this.verChat();
            }
            catch (Exception ex)
            {
                Response.Write(MessageBox.CreateMessageBox("Error: " + ex.ToString()));
            }
        }

    }
}