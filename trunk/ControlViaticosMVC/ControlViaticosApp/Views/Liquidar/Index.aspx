<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ControlViaticosApp.LiquidacionesWS.Liquidar>>" %>

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
                Ss_OtrosGastos
            </th>
            <th>
                Ss_TotalAsignado
            </th>
            <th>
                Ss_TotalUtilizado
            </th>
            <th>
                Co_Solicitud
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "LiquidarEdit", new {  id=item.Co_Liquidacion }) %> |
                <%: Html.ActionLink("Detalle", "LiquidarDetails", new { id = item.Co_Liquidacion })%> |
                <%: Html.ActionLink("Eliminar", "LiquidarDelete", new { id = item.Co_Liquidacion })%>
            </td>
            <td>
                <%: item.Co_Liquidacion %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.Fe_Liquidacion) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Ss_OtrosGastos) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Ss_TotalAsignado) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Ss_TotalUtilizado) %>
            </td>
            <td>
                <%: item.solicitud.Co_Solicitud %>
            </td>        
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "LiquidarCreate") %>
    </p>

</asp:Content>

