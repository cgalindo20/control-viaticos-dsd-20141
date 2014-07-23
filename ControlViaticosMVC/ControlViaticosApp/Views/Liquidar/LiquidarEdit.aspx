<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.LiquidacionesWS.Liquidar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Editar Liquidación</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
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
                <%: Html.TextBoxFor(model => model.Fe_Liquidacion, String.Format("{0:g}", Model.Fe_Liquidacion)) %>
                <%: Html.ValidationMessageFor(model => model.Fe_Liquidacion) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.solicitud) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.solicitud.Co_Solicitud) %>
                <%: Html.ValidationMessageFor(model => model.solicitud.Co_Solicitud)%>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Ss_TotalAsignado) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Ss_TotalAsignado, String.Format("{0:F}", Model.Ss_TotalAsignado)) %>
                <%: Html.ValidationMessageFor(model => model.Ss_TotalAsignado) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Ss_TotalUtilizado) %>
            </div>
            <div class="editor-field">  
                <%: Html.TextBoxFor(model => model.Ss_TotalUtilizado, String.Format("{0:F}", Model.Ss_TotalUtilizado)) %>
                <%: Html.ValidationMessageFor(model => model.Ss_TotalUtilizado) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Ss_OtrosGastos) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Ss_OtrosGastos, String.Format("{0:F}", Model.Ss_OtrosGastos)) %>
                <%: Html.ValidationMessageFor(model => model.Ss_OtrosGastos) %>
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

            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

