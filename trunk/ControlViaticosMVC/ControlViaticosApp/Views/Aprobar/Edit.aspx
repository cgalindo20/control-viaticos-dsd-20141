<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.AprobarWS.Aprobar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Editar Aprobación de Vático</h2>

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
                <%: Html.TextBoxFor(model => model.FechaSolicitud, new Dictionary<string, object> { { "readonly", "readonly" } })%>
                <%: Html.ValidationMessageFor(model => model.FechaSolicitud) %>
            </div>
            
            <div class="editor-label">
                <span style="color:red">Origen</span>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ubigeoOrigen.NoDescripcion, new Dictionary<string, object> { { "readonly", "readonly" } })%>
                <%: Html.ValidationMessageFor(model => model.ubigeoOrigen.NoDescripcion) %>
            </div>
            
            <div class="editor-label">
                <span style="color:red">Destino</span>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ubigeoDestino.NoDescripcion, new Dictionary<string, object> { { "readonly", "readonly" } })%>
                <%: Html.ValidationMessageFor(model => model.ubigeoDestino.NoDescripcion)%>
            </div>

            <div class="editor-label">
                <span style="color:red">Fecha de Salida</span>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaSalida, new Dictionary<string, object> { { "readonly", "readonly" } })%>
                <%: Html.ValidationMessageFor(model => model.FechaSalida)%>
            </div>

            <div class="editor-label">
                <span style="color:red">Fecha de Retorno</span>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaRetorno, new Dictionary<string, object> { { "readonly", "readonly" } })%>
                <%: Html.ValidationMessageFor(model => model.FechaRetorno)%>
            </div>
            
            <div class="editor-label">
                <span style="color:red">Motivo de viaje</span>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.SustentoViaje, new Dictionary<string, object> { { "readonly", "readonly" } })%>
                <%: Html.ValidationMessageFor(model => model.SustentoViaje)%>
            </div>
                  
            <div class="editor-label">
                <span style="color:red">Total Solicitado</span>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.TotalSolicitado, new Dictionary<string, object> { { "readonly", "readonly" } })%>
                <%: Html.ValidationMessageFor(model => model.TotalSolicitado)%>
            </div>
            
            <div class="editor-label">
               Aprobar
            </div>           
            <div class="editor-field">
                <%: Html.DropDownList("FlagAprobado", ViewData["estados"] as SelectList)%>                
            </div>                                                        
            <br />
            <br />
            <p>
                <input type="submit" value="Grabar" />
            </p>
        </fieldset>

    <% } %>

</asp:Content>

