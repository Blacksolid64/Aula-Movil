<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_MainMenu.aspx.cs" Inherits="Aula_Movil.Admin_MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
    <asp:GridView 
        ID="GridView1" runat="server" Height="217px" Width="557px"
        AutoGenerateColumns="false" 
        OnRowEditing="Gr1_OnRowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" >
        <Columns>
            <asp:TemplateField HeaderText = "Nombre">

                <ItemTemplate>
                    <asp:Label ID ="lbl_Nombre" runat="server" Text = '<%# Eval("Nombre") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID ="txt_Nombre" runat="server" Text = '<%# Eval("Nombre") %>'></asp:TextBox>
                </EditItemTemplate>
                </asp:TemplateField>
                
             <asp:TemplateField HeaderText = "Apellido">

                <ItemTemplate>
                    <asp:Label ID ="lbl_Apellido" runat="server" Text = '<%# Eval("Apellido") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID ="txt_Apellido" runat="server" Text = '<%# Eval("Apellido") %>'></asp:TextBox>
                </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText = "Cedula">
                    <ItemTemplate>
                    <asp:Label ID ="lbl_Cedula" runat="server" Text = '<%# Eval("Cedula") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID ="txt_Cedula" runat="server" Text = '<%# Eval("Cedula") %>'></asp:TextBox>
                </EditItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText ="Cedula original" Visible="false">
                    <ItemTemplate>
                    <asp:Label ID="lbl_OrigCed" runat="server" Text = '<%# Eval("Cedula") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText = "Contraseña">
                <ItemTemplate>
                    <asp:Label ID ="lbl_contrasenna" runat="server" Text = '<%# Eval("contrasenna") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID ="txt_contrasenna" runat="server" Text = '<%# Eval("contrasenna") %>'></asp:TextBox>
                </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText = "correo">
                <ItemTemplate>
                    <asp:Label ID ="lbl_correo" runat="server" Text = '<%# Eval("correo") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID ="txt_correo" runat="server" Text = '<%# Eval("correo") %>'></asp:TextBox>
                </EditItemTemplate>
                </asp:TemplateField>
                
                <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" />
        </Columns>    
    </asp:GridView>
    </center>
</asp:Content>
