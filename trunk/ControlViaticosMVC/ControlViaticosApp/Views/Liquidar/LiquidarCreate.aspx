<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.LiquidacionesWS.Liquidar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Crear REgistro</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Campos</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Co_Liquidacion) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Co_Liquidacion) %>
                <%: Html.ValidationMessageFor(model => model.Co_Liquidacion) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Fe_Liquidacion) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Fe_Liquidacion) %>
                <%: Html.ValidationMessageFor(model => model.Fe_Liquidacion) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Ss_TotalAsignado) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Ss_TotalAsignado) %>
                <%: Html.ValidationMessageFor(model => model.Ss_TotalAsignado) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Ss_TotalUtilizado) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Ss_TotalUtilizado) %>
                <%: Html.ValidationMessageFor(model => model.Ss_TotalUtilizado) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Ss_OtrosGastos) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Ss_OtrosGastos) %>
                <%: Html.ValidationMessageFor(model => model.Ss_OtrosGastos) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.solicitud.Co_Solicitud) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.solicitud.Co_Solicitud)%>
                <%: Html.ValidationMessageFor(model => model.solicitud.Co_Solicitud)%>
            </div>
                        
            <p>
                <input type="submit" value="LiquidarCreate" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Regresar a la Lista", "Index") %>
    </div>

</asp:Content>

