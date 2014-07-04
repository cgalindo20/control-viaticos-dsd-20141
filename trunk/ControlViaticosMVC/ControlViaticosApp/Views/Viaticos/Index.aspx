<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ControlViaticosApp.Models.Viaticos>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Lista de Viáticos</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Codigo
            </th>
            <th>
                ApellidosNombres
            </th>
            <th>
                Cargo
            </th>
            <th>
                Area
            </th>
            <th>
                Lugar Partida
            </th>
            <th>
                Lugar Destino
            </th>
            <th>
                MontoTotal
            </th>
             <th>
                Estado
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "Edit", new { id=item.Codigo  }) %> |
                <%: Html.ActionLink("Detalles", "Details", new { id = item.Codigo })%> |
                <%: Html.ActionLink("Eliminar", "Delete", new { id = item.Codigo })%>
            </td>
            <td>
                <%: item.Codigo %>
            </td>
            <td>
                <%: item.ApellidosNombres %>
            </td>
            <td>
                <%: item.Cargo %>
            </td>
            <td>
                <%: item.Area %>
            </td>
            <td>
                <%: item.LugarPartida %>
            </td>
            <td>
                <%: item.LugarDestino %>
            </td>           
            <td>
                <%: String.Format("{0:F}", item.MontoTotal) %>
            </td>
             <td>
                <%: item.Estado %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Solicitar", "Create") %>
    </p>

</asp:Content>

