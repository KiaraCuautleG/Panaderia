<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="Panaderia.InicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="../assets/css/login.css"/>
    <link href="../assets/icons/css/all.css" rel="stylesheet"/>
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@100&display=swap" rel="stylesheet"/> 
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="containerLogin">
                <i class="iconG fas fa-user-circle"></i>
                <asp:Label runat="server" Text="Usuario" CssClass="lbl" ID="lblUsuario"/>
                <div class="containerUser">
                    <i class="iconP fas fa-user-circle"></i>
                    <asp:TextBox runat="server" ID="txtUsuario" CssClass="txtUsuario" ></asp:TextBox>
                </div>
                <asp:Label runat="server" Text="Contraseña" CssClass="lbl" ID="lblContraseña"/>
                <div class="containerPassword">
                    <i class="iconP fas fa-lock"></i>
                    <asp:TextBox runat="server" ID="txtContraseña" CssClass="txtContraseña" ></asp:TextBox>
                </div>
                <div class="containerButton">
                    <asp:Button Text="Ingresar" ID="btnLogin" CssClass="btnIngresar" runat="server"/>
                </div>
                
            </div>
        </div>
    </form>
</body>
</html>
