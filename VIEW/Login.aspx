<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VIEW.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" href="Include/css/Login.css" rel="stylesheet" />
    <title>Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-5">
        <div class="justify-content-center d-flex py-5">
            <div class="user_card mb-5">
                <div class="d-flex justify-content-center">
                    <div class="brand_logo_container">
                        <img src="include/img/logo.png" class="brand_logo p-1" />
                    </div>
                    <div class="justify-content-center form-container">
                        
                        <div class="input-group mb-3">
                            <div class="input-group-append">
                                <span class="input-group-text"><i class="fas fa-user"></i></span>
                            </div>
                            <asp:TextBox ID="txtEmail" type="email" CssClass="form-control" class="form-control input_user" runat="server" placeholder="Correo"></asp:TextBox>
                        </div>
                        <div class="input-group mb-3">
                            <div class="input-group-append">
                                <span class="input-group-text"><i class="fas fa-key"></i></span>
                            </div>
							<asp:TextBox ID="txtContrasena" type="password" CssClass="form-control" TextMode="Password" class="form-control input_pass" runat="server" placeholder="Contraseña"></asp:TextBox>
                        </div>
                        <div class="d-flex justify-content-center mt-3 login_container">
					        <asp:Button ID="btnIngresar" class="btn login_btn" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
				        </div>
                    </div>
                </div>
                <%--<div class="d-flex justify-content-center links">
                    <a href="LoginAdmin.aspx"><i class="fas fa-user-cog ico-log"> Entrar como Administrador</i></a>
                </div>--%>
            </div>
        </div>
        <div id="mensajeError" visible="false" class="alert mt-3 alert-danger mt-1" runat="server" role="alert">
                        <div class="row">
                            <div class="col-11">
                                <asp:Label Text="Correo y/o contraseña Invalida" runat="server" ID="lblError"/>
                            </div>
                            <div class="col-1">
                                <asp:Button Text="Cerrar" CssClass="btn btn-outline-danger" runat="server" ID="btnError" OnClick="btnError_Click" />
                            </div>
                        </div>
                    </div>
        <div class="mt-4">
		    <div class="d-flex justify-content-center links">
                <p>¿No tienes cuenta?</p>
		    </div>
            <div class="d-flex justify-content-center links">
                <a href="Registro.aspx" class="ml-2 registro ">Registrate!</a>
            </div>
		</div>

    </div>
</asp:Content>
