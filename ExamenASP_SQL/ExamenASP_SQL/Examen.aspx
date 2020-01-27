<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Examen.aspx.cs" Inherits="ExamenASP_SQL.Examen" %>

<!DOCTYPE html>
 


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


 
    <title></title>
    <style type="text/css">

        h1,h3{
            color:blue;
            text-decoration-style:double;
            font-style:oblique 


        }

        .auto-style1 {
            width: 100%;
        }
        .diseño-tabla-js {
            width: 100%;
            border-style: solid;
            border-width: 2px;
            background-color: white;
            border:0px
        }

        .diseño_campo{

           width:300px; 
           text-align:center;

        }

        .diseño_botones{

           width:300px; 
        }
        .auto-style2 {
            width: 100%;
            border: 1px solid #0000FF;
        }


        #bntTexto {
            width: 116px;
        }


        #bntInsertar {
            width: 81px;
        }


        .auto-style3 {
            width: 333px;
            text-align: left;
        }
        .auto-style4 {
            width: 333px;
        }


        .auto-style5 {
            width: 88px;
        }


        .auto-style6 {
            width: 145px;
        }

        
.box-content {
	-moz-border-radius-bottomleft: 5px;
	-moz-border-radius-bottomright: 5px;
	-webkit-border-bottom-left-radius: 5px;
	-webkit-border-bottom-right-radius: 5px;
	border: 1px solid #d8d8d8;
	/*border-top: 0;*/
	background: white;
	padding:  10px;
	-moz-box-shadow: 0 2px 2px #dddddd;
	-webkit-box-shadow: 0 2px 2px #dddddd;  
	margin:0 auto; /*AGREGADO*/
}

.TablaTitulos {
    font-weight: bold;
    font-size: 7.5pt;
    color: #003399;
    font-family: Verdana;
    text-decoration: none;
    border: #95b7f3 1px solid;
    background-image: url(../images/toolgrad.gif);
    background-repeat: repeat-x;
    background-color: #9ebff6;
    border-color: #95b7f3;
}
.tablaDatos {
    padding-left: 0;
    font-size: 10px;
    color: navy;
    font-weight: normal;
    font-family: Verdana;
    text-decoration: none;
    border-spacing: 1px;
    border: 1px solid #7F9DB9;
}

    .tablaDatos tr {
        height: 18px;
    }

    .tablaDatos td {
        padding: 1px 0;
        vertical-align: middle;
    }
    </style>

 


    <link href="estilos/jquery.dataTables.css" rel="stylesheet" />
    <link href="estilos/jquery.dataTables_themeroller.css" rel="stylesheet" />
    <link href="estilos/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" />
  

   <script src="JS_Claro/jquery-1.10.2.js"></script>

 
    <script src="JS_Claro/jquery-ui-1.10.3.custom.min.js"></script>
    <script src="JS_Claro/jquery.dataTables.js"></script>
   <script src="JS_creados/JSEstudiantes.js"></script>
    
 

</head>

<body>
    <form id="form1" runat="server">
        <hr />


        <div>

         <h1  style="text-shadow:0 1px 0 white;background-color:cadetblue ;color:white;text-align:center;border:1px solid black;line-height: 35px;padding:0px " > Mantenimiento </h1>
     

        </div>


         <div  class="box-content"    >

             <table align="center" class="diseño-tabla-js">
                 <tr>
                     <td  >Id</td>
                     <td class="auto-style3"> 
                         <input id="txtClave"  type="text" name="name" value="" style=" width:200px "/></td>
                     <td>
                         &nbsp;

                     </td>
                         
                 </tr>
                 <tr>
                     <td class="auto-style6">&nbsp;</td>
                     <td class="auto-style4"> </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td class="auto-style6"> 
                         
                       <%--  <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Descarga Excel" Width="107px" />--%>

                     </td>

                     
                      <td class="auto-style4" >  
                             <input id="bntConsultaAjax"   type="button" name="name1" value="Consulta ajax" />
                             <input id="bntInsertar"   type="button" name="name1" value="Insertar" class="auto-style5" />&nbsp; 
                      </td>
   
                      <td> </td>

                 </tr>
             </table>
             <br />

         </div>

<div id="divTabla">

    <table id="TblEstudiente" class="tablaDatos" style="width:100%">

        <thead class="TablaTitulos">
            
        <tr>
            <td>CODIGO</td><td>NOMBRE</td><td>EDAD</td><td>F.NACIMIENTO</td><td>ACTUALIZAR</td><td>ELIMINAR</td>
        </tr>

        </thead>

        <tbody>
            
        

        </tbody>

    </table>

</div>



<div id="divModal"  style="display:none"  >

    <table align="center" class="auto-style2">
        <tr>
            <td>Codigo</td>
            <td  >
                <input id="txtvCodgigo"   class="requerido" type ="text" name="name"   /></td>
         </tr>
        <tr>
            <td>Nombre</td>
            <td> <input id="txtvNombre"  class="requerido" type ="text" name="name"   /></td> 
            
        </tr>
        <tr>
            <td>Edad</td>
           <td> <input id="txtvEdad" class="requerido" type ="text" name="name"   /></td> 
             
        </tr>
        
           <tr>
            <td>F.Nacimiento</td>
           <td> <input id="txtfecha" class="requerido" type ="text" name="name"   /></td> 
             
        </tr>
 

    </table>
    
    <div style="text-align:center">
                <input id="btnGuardarPop" type ="button" name="name" value="Guardar"    />
                <input id="btnUpdatePop" type ="button" name="name" value="Actualizar"    />

    </div>


</div>

    </form>
</body>
</html>

