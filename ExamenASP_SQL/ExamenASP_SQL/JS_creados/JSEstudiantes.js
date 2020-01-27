 

var nombre = "cristhian";

//data table
//https://cdn.datatables.net/1.9.4/

$(document).ready(function () {

    $("#bntConsultaAjax").click(function () {
        ConsultaAjax();
    });

    $("#bntInsertar").click(function () {
         Fregistrar();
    });

});
 
function ajaxGeneral(llamada, url, datos, contenido, fMetodo) {

    $.ajax({
        //"post"
        type: llamada,
        //"../Examen/LlamdaTexto"
        url: url,
        data: datos,
        contentType: (contenido == 1 ? "application/text; charset=utf-8" : "application/json; charset=utf-8"),
        cache: false,
        dataType: (contenido == 1 ? "text" : contenido == 2 ? "html" : "json"),

        success: function (data) {
            fMetodo(data);

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
        }
    });

};



function ConsultaAjax() {

    var parBusqueda = new Object();
    parBusqueda.dato1 = $("#txtClave").val();

    ajaxGeneral("post", "Examen.aspx/ConsultaAjax", JSON.stringify(parBusqueda), "", call_Consulta);
}


function call_Consulta(data) {

    var coleccion = [];
    var TblEstudiente = $('#TblEstudiente').dataTable();
    TblEstudiente.fnClearTable();
    var i = 0;
    var row_detalle = new Object();
    $.each(data.d, function (indice, valor) {

        var opcEditar = "<img id='img_" + i + "'  name='img_" + i + "' src='../images/abrir.gif' style='cursor:pointer;' ";
        opcEditar += "onClick='recuperar_Row(&quot;" + valor.codigo + "&quot; ,&quot;" + valor.nombre + "&quot;,&quot;" + valor.edad + "&quot; ,&quot;" + valor.fnacimiento + "&quot; );' />"
         
        var opcEliminar = "<img id='img_" + i + "'  name='img_" + i + "' src='../images/ico_eliminar.gif' style='cursor:pointer;' ";
        opcEliminar += "onClick='fn_Eliminar(&quot;" + valor.codigo + "&quot; );' />"



        var array = [valor.codigo, valor.nombre, valor.edad, valor.fnacimiento, opcEditar, opcEliminar];
        coleccion.push(array);
        i++;
    });

    TblEstudiente.fnAddData(coleccion);
};


function fn_Eliminar(codigo) {

    var parBusqueda = new Object();
    parBusqueda.codigo = codigo;
    ajaxGeneral("post", "../Examen.aspx/eliminarAjax", JSON.stringify(parBusqueda), "", call_eliminar);
    
}

function call_eliminar(data) {

    if (data.d == "1") {

        alert("El registro se elimino correctamente - codigo:" + $("#txtvCodgigo").val());
        $("#bntConsultaAjax").click();
    }
};
 
function recuperar_Row(codigo, nombre, edad, fnacimiento) {

    $("#btnUpdatePop").show();
    $("#btnGuardarPop").hide();
    
    

    $("#txtvCodgigo").val(codigo);
    $("#txtvNombre").val( nombre);
    $("#txtvEdad").val( edad);
    $("#txtfecha").val(fnacimiento);

    openVentana("Detalle..");



    $("#btnUpdatePop").click(
        function () {

            var parBusqueda = new Object();

            parBusqueda.codigo = $("#txtvCodgigo").val();
            parBusqueda.nombre = $("#txtvNombre").val();
            parBusqueda.edad =   $("#txtvEdad").val();
            parBusqueda.fecha = $("#txtfecha").val();

            ajaxGeneral("post", "../Examen.aspx/updateAjax", JSON.stringify(parBusqueda), "", callUpdate);

          

        });
        
}
 

function callUpdate(data) {


    if (data.d == "1") {
        alert("Se actualizo correctamente el registro, del código " + $("#txtvCodgigo").val())
        $("#divModal").dialog("close");
        $("#bntConsultaAjax").click();
    }
};


function openVentana(titulo) {

    //https://www.jqueryscript.net/demo/Simple-jQuery-Modal-Dialog-Box-Plugin-Dialog/
    //https://api.jqueryui.com/dialog/#event-create

    $("#divModal").dialog({
        //body: "jQueryScript.net!",
        //bloqueo de Pantalla
        modal: true,
        draggable: false,
        //*no desapare con la tecla scape
        closeOnEscape: false,
        //*desapare boton cerrar
        //dialogClass: "noclose",
        title: titulo,
        //*ancho de la venta
        width: '300px',
        //*no se pueda redimensionar la ventana
        resizable: false,

        //estilo al mostrar la pantalla
        show: "fold",
        hide: "scale",
        position: ['center', 200],
        //of: window,
        //buttons: {
        //    'Cancel': function () {
        //        // YOUR CODE
        //        $(this).dialog("close");
        //    },
        //    'Continue': function () {
        //        // YOUR CODE
        //        $(this).dialog("close");
        //    },
        //},
        create: function () {
            var punto = $(this);
            punto.css("maxHeight", 400);
        },


        open: function () {

            $(this).css("max-height", $(window).height() * 0.9);
          
             
        }


    });

};


function Fregistrar() {

    $("#btnUpdatePop").hide();
    $("#btnGuardarPop").show();
    openVentana("Registrar..");
    limpiar_PopPup();


    $("#btnGuardarPop").click(function () {
        var valores = new Object();
        valores.codigo = $("#txtvCodgigo").val();
        valores.nombre = $("#txtvNombre").val();
        valores.edad = $("#txtvEdad").val();
        valores.fecha = $("#txtfecha").val();
        ajaxGeneral("post", "../Examen.aspx/insertAjax", JSON.stringify(valores), "", exitoRegistro);

    })

}

function exitoRegistro(data) {


    if (data.d == "1") {

         $("#divModal").dialog('close');
         alert("El código " + $("#txtvCodgigo").val() + " se inserto correctamente");
         $("#bntConsultaAjax").click();
    }

}


function limpiar_PopPup() {

    var clase = $(".requerido"); 
    for (var i = 0; i < clase.length; i++) {
        clase.eq(i).val("");
    };

}