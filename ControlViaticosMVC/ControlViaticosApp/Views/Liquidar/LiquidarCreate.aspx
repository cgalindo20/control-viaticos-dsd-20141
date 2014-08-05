<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.LiquidacionesWS.Liquidar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Liquidar Solicitud</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.solicitud.Co_Solicitud) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.solicitud.Co_Solicitud) %>
                <%: Html.ValidationMessageFor(model => model.solicitud.Co_Solicitud) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.solicitud.Fe_Solicitud) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.solicitud.Fe_Solicitud) %>
                <%: Html.ValidationMessageFor(model => model.solicitud.Fe_Solicitud) %>
            </div>            

            <div class="editor-label">
                <%: Html.LabelFor(model => model.solicitud.Ss_TotalSolicitado) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.solicitud.Ss_TotalSolicitado)%>
                <%: Html.ValidationMessageFor(model => model.solicitud.Ss_TotalSolicitado)%>
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
				    <% foreach (var item in Model.solicitud.Detalles)  { %>
					    <tr>
						    <td width="60">
                                <%: item.PK.TipoViatico.No_Descripcion %> 
						    </td>
			
						    <td width="60">
							    <%: String.Format("{0:F}", item.Ss_MontoSolicitado) %>
						    </td>

						    <td width="60">
							    <%: Html.TextBoxFor(model => item.Ss_MontoSolicitado , item.Ss_MontoSolicitado)%>
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
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>


    <div>
        <%: Html.ActionLink("Regresar a la Lista", "Index") %>
    </div>

</asp:Content>

