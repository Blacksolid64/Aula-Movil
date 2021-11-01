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
    public class APICaller
    {
        private string RequestAPIData(String url)
        {        
            WebClient client = new WebClient();
            string respuesta = client.DownloadString(apiURL);
            return respuesta
        }
    }
}