<%@ Page Title="" Language="C#" MasterPageFile="~/webForms/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Panaderia.webForms.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="containerProducto">
        <div class="containerCenter">
            <div class="container">
                <asp:GridView ID="gvPhoneBook" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="PhoneBookID"
                    ShowHeaderWhenEmpty="true"

                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
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
                                <asp:TextBox ID="txtIDFooter" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Nombre") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtLastName" Text='<%# Eval("Nombre") %>' runat="server" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNombreFooter" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Distribuidor">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Distribuidor") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDistribuidor" Text='<%# Eval("Distribuidor") %>' runat="server" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtDistribuidorFooter" runat="server" />
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
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Images/gridView/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                                <asp:ImageButton ImageUrl="~/Images/gridView/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px"/>
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
              
        </div>
      
    </div>
</asp:Content>
