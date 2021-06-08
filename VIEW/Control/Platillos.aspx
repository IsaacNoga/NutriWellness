<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Platillos.aspx.cs" Inherits="VIEW.Control.Platillos" %>
<%@ import Namespace="MODEL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Platillos</title>
</asp:Content>
<asp:Content ID="titulo" ContentPlaceHolderID="Titulo" runat="server">
    <a class="navbar-brand">Platillos</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="container-fluid">
            <div class="card">
                <div class="card-header card-header-primary">
                    <h4 class="card-title">Administración Platillos</h4>
                    <p class="card-category">Formulario</p>
                </div>
                <div class="card-body">
                    <div class="row mb-5">
                <div class="col-md-4 col-md-offset-4 mt-5 mb-5">
                    
                    <br />
                    Foto:
                    <asp:FileUpload ID="fuploadImagen" accept=".jpg" CssClass="form-control" runat="server" />
                    <br />
                    <br />
                    Nombre del Platillo:
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    Descripción:
                    <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Height="200px" Width="100%" CssClass="form-control"></asp:TextBox>
                    <br />
                    <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-success" runat="server" OnClick="btnAgregar_Click" />
                    <br />
                </div>
                <div class="col-md-4">
                    <br />
                    <br />
                    <asp:Image ImageUrl="~/Include/img/noImage.png" Width="350" ID="imgPreview" runat="server" />
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
            <div class="row mt-5">
                <div class="input-group input-group-sm mb-3 col-9">
                  <div class="input-group-prepend">
                    <span class="input-group-text" id="inputGroup-sizing-sm">Buscar Platillos</span>
                  </div>
                  <asp:TextBox runat="server" ID="txtCriterios" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
            
                </div>
                <div class="row col-3">
                    <asp:CheckBoxList ID="chbxEstado" runat="server">
                        <asp:ListItem Selected="True" Value="1"> Activos</asp:ListItem>
                        <asp:ListItem Value="0"> Inactivos</asp:ListItem>
                    </asp:CheckBoxList>
                    <asp:Button ID="btnBuscar" Text="Buscar" CssClass="btn btn-primary mt-1 ml-5" runat="server" OnClick="btnBuscar_Click" />
                </div>
            </div>
            
            <div class="row mt-4">
                <div class="col-7">
                    <asp:GridView id="gvPlatillos" CssClass="table table-bordered dataTable" AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:BoundField dataField="idPlatillo" HeaderText="Id" />
                            <asp:BoundField dataField="nombre" HeaderText="Nombre" />
                            <asp:BoundField dataField="descripcion" HeaderText="Descripcion"/>
                            <asp:TemplateField HeaderText="Foto">
                                <ItemTemplate>
                                    <img class="img-responsive" style="height:100px" src="data:image/jpg;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"imagen")) %>" /> 
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:ImageButton CommandArgument="<%#((Platillo)(Container.DataItem)).idPlatillo%>" imageUrl="~/Include/img/icons/visibility.png" Width="30" Height="30" ID="ImgBtnEliminar" runat="server" OnCommand="ImgBtnEliminar_Command" />
                                    <asp:ImageButton CommandArgument="<%#((Platillo)(Container.DataItem)).idPlatillo%>" ImageUrl="~/Include/img/icons/pencil.png" Width="30" Height="30" ID="ImgBtnModificar" runat="server" OnCommand="ImgBtnModificar_Command" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-5">
                    <asp:Panel runat="server" Visible="false" ID="pnlEditar">
                        <div class="col-9">
                            <h3>Editar</h3>
                            <div class="row input-group input-group-sm mb-3 ">
                                <asp:TextBox runat="server" ID="txtId" Visible="false" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
                                <div class="col-12 mb-3">
                                    <asp:Label Text="Nombre:" ID="lblNombre" Visible="true" CssClass="input-group-text" runat="server" />
                                    <asp:TextBox runat="server" ID="txtNombreEdit" Visible="true" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
                                </div>
                            </div>
                            <div class="row input-group input-group-sm ">
                                <div class="col-12 mb-3">
                                    <asp:Label Text="Descripción:" ID="lblDescripcion" Visible="true" CssClass="input-group-text" runat="server" />
                                    <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcionEdit" Visible="true" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
                                </div>
                            </div>
                            <div class="row input-group input-group-sm ">
                                <div class="col-12 mb-3">
                                    <asp:Label Text="Foto:" ID="lblImagen" Visible="true" CssClass="input-group-text" runat="server" />
                                    <asp:FileUpload ID="fuploadImagenEdit" accept=".jpg" CssClass="form-control" runat="server" />
                                </div>
                            </div>
                            <asp:Button ID="btnActualizar" Text="Actualizar" CssClass="btn btn-primary mt-3" runat="server" OnClick="btnActualizar_Click" />
                        </div>
                    </asp:Panel>
                </div>
            </div>
                </div>
            </div>
            
        </div>
    </form>
</asp:Content>
