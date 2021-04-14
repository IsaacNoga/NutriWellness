<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DietaUsuario.aspx.cs" Inherits="VIEW.Control.DietaUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dietas</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    <a class="navbar-brand">Dieta de usuarios</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <asp:Panel runat="server" ID="pnlSeleccionar">
            <div class="row">
                <div class="col-3 ">
                    <asp:Label Text="Paciente" ID="lblCliente" runat="server" />
                    <asp:DropDownList cssClass="custom-select" runat="server" ID="ddlUsuarios" AutoPostBack="true" DataSourceID="SqlDataSource1" DataTextField="correo" DataValueField="idUsuario" ></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProyectoConnectionString %>" SelectCommand="SELECT * FROM [Usuario]"></asp:SqlDataSource>
                </div>
                <div class="col-2 mt-2">
                    <asp:Button ID="btnSeleccionar" Text="Seleccionar" CssClass="btn btn-primary mt-3" runat="server" OnClick="btnSeleccionar_Click"  />
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" Visible="false" ID="pnlDieta" CssClass=" mt-5">
            <asp:Label Text="nombre" ID="lblNombre" runat="server" />
            <div class="row">
                <div class="col-2">
                    <asp:Label Text="Peso" ID="lblPeso" runat="server" />
                    <asp:TextBox runat="server" ID="txtPeso" Visible="true" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
                </div>
                <div class="col-2">
                    <asp:Label Text="Altura" ID="lblAltura" runat="server" />
                    <asp:TextBox runat="server" ID="txtAltura" Visible="true" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
                </div>
                <div class="col-2">
                    <asp:Label Text="IMC Inicial" ID="lblIMCI" runat="server" />
                    <asp:TextBox runat="server" Enabled="false" ID="txtIMCI" Visible="true" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
                </div>
                <div class="col-2">
                    <asp:Label Text="IMC Actual" ID="lblIMCA" runat="server" />
                    <asp:TextBox runat="server" ID="txtIMCA" Visible="true" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
                </div>
                <div class="col-2">
                    <asp:Label Text="NAF" ID="lblNaf" runat="server" />
                    <asp:TextBox runat="server" ID="txtNaf" Visible="true" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
                </div>
                <div class="col-2">
                    <asp:Label Text="Resultado" ID="lblResultado" runat="server" />
                    <asp:TextBox runat="server" ID="txtResultado" Visible="true" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" Visible="false" ID="pnlPlan">
            <div class="row">
                <div class="col-3">
                    <asp:Label Text="Desayuno" runat="server" />
                    <asp:TextBox Height="150px" ID="txtDesayuno" runat="server" TextMode="MultiLine" CssClass="form-control" />
                </div>
                <div class="col-3">
                    <asp:Label Text="Comida" runat="server" />
                    <asp:TextBox Height="150px" ID="txtComida" runat="server" TextMode="MultiLine" CssClass="form-control" />
                </div>
                <div class="col-3">
                    <asp:Label Text="Cena" runat="server" />
                    <asp:TextBox Height="150px" ID="txtCena" runat="server" TextMode="MultiLine" CssClass="form-control" />
                </div>
                <div class="col-3">
                    <asp:Label Text="Colaciones" runat="server" />
                    <asp:TextBox Height="600px" ID="txtColaciones" runat="server" TextMode="MultiLine" CssClass="form-control" />
                </div>
            </div>
            <div class="row">
                <div class="col-2">
                    <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-primary mt-3" runat="server"  OnClick="btnGuardar_Click"  />
                </div>
            </div>
        </asp:Panel>
        <div id="mensaje" visible="false" runat="server" class="alert alert-success mt-3" role="alert">
                        
            <div class="row">
            <div class="col-10 mt-1">
                <asp:Label Text="Datos guardados exitosamente" runat="server" ID="Label1"/>
            </div>
                <div class="col-2">
                    <asp:Button Text="Cerrar" CssClass="btn   btn-dark" runat="server" ID="Button1" OnClick="btnError_Click" />
                </div>
            </div>
        </div>
        <div id="mensajeError" visible="false" class="alert mt-3 alert-danger mt-1" runat="server" role="alert">
            <div class="row">
                <div class="col-10">
                    <asp:Label Text="" runat="server" ID="lblError"/>
                </div>
                <div class="col-2">
                    <asp:Button Text="Cerrar" CssClass="btn  btn-dark" runat="server" ID="btnError" OnClick="btnError_Click" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
