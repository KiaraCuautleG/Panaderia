<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="Panaderia.InicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="../assets/css/login.css"/>
    <link href="../assets/icons/css/all.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="containerLogin">
                <i class="fas fa-user-circle"></i>
                <asp:TextBox runat="server" ID="txtUsuario" Text="Usuario"></asp:TextBox>
                <i class="fas fa-lock"></i>
                <asp:TextBox runat="server" ID="txtContraseña" Text="Contraseña"></asp:TextBox>
            </div>
        </div>
    </form>
</body>
</html>
