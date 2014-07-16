<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.Models.Aprobar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Editar Aprobación de Vático</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                Codigo de Solicitud
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CodigoSolicitud) %>
                <%: Html.ValidationMessageFor(model => model.CodigoSolicitud) %>
            </div>
            
            <div class="editor-label">
                Fecha de Solictud
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaSolicitud, String.Format("{0:g}", Model.FechaSolicitud)) %>
                <%: Html.ValidationMessageFor(model => model.FechaSolicitud) %>
            </div>                       
            
            <div class="editor-label">
                Fecha de Salida
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaSalida, String.Format("{0:g}", Model.FechaSalida)) %>
                <%: Html.ValidationMessageFor(model => model.FechaSalida) %>
            </div>
            
            <div class="editor-label">
               Fecha de Retorno
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaRetorno, String.Format("{0:g}", Model.FechaRetorno)) %>
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
            
            <div class="editor-label">
               Aprobado            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FlagAprobar) %>
                <%: Html.ValidationMessageFor(model => model.FlagAprobar) %>
            </div>
            
            <div class="editor-label">
                Fecha Aprobacion
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaAprobar, String.Format("{0:g}", Model.FechaAprobar)) %>
                <%: Html.ValidationMessageFor(model => model.FechaAprobar) %>
            </div>
            
            <div class="editor-label">
                Aprobador
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CodigoEmpleadoAprobar) %>
                <%: Html.ValidationMessageFor(model => model.CodigoEmpleadoAprobar) %>
            </div>
            
            <p>
                <input type="submit" value="Grabar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Regresar a la Lista", "Index") %>
    </div>

</asp:Content>

