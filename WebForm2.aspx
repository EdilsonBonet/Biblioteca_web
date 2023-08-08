<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Lib_UNSA.WebForm2" %>


<!DOCTYPE html>
<div></div>

<html text=""  xmlns="<input id=">
<head>
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cuarto Laboratoorio wimc</title>
   
    <script type="text/javascript" src="/Scripts/jquery-3.4.1.min.js"></script>
   
    <link rel="stylesheet" href="/Content/bootstrap.min.css" />
    <script type="text/javascript" src="/Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="/Scripts/modernizr-2.8.3.js"></script>
    
    <style>
    body {
        background-image: url("https://images2.alphacoders.com/261/26102.jpg" );
        background-repeat: no-repeat;
        background-size: cover;
    }
    p {
        font-family: sans-serif;
        font-size: 20px;
        color: black;
        text-shadow: 0 0 10px rgba(255, 0, 0, 1);
        text-align: center;

    }
    h1 {
        background-color:#a45454;
        color: white;
        text-align: center;
    }
    label {
        font-family: sans-serif;
        font-size: 20px;
        color: black;
        text-shadow: 0 0 10px rgba(255, 0, 0, 1);
        width:100px;
    }
    input {
        color: black;
        background-color: rgb(218, 215, 215);
        border: 1px solid black;
        border-radius: 5px;
        width:200px;
    }
    #macho{
        width:10px;
    }
    #hembra{
        width:10px;
    }
    #aceptar{
        width:20px;
    }
    textarea{
        color: black;
        background-color: rgb(218, 215, 215);
        border: 1px solid #e600e6;
        border-radius: 5px;
        width:100%;
        height:200px;
    }
    .listaop{
        color: black;
        background-color: #96c7dd;
        border: 1px solid #e600e6;
        border-radius: 5px;
    }
    .botones{
        display:flex;
        justify-content:space-around;
    }

    .boton {
        background-color: rgba(203, 43, 8 );
        border-color: black;
        color: #fff;
        border-radius: 5px;
    }

    .boton:hover {
        background-color: rgb(247, 250, 36);
        border-color: #e600e6;
    }
    #texto_resumen{
        font-size:14px;
    }
    .clase_temporal{
        height : 20px;
    }
    .todo {
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
      
    }

    form {
        background-color: rgba(240, 240, 240, 0.5);
        width: 600px;
        padding: 20px ;
        margin: 0px 50px;
        border: 1px solid #ccc;
        border-radius: 5px;
    }

    label[for="aceptar"] {
      color: blue;
      font-weight: bold;
      font-family: sans-serif;
      font-size: 15px;
      color: black;
      text-shadow: 0 0 10px rgba(255, 0, 0, 1);
      width:280px;
      margin-right: 10px;
    }

    .alertac {
        width: 400px;
        background-color: rgba(240, 240, 240, 0.5);
        position: fixed;
        top: 0px;
        left: 50%;
        transform: translateX(-50%);
        color: #e97015;
        text-align: center;
    }

    .alertac .confirmar-boton {
        background-color: #007bff;
        color: #fff;
        padding: 8px 16px;
    }
  </style>
