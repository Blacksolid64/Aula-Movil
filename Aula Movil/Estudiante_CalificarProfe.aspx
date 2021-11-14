<%@ Page Title="" Language="C#" MasterPageFile="~/Estudiante.Master" AutoEventWireup="true" CodeBehind="Estudiante_CalificarProfe.aspx.cs" Inherits="Aula_Movil.Estudiante_CalificarProfe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
    <asp:GridView ID="GR_Cal" AutoGenerateColumns="false" runat="server">
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

                <asp:TemplateField HeaderText="Calificacion">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Calificacion" runat="server" Text='<%# Eval("Calificacion","{0:N2}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Cedula">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Cedula" runat="server" Text='<%# Eval("Cedula") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
            <tr>
                <td>Calificacion:<br />
                    <asp:TextBox ID="txt_nuevaCalificacion" TextMode="Number" min="1" max="5" runat="server" />
                </td>
                <td> <asp:RangeValidator runat="server" ControlToValidate="txt_nuevaCalificacion" 
                    ErrorMessage="El numero no es valido para la calificacion" Type="Integer"
                    MinimumValue="1" MaximumValue="5" ForeColor="Red"></asp:RangeValidator> </td>
                <td>
                    <asp:Button ID="btnAnnadir" runat="server" Text="Insertar" OnClick="calificarDocente" />
                </td>
            </tr>
        </table>
       </center>
</asp:Content>
