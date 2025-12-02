<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Parcial3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Sistema de Gestión de Casos Legales</h2>

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
    <br /><br />

    <table>
        <tr>
            <td>ID:</td>
            <td><asp:TextBox ID="txtId" runat="server" /></td>
        </tr>
        <tr>
            <td>Cliente:</td>
            <td><asp:TextBox ID="txtCliente" runat="server" /></td>
        </tr>
        <tr>
            <td>Tipo de caso:</td>
            <td><asp:TextBox ID="txtTipoCaso" runat="server" /></td>
        </tr>
        <tr>
            <td>Abogado:</td>
            <td><asp:TextBox ID="txtAbogado" runat="server" /></td>
        </tr>
        <tr>
            <td>Fecha límite (AAAA-MM-DD):</td>
            <td><asp:TextBox ID="txtFechaLimite" runat="server" /></td>
        </tr>
    </table>

    <br />

    <asp:Button ID="btnAgregar" runat="server" Text="Registrar caso" OnClick="btnAgregar_Click" />
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar por ID" OnClick="btnBuscar_Click" />
    <asp:Button ID="btnCerrar" runat="server" Text="Cerrar caso" OnClick="btnCerrar_Click" />
    <asp:Button ID="btnListar" runat="server" Text="Listar casos" OnClick="btnListar_Click" />

    <br /><br />

    <asp:GridView ID="gvCasos" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
            <asp:BoundField DataField="TipoCaso" HeaderText="Tipo de caso" />
            <asp:BoundField DataField="Abogado" HeaderText="Abogado" />
            <asp:BoundField DataField="FechaLimite" HeaderText="Fecha límite" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
        </Columns>
    </asp:GridView>

</asp:Content>
