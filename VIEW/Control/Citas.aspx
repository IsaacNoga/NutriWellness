<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Citas.aspx.cs" Inherits="VIEW.Control.Citas" %>

<%@ Import Namespace="MODEL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Citas</title>
</asp:Content>
<asp:Content ID="titulo" ContentPlaceHolderID="Titulo" runat="server">
    <a class="navbar-brand">Citas</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="container-fluid">
            <div class="card">
                <div class="card-header card-header-primary">
                    <h4 class="card-title">Administración de citas</h4>
                    <p class="card-category">Formulario</p>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-2">
                            <asp:Label Text="Paciente" ID="lblCliente" runat="server" />
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProyectoConnectionString %>" SelectCommand="SELECT * FROM [Usuario]"></asp:SqlDataSource>
                            <asp:DropDownList CssClass="custom-select" runat="server" ID="ddlUsuarios" AutoPostBack="true" DataSourceID="SqlDataSource1" DataTextField="Nombre" DataValueField="idUsuario">
                            </asp:DropDownList>
                        </div>
                        <div class="col-2">
                            <asp:Label Text="Día" ID="lbldia" runat="server" />
                            <asp:TextBox ID="txtDia" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-2">
                            <asp:Label Text="Hora" ID="lblhora" runat="server" />
                            <asp:TextBox ID="txtHora" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                        </div>
                        <div class="col-6">
                            <asp:Panel runat="server" ID="pnlEditar" Visible="false">
                                <asp:TextBox runat="server" ID="txtIdCita" Visible="false" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm" />
                                <div class="row">
                                    <div class="col-4">
                                        <asp:Label Text="Editar Día" runat="server" />
                                        <asp:TextBox ID="txtDiaEdit" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <asp:Label Text="Editar Hora" runat="server" />
                                        <asp:TextBox ID="txtHoraEdit" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <asp:Label Text="Editar Observación" runat="server" />
                                        <asp:TextBox ID="txtObservacion" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-4">
                                        <asp:Button ID="btnEditar" CssClass="form-control" Text="Guardar" runat="server" OnClick="btnEditar_Click" />
                                    </div>
                                    <div class="col-4">
                                        <asp:Button ID="btnCancelarEdicion" Text="Cancelar" CssClass="btn btn-danger mt-3" runat="server" OnClick="btnCancelarEdicion_Click" />
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col-2">
                            <asp:Button ID="btnAgregar" CssClass="btn btn-primary mt-3" Text="Agregar" runat="server" OnClick="btnAgregar_Click" />
                        </div>
                        <div class="col-3">
                            <div id="mensaje" visible="false" runat="server" class="alert alert-success mt-3" role="alert">
                                <div class="row">
                                    <div class="col-10 mt-1">
                                        <asp:Label Text="¡La cita se generó correctamente!" runat="server" ID="Label1" />
                                    </div>
                                    <div class="col-2">
                                        <asp:Button Text="Cerrar" CssClass="btn   btn-dark" runat="server" ID="Button1" OnClick="btnError_Click" />
                                    </div>
                                </div>
                            </div>
                            <div id="mensajeError" visible="false" class="alert mt-3 alert-danger mt-1" runat="server" role="alert">
                                <div class="row">
                                    <div class="col-10">
                                        <asp:Label Text="" runat="server" ID="lblError" />
                                    </div>
                                    <div class="col-2">
                                        <asp:Button Text="Cerrar" CssClass="btn  btn-dark" runat="server" ID="btnError" OnClick="btnError_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="input-group input-group-sm mb-3 col-9 mt-5">
                        <div class="input-group-prepend">
                            <span class="input-group-text" id="inputGroup-sizing-sm">Buscar</span>
                        </div>
                        <asp:TextBox runat="server" ID="txtCriterios" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm" />
                    </div>
                    <asp:CheckBoxList ID="chbxEstado" runat="server">
                        <asp:ListItem Selected="True" Value="1">Activos</asp:ListItem>
                        <asp:ListItem Value="0">Inactivos</asp:ListItem>
                    </asp:CheckBoxList>
                    <asp:Button ID="btnBuscar" Text="Buscar" CssClass="btn btn-primary mt-1 ml-5" runat="server" OnClick="btnBuscar_Click" />
                    <asp:GridView ID="gvCitas" CssClass="table table-hover dataTable" AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:BoundField DataField="idCita" HeaderText="Id Cita" />
                            <asp:BoundField DataField="idUsuario" HeaderText="Id Usuario" />
                            <asp:BoundField DataField="fecha" HeaderText="fecha" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="hora" HeaderText="hora" />
                            <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:ImageButton CommandArgument="<%#((Cita)(Container.DataItem)).idCita%>" ImageUrl="~/include/img/icons/check.png" Width="30" Height="30" ID="ImgBtnEliminar" runat="server" OnCommand="ImgBtnEliminar_Command" />
                                    <asp:ImageButton CommandArgument="<%#((Cita)(Container.DataItem)).idCita%>" ImageUrl="~/Include/img/icons/pencil.png" Width="30" Height="30" ID="ImgBtnModificar" runat="server" OnCommand="ImgBtnModificar_Command" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

    </form>
</asp:Content>
