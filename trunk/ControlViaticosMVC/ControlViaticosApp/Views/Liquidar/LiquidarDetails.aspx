<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ControlViaticosApp.LiquidacionesWS.Liquidar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control de Viáticos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div  class="ui-panel ui-corner-all" style="width: 1130px; margin: 0px auto">

    <div class="ui-panel-titlebar ui-widget-header ui-corner-all">
        <span>Detalle de Liquidación</span>
    </div>

    <div class="ui-panel-body" id="divLiquidarDetails">
        
        <table width="1110px" border ="0px" >
            <tr>
                <td valign="top" style="position: relative; width: 710px;">
                    <fieldset>
                        <table width="100%" class="tlb">
                            <tr>
                                <td width="25%" class="td_right">Código de Liquidación:</td>
                                <td width="75%">
                                    <input  type="text" readonly="readonly"
                                            size="8" 
                                            value = "<%: Model.Co_Liquidacion %>"/>
                                </td>
                            </tr>

                            <tr>
                                <td width="25%" class="td_right">Fecha de Liquidación:</td>
                                <td width="75%">
                                    <input  type="text" readonly="readonly"
                                            size="10" 
                                            value = "<%: String.Format("{0:g}", Model.Fe_Liquidacion) %>"/>
                                </td>
                            </tr>

                            <tr>
                                <td width="25%" class="td_right">Total Asignado:</td>
                                <td width="75%">
                                    <input  type="text" readonly="readonly"
                                            size="8" 
                                            value = "<%: String.Format("{0:F}", Model.Ss_TotalAsignado) %>"/>
                                </td>
                            </tr>

                            <tr>
                                <td width="25%" class="td_right">Total Utilizado:</td>
                                <td width="75%">
                                    <input  type="text" readonly="readonly"
                                            size="8" 
                                            value = "<%: String.Format("{0:F}", Model.Ss_TotalUtilizado) %>"/>
                                </td>
                            </tr>

                            <tr>
                                <td width="25%" class="td_right">Otros Gastos:</td>
                                <td width="75%">
                                    <input  type="text" readonly="readonly"
                                            size="8" 
                                            value = "<%: String.Format("{0:F}", Model.Ss_OtrosGastos) %>"/>
                                </td>
                            </tr>

                            <tr>
                                <td width="25%" class="td_right">Código de Solicitud:</td>
                                <td width="75%">
                                    <input  type="text" readonly="readonly"
                                            size="8" 
                                            value = "<%: String.Format("{0:F}", Model.solicitud.Co_Solicitud) %>"/>
                                </td>
                            </tr>


                        </table>    
                        
                    </fieldset>
                </td>
            </tr>
        </table>


        
        <fieldset>
            <div class="display-label">Detalle</div>
        
            <div class="ui-datatable-scrollable-header">
                <table class="ui-state-default">
                    <thead>
                        <tr>
                            <th width="60" align="center">Tipo de Viatico</th>
                            <th width="30" align="center">Monto Asignado</th>
                            <th width="30" align="center">Monto Utilizado</th>
                        </tr>
                    </thead>
                </table>
            </div>

            <div class="bx_sb ui-datatable-scrollable-body" style='height:350px;'>
                <table class="ui-datatable-data">
                    <tbody>
                        <% foreach (var item in Model.Detalles)  { %>
                            <tr class="ui-datatable-even">
                                <td width="60">
                                    <%: item.PK.TipoViatico.No_Descripcion %> 
                                </td>
                    
                                <td width="30">
                                    <%: String.Format("{0:F}", item.Ss_MontoAsignado) %>
                                </td>

                                <td width="30">
                                    <%: String.Format("{0:F}", item.Ss_MontoUtilizado) %>
                                </td>
                            </tr>
                        <% }  %>
                    </tbody>
                </table>
            </div>
        
        </fieldset>
        <p>
            <%: Html.ActionLink("Editar", "Edit", new { id=Model.Co_Liquidacion}) %> |
            <%: Html.ActionLink("Regresa a la Lista", "Index") %>
        </p>
    </div>
</div>

</asp:Content>

