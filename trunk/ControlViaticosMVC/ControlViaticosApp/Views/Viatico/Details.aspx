<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.ViaticoWS.Viatico>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Ver Solicitud</h2>

    <fieldset>
        <legend>Solicitud de Viatico</legend>
        
        <div class="display-label"><b>Codigo Solicitud</b></div>
        <div class="display-field"><%: Model.CodigoSolicitud %></div>
        
        <div class="display-label"><b>Fecha Solicitud</b></div>
        <div class="display-field"><%: String.Format("{0:d}", Model.FechaSolicitud) %></div>
        
        <div class="display-label"><b>Origen</b></div>
        <div class="display-field"><%: Model.ubigeoOrigen.NoDescripcion %></div>
        
        <div class="display-label"><b>Destino</b></div>
        <div class="display-field"><%: Model.ubigeoDestino.NoDescripcion%></div>
        
        <div class="display-label"><b>Fecha Salida</b></div>
        <div class="display-field"><%: String.Format("{0:d}", Model.FechaSalida) %></div>
        
        <div class="display-label"><b>Fecha Retorno</b></div>
        <div class="display-field"><%: String.Format("{0:d}", Model.FechaRetorno) %></div>
        
        <div class="display-label"><b>Motivo</b></div>
        <div class="display-field"><%: Model.SustentoViaje %></div>
        
        <div class="display-label"><b>Total Solicitado</b></div>
        <div class="display-field"><%: String.Format("{0:F}", Model.TotalSolicitado) %></div>        
        
    </fieldset>

    <fieldset>	
        <legend>Montos multiplicados por los días de estadía</legend>
		<table>
			<thead>
				<tr>
					<th width="60" align="center">Tipo de Viatico</th>
					<th width="60" align="center">Monto Solicitado</th>
				</tr>
			</thead>
			<tbody>
				<% foreach (var item in Model.Detalles)  { %>
					<tr>
						<td width="60">
							<%: item.PK.TipoViatico.No_Descripcion %> 
						</td>
			
						<td width="60">
							<%: String.Format("{0:F}", item.Ss_MontoSolicitado) %>
						</td>
					</tr>
				<% }  %>
			</tbody>
		</table>
	</fieldset>	

    <p>
        <%--<%: Html.ActionLink("Modificar", "Edit", new { id = Model.CodigoSolicitud })%> |--%>
        <%: Html.ActionLink("Regresar a la Lista", "Index") %>
    </p>

</asp:Content>

