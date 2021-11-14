using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula_Movil
{
    public static class MessageBox
    {
        public static String CreateMessageBox(string Message)
        {
            String Response = ("<script>alert('" + Message + "')</script>");
            return Response;
        }
    }
}