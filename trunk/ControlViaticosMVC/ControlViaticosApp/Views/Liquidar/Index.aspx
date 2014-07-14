<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ControlViaticosApp.Models.Liquidar>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Co_Liquidacion
            </th>
            <th>
                Fe_Liquidacion
            </th>
            <th>
                Ss_TotalAsignado
            </th>
            <th>
                Ss_TotalUtilizado
            </th>
            <th>
                Ss_OtrosGastos
            </th>
            <th>
                Co_Solicitud
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "Edit", new {  id=item.Co_Liquidacion }) %> |
                <%: Html.ActionLink("Detalle", "Details", new { id = item.Co_Liquidacion })%> |
                <%: Html.ActionLink("Eliminar", "Delete", new { id = item.Co_Liquidacion })%>
            </td>
            <td>
                <%: item.Co_Liquidacion %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.Fe_Liquidacion) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Ss_TotalAsignado) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Ss_TotalUtilizado) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Ss_OtrosGastos) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.solicitud.CodigoSolicitud) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Crear", "Create") %>
    </p>

</asp:Content>