</head>
<script type="text/javascript">
    var cont = 0;
    function verificarNombreyApellidos() {
        var nombre = $('#TextNombre').val();
        var apellido = $('#TextApellido').val();


        if (nombre !== "" && apellido !== "") {
            $.ajax({
                url: 'WebForm2.aspx/verificarNombreyApellido',
                type: 'POST',
                async: true,
                data: JSON.stringify({ nombre: nombre, apellido: apellido }),
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                success: exito
            });
        }
        return false;
    }
    function exito(data) {
        var returnS = data.d;

        if (returnS) {

            $('#mensajeExito').hide();
            $('#mensajeError').text('El nombre y apellido ya están registrados.').show();
        } else {
            $('#mensajeError').hide();
            $('#mensajeExito').text('Nombre y apellidos permitidos.').show();
        }
        return false;
    }
    function limpiar_contenido() {
        var vacio = "";

        document.getElementById("TextNombre").value = vacio;
        document.getElementById("TextApellido").value = vacio;
        document.getElementById("macho").checked = vacio;
        document.getElementById("hembra").checked = vacio;
        document.getElementById("TextEmail").value = vacio;
        document.getElementById("TextCelular").value = vacio;
        document.getElementById("anio").value = 0;
        document.getElementById("TextCui").value = vacio;
        document.getElementById("contraseña1").value = vacio;
        document.getElementById("contraseña2").value = vacio;

        alerta("Limpieza exitosa");
        return false;
    }
    function validar_nombre(nombre) {
        var caracteresValidos = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
        if (nombre.length == 0) {
            return false;
        }
        for (var i = 0; i < nombre.length; i++) {
            if (caracteresValidos.indexOf(nombre[i]) === -1) {
                return false;
            }
        }
        return true;
    }
    function validar_apellido(apellido) {
        var caracteresValidos = "ABCDEFGHIJKLMÑNOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz ";
        var aux = 0;
        for (var i = 0; i < apellido.length; i++) {

            if (aux == 1 && apellido[i] == " ") {
                return false;
            }
            if (caracteresValidos.indexOf(apellido[i]) === -1) {
                return false;
            }
            if (apellido[i] == " " && aux == 0) {
                aux = 1;
            }
        }
        if (apellido.length > 0) {
            return true;
        }
        return false;

    }

    function validar_sexo(radios) {

        for (var i = 0; i < radios.length; i++) {
            if (radios[i].checked) {

                return true;
            }
        }

        return false;
    }

    function verificarSeleccion() {
        var selectElement = document.getElementById("ciudadOpciones").value;

        if (selectElement == "") {
            alert("Por favor, seleccione una opción.");
            return false;
        }
        return true;
    }
    function validar_email(correo) {
        var caracteresValidos = "abcdefghijklmnopqrstuvwxyz";
        const formato = "@unsa.edu.pe";
        var pos = correo.indexOf("@");

        for (var i = 0; i < pos; i++) {
            if (caracteresValidos.indexOf(correo[i]) === -1) {
                return false;
            }
        }
        for (var i = 0; i < formato.length; i++) {
            if (!(correo[pos + i] == formato[i])) {
                return false;
            }
        }
        if (correo == "") {
            return false;
        }
        return true;

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
            alerta("Correo no valido " + campoTexto[0]);
            return false;
        } else if (count != 0) {
            alerta("El dominio del correo ingresado es invalido");
            return false;
        }
        return true;
    }
    function validarNumero() {
        var inputText = document.getElementById("TextCelular").value;

        if (isNaN(inputText)) {
            alerta("Por favor, el campo de celular solo resive numeros.", 1);
            return false;
        }
        if (inputText.length !== 9) {
            alerta("Por favor, ingresa exactamente 9 digitos para el celular.", 1);
            return false;
        }
        return true;
    }
    function validarCui() {
        var inputText = document.getElementById("TextCui").value;

        if (isNaN(inputText)) {
            alerta("El cui solo resive datos numericos.", 1);
            return false;
        }
        if (inputText.length !== 8) {
            alerta("Por favor, ingresa exactamente 8 números para el CUI.", 1);
            return false;
        }
        return true;
    }
    function validarContraseñas() {
        var pass1 = document.getElementById("contraseña1").value;
        var pass2 = document.getElementById("contraseña2").value;

        if (pass1 !== pass2) {
            alerta("Las contraseñas no coinciden. Por favor, intenta de nuevo.");
            return false;
        }

        if (pass1.length < 7) {
            alerta("La contraseña debe tener al menos 7 caracteres.");
            return false;
        }

        var numCount = 0;
        for (var i = 0; i < pass1.length; i++) {
            if (!isNaN(pass1[i])) {
                numCount++;
            }
        }

        if (numCount < 2) {
            alerta("La contraseña debe contener al menos 2 números.");
            return false;
        }
        return true;
    }
    function verificarCheckbox() {
        var checkbox = document.getElementById("aceptar");

        if (checkbox.checked) {
            return true;
        } else {
            alert("Por favor, Necesitas aceptar los terminos y condiciones.");
            return false;
        }
    }

    function alerta(texto, n) {
        var cuadro_alerta = document.createElement('div');
        cuadro_alerta.className = 'alertac';
        var tema = document.createElement('p');
        if (n == 1) {
            tema.textContent = 'ERROR';
            tema.className = 'rojo';
        } else {
            tema.textContent = 'BIEN HECHO';
            tema.className = 'verde';
        }
        var mensaje = document.createElement('p');
        mensaje.textContent = texto;

        var confirmaBtn = document.createElement('button');
        confirmaBtn.textContent = 'Confirmar';
        confirmaBtn.className = 'confirmar-boton';
        confirmaBtn.addEventListener('click', function () {
            cuadro_alerta.remove();
        });

        cuadro_alerta.appendChild(tema);
        cuadro_alerta.appendChild(mensaje);
        cuadro_alerta.appendChild(confirmaBtn);

        document.body.appendChild(cuadro_alerta);
    }


    function verificar_llenado() {

        if (!validar_nombre(document.getElementById("TextNombre").value)) {
            alerta("El nombre ingresado no es valido", 1);

            return false;
        }

        if (!validar_apellido(document.getElementById("TextApellido").value)) {
            alerta("El apellido ingresado no es valido", 1);
            return false;
        }

        if (!validar_sexo(document.getElementsByName("sexo"))) {
            alerta("Sexo no indicado", 1);
            return false;
        }
        if (!emaileva()) {

            return false;


        }
        if (document.getElementById("anio").value == 0) {
            alerta("Falta indicar la ciudad", 1);
            return false;
        }
        if (!validarNumero()) { return false; }
        if (!validarCui()) { return false; }
        if (!validarContraseñas()) { return false; }
        if (!verificarCheckbox()) { return false; }

        var fechaActual = new Date();
        //var mensaje = "Registro realizado el " + fechaActual;
        alert("REGISTRO REALZADO EL " + fechaActual);
        //alerta(mensaje,2);


        return true;//apra que no recarge l apagina y no pase alguna solicitud als server
    }

