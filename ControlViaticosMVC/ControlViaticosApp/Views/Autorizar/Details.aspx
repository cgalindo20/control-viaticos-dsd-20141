﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.AutorizarWS.Autorizar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalles de Autorización de Vático</h2>

    <fieldset>
        <legend>Campos</legend>
        
        <div class="display-label"><b>Solicitud</b></div>
        <div class="display-field"><%: Model.CodigoSolicitud %></div>
        
        <div class="display-label"><b>Fecha Solicitud</b></div>
        <div class="display-field"><%: String.Format("{0:d}", Model.FechaSolicitud) %></div>

         <div class="display-label"><b>Origen</b></div>
        <div class="display-field"><%: Model.ubigeoOrigen.NoDescripcion %></div>
        
        <div class="display-label"><b>Destino</b></div>
        <div class="display-field"><%: Model.ubigeoDestino.NoDescripcion%></div>
        
        <div class="display-label"><b>Fecha Salida</b></div>
        <div class="display-field"><%: String.Format("{0:d}", Model.FechaSalida) %></div>
        
        <div class="display-label"><b>Fecha  Retorno</b></div>
        <div class="display-field"><%: String.Format("{0:d}", Model.FechaRetorno) %></div>
        
        <div class="display-label"><b>Motivo de Viaje</b></div>
        <div class="display-field"><%: Model.SustentoViaje %></div>
        
        <div class="display-label"><b>Total Solicitado</b></div>
        <div class="display-field"><%: String.Format("{0:F}", Model.TotalSolicitado) %></div>
        
        <div class="display-label"><b>Autorizado</b></div>
        <div class="display-field"><%: Model.FlagAutorizar %></div>
        
        <div class="display-label"><b>Fecha de Autorizadocion</b></div>
        <div class="display-field"><%: String.Format("{0:g}", Model.FechaAutorizar) %></div>
        
        <div class="display-label"><b>Autorizador</b></div>
        <div class="display-field"><%: Model.empleado.TxAp_Paterno + " " + Model.empleado.TxPreNombre %></div>
      
    </fieldset>
    <p>
        <%: Html.ActionLink("Autorizar", "Edit", new {  id=Model.CodigoSolicitud  }) %> |
        <%: Html.ActionLink("Regresar a Lista", "Index") %>
    </p>

</asp:Content>
