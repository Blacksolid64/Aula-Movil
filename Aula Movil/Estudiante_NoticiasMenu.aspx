<%@ Page Title="" Language="C#" MasterPageFile="~/Estudiante.Master" AutoEventWireup="true" CodeBehind="Estudiante_NoticiasMenu.aspx.cs" Inherits="Aula_Movil.Estudiante_NoticiasMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
    <asp:GridView ID="GR_nws" AutoGenerateColumns="false" runat="server">
        <Columns>
             <asp:TemplateField HeaderText="Titulo">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Titulo" runat="server" Text='<%# Eval("titulo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Descripcion">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Descripcion" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Fecha">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Fecha" runat="server" Text='<%# Eval("fecha") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </center>
</asp:Content>
