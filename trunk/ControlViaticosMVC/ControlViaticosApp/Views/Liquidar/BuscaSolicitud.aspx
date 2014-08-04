<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.ViaticoWS.Viatico>" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.LiquidacionesWS.Liquidar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	BuscaSolicitud
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>BuscaSolicitud</h2>

     <fieldset>
        <legend>Campos</legend>
            
         <%: Html.ValidationSummary(true) %>
        <form action="ConsultarSolicitud" method="post">
            <div>
                N° de Solicitud a Liquidar: <input name="Co_Solicitud" type="text"/>
            </div>
            <div>
                <input type="submit" value="Buscar"/>
            </div>
        </form>

    </fieldset>

</asp:Content>
