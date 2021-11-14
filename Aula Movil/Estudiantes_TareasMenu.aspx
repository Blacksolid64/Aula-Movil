<%@ Page Title="" Language="C#" MasterPageFile="~/Estudiante.Master" AutoEventWireup="true" CodeBehind="Estudiantes_TareasMenu.aspx.cs" Inherits="Aula_Movil.Estudiantes_TareasMenu" %>

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
                        <asp:Label ID="lbl_Fecha" runat="server" Text='<%# Eval("Fecha") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>
    </center>
</asp:Content>
