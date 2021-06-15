<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="VIEW.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro</title>
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
                                <asp:TextBox ID="txtNombre" class="form-control" placeholder="Juan" runat="server"></asp:TextBox>
						    </div>
                            <asp:RequiredFieldValidator 
                                ID="rfvNombre" 
                                runat="server" 
                                ErrorMessage="* Campo requerido" 
                                ControlToValidate="txtNombre" 
                                ForeColor="#CC3300" 
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="input-group mb-3 col-md-3">
                            <div class="input-group-append">
							    <span class="input-group-text"><label>Apellido Paterno</label></span>
                                <asp:TextBox ID="txtaPaterno" class="form-control" placeholder="Hernandez" runat="server"></asp:TextBox>
							</div>
                            <asp:RequiredFieldValidator 
                                ID="rfvAPaterno" 
                                runat="server" 
                                ErrorMessage="* Campo requerido" 
                                ControlToValidate="txtaPaterno" 
                                ForeColor="#CC3300" 
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="input-group mb-3 col-md-3">
                            <div class="input-group-append">
							    <span class="input-group-text"><label>Apellido Materno</label></span>
                                <asp:TextBox ID="txtaMaterno" class="form-control" placeholder="Perez" runat="server"></asp:TextBox>
							</div>
                            
                            <asp:RequiredFieldValidator 
                                ID="rfvAMaterno" 
                                runat="server" 
                                ErrorMessage="* Campo requerido" 
                                ControlToValidate="txtaMaterno" 
                                ForeColor="#CC3300" 
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="input-group mb-3 col-md-3">
                            <div class="input-group-append">
							    <span class="input-group-text"><label>Nacimiento</label></span>
                                
							</div>
                            <asp:TextBox ID="txtNacimiento" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator 
                                ID="rfvNacimiento" 
                                runat="server" 
                                ErrorMessage="* Campo requerido" 
                                ControlToValidate="txtNacimiento" 
                                ForeColor="#CC3300" 
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-row mb-4">
                        <div class="input-group col-md-3">
                            <div class="input-group-append">
							    <span class="input-group-text"><label>Genero</label></span>
							</div>
                            <asp:DropDownList cssClass="custom-select" runat="server" ID="ddlGenero" AutoPostBack="true" DataSourceID="SqlDataSource1" DataTextField="genero" DataValueField="idGenero"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProyectoConnectionString %>" SelectCommand="SELECT * FROM [Genero]"></asp:SqlDataSource>
                        </div>
                        <div class="input-group col-md-3">
                            <div class="input-group-append">
							    <span class="input-group-text"><label>Correo</label></span>
                                <asp:TextBox ID="txtCorreo" CssClass="form-control" placeholder="ejemplo@gmail.com" runat="server"></asp:TextBox>
							</div>
                            
                            <asp:RegularExpressionValidator 
                                ID="revEmail" 
                                runat="server" 
                                ErrorMessage="* Formato de Email incorrecto" 
                                ControlToValidate="txtCorreo" 
                                Display="Dynamic" 
                                ForeColor="#CC3300" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator 
                                ID="rfvEmail" 
                                runat="server" 
                                ErrorMessage="* Campo requerido" 
                                ControlToValidate="txtCorreo" 
                                ForeColor="#CC3300" 
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="input-group col-md-3">
                            <div class="input-group-append">
							    <span class="input-group-text"><label>Contraseña</label></span>
                                <asp:TextBox ID="txtContrasena" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
							</div>
                            <asp:RequiredFieldValidator 
                                ID="rfvContrasena" 
                                runat="server" 
                                ErrorMessage="* Campo requerido" 
                                ControlToValidate="txtContrasena" 
                                ForeColor="#CC3300" 
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="input-group col-md-3">
                            <div class="input-group-append">
							    <span class="input-group-text"><label>Telefono</label></span>
                                <asp:TextBox ID="txtTelefono" CssClass="form-control" placeholder="##########" runat="server"></asp:TextBox>
							</div>                            
                            <asp:RegularExpressionValidator 
                                ID="revPhone" 
                                runat="server" 
                                ErrorMessage="* Se requieren 10 digitos" 
                                ControlToValidate="txtTelefono" 
                                ForeColor="#FF3300" 
                                ValidationExpression="^\d{10}$" 
                                Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator 
                                ID="rfvTelefono" 
                                runat="server" 
                                ErrorMessage="* Campo requerido" 
                                ControlToValidate="txtTelefono" 
                                ForeColor="#CC3300" 
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <asp:Button ID="btnGuardar" class="btn btn-danger fa-pull-right " runat="server" Text="Registrarse!" OnClick="btnGuardar_Click" />
                    <div id="mensaje" visible="false" runat="server" class="alert alert-success mt-3" role="alert">
                        
                        <div class="row">
                            <div class="col-11 mt-1">
                                <asp:Label Text="Registrad@ correctamente!" runat="server" ID="Label1"/>
                            </div>
                            <div class="col-1">
                                <asp:Button Text="Cerrar" CssClass="btn  btn-outline-success" runat="server" ID="Button1" OnClick="btnError_Click" />
                            </div>
                        </div>
                    </div>
                    <div id="mensajeError" visible="false" class="alert mt-3 alert-danger mt-1" runat="server" role="alert">
                        <div class="row">
                            <div class="col-11">
                                <asp:Label Text="xDD" runat="server" ID="lblError"/>
                            </div>
                            <div class="col-1">
                                <asp:Button Text="Cerrar" CssClass="btn btn-outline-danger" runat="server" ID="btnError" OnClick="btnError_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
