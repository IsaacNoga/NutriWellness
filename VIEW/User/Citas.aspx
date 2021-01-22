<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.Master" AutoEventWireup="true" CodeBehind="Citas.aspx.cs" Inherits="VIEW.User.Citas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Citas</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    <a class="navbar-brand">Citas</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <asp:GridView id="gvCitas" CssClass="table table-bordered dataTable" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField dataField="idCita" HeaderText="Número de Cita" />
                <asp:BoundField dataField="fecha" HeaderText="Fecha" DataFormatString = "{0:dd/MM/yyyy}" />
                <asp:BoundField dataField="hora" HeaderText="Hora" />
                <asp:BoundField dataField="observaciones" HeaderText="Observaciones" />
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>
