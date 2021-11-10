<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_CourseMenu.aspx.cs" Inherits="Aula_Movil.Admin_CourseMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
       
        <asp:GridView ID="GR_Courses" runat="server" AutoGenerateColumns="false" Height="217px" Width="557px">

            <Columns>
            
                <asp:TemplateField HeaderText = "Titulo">
                <ItemTemplate>
                    <asp:Label ID ="lbl_Titulo" runat="server" Text = '<%# Eval("Titulo") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID ="txt_Titulo" runat="server" Text = '<%# Eval("Titulo") %>'></asp:TextBox>
                </EditItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText = "Clase">
                <ItemTemplate>
                    <asp:Label ID ="lbl_Clase" runat="server" Text = '<%# Eval("Clase") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID ="txt_Clase" runat="server" Text = '<%# Eval("Clase") %>'></asp:TextBox>
                </EditItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText = "Descripcion">
                <ItemTemplate>
                    <asp:Label ID ="lbl_Descripcion" runat="server" Text = '<%# Eval("Descripcion") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID ="txt_Descripcion" runat="server" Text = '<%# Eval("Descripcion") %>'></asp:TextBox>
                </EditItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText = "Codigo">
                <ItemTemplate>
                    <asp:Label ID ="lbl_Codigo" runat="server" Text = '<%# Eval("Codigo") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID ="txt_Codigo" runat="server" Text = '<%# Eval("Codigo") %>'></asp:TextBox>
                </EditItemTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText ="Codigo original" Visible="false">
                    <ItemTemplate>
                    <asp:Label ID="lbl_OrigCod" runat="server" Text = '<%# Eval("Codigo") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText = "Fecha">
                <ItemTemplate>
                    <asp:Label ID ="lbl_Fecha" runat="server" Text = '<%# Eval("Fecha") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID ="txt_Fecha" runat="server" Text = '<%# Eval("Fecha") %>'></asp:TextBox>
                </EditItemTemplate>
                </asp:TemplateField>
                
                
            </Columns>

        </asp:GridView>
        
    </center>
</asp:Content>
