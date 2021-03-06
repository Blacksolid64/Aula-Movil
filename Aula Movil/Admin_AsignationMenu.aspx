<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_AsignationMenu.aspx.cs" Inherits="Aula_Movil.Admin_AsignationMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <asp:GridView ID="GR_AsignationTeacher" AutoGenerateColumns="false"
            OnRowDataBound="GR_Asignation_RowDataBound" OnSelectedIndexChanging="asignarMaestros" Caption="Asignacion de Profesores"
            runat="server">
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

                <asp:TemplateField HeaderText="Cursos disponibles">
                    <ItemTemplate>
                        <asp:DropDownList ID="Drp_Cursos" runat="server"></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Grado">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_Grados" runat="server">  </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:CommandField ButtonType="Link" ShowSelectButton="true" />

            </Columns>
        </asp:GridView>

        <asp:GridView ID="GR_AsignationStudent" AutoGenerateColumns="false" runat="server"
            OnRowDataBound="GR_Asignation_RowDataBound" OnSelectedIndexChanging="asignarEstdiantes" Caption="Asignacion de estudiantes">
            <Columns>
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label ID="lbl_NombreEst" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Apellido">
                    <ItemTemplate>
                        <asp:Label ID="lbl_ApellidoEst" runat="server" Text='<%# Eval("Apellido") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Cursos disponibles">
                    <ItemTemplate>
                        <asp:DropDownList ID="Drp_Cursos" runat="server"></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Grado">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_GradosEst" runat="server">  </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:CommandField ButtonType="Link" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>

    </center>

</asp:Content>
