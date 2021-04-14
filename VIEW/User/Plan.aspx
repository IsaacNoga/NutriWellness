<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.Master" AutoEventWireup="true" CodeBehind="Plan.aspx.cs" Inherits="VIEW.User.Plan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Plan</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    <a class="navbar-brand">Plan nutricional</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <asp:GridView id="gvPlan" CssClass="table table-bordered dataTable" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField dataField="Desayuno" HeaderText="Desayuno" />
                <asp:BoundField dataField="Comida" HeaderText="Comida" />
                <asp:BoundField dataField="Cena" HeaderText="Cena" />
                <asp:BoundField dataField="Colaciones" HeaderText="Colaciones" />
            </Columns>
        </asp:GridView>
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
        <asp:Panel runat="server" Visible="true" Enabled="false" ID="pnlDieta" CssClass=" mt-5">
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
    </form>
</asp:Content>
