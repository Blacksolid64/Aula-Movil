<%@ Page Title="" Language="C#" MasterPageFile="~/Estudiante.Master" AutoEventWireup="true" CodeBehind="Estudiante_MainMenu.aspx.cs" Inherits="Aula_Movil.Estudiante_MainMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GR_Std" AutoGenerateColumns="false"  AutoGenerateSelectButton="true" OnSelectedIndexChanging="GR_Std_SelectedIndexChanging" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Nombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Clase">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Clase" runat="server" Text='<%# Eval("Clase") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Codigo">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Codigo" runat="server" Text='<%# Eval("Codigo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
