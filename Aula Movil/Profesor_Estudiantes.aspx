<%@ Page Title="" Language="C#" MasterPageFile="~/Profesor.Master" AutoEventWireup="true" CodeBehind="Profesor_Estudiantes.aspx.cs" Inherits="Aula_Movil.Profesor_Estudiantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <asp:GridView ID="GR_Est" AutoGenerateColumns="false" runat="server">
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
            </Columns>
        </asp:GridView>
    </center>
</asp:Content>
