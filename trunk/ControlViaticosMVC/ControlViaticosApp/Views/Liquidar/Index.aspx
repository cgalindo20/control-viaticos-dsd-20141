<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ControlViaticosApp.ViaticoWS.Viatico>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Liquidación Solicitudes de Viáticos</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Solicitud
            </th>
            <th>
                Fecha Solicitud
            </th>
            <th>
                Total Solicitado
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Liquidar", "LiquidarCreate", new {  id=item.CodigoSolicitud }) %> |
            </td>
            <td>
                <%: item.CodigoSolicitud %>
            </td>
            <td>
                <%: String.Format("{0:d}", item.FechaSolicitud) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.TotalSolicitado) %>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

