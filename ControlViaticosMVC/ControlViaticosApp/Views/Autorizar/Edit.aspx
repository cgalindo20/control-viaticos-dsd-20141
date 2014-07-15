<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.Models.Autorizar>" %>

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
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.FlagAutorizar) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FlagAutorizar) %>
                <%: Html.ValidationMessageFor(model => model.FlagAutorizar) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.FechaAutorizar) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaAutorizar, String.Format("{0:g}", Model.FechaAutorizar)) %>
                <%: Html.ValidationMessageFor(model => model.FechaAutorizar) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CodigoEmpleadoAutorizar) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CodigoEmpleadoAutorizar) %>
                <%: Html.ValidationMessageFor(model => model.CodigoEmpleadoAutorizar) %>
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

