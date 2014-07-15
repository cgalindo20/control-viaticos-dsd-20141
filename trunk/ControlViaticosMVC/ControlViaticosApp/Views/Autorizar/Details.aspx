<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.Models.Autorizar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalles de Autorización de Vático</h2>

    <fieldset>
        <legend>Campos</legend>
        
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
        
        <div class="display-label">FlagAutorizar</div>
        <div class="display-field"><%: Model.FlagAutorizar %></div>
        
        <div class="display-label">FechaAutorizar</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.FechaAutorizar) %></div>
        
        <div class="display-label">CodigoEmpleadoAutorizar</div>
        <div class="display-field"><%: Model.CodigoEmpleadoAutorizar %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Modificar", "Edit", new {  id=Model.CodigoSolicitud  }) %> |
        <%: Html.ActionLink("Regresar a Lista", "Index") %>
    </p>

</asp:Content>

