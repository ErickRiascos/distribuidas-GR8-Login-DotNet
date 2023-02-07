<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="login_dotnet_grupo8.ec.edu.espe.monster.vista.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="recursos/css/estilo.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <section>
            <img src="recursos/imagenes/monster.jpg" class="panel" />
        </section>
        
        <div class="sec2">
            <div class="contenedor">
                <div class="social">
                    <asp:Image ID="img1" runat="server" ImageUrl="~/ec/edu/espe/monster/vista/recursos/imagenes/logo_facebook.png" />
                    <asp:Image ID="img2" runat="server" ImageUrl="~/ec/edu/espe/monster/vista/recursos/imagenes/logo_twitter.png" />
                </div>

                <div class="contenido">
                    <h2>Iniciar Sesión</h2>

                    <asp:TextBox ID="txtNombreUsuario" placeholder="Nombre de usuario" runat="server" /> <br />
                    <asp:TextBox ID="txtClave" placeholder="Contraseña" runat="server" TextMode="Password" /> <br />
                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" />


                </div>

            </div>
        </div>
    </form>
</body>
</html>
