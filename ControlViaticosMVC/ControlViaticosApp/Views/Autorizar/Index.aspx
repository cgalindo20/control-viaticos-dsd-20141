<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ControlViaticosApp.AutorizarWS.Autorizar>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Viáticos Por Autorizar</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Solicitud
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
        </tr>

   <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Autorizar", "Edit", new { id = item.CodigoSolicitud })%> |
                <%: Html.ActionLink("Detalles", "Details", new { id = item.CodigoSolicitud })%>                
            </td>
            <td align='center'>
                <%: item.CodigoSolicitud %>
            </td>          
             <td>
                <%: item.empleado.TxAp_Paterno + " " + item.empleado.TxPreNombre %>
            </td>
            <td>
                <%: String.Format("{0:d}", item.FechaSalida) %>
            </td>
            <td>
                <%: String.Format("{0:d}", item.FechaRetorno) %>
            </td>
            <td>
                <%: item.SustentoViaje %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.TotalSolicitado) %>
            </td>            
            <td>
            <% if (item.FlagAutorizar.Equals("P"))
               { %>
                Pendiente
            <% }else{ %>
                Autorizado            
             <% } %>
            </td>           
        </tr>
    
    <% } %>
    </table> 

</asp:Content>

