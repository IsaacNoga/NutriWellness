<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Alimentos.aspx.cs" Inherits="VIEW.Control.Alimentos" %>
<%@ import Namespace="MODEL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Alimentos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Titulo" runat="server">
    <a class="navbar-brand">Alimentos</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="container-fluid">
            <div class="card">
                <div class="card-header card-header-primary">
                    <h4 class="card-title">Administración de alimentos</h4>
                    <p class="card-category">Formulario</p>
                </div>
                <div class="card-body">
                    <asp:Panel runat="server" ID="pnlAgregar" Visible="false">
            <div class="row">
                <div class="col-3">
                    <asp:Label Text="Nombre" runat="server" />
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"/>
                    <asp:Label Text="Cantidad Sugerida" runat="server" />
                    <asp:TextBox runat="server" ID="txtCantidadSu" CssClass="form-control"/>
                    <asp:Label Text="Unidad" runat="server" />
                    <asp:TextBox runat="server" ID="txtUnidad" CssClass="form-control"/>
                    <asp:Label Text="Peso bruto recomendado (g)" runat="server" />
                    <asp:TextBox runat="server" ID="txtPesoBruto" CssClass="form-control"/>
                </div>
                <div class="col-3">
                    <asp:Label Text="Peso Neto (g)" runat="server" />
                    <asp:TextBox runat="server" ID="txtPesoNeto" CssClass="form-control"/>
                    <asp:Label Text="Energia (Kcal)" runat="server" />
                    <asp:TextBox runat="server" ID="txtEnergia" CssClass="form-control"/>
                    <asp:Label Text="Proteina (g)" runat="server" />
                    <asp:TextBox runat="server" ID="txtProteina" CssClass="form-control"/>
                    <asp:Label Text="Lipidos (g)" runat="server" />
                    <asp:TextBox runat="server" ID="txtLipidos" CssClass="form-control"/>
                </div>
                <div class="col-3">
                    <asp:Label Text="Hidratos de carbono (g)" runat="server" />
                    <asp:TextBox runat="server" ID="txtHidratos" CssClass="form-control"/>
                    <asp:Label Text="Fibra (g)" runat="server" />
                    <asp:TextBox runat="server" ID="txtFibra" CssClass="form-control"/>
                    <asp:Label Text="Vitamina A (µg RE)" runat="server" />
                    <asp:TextBox runat="server" ID="txtVitaminaA" CssClass="form-control"/>
                    <asp:Label Text="Acido Folico (µg)" runat="server" />
                    <asp:TextBox runat="server" ID="txtAcidoFolico" CssClass="form-control"/>
                </div>
                <div class="col-3">
                    <asp:Label Text="Hierro (mg)" runat="server" />
                    <asp:TextBox runat="server" ID="txtHierro" CssClass="form-control"/>
                    <asp:Label Text="Potasio (mg)" runat="server" />
                    <asp:TextBox runat="server" ID="txtPotasio" CssClass="form-control"/>
                    <asp:Label Text="Indice Glicemico" runat="server" />
                    <asp:TextBox runat="server" ID="txtIndiceGlic" CssClass="form-control"/>
                    <asp:Label Text="Carga Glicemica" runat="server" />
                    <asp:TextBox runat="server" ID="txtCargaGlic" CssClass="form-control"/>
                </div>
                <div class="col-2">
                    <asp:Button ID="btnAgregar" Text="Agregar" CssClass="btn btn-success" runat="server" OnClick="btnAgregar_Click" />
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlEditar" Visible="false">
            <asp:TextBox runat="server" ID="TextBox0" CssClass="form-control" Visible="false"/>
            <div class="row">
                <div class="col-3">
                    <asp:Label Text="Nombre" runat="server" />
                    <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control"/>
                    <asp:Label Text="Cantidad Sugerida" runat="server" />
                    <asp:TextBox runat="server" ID="TextBox16" CssClass="form-control"/>
                    <asp:Label Text="Unidad" runat="server" />
                    <asp:TextBox runat="server" ID="TextBox15" CssClass="form-control"/>
                    <asp:Label Text="Peso bruto recomendado (g)" runat="server" />
                    <asp:TextBox runat="server" ID="TextBox7" CssClass="form-control"/>
                </div>
                <div class="col-3">
                    <asp:Label Text="Peso Neto" runat="server" />
                    <asp:TextBox runat="server" ID="TextBox8" CssClass="form-control"/>
                    <asp:Label Text="Energia (Kcal)" runat="server" />
                    <asp:TextBox runat="server" ID="TextBox9" CssClass="form-control"/>
                    <asp:Label Text="Proteina (g)" runat="server" />
                    <asp:TextBox runat="server" ID="TextBox10" CssClass="form-control"/>
                    <asp:Label Text="Lipidos (g)" runat="server" />
                    <asp:TextBox runat="server" ID="TextBox11" CssClass="form-control"/>
                </div>
                <div class="col-3">
                    <asp:Label Text="Hidratos de carbono (g)" runat="server" />
                    <asp:TextBox runat="server" ID="TextBox12" CssClass="form-control"/>
                    <asp:Label Text="Fibra (g)" runat="server" />
                    <asp:TextBox runat="server" ID="TextBox6" CssClass="form-control"/>
                    <asp:Label Text="Vitamina A" runat="server" />
                    <asp:TextBox runat="server" ID="TextBox5" CssClass="form-control"/>
                    <asp:Label Text="Acido Folico (µg)" runat="server" />
                    <asp:TextBox runat="server" ID="TextBox4" CssClass="form-control"/>
                </div>
                <div class="col-3">
                    <asp:Label Text="Hierro (mg)" runat="server" />
                    <asp:TextBox runat="server" ID="TextBox3" CssClass="form-control"/>
                    <asp:Label Text="Potasio (mg)" runat="server" />
                    <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control"/>
                    <asp:Label Text="Indice Glicemico" runat="server" />
                    <asp:TextBox runat="server" ID="TextBox14" CssClass="form-control"/>
                    <asp:Label Text="Carga Glicemica" runat="server" />
                    <asp:TextBox runat="server" ID="TextBox13" CssClass="form-control"/>
                </div>
                <div class="col-2">
                    <asp:Button ID="btnConfirmar" Text="Confirmar" CssClass="btn btn-success" runat="server" OnClick="btnConfirmar_Click"/>
                </div>
            </div>
        </asp:Panel>
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
        <asp:Panel runat="server" ID="pnlAlimentos" Visible="true">
            
            <div class="row mt-3">
                <asp:Label Text="Criterios:" runat="server" />
                <div class="col-4 mt-1">
                    <asp:TextBox runat="server" ID="txtCriterios" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
                </div>
                <div class="col-2">
                    <asp:Button ID="btnBuscar" Text="Buscar" CssClass="btn btn-primary mt-1 ml-5" runat="server" OnClick="btnBuscar_Click" />
                </div>
                <div class="col-2">
                    <asp:Button Text="Agregar Alimento" CssClass="btn btn-primary" runat="server" id="btnAgregarA" OnClick="btnAgregarA_Click" />
                </div>
            </div>
            <div class="mt-3">
                <asp:GridView id="gvAlimentos" CssClass="table table-bordered dataTable" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField dataField="idAlimento" HeaderText="Id" />
                        <asp:BoundField dataField="nombre" HeaderText="Nombre" />
                        <asp:BoundField dataField="cantidadSu" HeaderText="Cantidad Sugerida" />
                        <asp:BoundField dataField="unidad" HeaderText="Unidad"/>
                        <asp:BoundField dataField="pesoBruto" HeaderText="Peso Bruto" />
                        <asp:BoundField dataField="pesoNeto" HeaderText="Peso Neto" />
                        <asp:BoundField dataField="energia" HeaderText="Energia"/>
                        <asp:BoundField dataField="protenia" HeaderText="Proteina" />
                        <asp:BoundField dataField="lipidos" HeaderText="Lipidos" />
                        <asp:BoundField dataField="hidratosDC" HeaderText="Hidratos DC" />
                        <asp:BoundField dataField="fibra" HeaderText="Fibra"/>
                        <asp:BoundField dataField="vitmaminaA" HeaderText="Vitmamina A" />
                        <asp:BoundField dataField="acidoFolico" HeaderText="Acido Folico" />
                        <asp:BoundField dataField="hierro" HeaderText="Hierro" />
                        <asp:BoundField dataField="potasio" HeaderText="Potasio"/>
                        <asp:BoundField dataField="indiceGlic" HeaderText="Indice Glicemico" />
                        <asp:BoundField dataField="cargaGlic" HeaderText="Carga Glicemica"/>
                        
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:ImageButton CommandArgument="<%#((Alimento)(Container.DataItem)).idAlimento%>" ImageUrl="~/Include/img/icons/editar.png" Width="30" Height="30" ID="ImgBtnModificar" runat="server" OnCommand="ImgBtnModificar_Command" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </asp:Panel>
                </div>
            </div>
        </div>
        
        
        
    </form>
</asp:Content>
