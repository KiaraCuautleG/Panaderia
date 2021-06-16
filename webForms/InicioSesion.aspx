<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="Panaderia.InicioSesion" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="../assets/css/login.css"/>
    <link href="../assets/icons/css/all.css" rel="stylesheet"/>
    <link rel="preconnect" href="https://fonts.gstatic.com">
<link href="https://fonts.googleapis.com/css2?family=Noto+Sans+JP:wght@500&display=swap" rel="stylesheet"> 
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@100&display=swap" rel="stylesheet"/> 
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="containerLogin">
                <i class="iconG fas fa-user-circle"></i>
                <asp:Label ID="lbl2" runat="server" Text="" CssClass="datosIncorrectos"></asp:Label>
                <asp:Label runat="server" Text="Usuario" CssClass="lbl" ID="lblUsuario"/>
                <div class="containerUser">
                    <i class="iconP fas fa-user-circle"></i>
                    <asp:TextBox runat="server" ID="txtUsuario" CssClass="txtUsuario" ></asp:TextBox>
                </div>
                <asp:RegularExpressionValidator CssClass="validacion" ID="RegularExpressionValidator1" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ControlToValidate="txtUsuario" runat="server" ErrorMessage="Usuario no valido"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="validacion" ControlToValidate="txtUsuario" runat="server" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
                <asp:Label runat="server" Text="Contraseña" CssClass="lbl" ID="lblContraseña"/>
                <div class="containerPassword">
                    <i class="iconP fas fa-lock"></i>
                    <asp:TextBox runat="server" ID="txtContraseña" TextMode="Password" CssClass="txtContraseña" ></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validacion" ControlToValidate="txtContraseña" runat="server" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator>
                <div class="containerButton">
                    <asp:ValidationSummary CssClass="validacion" ID="ValidationSummary1" runat="server" />
                    <asp:Button Text="Ingresar" ID="btnLogin" CssClass="btnIngresar" runat="server" OnClick="btnLogin_Click"/>
                    <asp:Label ID="lbl1" runat="server" Text=""></asp:Label>
                    
                </div>
                
            </div>
        </div>
    </form>
</body>
</html>
