<%@ Page Title="" Language="C#" MasterPageFile="~/Estudiante.Master" AutoEventWireup="true" CodeBehind="Estudiante_Chat.aspx.cs" Inherits="Aula_Movil.Estudiante_Chat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <asp:GridView ID="GR_Chat" runat="server" AutoGenerateColumns="True" GridLines="None"></asp:GridView>
        <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
            <tr>
                <td>Mensaje:<br />
                    <asp:TextBox ID="txt_mensajeNuevo" runat="server" />
                </td>
                <td>
                    <asp:Button ID="btnAnnadir" runat="server" Text="Enviar Mensaje" OnClick="publicarMensaje" />
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
