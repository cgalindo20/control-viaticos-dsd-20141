<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.Models.Autorizar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalles de Autorización de Vático</h2>

    <fieldset>
        <legend>Campos</legend>
        
        <div class="display-label">Codigo Solicitud</div>
        <div class="display-field"><%: Model.CodigoSolicitud %></div>
        
        <div class="display-label">Fecha Solicitud</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.FechaSolicitud) %></div>
        
        <div class="display-label">Fecha Salida</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.FechaSalida) %></div>
        
        <div class="display-label">Fecha  Retorno</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.FechaRetorno) %></div>
        
        <div class="display-label">Motivo de Viaje</div>
        <div class="display-field"><%: Model.SustentoViaje %></div>
        
        <div class="display-label">Total Solicitado</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.TotalSolicitado) %></div>
        
        <div class="display-label">Autorizado</div>
        <div class="display-field"><%: Model.FlagAutorizar %></div>
        
        <div class="display-label">Fecha de Atorizadocion</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.FechaAutorizar) %></div>
        
        <div class="display-label">Autorizador</div>
        <div class="display-field"><%: Model.CodigoEmpleadoAutorizar %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Modificar", "Edit", new {  id=Model.CodigoSolicitud  }) %> |
        <%: Html.ActionLink("Regresar a Lista", "Index") %>
    </p>

</asp:Content>

