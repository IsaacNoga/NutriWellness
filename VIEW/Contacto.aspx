<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="contacto.aspx.cs" Inherits="VIEW.contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Contacto</title>
    <link href="include/css/Estilos.css" rel="stylesheet" />
    <link href="include/css/textCss.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Montserrat&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container py-4" id="Contacto">
              
                <div class="mb-5" style="margin-top: 55px; margin-bottom: 5px; min-height: 0px;">
                    <div class="">
                        <h1 class="h1 cOscuro-claro ">Contacto</h1>
                        <hr />
                    </div>
                    <div class="redes p-3 backg-1 ">
                        <hr />
                        <div class="row">
                            <div class="col-md-4">
                                <a href="https://www.facebook.com/nutperlamedc/">
                                    <i class="fab fa-facebook-square ico-redes m-2"> Facebook</i>
                                </a>
                            </div>
                            <div class="col-md-4">
                                <a href="https://instagram.com/nutperlamedc">
                                    <i class="fab fa-instagram ico-redes m-2"> Instagram</i>
                                </a>
                            </div>
                            <div class="col-md-4">
                                <i class="fab fa-whatsapp ico-redes"> (662)4636874</i>
                            </div>
                        </div>
                        <hr />
                    </div>
                </div>
                <div class="row" style="margin-top: 0px; margin-bottom: 0px; min-height: 0px;">
                    <div class="wpb_column vc_column_container col-sm-8">
                        <div class="vc_column-inner">
                            <div class="wpb_wrapper">
                                <div class="wpb_gmaps_widget wpb_content_element">
                                    <div class="wpb_wrapper">
                                        <div class="wpb_map_wraper"> 
                                            <iframe width="100%" height="450" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.com/maps?width=100%25&amp;height=600&amp;hl=es&amp;q=Hermosillo+(Mi%20nombre%20de%20egocios)&amp;t=&amp;z=14&amp;ie=UTF8&amp;iwloc=B&amp;output=embed"></iframe>
                                            <!--<iframe src="https://maps.google.com/maps?width=100%&height=600&hl=es&q=Ni%C3%B1os%20H%C3%A9roes%20%23118%2C%20Centro%2C%2083000%20Hermosillo%2C%20Son.+(Nutri%C3%B3loga%20Lorena%20Romero)&ie=UTF8&t=&z=16&iwloc=B&output=embed" width="600" height="450" frameborder="0" style="border: 0px; pointer-events: none;" allowfullscreen=""></iframe>-->
                                        </div>
                                    </div>
                                </div>
                                <div class="vc_empty_space" style="height: 50px">
                                    <span class="vc_empty_space_inner"></span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="mb-3">
                            <p class="h2 cOscuro-claro">Envía tu mensaje</p>
                        </div>
                            <div role="form" class="wpcf7" id="wpcf7-f35569-p36084-o1" lang="en-US" dir="ltr">
                                <p>
                                    <asp:TextBox ID="txtNombre" class="form-control" placeholder="Nombre" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="* Campo requerido" ControlToValidate="txtNombre" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                                </p>
                                <p>
                                    <asp:TextBox ID="txtEmail" class="form-control" placeholder="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="* Campo requerido" ControlToValidate="txtEmail" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                                </p>
                                <p>
                                    <asp:TextBox ID="txtTelefono" class="form-control" placeholder="Telefono" runat="server"></asp:TextBox>
                                </p>
                                <p>
                                    <asp:TextBox ID="txtMensaje" CssClass="form-control" placeholder="¿En qué te podemos ayudar?" runat="server" TextMode="MultiLine" Height="150px" Width="80%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvMensaje" runat="server" ErrorMessage="* Campo requerido" ControlToValidate="txtMensaje" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                                </p>
                                <p>
                                    <asp:Button ID="btnEnviar" CssClass="btn btn-info" Text="Enviar" runat="server" OnClick="btnEnviar_Click" />
                                </p>
                                    <asp:CheckBox Id="chbxTerminos" Checked="true" Text="" runat="server" />
                                    <asp:Label Text="Acepto la <a href = 'PoliticaDePrivacidad.aspx' target=_blank> Politica de Privacidad </a>" runat="server" />
                            </div>
                        <div class="vc_empty_space" style="height: 50px">
                            <span class="vc_empty_space_inner"></span>
                        </div>
                        <div id="mensaje" visible="false" runat="server" class="alert alert-success mt-1" role="alert">
                          <h4 class="alert-heading">Enviado!</h4>
                          <hr>
                          <p class="mb-0">Gracias por tu mensaje, me se contactaré contigo en breve.</p>
                        </div>
                        <div id="mensajeError" visible="false" class="alert mt-3 alert-danger mt-1" runat="server" role="alert">
                            <div class="row">
                                <div class="col-8">
                                    <asp:Label Text="Debe aceptar la politica de privacidad" runat="server" ID="lblError"/>
                                </div>
                                <div class="col-1 mt-1">
                                    <asp:Button Text="Cerrar" CssClass="btn btn-outline-danger" runat="server" ID="btnError" OnClick="btnError_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
          </div>
</asp:Content>
