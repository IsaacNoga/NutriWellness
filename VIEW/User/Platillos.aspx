<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.Master" AutoEventWireup="true" CodeBehind="Platillos.aspx.cs" Inherits="VIEW.User.Platillos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Platillos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    <a class="navbar-brand">Platillos</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="row">
            <div class="col-10">
                <asp:Label Text="Criterios de busqueda: " runat="server" />
                <asp:TextBox runat="server" ID="txtCriterios" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
            </div>
            <div class="col-2 mt-4">
                <asp:Button ID="btnBuscar" Text="Buscar" CssClass="btn btn-primary mt-1 ml-5" runat="server"/>
            </div>
        </div>
        <div id="mensajeError" visible="false" class="alert mt-3 alert-danger mt-1" runat="server" role="alert"></div>
        <div class="row">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class=" col-4">
                        <img class="img-responsive p-3 m-3" style="height:150px" src="data:image/jpg;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"imagen")) %>" />
                        <br />
                        <asp:Label Text="Nombre: " CssClass="text-body" runat="server" />
                        <%#DataBinder.Eval(Container.DataItem,"nombre") %>
                        <br />
                        <asp:Label Text="Descripción: " CssClass="text-body" runat="server" />
                        <br />
                        <%#DataBinder.Eval(Container.DataItem,"descripcion") %>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</asp:Content>
