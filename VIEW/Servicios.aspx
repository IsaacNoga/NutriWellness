<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="VIEW.Servicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Servicios</title>
    <link href="include/css/textCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container py-5 ">
        <h1 class="h1 cbase-oscuro mb-5">Servicios en línea:</h1>
        <div class="row mb-2">
            <div class="col-md-5">
                <h2 class="h2 cbase-oscuro"><i class="fas fa-utensils ico-footer"></i> Reto mensual</h2>
                
            </div>
            <div class="col-md-7 ">
                <p class="h4 cOscuro-claro">Se hace una Evaluación antropométrica y se aplica un cuestionario, en base a eso se realiza un plan de alimentación 100% personalizado de acuerdo a las necesidades y objetivos del paciente. 
                   Manual de recomendaciones generales. Contacto con paciente para resolución de dudas.</p>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-md-5 cbase-oscuro">
                <h2 class="h2"><i class="fas fa-brain ico-footer"></i> Consulta nutricional</h2>
            </div>
            <div class="col-md-7">
                <p class="h4 cOscuro-claro">
                    Se hace una Evaluación antropométrica y se aplica un cuestionario, en base a eso se realiza un plan de alimentación 100% personalizado de acuerdo a las necesidades y objetivos del paciente. 
                </p>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-md-5 cbase-oscuro">
                <h2 class="h2"><i class="fas fa-heartbeat ico-footer"></i> Evaluación antropométrica</h2>
            </div>
            <div class="col-md-7">
                <p class="h4 cOscuro-claro">
                    Se hace una evaluación de las diferentes medidas del paciente: peso, estatura, circunferencia de cintura, porcentaje de grasa, porcentaje de músculo, índice de masa corporal y grasa visceral. 
                </p>
            </div>
        </div>
    </div>
</asp:Content>
