<%@ Page Title="" Language="C#" MasterPageFile="~/webForms/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="Panaderia.webForms.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="containerVentas">
        <div class="containerCenter">
            <div class="containerTitulo">
                <asp:Label ID="lblErrorMessage"  CssClass="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
                <asp:Label ID="lblErrorMessage2"  CssClass="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
                <h1>Ventas</h1>
            </div>
            <div class="container">
                <asp:Label runat="server" Text="Fecha" CssClass="label"></asp:Label>
                <asp:Calendar ID="Calendar1" runat="server" CssClass="calendar" ></asp:Calendar>
                <asp:Label runat="server"  Text="ID Venta:" CssClass="label"></asp:Label>
                <asp:Label ID="lblIDVenta" ForeColor="#a52626" runat="server" CssClass="label" ></asp:Label>
                <asp:Button ID="btnIniciarVenta" runat="server" Text="Iniciar Venta" CssClass="button" OnClick="btnIniciarVenta_Click" />
            </div>
            <div class="container" >
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropList" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:Label runat="server" Text="Cantidad" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="txtBox" TextMode="Number"></asp:TextBox>
                <asp:Label runat="server" Text="Precio" CssClass="label"></asp:Label>
                <asp:Label runat="server" Text="" ForeColor="Red" ID="txtPrecio" CssClass="label"></asp:Label>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="button" OnClick="btnAgregar_Click" />
                
            </div>
            <div class="container" >
                <asp:GridView ID="gvVentas" runat="server" AutoGenerateColumns="false" ShowFooter="true" 
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
                        <asp:TemplateField ControlStyle-Width="150px"  HeaderText="Pan">
                            <ItemTemplate >
                                <asp:Label Text='<%# Eval("Nombre_Pan") %>' runat="server" />
                            </ItemTemplate>
                        
                        </asp:TemplateField>
                        <asp:TemplateField  ControlStyle-Width="150px" HeaderText="Precio">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Precio_Pan") %>' runat="server" />
                            </ItemTemplate>
                        
                        </asp:TemplateField>    
                        <asp:TemplateField  ControlStyle-Width="150px" HeaderText="Cantidad">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Cantidad_Detalle") %>' runat="server" />
                            </ItemTemplate>
                        
                        </asp:TemplateField>
                         <asp:TemplateField ControlStyle-Width="150px" HeaderText="Subtotal">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Subtotal_Detalle") %>' runat="server" />
                            </ItemTemplate>
                        
                        </asp:TemplateField>
                </Columns>
              </asp:GridView>
            </div>
            <div class="container" >
                <asp:Label runat="server" Text="Total" CssClass="label"></asp:Label>
                <asp:Label runat="server" Text="" id="lblTotal" ForeColor="Red" CssClass="label"></asp:Label>
                
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="button" OnClick="btnEnviar_Click"/>
                <asp:Label runat="server" Text="" ID="lbl1" CssClass="label"></asp:Label>
            </div>
        </div>
        
    </div>
    
</asp:Content>
