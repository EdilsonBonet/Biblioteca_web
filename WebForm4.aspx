<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="Lib_UNSA.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Administración | Lib-UNSA</title>
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'/>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script type="text/javascript">
        function mostrarDatos(nro, titulo, anio, edicion, editorial, autores, categoria, cantidad) {
            // Obtener el elemento de la página donde se mostrarán los datos (por ejemplo, un div con id="resultado")
            var resultadoDiv = document.getElementById('<%= resultado.ClientID %>');

            // Crear una tabla para mostrar la información de cada libro
            var tablaLibro = document.createElement("table");
            tablaLibro.classList.add("tabla-libro"); // Agregar una clase CSS para dar estilo a la tabla

            // Crear una fila para los encabezados
            var filaEncabezados = tablaLibro.insertRow();
            var encabezados = ["CUI", "NOMBRE", "ID-LIBRO", "TITULO", "FECHA"];

            for (var i = 0; i < encabezados.length; i++) {
                var th = document.createElement("th");
                th.textContent = encabezados[i];
                filaEncabezados.appendChild(th);
            }

            // Crear una nueva fila para cada libro
            var filaLibro = tablaLibro.insertRow();
            var celdas = [cui, nombre, id, titulo, fecha];

            for (var i = 0; i < celdas.length; i++) {
                var td = document.createElement("td");
                td.textContent = celdas[i];
                filaLibro.appendChild(td);
            }

            // Agregar la tabla al div de resultado
            resultadoDiv.appendChild(tablaLibro);
        }
    </script>
    <style>
        body {
            background-image: url("https://w0.peakpx.com/wallpaper/910/943/HD-wallpaper-warm-lights-in.jpg");
            background-repeat: repeat;
            background-size: cover;
            background-attachment: fixed;
            background-color: rgba(255, 255, 255, 0.4);
        }
        .grid-container {
            display: grid;
            grid-template-columns: 16% 16% 16% 16% 16% 16%;
            padding: 10px;
            
        }
        .grid-container > div {
            font-family: 'Courier New', monospace;
        }
        .grid-container-filtros {
            padding: 20px 20px;
            display: grid;
            grid-template-columns: auto auto;
            padding: 10px;
        }
        .grid-container-filtros > div {
            padding: 20px 10px;
            font-family: 'Courier New', monospace;
        }
        .grid-User {
            display: grid;
            grid-template-columns: auto auto auto auto;
            padding: 10px;
            background-color: rgb(177, 27, 0, 0.50);
            border-radius: 20px;
        }
        .grid-User > div {
            font-family: 'Courier New', monospace;
        }
        .grid-Books {
            display: grid;
            grid-template-columns: auto auto auto auto auto auto;
            padding: 10px;
            gap: 10px;
        }
        .grid-Books > div {
            font-family: 'Courier New', monospace;
        }
        .item-Encabezado {
            padding: 30px 20px;
            grid-column: span 3;
            background-color: rgba(255, 255, 255, 0.8);
        }
        .item-UNSA {
            background-color: rgba(255, 255, 255, 0.8);
        }
        .item-Usuario {
            padding: 20px 20px;
            grid-column: span 2;
            background-color: rgba(255, 255, 255, 0.8);
        }
        .item-boton-buscar {
            grid-column: span 4;
        }
        .item-Resultados {
            padding: 20px 20px;
            grid-column: span 6;
            background-color: rgba(255, 255, 255, 0.8);
            border-color: brown;
            border-width: 1px;
            border-style: dashed;
            border-right: none;
            border-left: none;
        }
        .item-Filtros {
            grid-row: span 4;
        }
        .filtros {
            background-color: rgb(255, 255, 255, 0.4);
        }
        .Title-Filtro {
            grid-column: span 2;
            background-color: rgb(0, 148, 255, 0.3);
        }
        .grid-container .item-Busqueda {
            position: relative;
            width: 90%;
            height: 50px;
            margin: 30px 0;
        }
        .item-Busqueda input {
            width: 100%;
            height: 100%;
            border-radius: 40px;
            font-size: 15px;
            padding: 0 30px 0;
            font-family: 'Courier New', monospace;
        }
        .item-Busqueda i {
            position: absolute;
            right: -50px;
            top: 50%;
            transform: translateY(-50%);
            font-size: 40px;
        }
        .filtros-boton {
            grid-column: span 2;
        }
        #ButtonFiltros {
            color: white;
            font-size: 20px;
            border-width: 0px;
            background-color: cornflowerblue;
            border-color: blue;
            border-radius: 5px;
            height: 40px;
            width: 100%;
            font-family: 'Courier New', monospace;
            cursor: pointer;
        }
        #ButtonSearch {
            margin-top: 36px;
            margin-left: 30px;
            color: white;
            font-size: 20px;
            border-width: 0px;
            background-color: rgba(255, 255, 255, 0.4);
            border-color: blue;
            border-radius: 5px;
            height: 40px;
            width: 100%;
            font-family: 'Courier New', monospace;
            cursor: pointer;
        }
        l {
            font-family: 'Goudy Old Style';
            font-size: 50px;
            text-decoration-line: overline underline;
            text-shadow: 1px 1px 2px;
        }
        .User {
            height: 60px;
            width: auto;
        }
        .icon {
            text-align: center;
            grid-row: span 3;
        }
        .data-user {
            color: white;
            margin-left: 10px;
            grid-column: span 3;
        }
        .Libros {
            height: 200px;
            width: auto;
        }
        .Logo {
            
        }
        .book-info {
            grid-column: span 5;
        }

        .tabla-libro {
            width: 100%;
            border-collapse: collapse;
        }

        /* Estilos para las celdas del encabezado */
        .tabla-libro th {
            background-color: #f2f2f2;
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        /* Estilos para las filas pares */
        .tabla-libro tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        /* Estilos para las filas impares */
        .tabla-libro tr:nth-child(odd) {
            background-color: #ffffff;
        }

        /* Estilos para las celdas */
        .tabla-libro td {
            border: 1px solid #ddd;
            padding: 8px;
        }
        .Logo {
            margin-top: 25px;
            height: 65px;
            width: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="grid-container">
            <div class="item-Encabezado">
                <l>
                    LIB-UNSA
                </l>
            </div>
            <div class="item-UNSA">
                <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3a/LOGO_UNSA.png/1200px-LOGO_UNSA.png" class="Logo"/>
            </div>
            <div class="item-Usuario">
                <div class="grid-User">
                    <div class="icon">
                        <img src="https://assets.stickpng.com/images/585e4beacb11b227491c3399.png" class="User"/>
                    </div>
                    <div class="data-user">
                         Nombre de Usuario
                    </div>
                    <div class="data-user">
                         Info
                    </div>
                    <div class="data-user">
                         More info
                    </div>
                </div>
            </div>
            <div class="item">
                
            </div>
            <div class="item-boton-buscar">
                <asp:Button ID="ButtonSearch" runat="server" Text="Modo Administrador" OnClientClick="return false;"/>
            </div>
            <div class="item">
                
            </div>
            <div class="item-Result">
                
            </div>
            <div class="item-Resultados">
                <div class="grid-Books">
                    <div id="resultado" runat="server">
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
