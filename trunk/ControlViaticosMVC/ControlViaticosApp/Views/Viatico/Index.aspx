<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ControlViaticosApp.Models.Viatico>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Solicitudes</h2>

    <table>
        <tr>
            <th></th>
            <th>
                CodigoSolicitud
            </th>
            <th>
                FechaSolicitud
            </th>
            <th>
                CodigoEmpleadoSolicitante
            </th>
            <th>
                CodigoUbigeoOrigen
            </th>
            <th>
                CodigoUbigeoDestino
            </th>
            <th>
                FechaSalida
            </th>
            <th>
                FechaRetorno
            </th>
            <th>
                SustentoViaje
            </th>
            <th>
                TotalSolicitado
            </th>           
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "Edit", new {  id=item.CodigoSolicitud }) %> |
                <%: Html.ActionLink("Detalles", "Details", new {  id=item.CodigoSolicitud })%> |
                <%: Html.ActionLink("Eliminar", "Delete", new {  id=item.CodigoSolicitud })%>
            </td>
            <td>
                <%: item.CodigoSolicitud %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.FechaSolicitud) %>
            </td>
            <td>
                <%: item.CodigoEmpleadoSolicitante %>
            </td>
            <td>
                <%: item.CodigoUbigeoOrigen %>
            </td>
            <td>
                <%: item.CodigoUbigeoDestino %>
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
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Nueva Solicitud", "Create") %>
    </p>

</asp:Content>

