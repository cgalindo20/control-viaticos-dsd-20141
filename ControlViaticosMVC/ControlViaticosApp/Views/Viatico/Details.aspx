<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.Models.Viatico>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Ver Solicitud</h2>

    <fieldset>
        <legend>Campos</legend>
        
        <div class="display-label">CodigoSolicitud</div>
        <div class="display-field"><%: Model.CodigoSolicitud %></div>
        
        <div class="display-label">FechaSolicitud</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.FechaSolicitud) %></div>
        
        <div class="display-label">CodigoEmpleadoSolicitante</div>
        <div class="display-field"><%: Model.CodigoEmpleadoSolicitante %></div>
        
        <div class="display-label">CodigoUbigeoOrigen</div>
        <div class="display-field"><%: Model.CodigoUbigeoOrigen %></div>
        
        <div class="display-label">CodigoUbigeoDestino</div>
        <div class="display-field"><%: Model.CodigoUbigeoDestino %></div>
        
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
        
        <div class="display-label">FlagAprobar</div>
        <div class="display-field"><%: Model.FlagAprobar %></div>
        
        <div class="display-label">FechaAprobar</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.FechaAprobar) %></div>
        
        <div class="display-label">CodigoEmpleadoAprobar</div>
        <div class="display-field"><%: Model.CodigoEmpleadoAprobar %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

