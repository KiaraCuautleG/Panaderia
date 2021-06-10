<%@ Page Title="" Language="C#" MasterPageFile="~/webForms/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="Panaderia.webForms.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="containerVentas">
        <div class="containerCenter">
            <div class="container">
                <asp:Label runat="server" Text="Fecha" CssClass="label"></asp:Label>
                <asp:Calendar ID="Calendar1" runat="server" CssClass="calendar"></asp:Calendar>
                <asp:Label runat="server" Text="Número" CssClass="label"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="txtBox" TextMode="Number"></asp:TextBox>
            </div>
            <div class="container">
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                <asp:Label runat="server" Text="Cantidad" CssClass="label"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="txtBox" TextMode="Number"></asp:TextBox>
                <asp:Label runat="server" Text="Precio" CssClass="label"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="txtBox"></asp:TextBox>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="button" />
            </div>
            <div class="container">
                <asp:GridView ID="gvPhoneBook" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="PhoneBookID"
                ShowHeaderWhenEmpty="true"

              

                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="gvPhoneBook_SelectedIndexChanged">
                <%-- Theme Properties --%>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("ID") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtID" Text='<%# Eval("ID") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtID" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Producto">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Producto") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProducto" Text='<%# Eval("Producto") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtProductoFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Precio">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Precio") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrecio" Text='<%# Eval("Precio") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtPrecioFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Cantidad") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCantidad" Text='<%# Eval("Cantidad") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCantidadFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/gridView/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/gridView/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/Images/gridView/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/Images/gridView/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
              </asp:GridView>
            </div>
            <div class="container">
                <asp:Label runat="server" Text="Total" CssClass="label"></asp:Label>
                <asp:TextBox ID="TextBox4" runat="server" CssClass="txtBox"></asp:TextBox>
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="button"/>
            </div>
        </div>
        
    </div>
    
</asp:Content>
