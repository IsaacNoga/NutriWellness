<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="VIEW.Control.Usuarios" %>

<%@ Import Namespace="MODEL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Usuarios</title>
</asp:Content>
<asp:Content ID="titulo" ContentPlaceHolderID="Titulo" runat="server">
    <a class="navbar-brand">Usuarios</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="container-fluid">
            <div class="card">
                <div class="card-header card-header-primary">
                    <h4 class="card-title">Administración de pacientes</h4>
                    <p class="card-category">Formulario</p>
                </div>
                <div class="card-body">
                    <div class=" row">
                        <div class="col-3">
                            <div class="input-group input-group-sm mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="inputGroup-sizing-sm">Buscar</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtCriterios" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm" />
                            </div>
                            <asp:CheckBoxList ID="chbxEstado" runat="server">
                                <asp:ListItem Selected="True" Value="1"> Activos</asp:ListItem>
                                <asp:ListItem Value="0"> Inactivos</asp:ListItem>
                            </asp:CheckBoxList>
                            <asp:Button ID="btnBuscar" Text="Buscar" CssClass="btn btn-primary mt-1" runat="server" OnClick="btnBuscar_Click" />
                        </div>
                        <asp:Panel runat="server" Visible="false" ID="pnlEditar">
                            <div class="col-9">
                                <div class="row input-group input-group-sm mb-3 ">
                                    <asp:TextBox runat="server" ID="txtId" Visible="false" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm" />
                                    <div class="col-4">
                                        <asp:Label Text="Nombre" ID="lblNombre" Visible="true" CssClass="input-group-text" runat="server" />
                                        <asp:TextBox runat="server" ID="txtNombre" Visible="true" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm" />
                                        <asp:RegularExpressionValidator ID="revNombre" runat="server" ErrorMessage="* No valido" ControlToValidate="txtNombre" Display="Dynamic" ForeColor="#FF3300" ValidationExpression="^[A-Z][a-zA-Z]+$"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="* Campo requerido" ControlToValidate="txtNombre" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-4">
                                        <asp:Label Text="Primer apellido" ID="lblApellido1" Visible="true" CssClass="input-group-text" runat="server" />
                                        <asp:TextBox runat="server" ID="txtApellido1" Visible="true" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm" />
                                        <asp:RegularExpressionValidator ID="revApellido1" runat="server" ErrorMessage="* No valido" ControlToValidate="txtApellido1" Display="Dynamic" ForeColor="#FF3300" ValidationExpression="^[A-Z][a-zA-Z]+$"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="rfvApellido1" runat="server" ErrorMessage="* Campo requerido" ControlToValidate="txtApellido1" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-4">
                                        <asp:Label Text="Segundo apellido" ID="lblApellido2" Visible="true" CssClass="input-group-text" runat="server" />
                                        <asp:TextBox runat="server" ID="txtApellido2" Visible="true" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm" />
                                        <asp:RegularExpressionValidator ID="revApellido2" runat="server" ErrorMessage="* No valido" ControlToValidate="txtApellido2" Display="Dynamic" ForeColor="#FF3300" ValidationExpression="^[A-Z][a-zA-Z]+$"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="rfvApellido2" runat="server" ErrorMessage="* Campo requerido" ControlToValidate="txtApellido2" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row input-group input-group-sm ">
                                    <div class="col-6">
                                        <asp:Label Text="Correo" ID="lblCorreo" Visible="true" CssClass="input-group-text" runat="server" />
                                        <asp:TextBox runat="server" ID="txtCorreo" Visible="true" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm" />
                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="* Formato de Email incorrecto" ControlToValidate="txtCorreo" Display="Dynamic" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="* Campo requerido" ControlToValidate="txtCorreo" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-6">
                                        <asp:Label Text="Telefono" ID="lblTelefono" Visible="true" CssClass="input-group-text" runat="server" />
                                        <asp:TextBox runat="server" ID="txtTelefono" Visible="true" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm" />
                                        <asp:RegularExpressionValidator ID="revPhone" runat="server" ErrorMessage="* Se requieren 10 digitos" ControlToValidate="txtTelefono" ForeColor="#FF3300" ValidationExpression="^\d{10}$" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ErrorMessage="* Campo requerido" ControlToValidate="txtTelefono" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:Button ID="btnActualizar" Text="Actualizar" CssClass="btn btn-primary mt-3" runat="server" OnClick="btnActualizar_Click" />
                                <asp:Button ID="btnCancelarEdicion" Text="Cancelar" CssClass="btn btn-danger mt-3" runat="server" OnClick="btnCancelarEdicion_Click" />
                            </div>
                        </asp:Panel>
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
                    <div class="mt-5">
                        <asp:GridView ID="gvUsuarios" CssClass="table table-hover dataTable" AutoGenerateColumns="false" runat="server">
                            <Columns>
                                <asp:BoundField DataField="idUsuario" HeaderText="Id" />
                                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="aPaterno" HeaderText="Apellido Paterno" />
                                <asp:BoundField DataField="aMaterno" HeaderText="Apellido Materno" />
                                <asp:BoundField DataField="correo" HeaderText="Correo" />
                                <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                                <asp:TemplateField HeaderText="Edad">
                                    <ItemTemplate>
                                        <%# CalculateAge(Convert.ToDateTime(Eval("Nacimiento"))) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:ImageButton CommandArgument="<%#((Usuario)(Container.DataItem)).idUsuario%>" ImageUrl="~/Include/img/icons/delete.png" Width="30" Height="30" ID="ImgBtnEliminar" runat="server" OnCommand="ImgBtnEliminar_Command" />
                                        <asp:ImageButton CommandArgument="<%#((Usuario)(Container.DataItem)).idUsuario%>" ImageUrl="~/Include/img/icons/edit.png" Width="30" Height="30" ID="ImgBtnModificar" runat="server" OnCommand="ImgBtnModificar_Command" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

    </form>
</asp:Content>
