<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="VIEW.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" href="Include/css/Registro.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-5 mt-5">
        <div class="d-flex justify-content-center ">
            <div class="user_card">
                <div class="d-flex justify-content-center">
					<div class="brand_logo_container">
						<img src="include/img/logo.png" class="brand_logo" alt="Logo"/>
					</div>
				</div>
                <div class=" justify-content-center form_container">
                    <!--Registrotext-->
                    <div class="form-row mb-4"> 
                        <div class="input-group mb-3 col-md-3">        
                        <div class="input-group-append">
						    <span class="input-group-text"><label>Nombre</label></span>
						</div>
                            <asp:TextBox ID="txtNombre" class="form-control" placeholder="Juan" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-group mb-3 col-md-3">
                            <div class="input-group-append">
							    <span class="input-group-text"><label>Primer Apellido</label></span>
							</div>
                            <asp:TextBox ID="txtaPaterno" class="form-control" placeholder="Hernandez" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-group mb-3 col-md-3">
                            <div class="input-group-append">
							    <span class="input-group-text"><label>Segundo Apellido</label></span>
							</div>
                            <asp:TextBox ID="txtaMaterno" class="form-control" placeholder="Perez" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-group mb-3 col-md-3">
                            <div class="input-group-append">
							    <span class="input-group-text"><label>Nacimiento</label></span>
							</div>
                            <asp:TextBox ID="txtNacimiento" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                            
                        </div>
                    </div>
                    <div class="form-row mb-4">
                        <div class="input-group col-md-4">
                            <div class="input-group-append">
							    <span class="input-group-text"><label>Correo</label></span>
							</div>
                            <asp:TextBox ID="txtCorreo" CssClass="form-control" placeholder="ejemplo@gmail.com" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-group col-md-4">
                            <div class="input-group-append">
							    <span class="input-group-text"><label>Contraseña</label></span>
							</div>
                            <asp:TextBox ID="txtContrasena" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                        </div>
                        <div class="input-group col-md-4">
                            <div class="input-group-append">
							    <span class="input-group-text"><label>Telefono</label></span>
							</div>
                            <asp:TextBox ID="txtTelefono" CssClass="form-control" placeholder="##########" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button ID="btnGuardar" class="btn btn-danger " runat="server" Text="Registrarse!" OnClick="btnGuardar_Click" />
                    <div id="mensaje" visible="false" runat="server" class="alert alert-success mt-3" role="alert">
                        Registrad@!
                    </div>
                    <div id="mensajeError" visible="false" class="alert mt-3 alert-danger mt-1" runat="server" role="alert"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
