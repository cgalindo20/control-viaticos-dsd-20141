<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.Models.Aprobar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalles de Aprobación de Vático</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">CodigoSolicitud</div>
        <div class="display-field"><%: Model.CodigoSolicitud %></div>
        
        <div class="display-label">FechaSolicitud</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.FechaSolicitud) %></div>
        
        <div class="display-label">FechaSalida</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.FechaSalida) %></div>
        
        <div class="display-label">FechaRetorno</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.FechaRetorno) %></div>
        
        <div class="display-label">SustentoViaje</div>
        <div class="display-field"><%: Model.SustentoViaje %></div>
        
        <div class="display-label">TotalSolicitado</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.TotalSolicitado) %></div>
        
        <div class="display-label">FlagAprobar</div>
        <div class="display-field"><%: Model.FlagAprobar %></div>
        
        <div class="display-label">FechaAprobar</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.FechaAprobar) %></div>
        
        <div class="display-label">CodigoEmpleadoAprobar</div>
        <div class="display-field"><%: Model.CodigoEmpleadoAprobar %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Aprobar", "Edit", new { id = Model.CodigoSolicitud })%> |
        <%: Html.ActionLink("Regresar a la Lista", "Index") %>
    </p>

</asp:Content>

