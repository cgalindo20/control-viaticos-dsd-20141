<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.Models.Viaticos>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Víaticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edición</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Campos</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Codigo) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Codigo) %>
                <%: Html.ValidationMessageFor(model => model.Codigo) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ApellidosNombres) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ApellidosNombres) %>
                <%: Html.ValidationMessageFor(model => model.ApellidosNombres) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Cargo) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Cargo) %>
                <%: Html.ValidationMessageFor(model => model.Cargo) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Area) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Area) %>
                <%: Html.ValidationMessageFor(model => model.Area) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CentroCosto) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CentroCosto) %>
                <%: Html.ValidationMessageFor(model => model.CentroCosto) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.JustificacionViaje) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.JustificacionViaje) %>
                <%: Html.ValidationMessageFor(model => model.JustificacionViaje) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.LugarPartida) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.LugarPartida) %>
                <%: Html.ValidationMessageFor(model => model.LugarPartida) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.LugarDestino) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.LugarDestino) %>
                <%: Html.ValidationMessageFor(model => model.LugarDestino) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.FomaPago) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FomaPago) %>
                <%: Html.ValidationMessageFor(model => model.FomaPago) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.NumeroDias) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.NumeroDias) %>
                <%: Html.ValidationMessageFor(model => model.NumeroDias) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.MontoViaticoDiario) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.MontoViaticoDiario, String.Format("{0:F}", Model.MontoViaticoDiario)) %>
                <%: Html.ValidationMessageFor(model => model.MontoViaticoDiario) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.MontoTotal) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.MontoTotal, String.Format("{0:F}", Model.MontoTotal)) %>
                <%: Html.ValidationMessageFor(model => model.MontoTotal) %>
            </div>
            
            <p>
                <input type="submit" value="Grabar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Regresar a la Lista", "Index")%>
    </div>

</asp:Content>

