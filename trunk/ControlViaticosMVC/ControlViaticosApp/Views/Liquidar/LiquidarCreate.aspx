<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.LiquidacionesWS.Liquidar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">

    <h2>Liquidar Solicitud</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
                        
            <div class="display-label"><b>Nº Solicitud</b></div>
            <div class="display-field"><%: Model.solicitud.Co_Solicitud %></div>

            <div class="display-label"><b>Fecha de Solicitud</b></div>
            <div class="display-field"><%: String.Format("{0:g}", Model.solicitud.Fe_Solicitud) %></div>

            <div class="display-label"><b>Origen</b></div>
            <div class="display-field"><%: Model.solicitud.ubigeoOrigen.NoDescripcion %></div>

            <div class="display-label"><b>Fecha Salida</b></div>
            <div class="display-field"><%: String.Format("{0:d}", Model.solicitud.Fe_Salida) %></div>

            <div class="display-label"><b>Destino</b></div>
            <div class="display-field"><%: Model.solicitud.ubigeoDestino.NoDescripcion%></div>

            <div class="display-label"><b>Fecha Retorno</b></div>
            <div class="display-field"><%: String.Format("{0:d}", Model.solicitud.Fe_Retorno) %></div>

            <div class="display-label"><b>Sustento</b></div>
            <div class="display-field"><%: Model.solicitud.Tx_Sustento %></div>
                                    
            <fieldset>	
		        <table>
			        <thead>
				        <tr>
					        <th width="60" align="center">Tipo de Viatico</th>
					        <th width="60" align="center">Monto Asignado</th>
					        <th width="60" align="center">Monto Utilizado</th>
				        </tr>
			        </thead>
			        <tbody>
				        <% foreach (var item in Model.Detalles)  { %>
					        <tr>
						        <td width="60">
                                    <%: item.PK.TipoViatico.No_Descripcion %> 
						        </td>
			
						        <td width="60">
							        <%: String.Format("{0:F}", item.Ss_MontoAsignado) %>
						        </td>

						        <td width="60">
							        <%: Html.TextBoxFor(model => item.Ss_MontoUtilizado, item.Ss_MontoUtilizado)%>
						        </td>
					        </tr>
				        <% }  %>
			        </tbody>
		        </table>
	        </fieldset>	
                      
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Ss_OtrosGastos) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Ss_OtrosGastos) %>
                <%: Html.ValidationMessageFor(model => model.Ss_OtrosGastos) %>
            </div>

            <p>
                <input type="submit" value="LiquidarCreate" />
            </p>
        </fieldset>

    <% } %>


    <div>
        <%: Html.ActionLink("Regresar a la Lista", "Index") %>
    </div>

</form>

</asp:Content>

