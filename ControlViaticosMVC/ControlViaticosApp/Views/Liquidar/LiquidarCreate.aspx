<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.LiquidacionesWS.Liquidar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">

    <h2>Crear REgistro</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Campos</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Co_Liquidacion) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Co_Liquidacion) %>
                <%: Html.ValidationMessageFor(model => model.Co_Liquidacion) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Fe_Liquidacion) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Fe_Liquidacion) %>
                <%: Html.ValidationMessageFor(model => model.Fe_Liquidacion) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Ss_TotalAsignado) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Ss_TotalAsignado) %>
                <%: Html.ValidationMessageFor(model => model.Ss_TotalAsignado) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Ss_TotalUtilizado) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Ss_TotalUtilizado) %>
                <%: Html.ValidationMessageFor(model => model.Ss_TotalUtilizado) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Ss_OtrosGastos) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Ss_OtrosGastos) %>
                <%: Html.ValidationMessageFor(model => model.Ss_OtrosGastos) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.solicitud.Co_Solicitud) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.solicitud.Co_Solicitud)%>
                <%: Html.ValidationMessageFor(model => model.solicitud.Co_Solicitud)%>
            </div>
            
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
					    <tr>
						    <td width="60">
                                <%: Html.TextBoxFor(model => model.Detalles[0].PK.TipoViatico)%>
						    </td>
			
						    <td width="60">
							    <%: Html.TextBoxFor(model => model.Detalles[0].Ss_MontoAsignado)%>
						    </td>

						    <td width="60">
							    <%: Html.TextBoxFor(model => model.Detalles[0].Ss_MontoUtilizado)%>
						    </td>
					    </tr>

					    <tr>
						    <td width="60">
                                <%: Html.TextBoxFor(model => model.Detalles[1].PK.TipoViatico)%>
						    </td>
			
						    <td width="60">
							    <%: Html.TextBoxFor(model => model.Detalles[1].Ss_MontoAsignado)%>
						    </td>

						    <td width="60">
							    <%: Html.TextBoxFor(model => model.Detalles[1].Ss_MontoUtilizado)%>
						    </td>
					    </tr>

			        </tbody>
		        </table>
	        </fieldset>	



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

