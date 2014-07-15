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
                <%: Html.LabelFor(model => model.CodigoSolicitud) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CodigoSolicitud) %>
                <%: Html.ValidationMessageFor(model => model.CodigoSolicitud) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.FechaSolicitud) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaSolicitud, String.Format("{0:g}", Model.FechaSolicitud)) %>
                <%: Html.ValidationMessageFor(model => model.FechaSolicitud) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.CodigoEmpleadoSolicitante) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CodigoEmpleadoSolicitante) %>
                <%: Html.ValidationMessageFor(model => model.CodigoEmpleadoSolicitante) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ubigeoOrigen.CodigoUbigeo)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ubigeoOrigen.CodigoUbigeo)%>
                <%: Html.ValidationMessageFor(model => model.ubigeoOrigen.CodigoUbigeo)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ubigeoDestino.CodigoUbigeo)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ubigeoDestino.CodigoUbigeo)%>
                <%: Html.ValidationMessageFor(model => model.ubigeoDestino.CodigoUbigeo)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.FechaSalida) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaSalida, String.Format("{0:g}", Model.FechaSalida)) %>
                <%: Html.ValidationMessageFor(model => model.FechaSalida) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.FechaRetorno) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaRetorno, String.Format("{0:g}", Model.FechaRetorno)) %>
                <%: Html.ValidationMessageFor(model => model.FechaRetorno) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.SustentoViaje) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.SustentoViaje) %>
                <%: Html.ValidationMessageFor(model => model.SustentoViaje) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.TotalSolicitado) %>
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

</asp:Content>

