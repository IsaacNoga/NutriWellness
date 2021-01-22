<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="VIEW.Control.Usuarios" %>
<%@ import Namespace="MODEL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Usuarios</title>
</asp:Content>
<asp:Content ID="titulo" ContentPlaceHolderID="Titulo" runat="server">
    <a class="navbar-brand">Usuarios</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form  runat="server">
        <div class=" row">
            <div class="col-3">
                <div class="input-group input-group-sm mb-3">
                  <div class="input-group-prepend">
                    <span class="input-group-text" id="inputGroup-sizing-sm">Buscar</span>
                  </div>
                  <asp:TextBox runat="server" ID="txtCriterios" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
            
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
                        <asp:TextBox runat="server" ID="txtId" Visible="false" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
                        <div class="col-4">
                            <asp:Label Text="Nombre" ID="lblNombre" Visible="true" CssClass="input-group-text" runat="server" />
                            <asp:TextBox runat="server" ID="txtNombre" Visible="true" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
                        </div>
                        <div class="col-4">
                            <asp:Label Text="Primer apellido" ID="lblApellido1" Visible="true" CssClass="input-group-text" runat="server" />
                            <asp:TextBox runat="server" ID="txtApellido1" Visible="true" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
                        </div>
                        <div class="col-4">
                            <asp:Label Text="Segundo apellido" ID="lblApellido2" Visible="true" CssClass="input-group-text" runat="server" />
                            <asp:TextBox runat="server" ID="txtApellido2" Visible="true" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
                        </div>
                    </div>
                    <div class="row input-group input-group-sm ">
                        <div class="col-6">
                            <asp:Label Text="Correo" ID="lblCorreo" Visible="true" CssClass="input-group-text" runat="server" />
                            <asp:TextBox runat="server" ID="txtCorreo" Visible="true" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
                        </div>
                        <div class="col-6">
                            <asp:Label Text="Telefono" ID="lblTelefono" Visible="true" CssClass="input-group-text" runat="server" />
                            <asp:TextBox runat="server" ID="txtTelefono" Visible="true" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
                        </div>
                    </div>
                    <asp:Button ID="btnActualizar" Text="Actualizar" CssClass="btn btn-primary mt-3" runat="server" OnClick="btnActualizar_Click"  />
                </div>
            </asp:Panel>
        </div>
        <div id="mensajeError" visible="false" class="alert mt-3 alert-danger mt-1" runat="server" role="alert">
        </div>
        <div class="mt-5">
            <asp:GridView id="gvUsuarios" CssClass="table table-bordered dataTable" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField dataField="idUsuario" HeaderText="Id" />
                    <asp:BoundField dataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField dataField="aPaterno" HeaderText="Apellido Paterno"/>
                    <asp:BoundField dataField="aMaterno" HeaderText="Apellido Materno" />
                    
                    <asp:BoundField DataField="correo" HeaderText="Correo" />
                    <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:ImageButton CommandArgument="<%#((Usuario)(Container.DataItem)).idUsuario%>" imageUrl="~/Include/img/icons/delete.png" Width="30" Height="30" ID="ImgBtnEliminar" runat="server" OnCommand="ImgBtnEliminar_Command" />
                            <asp:ImageButton CommandArgument="<%#((Usuario)(Container.DataItem)).idUsuario%>" ImageUrl="~/Include/img/icons/edit.png" Width="30" Height="30" ID="ImgBtnModificar" runat="server" OnCommand="ImgBtnModificar_Command" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</asp:Content>
