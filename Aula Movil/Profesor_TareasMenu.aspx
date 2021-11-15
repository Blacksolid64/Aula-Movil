<%@ Page Title="" Language="C#" MasterPageFile="~/Profesor.Master" AutoEventWireup="true" CodeBehind="Profesor_TareasMenu.aspx.cs" Inherits="Aula_Movil.Profesor_TareasMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <center>
        <asp:GridView ID="GR_tr" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="Titulo">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Titulo" runat="server" Text='<%# Eval("Titulo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Clase">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Clase" runat="server" Text='<%# Eval("Clase") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Descripcion">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Descripcion" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Codigo">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Codigo" runat="server" Text='<%# Eval("Codigo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Fecha">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Fecha" runat="server"  Text='<%# Eval("Fecha") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
            <tr>
                <td>Titulo:<br />
                    <asp:TextBox ID="txt_nuevoTitulo" runat="server" />
                </td>
                <td>Descripcion<br />
                    <asp:TextBox ID="txt_nuevaDecripcion" runat="server" />
                </td>
                <td>Fecha de entrega:<br />
                    <asp:TextBox ID="txt_nuevaFecha" TextMode="Date" runat="server" />
                </td>
                <td>Codigo de la tarea:<br />
                    <asp:TextBox ID="txt_nuevoCodigo" runat="server" />
                </td>
                <td>
                    <asp:Button ID="btnAnnadir" runat="server" Text="Insertar" OnClick="agregarTarea" />
                </td>
            </tr>
        </table>
        <hr/>
    </center>


</asp:Content>
