<%@ Page Title="" Language="C#" MasterPageFile="~/Profesor.Master" AutoEventWireup="true" CodeBehind="Profesor_Estudiantes.aspx.cs" Inherits="Aula_Movil.Profesor_Estudiantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <asp:GridView ID="GridView1" runat="server">
        <Columns>
                <asp:TemplateField HeaderText="Nombre">

                    <ItemTemplate>
                        <asp:Label ID="lbl_Nombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Apellido">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Apellido" runat="server" Text='<%# Eval("Apellido") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Cedula">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Cedula" runat="server" Text='<%# Eval("Cedula") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

             

              

  

                <asp:TemplateField HeaderText="Correo">
                    <ItemTemplate>
                        <asp:Label ID="lbl_correo" runat="server" Text='<%# Eval("correo") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_correo" runat="server" Text='<%# Eval("correo") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Clase">
                    <ItemTemplate>
                        <asp:Label ID="lbl_clase" runat="server" Text='<%# Eval("clase") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_clase" runat="server" Text='<%# Eval("clase") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
        </Columns>
            </asp:GridView>
    </center>
</asp:Content>
