<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Mensajes.aspx.cs" Inherits="VIEW.Control.Mensajes" %>

<%@ Import Namespace="MODEL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Mensajes</title>
</asp:Content>
<asp:Content ID="titulo" ContentPlaceHolderID="Titulo" runat="server">
    <a class="navbar-brand">Mensajes</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="container-fluid">
            <div class="card">
                <div class="card-header card-header-primary">
                    <h4 class="card-title">Consulta de mensajes</h4>
                    <p class="card-category">Se muestran los mensajes que se envian en la sección de contacto</p>
                </div>
                <div class=" card-body">
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
                    <div class="row">
                        <div class="col-1"></div>
                        <div class="col-10">
                            <asp:GridView ID="gvMensajes" CssClass="table table-hover dataTable" AutoGenerateColumns="false" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="correo" HeaderText="Correo" />
                                    <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                                    <asp:BoundField DataField="mensaje1" HeaderText="Mensaje" />
                                    <asp:TemplateField HeaderText="Marcar como leído">
                                        <ItemTemplate>
                                            <asp:ImageButton CommandArgument="<%#((Mensaje)(Container.DataItem)).idMensaje%>" ImageUrl="~/Include/img/icons/check.png" Width="30" Height="30" ID="ImgBtnLeido" runat="server" OnCommand="ImgBtnLeido_Command" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="col-1"></div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</asp:Content>
