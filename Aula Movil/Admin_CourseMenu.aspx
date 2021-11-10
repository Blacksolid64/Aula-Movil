<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_CourseMenu.aspx.cs" Inherits="Aula_Movil.Admin_CourseMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
       
        <asp:GridView ID="GR_Courses" runat="server" AutoGenerateColumns="false" Height="217px" Width="557px">

            <Columns>
            
                <asp:TemplateField HeaderText = "Nombre">
                <ItemTemplate>
                    <asp:Label ID ="lbl_Nombre" runat="server" Text = '<%# Eval("Nombre") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID ="txt_Nombre" runat="server" Text = '<%# Eval("Nombre") %>'></asp:TextBox>
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
                
                <asp:TemplateField HeaderText = "Hora de inicio">
                <ItemTemplate>
                    <asp:Label ID ="lbl_HoraInicio" runat="server" Text = '<%# Eval("HoraInicio") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID ="txt_HoraInicio" runat="server" Text = '<%# Eval("HoraInicio") %>'></asp:TextBox>
                </EditItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText = "Hora de finalización">
                <ItemTemplate>
                    <asp:Label ID ="lbl_HoraFinal" runat="server" Text = '<%# Eval("HoraFinal") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID ="txt_HoraFinal" runat="server" Text = '<%# Eval("HoraFinal") %>'></asp:TextBox>
                </EditItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText = "Dia de la semana">
                <ItemTemplate>
                    <asp:Label ID ="lbl_DiaSem" runat="server" Text = '<%# Eval("DiaSem") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID ="txt_DiaSem" runat="server" Text = '<%# Eval("DiaSem") %>'></asp:TextBox>
                </EditItemTemplate>
                </asp:TemplateField>
                
                <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" />
            </Columns>
            <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
    <tr>
        <td>Nombre:<br/>
            <asp:TextBox ID="txt_nuevoNombre" runat="server" />
        </td>
        <td>Clase:<br/>
            <asp:TextBox ID="txt_nuevaClase" runat="server" />
        </td>
        <td>Codigo:<br/>
            <asp:TextBox ID="txt_nuevoCodigo" runat="server" />
        </td>
        <td>Hora de Inicio:<br/>
            <asp:TextBox ID="txt_nuevaHoraInicio" runat="server" />
        </td>
        <td>Hora de Finalización:<br/>
            <asp:TextBox ID="txt_nuevaHoraFinal" runat="server" />
        </td>
        <td>Dia de la semana:<br/>
            <asp:TextBox ID="txt_nuevoDiaSem" runat="server" />
        </td>
        <td>
            <asp:Button ID="btnAnnadir" runat="server" Text="Insertar" OnClick="agregarCurso" />
        </td>
    </tr>
    </table>
    <hr/>
            
        </asp:GridView>
        
    </center>
</asp:Content>
