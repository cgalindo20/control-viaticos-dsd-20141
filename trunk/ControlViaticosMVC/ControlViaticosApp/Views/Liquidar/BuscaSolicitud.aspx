<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.ViaticoWS.Viatico>" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.LiquidacionesWS.Liquidar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	BuscaSolicitud
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Liquidar Solicitud</h2>


    <h2>BuscaSolicitud</h2>

     <fieldset>
        <legend>Campos</legend>
          
        <div>
            N° de Solicitud a Liquidar: <input name="Co_Solicitud" type="text"/>
        </div>
        <div class="editor-field">
                <%: Html.TextBoxFor(model => model.solicitud.Co_Solicitud) %>
                <%: Html.ValidationMessageFor(model => model.solicitud.Co_Solicitud) %>
            </div>
        <div>
            <%: Html.ActionLink("LiquidarCreate", "LiquidarCreate", new {  ID= model.solicitud.Co_Solicitud}) %> |
        </div>
        
    </fieldset>
    
</asp:Content>
