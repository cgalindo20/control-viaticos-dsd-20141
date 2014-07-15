<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ControlViaticosApp.ViaticoWS.Viatico>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Solicitudes</h2>

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
                Origen
            </th>
            <th>
                Destino
            </th>
            <th>
                Fecha Salida
            </th>
            <th>
                Fecha Retorno
            </th>
            <th>
                Sustento Viaje
            </th>
            <th>
                Total Solicitado
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
                <%: item.ubigeoOrigen.NoDescripcion%>
            </td>
            <td>
                <%: item.ubigeoDestino.NoDescripcion%>
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

