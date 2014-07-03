<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.Models.Viaticos>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Víaticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalles</h2>

    <fieldset>
        <legend>Campos</legend>
        
        <div class="display-label">Codigo</div>
        <div class="display-field"><%: Model.Codigo %></div>
        
        <div class="display-label">ApellidosNombres</div>
        <div class="display-field"><%: Model.ApellidosNombres %></div>
        
        <div class="display-label">Cargo</div>
        <div class="display-field"><%: Model.Cargo %></div>
        
        <div class="display-label">Area</div>
        <div class="display-field"><%: Model.Area %></div>
        
        <div class="display-label">CentroCosto</div>
        <div class="display-field"><%: Model.CentroCosto %></div>
        
        <div class="display-label">JustificacionViaje</div>
        <div class="display-field"><%: Model.JustificacionViaje %></div>
        
        <div class="display-label">LugarPartida</div>
        <div class="display-field"><%: Model.LugarPartida %></div>
        
        <div class="display-label">LugarDestino</div>
        <div class="display-field"><%: Model.LugarDestino %></div>
        
        <div class="display-label">FomaPago</div>
        <div class="display-field"><%: Model.FomaPago %></div>
        
        <div class="display-label">NumeroDias</div>
        <div class="display-field"><%: Model.NumeroDias %></div>
        
        <div class="display-label">MontoViaticoDiario</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.MontoViaticoDiario) %></div>
        
        <div class="display-label">MontoTotal</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.MontoTotal) %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%: Html.ActionLink("Regresar a la Lista", "Index")%>
    </p>

</asp:Content>

