<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="VIEW.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <link href="include/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="include/css/index.css" rel="stylesheet" />
    <link type="text/css" href="Include/fontawesome/css/all.css" rel="stylesheet" />

    <script src="include/vendor/jquery/jquery.min.js"></script>
    <script src="include/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
          <nav class="navbar navbar-expand-lg navbar-dark nav-color fixed-top">
            <div class="container">
              <a class="navbar-brand" href="#">
                  <img src="include/img/logo.png" width="130px" alt="Alternate Text" /></a>
              <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
              </button>
              <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="navbar-nav ml-auto">
                  <li class="nav-item active">
                    <a class="nav-link" href="#">Home
                      <span class="sr-only">(current)</span>
                    </a>
                  </li>
                  <li class="nav-item">
                    <a class="nav-link" href="#">About</a>
                  </li>
                  <li class="nav-item">
                    <a class="nav-link" href="#">Services</a>
                  </li>
                  <li class="nav-item">
                    <a class="nav-link" href="#">Contact</a>
                  </li>
                </ul>
              </div>
            </div>
          </nav>

          <!-- Header -->
          <header class="backg-1 py-5 mb-5">
            <div class="container h-100">
              <div class="row h-100 align-items-center">
                <div class="col-lg-12">
                  <h1 class="display-4 header-text-1 mt-5 mb-2">Valora, protege y atiende tu salud</h1>
                  <p class="mb-5 header-text-2">Consulta presencial y en línea</p>
                </div>
              </div>
            </div>
          </header>

          <!-- Page Content -->
          <div class="container">

            <div class="row">
              <div class="col-md-8 mb-5">
                  <h2>¿Quién soy?</h2>
                  <hr/>
                  <div class="row">
                      <div class="col-md-4">
                          <img src="include/img/lr-1.jpg" width="200" alt="Alternate Text" />
                        
                      </div>
                      <div class="col-md-8">
                          <p>Mi nombre es Lorena Romero.</p>
                        <p>Soy Licenciada en Ciencias Nutricionales, egresada de la Universidad de Sonora.</p>
                        <p>Cédula profesional 045272.</p>
                      </div>
                  </div>
              </div>
              <div class="col-md-4 mb-5">
                <h2>Contacto:</h2>
                <hr/>
                <address>
                  <strong>Dirección</strong>
                  <br>Niños Héroes #118, 
                  <br>Centro, 83000 Hermosillo, Son.
                  <br>
                </address>
                <address>
                  <abbr title="">Teléfono: </abbr>
                  662 316 6892
                  <br>
                  <abbr title="">Correo: </abbr>
                  <a href="mailto:#">nutriologa.lorenaromero@gmail.com</a>
                </address>
              </div>
            </div>
            <!-- /.row -->

            <div class="row">
              <div class="col-md-4 mb-5">
                <div class="card h-100">
                  <img class="card-img-top" src="https://placehold.it/300x200" alt="">
                  <div class="card-body">
                    <h4 class="card-title">Card title</h4>
                    <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente esse necessitatibus neque sequi doloribus.</p>
                  </div>
                  <div class="card-footer">
                    <a href="#" class="btn btn-primary">Find Out More!</a>
                  </div>
                </div>
              </div>
              <div class="col-md-4 mb-5">
                <div class="card h-100">
                  <img class="card-img-top" src="https://placehold.it/300x200" alt="">
                  <div class="card-body">
                    <h4 class="card-title">Card title</h4>
                    <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente esse necessitatibus neque sequi doloribus totam ut praesentium aut.</p>
                  </div>
                  <div class="card-footer">
                    <a href="#" class="btn btn-primary">Find Out More!</a>
                  </div>
                </div>
              </div>
              <div class="col-md-4 mb-5">
                <div class="card h-100">
                  <img class="card-img-top" src="https://placehold.it/300x200" alt="">
                  <div class="card-body">
                    <h4 class="card-title">Card title</h4>
                    <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente esse necessitatibus neque.</p>
                  </div>
                  <div class="card-footer">
                    <a href="#" class="btn btn-primary">Find Out More!</a>
                  </div>
                </div>
              </div>
            </div>
            <!-- /.row -->

          </div>

          <div class="container" id="Contacto">
              <hr />
                <div class="mb-5" style="margin-top: 55px; margin-bottom: 5px; min-height: 0px;">
                    <div class="">
                        <h2 class="h2">Contactame!</h2>
                        <p style="text-align: center; font: normal 19px / 25px;">Llama al 662 316 6892 o envíanos un mensaje</p>
                    </div>
                </div>
                <div class="row" style="margin-top: 0px; margin-bottom: 0px; min-height: 0px;">
                    <div class="wpb_column vc_column_container col-sm-8">
                        <div class="vc_column-inner">
                            <div class="wpb_wrapper">
                                <div class="wpb_gmaps_widget wpb_content_element">
                                    <div class="wpb_wrapper">
                                        <div class="wpb_map_wraper"> 
                                            <iframe src="https://maps.google.com/maps?width=100%&height=600&hl=es&q=Ni%C3%B1os%20H%C3%A9roes%20%23118%2C%20Centro%2C%2083000%20Hermosillo%2C%20Son.+(Nutri%C3%B3loga%20Lorena%20Romero)&ie=UTF8&t=&z=16&iwloc=B&output=embed" width="600" height="450" frameborder="0" style="border: 0px; pointer-events: none;" allowfullscreen=""></iframe>
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
                                </p>
                                <p>
                                    <asp:TextBox ID="txtEmail" class="form-control" placeholder="Email" runat="server"></asp:TextBox>
                                </p>
                                <p>
                                    <asp:TextBox ID="txtTelefono" class="form-control" placeholder="Telefono" runat="server"></asp:TextBox>
                                </p>
                                <p>
                                    <asp:TextBox ID="txtMensaje" CssClass="form-control" placeholder="¿En qué te podemos ayudar?" runat="server" TextMode="MultiLine" Height="150px" Width="80%"></asp:TextBox>
                                </p>
                                <p>
                                    <asp:Button CssClass="btn btn-info" Text="Enviar" runat="server" />
                                </p>
                                    <asp:CheckBox Id="chbxTerminos" Checked="true" Text="" runat="server" />
                                    <asp:Label Text="Acepto la politica de privacidad" runat="server" />
                            </div>
                        <div class="vc_empty_space" style="height: 50px">
                            <span class="vc_empty_space_inner"></span>
                        </div>
                    </div>
                </div>
          </div>
          <!-- /.container -->

          <!-- Footer -->
          <footer class="py-5 bg-footer">
            <div class="container">
                <div class="row">
                    <div class="col-md-8 text-center">
                        <img src="include/img/logo.png" width="300px" alt="Alternate Text" />
                    </div>
                    <div class="col-md-4">
                        <a href="https://www.facebook.com/nutriologa.lorenaromero/">
                            <i class="fab fa-facebook-square ico-footer m-2"></i>
                        </a>
                        <a href="#">
                            <i class="fas fa-envelope-open-text ico-footer m-2"></i>
                        </a>
                        <a href="https://www.instagram.com/nutriologa.lorenaromero/">
                            <i class="fab fa-instagram ico-footer m-2"></i>
                        </a>
                    </div>
                </div>
              <p class="m-0 text-center text-white">&copy; Derechos de autor - Lorena Romero 2020</p>
            </div>
            <!-- /.container -->
          </footer>
    </form>
</body>
</html>
