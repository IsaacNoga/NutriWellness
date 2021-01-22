﻿<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Mensajes.aspx.cs" Inherits="VIEW.Control.Mensajes" %>
<%@ import Namespace="MODEL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Mensajes</title>
</asp:Content>
<asp:Content ID="titulo" ContentPlaceHolderID="Titulo" runat="server">
    <a class="navbar-brand">Mensajes</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div>
            <div class="row mt-5">
                <div class="input-group input-group-sm mb-3 col-6">
                  <div class="input-group-prepend">
                    <span class="input-group-text" id="inputGroup-sizing-sm">Buscar</span>
                  </div>
                  <asp:TextBox runat="server" ID="txtCriterios" CssClass="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"/>
            
                </div>
                <div class="row col-3">
                    <asp:CheckBoxList ID="chbxEstado" runat="server">
                        <asp:ListItem Selected="True" Value="1"> Activos</asp:ListItem>
                        <asp:ListItem Value="0"> Leídos</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
                <div class="col-3">
                    <asp:Button ID="btnBuscar" Text="Buscar" CssClass="btn btn-primary mt-1 ml-5" runat="server" OnClick="btnBuscar_Click" />
                </div>
            </div>

            <div class="row">
                <div class="col-8">
                    <asp:GridView ID="gvMensajes" CssClass="table table-bordered dataTable" AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="correo" HeaderText="Correo" />
                            <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                            <asp:BoundField DataField="mensaje1" HeaderText="Mensaje" />
                            <asp:TemplateField HeaderText="Marcar como leído">
                                <ItemTemplate>
                                    <asp:ImageButton CommandArgument="<%#((Mensaje)(Container.DataItem)).idMensaje%>" imageUrl="~/Include/img/icons/check.png" Width="30" Height="30" ID="ImgBtnLeido" runat="server" OnCommand="ImgBtnLeido_Command"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</asp:Content>