<%@ Page Title="" Language="C#" MasterPageFile="~/webForms/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="Panaderia.webForms.Inventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="containerInventario">
        <div class="containerCenter">
            <div class="containerTitulo">
                <h1>Inventario</h1>
            </div>
            <div class="container">
                <asp:Label ID="Label1" runat="server" Text="Producto:" CssClass="label"></asp:Label>
                <asp:DropDownList ID="dropDownProductosI" runat="server" CssClass="dropList"></asp:DropDownList>
                <asp:Label ID="Label2" runat="server" Text="Cantidad:" CssClass="label"></asp:Label>
                <asp:TextBox ID="txtCantidadI" runat="server" CssClass="txtBox"></asp:TextBox>
                
                <asp:Button ID="btnAgregarInventario" runat="server" Text="Enviar" CssClass="button" OnClick="AgregarInventario" />
                
            </div>
            <div class="containerTb">
                <asp:Label ID="lblSuccessMessage" CssClass="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
                
                <asp:Label ID="lblErrorMessage"  CssClass="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
              <asp:GridView ID="gvInventario" CssClass="gridView" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="ID_Pan"
                    ShowHeaderWhenEmpty="true"
                    OnRowEditing="gvPhoneBook_RowEditing" OnRowCancelingEdit="gvPhoneBook_RowCancelingEdit"
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
                        <asp:TemplateField ControlStyle-Width="150px" HeaderText="ID Pan">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("ID_Pan") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ControlStyle-Width="150px" HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Nombre_Pan") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ControlStyle-Width="150px" HeaderText="Existencias">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Cantidad_Existencias") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCantidadExistencia" Text='<%# Eval("Cantidad_Existencias") %>' runat="server" />
                            </EditItemTemplate>
                      
                        </asp:TemplateField>
                        <asp:TemplateField ControlStyle-Width="150px" HeaderText="Precio">
                            <ItemTemplate>
                                <asp:Label Text='<%# Eval("Precio_Pan") %>' runat="server" />
                            </ItemTemplate>
                            
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
                            
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        
    </div>

</asp:Content>
