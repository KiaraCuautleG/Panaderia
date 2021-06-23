<%@ Page Title="" Language="C#" MasterPageFile="~/webForms/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="ConsultarVentas.aspx.cs" Inherits="Panaderia.webForms.ConsultarVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="containerConsultarVentas">
        <div class="containerCenter">
            <div class="containerTitulo">
                <h1 style="text-align:center">Consulta de ventas</h1>
            </div>
            <div class="container">
                <asp:GridView ID="GridViewVentas" CssClass="gridView" runat="server" AutoGenerateColumns="false" ShowFooter="false" 
                    ShowHeaderWhenEmpty="true"

                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" >
                    <%-- Theme Properties --%>
                    <FooterStyle BackColor="White" ForeColor="#a52626" />
                    <HeaderStyle BackColor="#a52626" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#a52626" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#a52626" />
                    <SelectedRowStyle BackColor="#a52626" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#a52626" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#a52626" />
                
                    <Columns>
                        <asp:TemplateField ControlStyle-Width="100px" HeaderText="ID Ventas">
                            <ItemTemplate>
                                <!--La función incorporada eval permite ejecutar una cadena de código.-->
                                <asp:Label Text='<%# Eval("ID_Venta") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Fecha_Venta") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ControlStyle-Width="100px" HeaderText="Total_Venta">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Total_Venta") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                      
                    </Columns>
              </asp:GridView>
                <asp:GridView ID="DetalleVenta" CssClass="gridView" runat="server" AutoGenerateColumns="false" ShowFooter="false" 
                    ShowHeaderWhenEmpty="true"


                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" >
                    <%-- Theme Properties --%>
                    <FooterStyle BackColor="White" ForeColor="#a52626" />
                    <HeaderStyle BackColor="#a52626" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#a52626" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#a52626" />
                    <SelectedRowStyle BackColor="#a52626" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#a52626" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#a52626" />
                
                    <Columns>
                        <asp:TemplateField ControlStyle-Width="100px"  HeaderText="ID Ventas">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("ID_Venta") %>' runat="server" />
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField ControlStyle-Width="100px" HeaderText="ID Pan">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("ID_Pan") %>' runat="server" />
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre pan">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Nombre_Pan") %>' runat="server" />
                            </ItemTemplate>
                          
                        </asp:TemplateField>
                        <asp:TemplateField ControlStyle-Width="100px" HeaderText="Precio">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Precio_Pan") %>' runat="server" />
                            </ItemTemplate>
                          </asp:TemplateField>
                        <asp:TemplateField ControlStyle-Width="100px" HeaderText="Cantidad">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Cantidad_Detalle") %>' runat="server" />
                            </ItemTemplate>
                         
                        </asp:TemplateField>
                         <asp:TemplateField ControlStyle-Width="100px" HeaderText="Subtotal">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Subtotal_Detalle") %>' runat="server" />
                            </ItemTemplate>
                          
                       
                        </asp:TemplateField>
                
                       
                    </Columns>
              </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>