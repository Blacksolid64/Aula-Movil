<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_StudentMenu.aspx.cs" Inherits="Aula_Movil.Admin_StudentMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <asp:GridView ID="GR_Students" runat="server" Height="217px" Width="557px" AutoGenerateColumns="false"
            OnRowEditing="GR_Students_OnRowEditing"
            OnRowCancelingEdit="GR_Students_RowCancelingEdit" 
            OnRowUpdating="editarEstdiantes"
            OnRowDeleting="eliminarEstdiantes">
            <Columns>
                <asp:TemplateField HeaderText="Nombre">

                    <ItemTemplate>
                        <asp:Label ID="lbl_Nombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_Nombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Apellido">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Apellido" runat="server" Text='<%# Eval("Apellido") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_Apellido" runat="server" Text='<%# Eval("Apellido") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Cedula">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Cedula" runat="server" Text='<%# Eval("Cedula") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_Cedula" runat="server" Text='<%# Eval("Cedula") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Cedula original" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lbl_OrigCed" runat="server" Text='<%# Eval("Cedula") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Contraseña">
                    <ItemTemplate>
                        <asp:Label ID="lbl_contrasenna" runat="server" Text='<%# Eval("contrasenna") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_contrasenna" runat="server" Text='<%# Eval("contrasenna") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="correo">
                    <ItemTemplate>
                        <asp:Label ID="lbl_correo" runat="server" Text='<%# Eval("correo") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_correo" runat="server" Text='<%# Eval("correo") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>
        <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
            <tr>
                <td>Nombre:<br />
                    <asp:TextBox ID="txt_nuevoNombre" runat="server" />
                </td>
                <td>Apellido:<br />
                    <asp:TextBox ID="txt_nuevoApellido" runat="server" />
                </td>
                <td>Cedula:<br />
                    <asp:TextBox ID="txt_nuevaCedula" runat="server" />
                </td>
                <td>Contraseña:<br />
                    <asp:TextBox ID="txt_nuevaContrasenna" runat="server" />
                </td>
                <td>Correo:<br />
                    <asp:TextBox ID="txt_nuevoCorreo" runat="server" />
                </td>
                <td>
                    <asp:Button ID="btnAnnadir" runat="server" Text="Insertar" OnClick="agregarEstdiantes" />
                </td>
            </tr>
        </table>
        <hr />
    </center>
</asp:Content>
