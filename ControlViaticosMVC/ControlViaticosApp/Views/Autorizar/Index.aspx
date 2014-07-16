<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ControlViaticosApp.Models.Autorizar>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Viáticos Por Autorizar</h2>

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
                Flag Autorizar
            </th>
            <th>
                Fecha Autorizar
            </th>
            <th>
                Autorizador
            </th>
        </tr>

<%--    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id = item.CodigoSolicitud })%> |
                <%: Html.ActionLink("Details", "Details", new { id = item.CodigoSolicitud })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id = item.CodigoSolicitud })%>
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
                <%: item.FlagAutorizar %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.FechaAutorizar) %>
            </td>
            <td>
                <%: item.CodigoEmpleadoAutorizar %>
            </td>
        </tr>
    
    <% } %>
--%>
    </table> 

</asp:Content>

