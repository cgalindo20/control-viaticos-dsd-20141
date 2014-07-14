<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.LiquidacionesWS.Liquidar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	LiquidarDelete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Eliminar</h2>

    <h3>Seguro(a) de Eliminar?</h3>
    <fieldset>
        <legend>Campos</legend>
        
        <div class="display-label">Co_Liquidacion</div>
        <div class="display-field"><%: Model.Co_Liquidacion %></div>
        
        <div class="display-label">Fe_Liquidacion</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.Fe_Liquidacion) %></div>
        
        <div class="display-label">Ss_TotalAsignado</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Ss_TotalAsignado) %></div>
        
        <div class="display-label">Ss_TotalUtilizado</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Ss_TotalUtilizado) %></div>
        
        <div class="display-label">Ss_OtrosGastos</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Ss_OtrosGastos) %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Eliminar" /> |
		    <%: Html.ActionLink("Regresar a la Lista", "Index") %>
        </p>
    <% } %>

</asp:Content>