</script>
      
<body>
    
    

    <div class="todo">

    <form id="form1" runat="server" name="registro" >
        <div>
            <p>REGISTRO</p>
        </div>
        <div>
            <label for="nombre">Nombre:</label>
            <asp:TextBox runat="server" id="TextNombre"  onblur="verificarNombreyApellidos()"></asp:TextBox>
        </div>
        <div>
            <label for="apellido">Apellidos:</label>
            <asp:TextBox id="TextApellido" runat="server" onblur="verificarNombreyApellidos()"></asp:TextBox>
        </div>
        <div id="mensajeError" class="rojo separa" style="display: none;"></div>
        <div id="mensajeExito" class="verde separa" style="display: none;"></div>
        <div>
            <label for="sexo1">Sexo</label>
            <asp:RadioButton id="macho" runat="server" GroupName="sexo" Text="Masculino"  />

            <asp:RadioButton id="hembra" runat="server" GroupName="sexo" Text="Femenino" />
        </div>

        <div>
            <label for="email">Email:</label>
            <asp:TextBox id="TextEmail" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="celular">Celular:</label>
                <asp:TextBox id="TextCelular" runat="server"></asp:TextBox>
            <label for="anio">Año:</label>
                <asp:DropDownList id="anio" runat="server" class="listaop" DataTextField="seleccione-ciudad">


                </asp:DropDownList>
        </div>
        <div>
            <label for="cui">CUI:</label>
            <asp:TextBox ID="TextCui" runat="server"  ></asp:TextBox>
        </div>  
 
        <div >
            <label for="contraseña">Contraseña:</label>
            <asp:TextBox ID="contraseña1" runat="server" TextMode="Password" style="text-align: center;"></asp:TextBox>
        </div>
        <div >
            <label for="contraseña2">Verificar:</label>
            <asp:TextBox ID="contraseña2" runat="server" TextMode="Password" placeholder="validar contraseña" style="text-align: center;"></asp:TextBox>
        </div>  

        <div>
            
            <label for="aceptar">Acepto los términos y condiciones:</label>
            <input type="checkbox" id="aceptar" name="aceptar">
        </div>
        <div class="botones">
            <asp:Button id="btnLimpiar" runat="server" Text="Limpiar" class="boton" OnClientclick="return limpiar_contenido();"     />
            <asp:Button ID="btnEnviar" runat="server" Text="Registrar" class="boton" OnClientClick="return verificar_llenado();" OnClick="btnRegistrar_Click"/>
        </div>
        <div >
            <asp:Label ID="eti_salida" runat="server" Visible="false"></asp:Label>
        </div>
        <div>
            <textarea id="texto_resumen" runat="server" Visible="false" rows="4" cols="50"></textarea>

        </div>
</form>
    </div>
</body>
</html>
