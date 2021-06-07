<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="VIEW.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Inicio</title>
    <script src="include/js/jquery-3.4.1.min.js"></script>
    <link href="include/css/textCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Header -->
          <header class="backg-1 py-5 mb-5">
            <div class="container h-100">
              <div class="row h-100 align-items-center">
                <div class="col-lg-12">
                  <h1 class="display-4 header-text-1 mt-5 mb-2">Valora, protege y atiende tu salud</h1>
                  <p class="mb-5 header-text-2">Consulta medica profesional</p>
                </div>
              </div>
            </div>
          </header> 
    <div class="container">
            <div class="row">
              <div class="col-8 mb-5">
                  <h2 class="cOscuro-claro">¿Quién soy?</h2>
                  <hr/>
                  <div class="row ">
                      <div class="col-4">
                          <img src="include/img/logo5.png" width="200" alt="Alternate Text" />
                      </div>
                      <div class="col-8">
                          <p class="p"></p>
                        <p class="p"></p>
                        <p class="p"></p>
                      </div>
                  </div>
              </div>
              <div class="col-4 mb-5">
                <h2 class="h2 cOscuro-claro">Contacto:</h2>
                <hr/>
                <address>
                  <strong>Dirección</strong>
                  <br>Blv. Enrique Segoviano, 
                  <br>Centro, 83000 Hermosillo, Son.
                  <br>
                </address>
                <address>
                  <abbr title="">Teléfono: </abbr>
                  (662)4636874
                  <br>
                  <abbr title="">Correo: </abbr>
                  <a href="mailto:#">nutriologa.perla@gmail.com</a>
                </address>
              </div>
            </div>
            <!-- /.row -->
            <div id="servicios">
                <h2 class="cOscuro-claro">Servicios</h2>
                <hr />
                <div class="row">
                  <div class="col-md-4 mb-3">
                    <div class="card h-100">
                      <img class="card-img-top" src="include/img/svc1.jpg" alt="">
                      <div class="card-body">
                        <h4 class="card-title">Evaluación antropométrica</h4>
                        <p>Estas medidas sirven como un método de investigación del estado nutricional, así como para ayudar a evaluar el riesgo de enfermedades crónicas como la obesidad y las enfermedades cardíacas.</p>
                        <p class="card-text"></p>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-4 mb-3">
                    <div class="card h-100">
                      <img class="card-img-top" src="include/img/svc2.jpg" alt="">
                      <div class="card-body">
                        <h4 class="card-title">Consulta nutricional</h4>
                          <p>Consiste en realizar una evaluación del estado nutricional del paciente y, según los resultados, se realiza una planificación de alimentación. La dieta se tiene que adaptar a ti y no al revés.</p>
                        <p class="card-text"></p>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-4 mb-3">
                    <div class="card h-100">
                      <img class="card-img-top" src="include/img/svc3.jpg" alt="">
                      <div class="card-body">
                        <h4 class="card-title">Reto mensual</h4>
                        <p class="card-text">Para conseguir tus objetivos de peso, salud o rendimiento deportivo.</p>
                        <p class="card-text"></p>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="">
                    <a href="servicios.aspx" class="btn btn-primary">Más información!</a>
                </div>
            </div>
            
            
            <!-- /.row -->

          </div>

          <div class="container" id="Contacto">
              <hr />
                <div class="mb-5" style="margin-top: 55px; margin-bottom: 5px; min-height: 0px;">
                    <div class="">
                        <h2 class="h2 cOscuro-claro">Contactame!</h2>
                        <p style="text-align: center; font: normal 19px / 25px;">Llama o envíanos un mensaje</p>
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
                            <p style="font: normal 25px / 36px 'Roboto Slab', Helvetica, Arial, Verdana, sans-serif;">Envía tu mensaje</p>
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
