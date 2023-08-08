<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="EdilsonWeb.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Lib-UNSA</title>
    <style>
        body {
            background-image: url("https://w0.peakpx.com/wallpaper/910/943/HD-wallpaper-warm-lights-in.jpg");
            background-repeat: repeat;
            background-size: cover;
            background-attachment: fixed;
        }
        .grid-container {
            display: grid;
            grid-template-columns: 16% 16% 16% 16% 16% 16%;
            gap: 10px;
            padding: 10px;
        }

        .grid-container > div {
            padding: 20px 10px;
        }
        .grid-Sesion {
            display: grid;
            grid-template-columns: 50% 50%;
            gap: 10px;
            padding: 10px;
        }
        .grid-Sesion > div {
            padding: 20px 10px;
        }
        .item-Primero {
            background-color: rgba(255, 255, 255, 0.4);
            grid-column: 1/ span 5;
        }
        .Logo {
            height: 60px;
            width: auto;
            text-align: center;
        }
        .item-Imagen {
            grid-column: 1/ span 4;
            grid-row: 2/ span 6;
            background-image: url(https://w0.peakpx.com/wallpaper/702/557/HD-wallpaper-person-reading-a-book-with-hands-on-top-of-book.jpg);
            background-repeat: repeat;
            background-size: cover;
            background-attachment: fixed;
            border-radius: 15px;
            text-align: left;
            font-size: 40px;
            color: darkred;
            font-family: 'Century Gothic';
        }
        .item-Info {
            border-top: double;
            border-width: 10px;
            font-size: 30px;
            grid-column: 1/ span 6;
            grid-row: span 2;
            font-family: "Lucida Console", "Courier New", monospace;
            text-align: center;
            text-transform: uppercase;
            text-shadow: 1px 1px 2px;
            color: white;
        }
        .item-in {
            font-size: 25px;
            background-color: rgba(255, 255, 255, 0.4);
            font-family: "Lucida Console", "Courier New", monospace;
            grid-column: span 2;
            border-radius: 10px;
            text-align: center;
        }
        #ButtonRegister {
            color: white;
            font-size: 20px;
            border-width: 0px;
            background-color: green;
            border-color: limegreen;
            border-radius: 5px;
            height: 35px;
            font-family: 'Courier New', monospace;
        }
        #ButtonLogin {
            color: white;
            font-size: 20px;
            border-width: 0px;
            background-color: mediumblue;
            border-color: blue;
            border-radius: 5px;
            height: 40px;
            width: 350px;
            font-family: 'Courier New', monospace;
        }
        #TextBoxUser {
            border-width: 3px;
            border-color: black;
            border-radius: 5px;
            width: 95%;
            height: 120%;
            font-family: 'Courier New', monospace;
        }
        #TextBoxPassword {
            border-width: 3px;
            border-color: black;
            border-radius: 5px;
            width: 95%;
            height: 120%;
            font-family: 'Courier New', monospace;
        }
        .item-Sesion {
            font-size: 30px;
            background-color: rgba(255, 255, 255, 0.4);
            font-family: 'Courier New', monospace;
            grid-column: span 2;
            grid-row: span 2;
            border-radius: 30px;
        }
        .item-Ses {
            grid-column: span 2;
        }
        .ima {
            width: auto;
            height: 80px;
        }
        .item-Espacio {
            background-color: rgba(255, 255, 255, 0.4);
            grid-row: span 7;
        }
        .item-InfoIma {
            background-color: rgba(255, 255, 255, 0.4);
            grid-column: span 4;
            grid-row: span 7;
        }
        .registro {
            grid-column: span 2;
            text-align: center;
        }
        l{
            font-family: 'Goudy Old Style';
            font-size: 50px;
            text-decoration-line: overline underline;
            text-shadow: 1px 1px 2px;
        }
        .item-Data {
            background-color: rgba(255, 255, 255, 0.4);
        }
        .Libro {
            width: 215px;
            height: 430px;
        }
        reg {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="grid-container">
            <div class="item-Primero">
                Encabezado
            </div>
            <div class="item-Logo">
                <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3a/LOGO_UNSA.png/1200px-LOGO_UNSA.png" class="Logo"/>
            </div>
            <div class="item-Imagen">
                <l>
                    LIB-UNSA
                </l>
                <br /><br /><br /><br /><br /><br /><br /><br /> 
                Encuentra y reserva <br />tus libros favoritos de manera sencilla y rápida.
            </div>
            <div class="item-Ses">
                
            </div>
            <div class="item-Sesion">
                <div class="grid-Sesion">
                    <div class="registro">
                        <reg>INICIO DE SESIÓN</reg>
                    </div>
                </div>
                <div class="grid-Sesion">
                    <div>
                        Usuario:
                    </div>
                     <div>
                        <asp:TextBox ID="TextBoxUser" runat="server" placeholder=" Ingrese su usuario"></asp:TextBox>
                    </div>
                </div>
                <div class="grid-Sesion">
                    <div>
                        Contraseña: 
                    </div>
                    <div>
                        <asp:TextBox ID="TextBoxPassword" runat="server" placeholder=" Ingrese su contraseña"></asp:TextBox>
                    </div>
                </div>
                <div class="grid-Sesion">
                    <div class="registro">
                        <asp:Button ID="ButtonLogin" runat="server" Text=" INICIAR SESION" OnClick="Button1_Click" />
                    </div>
                    <div class="registro">
                        <asp:Button ID="ButtonRegister" runat="server" Text=" REGISTRARSE " />
                    </div>
                </div>
            </div>
            <div class="item-Ses">
                
            </div>
            <div class="item-Info">
                Cuales son los beneficios??
            </div>
            <div class="item-in">
                <img src="https://cdn-icons-png.flaticon.com/512/2421/2421033.png" class="ima"/>
                <p>
                    Acceso a la lista de libros y su disponibilidad.
                </p>
            </div>
            <div class="item-in">
                <img src="https://cdn-icons-png.flaticon.com/512/57/57477.png" class="ima"/>
                <p>
                    Variedad de filtros para una mejor búsqueda.
                </p>
            </div>
            <div class="item-in">
                <img src="https://cdn-icons-png.flaticon.com/512/6902/6902028.png" class="ima"/>
                <p>
                    Comunicación directa entre usuario y administrador.
                </p>
            </div>
            <div class="item-Info">
                
            </div>
            <div class="item-Espacio">
                <img src="https://images.pexels.com/photos/6559063/pexels-photo-6559063.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" class="Libro"/>
            </div>
            <div class="item-InfoIma">
               imagen<br />hola que hace
            </div>
            <div class="item-Data">
               hola
            </div>
            <div class="item-Data">
               hola
            </div>
            <div class="item-Data">
               hola
            </div>
            <div class="item-Data">
               hola
            </div>
            <div class="item-Data">
               hola
            </div>
            <div class="item-Data">
               hola
            </div>
            <div class="item-Data">
               hola
            </div>
        </div>
    </form>
</body>
</html>