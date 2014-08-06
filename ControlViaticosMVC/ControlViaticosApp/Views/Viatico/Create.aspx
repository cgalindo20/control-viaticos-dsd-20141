<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.ViaticoWS.Viatico>" %>

<%@ Import Namespace = "ControlViaticosApp.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Nueva Solicitud</h2>

     <% if(null != TempData["alertMessage"]) 
           { %>
              <script type="text/javascript">
                  alert("@TempData[alertMessage]");
              </script>
           <% } %>

    <% using (Html.BeginForm()) {%>
           
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Campos</legend>                                             
            
            <div class="editor-label">
                Origen
            </div>
            <div class="editor-field">
                <%: Html.DropDownList("ubigeoOrigen.CodigoUbigeo", ViewData["ubigeos"] as SelectList) %>                
            </div>            
            <div class="editor-label">
               Destino
            </div>
            <div class="editor-field">
                <%: Html.DropDownList("ubigeoDestino.CodigoUbigeo", ViewData["ubigeos"] as SelectList) %>
            </div>            
            <div class="editor-label">  
               Fecha Salida
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaSalida, new { @id = "datepicker1" })%>
                <%: Html.ValidationMessageFor(model => model.FechaSalida) %>
            </div>
            
            <div class="editor-label">
              Fecha Retorno
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaRetorno, new { @id = "datepicker2" })%>
                <%: Html.ValidationMessageFor(model => model.FechaRetorno) %>
            </div>
            
            <div class="editor-label">
               Motivo
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.SustentoViaje) %>
                <%: Html.ValidationMessageFor(model => model.SustentoViaje) %>
            </div>
            
            <div class="editor-label">
              Total Solicitado
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.TotalSolicitado) %>
                <%: Html.ValidationMessageFor(model => model.TotalSolicitado) %>
            </div>                        
            
            <fieldset>	
            <table>
	            <thead>
		            <tr>
                        <th width="60" align="center">Tipo de Viatico</th>
			            <th width="60" align="center">Monto Solicitado</th>
		            </tr>
	            </thead>
			        
                <tbody>
	            <% foreach (var tarifa in ViewData["tarifas"] as List<ControlViaticosApp.ViaticoWS.Tarifario>)  { %>
		            <tr>
                        <td width="60">
				            <%: tarifa.Co_Ubigeo.NoDescripcion%> 
			            </td>
			            <td width="60">
				            <%: tarifa.Co_TipoViatico.No_Descripcion%> 
			            </td>

                        <td width="60">
				            <%: tarifa.Ss_Costo%> 
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
        <%: Html.ActionLink("Regresar a la Lista", "Index") %>
    </div>
     <script type="text/javascript">
      
        $(function() {
            $("#datepicker1").datepicker({ dateFormat: "dd/mm/yy" });           
           
        });        

        $(function () {
            $("#datepicker2").datepicker({ dateFormat: "dd/mm/yy" });            
        });

        </script>
                
</asp:Content>

