<%@ Page Title="" Language="C#" MasterPageFile="~/Profesor.Master" AutoEventWireup="true" CodeBehind="Profesor_MainMenu.aspx.cs" Inherits="Aula_Movil.Profesor_MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <asp:GridView ID="GR_Tch" AutoGenerateColumns="false" AutoGenerateSelectButton="true" OnSelectedIndexChanging="GR_Tch_SelectedIndexChanging" runat="server">
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
    </center>
</asp:Content>
