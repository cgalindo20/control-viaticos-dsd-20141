<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ControlViaticosApp.Models.Aprobar>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Viáticos Por Aprobar</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Codigo Solicitud
            </th>
            <th>
                Fecha Solicitud
            </th>
            <th>
                Solicitante
            </th>
            <th>
                Fecha Salida
            </th>
            <th>
                Fecha Retorno
            </th>
            <th>
                Motivo Viaje
            </th>
            <th>
                Total Solicitado
            </th>
            <th>
                Aprobado
            </th>
            <th>
                Fecha Aprobación
            </th>
            <th>
                Aprobador
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Aprobar", "Edit", new { id = item.CodigoSolicitud })%> |
                <%: Html.ActionLink("Detalles", "Details", new { id = item.CodigoSolicitud })%> |                
            </td>
            <td>
                <%: item.CodigoSolicitud %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.FechaSolicitud) %>
            </td>
            <td>
                <%: item.empleado.Tx_Ap_Materno %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.FechaSalida) %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.FechaRetorno) %>
            </td>
            <td>
                <%: item.SustentoViaje %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.TotalSolicitado) %>
            </td>
            <td>
                <%: item.FlagAprobar %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.FechaAprobar) %>
            </td>
            <td>
                <%: item.CodigoEmpleadoAprobar %>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

