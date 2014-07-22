<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.ViaticoWS.Viatico>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
		Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Editar Solicitud</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Campos</legend>
            
            <div class="editor-label">
               <span style="color:red">Solicitud</span>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CodigoSolicitud, new Dictionary<string, object> { { "readonly", "readonly" } })%>
                <%: Html.ValidationMessageFor(model => model.CodigoSolicitud) %>
            </div>
            
            <div class="editor-label">
               <span style="color:red">Fecha Solicitud</span>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaSolicitud) %>
                <%: Html.ValidationMessageFor(model => model.FechaSolicitud) %>
            </div>

            <!--div class="editor-label">
               Solicitante
            </div-->
            <!--div class="editor-field">
                <!--%: Html.TextBoxFor(model => model.CodigoEmpleadoSolicitante) %-->
                <!--%: Html.ValidationMessageFor(model => model.CodigoEmpleadoSolicitante) %-->
            <!--/div-->
            
            <div class="editor-label">
                Origen
            </div>
            <div class="editor-field">
             <%: Html.DropDownList("ubigeoOrigen.CodigoUbigeo", ViewData["ubigeos"] as SelectList)%>                
            </div>
            
            <div class="editor-label">
               Destino
            </div>
            <div class="editor-field">
             <%: Html.DropDownList("ubigeoDestino.CodigoUbigeo", ViewData["ubigeos"] as SelectList)%>                
            </div>
            
            <div class="editor-label">
                Fecha de Salida
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaSalida, new { @id = "datepicker1", @Value = Model.FechaSalida.ToString("dd/MM/yyyy") })%>
                <%: Html.ValidationMessageFor(model => model.FechaSalida) %>
            </div>
            
            <div class="editor-label">
               Fecha de Retorno
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaRetorno, new { @id = "datepicker2", @Value = Model.FechaRetorno.ToString("dd/MM/yyyy") })%>
                <%: Html.ValidationMessageFor(model => model.FechaRetorno) %>
            </div>
            
            <div class="editor-label">
               Motivo de Viaje
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.SustentoViaje) %>
                <%: Html.ValidationMessageFor(model => model.SustentoViaje) %>
            </div>
            
            <div class="editor-label">
              Total Solicitado
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.TotalSolicitado, String.Format("{0:F}", Model.TotalSolicitado)) %>
                <%: Html.ValidationMessageFor(model => model.TotalSolicitado) %>
            </div>                       
            
            <p>
                <input type="submit" value="Modificar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Regresar a la Lista", "Index") %>
    </div>
    <script type="text/javascript">

        $(function () {
            $("#datepicker1").datepicker({ dateFormat: "dd/mm/yy" });

        });

        $(function () {
            $("#datepicker2").datepicker({ dateFormat: "dd/mm/yy" });
        });

        </script>

</asp:Content>

