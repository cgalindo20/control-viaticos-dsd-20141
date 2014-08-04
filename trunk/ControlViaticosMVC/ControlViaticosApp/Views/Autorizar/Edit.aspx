<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.AutorizarWS.Autorizar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Editar Autorización de Vático</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Campos</legend>
            
            <div class="editor-label">
                Codigo de Solicitud
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CodigoSolicitud) %>
                <%: Html.ValidationMessageFor(model => model.CodigoSolicitud) %>
            </div>                     
            <div class="editor-label">
                Fecha de Solicitud
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaSolicitud, String.Format("{0:d}", Model.FechaSolicitud)) %>
                <%: Html.ValidationMessageFor(model => model.FechaSolicitud) %>
            </div>
             <div class="editor-label">
                Solicitante
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.empleado.CoEmpleado) %>
                <%: Html.ValidationMessageFor(model => model.empleado.CoEmpleado) %>
            </div>   
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
                <%: Html.TextBoxFor(model => model.FechaSalida, String.Format("{0:d}", Model.FechaSalida)) %>
                <%: Html.ValidationMessageFor(model => model.FechaSalida) %>
            </div>
            
            <div class="editor-label">
                Fecha de Retorno
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaRetorno, String.Format("{0:d}", Model.FechaRetorno)) %>
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
                Total Solicitado            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.TotalSolicitado, String.Format("{0:F}", Model.TotalSolicitado)) %>
                <%: Html.ValidationMessageFor(model => model.TotalSolicitado) %>
            </div>
            
            <div class="editor-label">
               Autorizar
            </div>           
             <div class="editor-field">
             <%: Html.DropDownList("FlagAutorizar", ViewData["estados"] as SelectList)%>                
            </div>                                                        
            <br />
            <br />
            <p>
                <input type="submit" value="Grabar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Regresar a la Lista", "Index") %>
    </div>

</asp:Content>

