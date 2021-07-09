<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="VIEW.Servicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <title>Servicios</title>
    <link href="include/css/textCss.css" rel="stylesheet" />
    <link href="include/css/Servicios.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
	<section id="what-we-do" class="mt-5">
		<div class="container">
			<h2 class="section-title mb-2 h1">Servicios</h2>
			<p class="text-center text-muted h5">Ofrecemos los siguientes servicios a nuestros pacientes</p>
			<div class="row mt-5">
				<div class="col-xs-12 col-sm-6 col-md-4 col-lg-4 col-xl-4">
					<div class="card">
						<div class="card-block block-1">
							<h3 class="card-title">Evaluación antropométrica</h3>
							<p>
								Se hace una evaluación de las diferentes medidas del paciente: peso, estatura, circunferencia de cintura, porcentaje de grasa, porcentaje de músculo, índice de masa corporal y grasa visceral. 
							</p>
							<%--<a href="https://www.fiverr.com/share/qb8D02" title="Read more" class="read-more" >Read more<i class="fa fa-angle-double-right ml-2"></i></a>--%>
						</div>
					</div>
				</div>
				<div class="col-xs-12 col-sm-6 col-md-4 col-lg-4 col-xl-4">
					<div class="card">
						<div class="card-block block-2">
							<h3 class="card-title">Reto mensual</h3>
							<p class="cOscuro-claro">Se hace una Evaluación antropométrica y se aplica un cuestionario, en base a eso se realiza un plan de alimentación 100% personalizado de acuerdo a las necesidades y objetivos del paciente. 
								 Manual de recomendaciones generales. Contacto con paciente para resolución de dudas.
							</p>
							<%--<a href="https://www.fiverr.com/share/qb8D02" title="Read more" class="read-more" >Read more<i class="fa fa-angle-double-right ml-2"></i></a>--%>
						</div>
					</div>
				</div>
				<div class="col-xs-12 col-sm-6 col-md-4 col-lg-4 col-xl-4">
					<div class="card">
						<div class="card-block block-3">
							<h3 class="card-title">Consulta nutricional</h3>
							<p class="cOscuro-claro">
								Se hace una Evaluación antropométrica y se aplica un cuestionario, en base a eso se realiza un plan de alimentación 100% personalizado de acuerdo a las necesidades y objetivos del paciente. 
							</p>
							<%--<a href="https://www.fiverr.com/share/qb8D02" title="Read more" class="read-more" >Read more<i class="fa fa-angle-double-right ml-2"></i></a>--%>
						</div>
					</div>
				</div>
			</div>
		</div>	
	</section>
    <br />
    <br />
    <br />
</asp:Content>
