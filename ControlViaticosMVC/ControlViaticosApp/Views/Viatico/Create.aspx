<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.ViaticoWS.Viatico>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Nueva Solicitud</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Campos</legend>                                             
            
            <div class="editor-label">
               Fecha Solicitud
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaSolicitud)%>
                <%: Html.ValidationMessageFor(model => model.FechaSolicitud) %>
            </div>

            <div class="editor-label">
                Origen
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ubigeoOrigen.CodigoUbigeo) %>
                <%: Html.ValidationMessageFor(model => model.ubigeoOrigen.CodigoUbigeo)%>
            </div>
            
            <div class="editor-label">
               Destino
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ubigeoDestino.CodigoUbigeo) %>
                <%: Html.ValidationMessageFor(model => model.ubigeoDestino.CodigoUbigeo)%>
            </div>
            
            <div class="editor-label">
               Fecha Salida
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaSalida) %>
                <%: Html.ValidationMessageFor(model => model.FechaSalida) %>
            </div>
            
            <div class="editor-label">
              Fecha Retorno
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaRetorno) %>
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
            
            <p>
                <input type="submit" value="Guardar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Regresar a la Lista", "Index") %>
    </div>

</asp:Content>

