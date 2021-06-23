<%@ Page Title="" Language="C#" MasterPageFile="~/webForms/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Panaderia.webForms.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="containerProducto">
        <div class="containerCenter">
            <div class="containerTb">
                <asp:Label ID="lblSuccessMessage" CssClass="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
                
                <asp:Label ID="lblErrorMessage"  CssClass="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
                <h1 style="text-align:center">Productos</h1>
                <asp:GridView ID="gvProductos" CssClass="gridView" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="ID_Pan"
                    ShowHeaderWhenEmpty="true"
                    OnRowCommand="gvPhoneBook_RowCommand" OnRowEditing="gvPhoneBook_RowEditing" OnRowCancelingEdit="gvPhoneBook_RowCancelingEdit"
                    OnRowUpdating="gvPhoneBook_RowUpdating" OnRowDeleting="gvPhoneBook_RowDeleting"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
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
                        <asp:TemplateField HeaderText="ID">
                            
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("ID_Pan") %>' runat="server" />
                            </ItemTemplate>
                            
                            <FooterTemplate>
                                <asp:TextBox ID="txtIDPanFooter" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Nombre_Pan") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNombrePan" Text='<%# Eval("Nombre_Pan") %>' runat="server" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNombrePanFooter" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descripción">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Descripcion_Pan") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDescripcionPan" Text='<%# Eval("Descripcion_Pan") %>' runat="server" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtDescripcionPanFooter" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Precio">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Precio_Pan") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPrecioPan" Text='<%# Eval("Precio_Pan") %>' runat="server" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtPrecioPanFooter"  runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Distribuidor">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Distribuidor_Pan") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDistribuidorPan" Text='<%# Eval("Distribuidor_Pan") %>' runat="server" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtDistribuidorPanFooter" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="../assets/img/gridView/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                                <asp:ImageButton ImageUrl="../assets/img/gridView/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px"/>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ImageUrl="../assets/img/gridView/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                                <asp:ImageButton ImageUrl="../assets/img/gridView/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ImageUrl="../assets/img/gridView/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px"/>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
            
            </div>
              
        </div>
      
    </div>
</asp:Content>
