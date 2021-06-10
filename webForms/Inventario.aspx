<%@ Page Title="" Language="C#" MasterPageFile="~/webForms/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="Panaderia.webForms.Inventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="containerInventario">
        <div class="containerCenter">
            <div class="container">
                <asp:Label ID="Label1" runat="server" Text="Producto:" CssClass="label"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropList"></asp:DropDownList>
                <asp:Label ID="Label2" runat="server" Text="Cantidad:" CssClass="label"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="txtBox"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Enviar" CssClass="button" />
            </div>
            <div class="containerGridViewInventario">
                <asp:GridView runat="server" ID="gridViewInventario" >

                </asp:GridView>
            </div>
        </div>
        
    </div>

</asp:Content>
