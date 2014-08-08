<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ControlViaticosApp.AprobarWS.Aprobar>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Viáticos Por Aprobar</h2>

   <table>
        <tr>
            <th></th>
            <th>
                Solicitud
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
                Motivo Viaje
            </th>
            <th>
                Total Solicitado
            </th>
            <th>
                Estado
            </th>            
        </tr>

   <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Aprobar", "Edit", new { id = item.CodigoSolicitud })%>                               
            </td>
            <td align='center'>
                <%: item.CodigoSolicitud %>
            </td>          
            <td>
                <%: item.ubigeoOrigen.NoDescripcion%>
            </td>
            <td>
                <%: item.ubigeoDestino.NoDescripcion%>
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
            <% if (item.FlagAprobado.Equals("P"))
               { %>
                Pendiente
            <% }else{ %>
                Aprobado            
             <% } %>
            </td>           
        </tr>
    
    <% } %>
    </table> 

    

</asp:Content>

