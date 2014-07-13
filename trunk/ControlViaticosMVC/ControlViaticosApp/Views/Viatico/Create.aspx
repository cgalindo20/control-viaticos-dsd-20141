<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.Models.Viatico>" %>

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
                <%: Html.TextBoxFor(model => model.FechaSolicitud) %>
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
                <%: Html.LabelFor(model => model.CodigoUbigeoOrigen) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CodigoUbigeoOrigen) %>
                <%: Html.ValidationMessageFor(model => model.CodigoUbigeoOrigen) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CodigoUbigeoDestino) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CodigoUbigeoDestino) %>
                <%: Html.ValidationMessageFor(model => model.CodigoUbigeoDestino) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.FechaSalida) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaSalida) %>
                <%: Html.ValidationMessageFor(model => model.FechaSalida) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.FechaRetorno) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaRetorno) %>
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

