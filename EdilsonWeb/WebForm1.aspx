<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EdilsonWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <!--JQuery-->
    <script type="text/javascript" src="/Scripts/jquery-3.4.1.min.js"></script>
    <!-- Bootstrap core CSS -->
    <link rel="stylesheet" href="/Content/bootstrap.min.css" />
    <script type="text/javascript" src="/Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="/Scripts/modernizr-2.8.3.js"></script>
    <title></title>
    <style>
        body {

            background-color: black;
            background-image: url(https://larepublica.cronosmedia.glr.pe/migration/images/HZYN3U6UMVEO3DMCLMRMPHHVEA.jpg);
            background-size: cover;
            font-family: fantasy;
            font-size: 35px;
            color: grey;
            -webkit-text-stroke: 1px black;
            text-align: center;
        }
        h1 {
            color: #802434;
            text-align: center;
        }
        p {
            font-family: fantasy;
            font-size: 35px;
            color: grey;
        }
        Label {
            font-family: fantasy;
            font-size: 35px;
            color: grey;
        }
        #TextBoxNombre {
            color: #84c754;
            background-color: gray;
        }
        #ButtonLimpiar {
            background-color: gray;
            color: #ffffff;
        }
        #ButtonEnviar {
            background-color: black;
            color: #ffffff;
        }

        input[type="text"] {
            font-family: verdana;
            margin: 5px 0;
            border: 2px solid black;
            border-radius: 4px;
            padding: 1px 2px;
            background-color: #fff;
            color: #333;
            font-size: 20px;
        }
        #TextAreaRequerimiento {
            
            font-family: verdana;
            border: 2px solid black;
            font-size: 25px;
        }
        #txtAreaResultado{
            font-family: verdana;
            font-size: 15px;
            background-color: #DEFD41;
        }
        #ciudadOpciones{
            font-family: verdana;
            font-size: 20px;
        }

    </style>

     <script type="text/javascript">
        function limpiar_contenido() {
            var vacio = "";
            document.getElementById("TextNombre").value = vacio;
            document.getElementById("TextApellido").value = vacio;
            document.getElementById("macho").checked = false;
            document.getElementById("hembra").checked = false;
            document.getElementById("TextEmail").value = vacio;
            document.getElementById("TextDireccion").value = vacio;
            document.getElementById("ciudadOpciones").value = 0;
            document.getElementById("TextAreaRequerimiento").value = vacio;
            alert("Limpiado con exito")
            return false;
         }

         function validarNom() {

             var dato = document.getElementById("TextNombre").value;
             var regex = /^[a-zA-Z]+$/;
             var valor = dato.length;
             
             if (dato == "") {
                 alert("Nombre no ingresado");
                 return false;
             } else if(!regex.test(dato)) {
                 alert("Caracter no valido");
                 return false;
             }
             return true;
         }
         function validarApe() {

             var dato = document.getElementById("TextApellido").value;
             var regex = /^[A-Za-z\s]+$/;
             var space = " ";
             if (dato == "") {
                 alert("Apellido no ingresado");
                 return false;
             } else if (!regex.test(dato)) {
                 alert("Caracter no valido");
                 return false;
             }
             return true;
         }
         function bolas() {
             sexos = document.getElementsByName("sexo");
             for (var i = 0; i<sexos.length; i++) {
                 if (sexos[i].checked) {
                     return true;
                 }
             }
             alert("Falta elegir sexo");
             return false;

         }
         function emaileva() {
             var campoTexto = document.getElementById("TextEmail").value;
             var palabraProhibida = ['@', 'u', 'n', 's', 'a', '.', 'e', 'd', 'u', '.', 'p', 'e'];
             var count = 0;
             for (var i = 0; i < 12; i++) {
                 if (palabraProhibida[i] != campoTexto[campoTexto.length - 12 + i]) {
                     count++;
                 }      
             }
             if (campoTexto[0] == '@') {
                 alert("Correo no valido " + campoTexto[0]);
                 return false;
             } else if (count != 0) {
                 alert("El dominio del correo ingresado es invalido");
                 return false;
             }
             return true;
         }
         function verificarSeleccion() {
             var selectElement = document.getElementById("ciudadOpciones").value;

             if (selectElement == "") {
                 alert("Por favor, seleccione una opción.");
                 return false;
             }
             return true;
         }


         function mostrarFechaHoraPeru() {
             var fechaHora = new Date();
             var options = {
                 year: "numeric",
                 month: "long",
                 day: "numeric",
                 hour: "numeric",
                 minute: "numeric",
                 second: "numeric",
                 timeZone: "America/Lima"
             };

             var fechaHoraPeru = fechaHora.toLocaleString("es-PE", options);
             alert("Registrado con Fecha y hora en Perú: " + fechaHoraPeru);
             return false;
         }
         function validarinfo() {
             if (validarNom() == true && validarApe() == true && bolas() == true && emaileva() == true && verificarSeleccion() == true) {
                 mostrarFechaHoraPeru();
                 btnEnviar_Click;
                 
             }
             return false;
         }


     </script>
    
</head>
<body>
    <h1>Registro de Alumnos:</h1>
    <form id="form1" runat="server">
        <div>
            <label>Nombre:</label>
            <asp:TextBox ID="TextNombre" runat="server" onfocusout ="   validarNom(); "></asp:TextBox></div>

        <div>
            <label>Apellidos:</label>
            <asp:TextBox ID="TextApellido" runat="server" onfocusout ="   validarApe(); "></asp:TextBox></div>

        <div>
            <label>Sexo</label>
            <asp:radiobutton runat="server" id="macho" groupname="sexo" Text="Masculino"/>
            <asp:radiobutton runat="server" id="hembra" groupname="sexo" Text="Femenino"/></div>
            
        <div>
            <label>Email:</label>
            <asp:TextBox ID="TextEmail" runat="server" onblur =" emaileva();"></asp:TextBox></div>
        <div>
            <label>Direccion</label>
            <asp:TextBox ID="TextDireccion" runat="server"></asp:TextBox>

            <label>Ciudad</label>
            <asp:DropDownList ID="ciudadOpciones" runat="server"></asp:DropDownList>
        </div>
       
        <div><label>Requerimiento:</label></div>
        <div><textarea id="TextAreaRequerimiento" runat="server"></textarea></div>

        <asp:Button ID="ButtonLimpiar" runat="server" Text="Limpiar" OnClientClick="return limpiar_contenido();"/>
        <asp:Button ID="ButtonEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" OnClientClick="return  validarinfo();"    />
        
        <br />
        <textarea id="txtAreaResultado" runat="server" Visible="false" rows="8" cols="50"></textarea>
    </form>

     
</body>
</html>