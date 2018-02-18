/// Agregar publicidad
$(document).ready(function () {
    $("#frmagregarpubli").submit(function (e) {
        e.preventDefault();
        if ($("#namepubli").val() != "" && $("#maxcanjeo").val() != "" && $("#fechacupon").val() != "" && $("#descrip").val() != "") {
            var form = $('#frmagregarpubli')[0];
            var dataString = new FormData(form);
            $.ajax({
                url: '/Ajax/Ajax?data=addpubli',  //Server script to process data
                type: 'POST',
                data: dataString,
                //Options to tell jQuery not to process data or worry about content-type.
                cache: false,
                contentType: false,
                processData: false,
                beforeSend: function () {
                    $("#btnaddpubli").html('<i class="fa fa-spinner fa-pulse fa-fw"></i>  Agregando');
                },
                success: function (a) {
                    if (a == 1) {
                        swal({
                            text: 'Se ha agregado el cupón correctamente!',
                            type: "success",
                            confirmButtonText: "Aceptar",
                            confirmButtonColor: "#7986CB",
                            closeOnCancel: true,
                            closeOnConfirm: true,
                            showLoaderOnConfirm: true
                        })
                        $("#btnaddpubli").html('<i class="fa fa-plus"></i>  Agregar cupón');
                        $("#namepubli").val('');
                        $("#maxcanjeo").val('');
                        $("#fechacupon").val('');
                        $("#descrip").val('');
                    }
                    else if (a == 0) {
                        swal({
                            title: '¿Seguro no olvidas algo?',
                            html: '<li class="fa fa-image"></li>' + " " + "Debes ingresar una imagen",
                            type: "question",
                            confirmButtonText: "Aceptar",
                            confirmButtonColor: "#7986CB",
                            closeOnCancel: true,
                            closeOnConfirm: true,
                            showLoaderOnConfirm: true
                        });
                        $("#btnaddpubli").html('<i class="fa fa-plus"></i>  Agregar cupón');
                    }
                    else if (a == 2) {
                        swal({
                            title: '¡Ah ocurrido un error!',
                            html: "Un error ha ocurrido",
                            type: "error",
                            confirmButtonText: "Aceptar",
                            confirmButtonColor: "#7986CB",
                            closeOnCancel: true,
                            closeOnConfirm: true,
                            showLoaderOnConfirm: true
                        });
                        $("#btnaddpubli").html('<i class="fa fa-plus"></i>  Agregar cupón');
                    }

                }
            });
        }
        else {
            swal({

                text: 'No puedes dejar campos vacíos',
                type: "question",
                confirmButtonText: "Aceptar",
                confirmButtonColor: "#7986CB",
                closeOnCancel: true,
                closeOnConfirm: true,
                showLoaderOnConfirm: true
            });
            $("#btnagregarlugar").html('<i class="fa fa-plus"></i>  Agregar cupón');
        }
    });
});
/// Agregar sucursales
$(document).ready(function () {
    $("#frmagregarlugar").submit(function (e) {
        e.preventDefault();
        if ($("#namelugar").val() != "" && $("#infolugarweb").val() != "" && $("#direccionlugar").val() != "") {
            var form = $('#frmagregarlugar')[0];
            var dataString = new FormData(form);
            $.ajax({
                url: '/Ajax/Ajax?data=addsuc',  //Server script to process data
                type: 'POST',
                data: dataString,
                //Options to tell jQuery not to process data or worry about content-type.
                cache: false,
                contentType: false,
                processData: false,
                beforeSend: function () {
                    $("#btnagregarlugar").html('<i class="fa fa-spinner fa-pulse fa-fw"></i>  Agregando');
                },
                success: function (a) {
                    if (a == 1) {
                        swal({
                            text: 'Se ha agregado la sucursal correctamente!',
                            type: "success",
                            confirmButtonText: "Aceptar",
                            confirmButtonColor: "#7986CB",
                            closeOnCancel: true,
                            closeOnConfirm: true,
                            showLoaderOnConfirm: true
                        })
                        $("#btnagregarlugar").html('<i class="fa fa-plus"></i>  Añadir nueva sucursal');
                        $("#namelugar").val('');
                        $("#infolugarweb").val('');
                        $("#infolugarapp").val('');
                        $("#direccionlugar").val('');
                        $("#fechalugar").val('');
                        $("#imglugar").prop("src", "/img/addimagen.png");


                    }
                    else if (a == 0) {
                        swal({
                            title: '¿Seguro no olvidas algo?',
                            html: '<li class="fa fa-image"></li>' + " " + "Debes ingresar una imagen",
                            type: "question",
                            confirmButtonText: "Aceptar",
                            confirmButtonColor: "#7986CB",
                            closeOnCancel: true,
                            closeOnConfirm: true,
                            showLoaderOnConfirm: true
                        });
                        $("#btnagregarlugar").html('<i class="fa fa-plus"></i>  Añadir nueva sucursal');
                    }
                    else {



                    }

                }
            });
        }
        else {
            swal({

                text: 'No puedes dejar campos vaciós',
                type: "question",
                confirmButtonText: "Aceptar",
                confirmButtonColor: "#7986CB",
                closeOnCancel: true,
                closeOnConfirm: true,
                showLoaderOnConfirm: true
            });
            $("#btnagregarlugar").html('<i class="fa fa-plus"></i>  Añadir nueva sucursal');
        }
    });
});
///Ver Sucursales
$(document).ready(function () {
    myinfo();
    $.ajax({
        url: "/Ajax/Ajax?data=loadsucursales",
        type: "POST",
        success: function (a) {

            $("#listasucursales").html(a);

        }
    });
});
function verinfosuc(e) {
    clearInterval(interval);
    $.ajax({
        url: '/Ajax/Ajax?data=verinfosuc&idlugar=' + e,
        type: "post",

        success: function (a) {
            if (a == 1) {

                window.location = "/Comercio/EditarSucursal"
            }
        }
    });
};
///cargar imagen
var loadimagenpubli = function (event) {
    var imgpubli = document.getElementById('imgpubli');
    imgpubli.src = URL.createObjectURL(event.target.files[0]);
};
////////cargra imagen de editar lugar en <img>
var loadimagenlugar = function (event) {
    var imgpubli = document.getElementById('imglugar');
    imglugar.src = URL.createObjectURL(event.target.files[0]);
};

var loadimagenlugareditar = function (event) {
    var imgpubli = document.getElementById('imgeditarlugar');
    imgeditarlugar.src = URL.createObjectURL(event.target.files[0]);
};
///cargar imagen en <img> del perfil del administrador
var loadfile = function (event) {
    var pic = document.getElementById('imgcomer');
    pic.src = URL.createObjectURL(event.target.files[0]);
};
////cambiar imagen de perfil
$(document).ready(function () {
    $("#frmcambiarfoto").submit(function (e) {
        e.preventDefault();
        var form = $('#frmcambiarfoto')[0];
        var dataString = new FormData(form);
        $.ajax({
            url: '/Ajax/Ajax?data=guardarfotos',  //Server script to process data
            type: 'POST',
            data: dataString,
            //Options to tell jQuery not to process data or worry about content-type.
            cache: false,
            contentType: false,
            processData: false,

            beforeSend: function () {

                $("#btnupdatepicture").html('<li class="fa fa-spinner fa-spin"></li>Actualizando');
                $("#btnupdatepicture").prop('disabled', true);
            },
            success: function (a) {
                if (a == 1) {
                    swal({
                        text: 'Se ha actualizado tu foto de perfil!',
                        type: "success",
                        confirmButtonText: "Aceptar",
                        confirmButtonColor: "#7986CB",
                        closeOnCancel: true,
                        closeOnConfirm: true,
                        showLoaderOnConfirm: true
                    })
                    myinfo();
                    $("#btnupdatepicture").html('Actualizar');
                    $("#btnupdatepicture").prop('disabled', true);
                    $("#uploadimg").hide();
                    $("#btncancelarfoto").hide();


                }

            }
        });
    });
});
///cambiar password
$(document).ready(function () {
    $("#frmvalidarcontra").submit(function (e) {
        e.preventDefault();
        if ($("#contranue").val() != "" && $("#contraconfi").val() != "" && $("#contrac").val() != "") {
            if ($("#contranue").val() == $("#contraconfi").val()) {

                $.ajax({
                    url: "/Ajax/Ajax?data=checkpass",
                    type: "POST",
                    data: $("#frmvalidarcontra").serialize(),
                    beforeSend: function () {
                        $("#btnvalidar").html('<i class="fa fa-spinner fa-pulse fa-fw"></i> Validando');
                    },
                    success: function (a) {
                        if (a == 1) {
                            swal({
                                text: 'Se actualizo tu contraseña!',
                                type: "success",
                                confirmButtonText: "Aceptar",
                                confirmButtonColor: "#4CAF50",
                                closeOnCancel: true,
                                closeOnConfirm: true,
                                showLoaderOnConfirm: true
                            })
                            $("#btnvalidar").html('<i class="fa fa-sign-in" aria-hidden="true"></i> Validar contraseña');
                            $("#contranue").val('');
                            $("#contraconfi").val('');
                            $("#contrac").val('');
                            $("#contranue").prop('disabled', true);
                            $("#contraconfi").prop('disabled', true);
                            $("#contrac").prop('disabled', true);
                            $("#btnvalidar").prop('disabled', true);
                            $("#btncancelarcontra").prop('disabled', true);
                        }
                        else if (a == 0) {
                            swal({
                                text: 'Contraseña actual incorrecta, intentalo de nuevo!',
                                type: "error",
                                confirmButtonText: "Aceptar",
                                confirmButtonColor: "#4CAF50",
                                closeOnCancel: true,
                                closeOnConfirm: true,
                                showLoaderOnConfirm: true
                            })

                            $("#btnvalidar").html('<i class="fa fa-sign-in" aria-hidden="true"></i> Validar contraseña');
                            $("#passprofilevalidar").val('');


                        }
                        else {

                        }
                    }
                });
            }
            else {

                swal({
                    text: 'las contraseñas no coinciden, confirmalas!',
                    type: "question",
                    confirmButtonText: "Aceptar",
                    confirmButtonColor: "#3F51B5",
                    closeOnCancel: true,
                    closeOnConfirm: true,
                    showLoaderOnConfirm: true
                })

            }
        }
        else {

            swal({
                title: 'No haz llenado los campos',
                text: 'No puedes dejar campos vacíos!',
                type: "question",
                confirmButtonText: "Aceptar",
                confirmButtonColor: "#3F51B5",
                closeOnCancel: true,
                closeOnConfirm: true,
                showLoaderOnConfirm: true
            })
        }
    });

});
///cargar info usuario
$(document).ready(function () {
    myinfo();
    $("#validationCustom02").prop('disabled', true);
    $("#validationCustom04").prop('disabled', true);
    $("#validationCustom06").prop('disabled', true);
    $("#validationCustom10").prop('disabled', true);
    $("#validationCustom11").prop('disabled', true);
    $("#btnupdatepicture").prop('disabled', true);
    $("#uploadimg").hide();
    $("#contrac").prop('disabled', true);
    $("#contranue").prop('disabled', true);
    $("#contraconfi").prop('disabled', true);
    $("#btnvalidar").prop('disabled', true);
    $("#btnupdate").prop('disabled', true);
    $("#btncancelar").prop('disabled', true);
    $("#btncancelarcontra").prop('disabled', true);
    $("#btncancelarfoto").hide();
    $("#btnupdateinfocomer").hide();
    $("#btncancelar").hide();
    $("#btnupdatepicture").hide();
    $("#btnvalidar").hide();
    $("#btncancelarcontra").hide();


});
///cancelar 
$("#btncancelar").click(function () {

    myinfo();

    $("#validationCustom02").prop('disabled', true);
    $("#validationCustom04").prop('disabled', true);
    $("#validationCustom06").prop('disabled', true);
    $("#validationCustom10").prop('disabled', true);
    $("#validationCustom11").prop('disabled', true);
    $("#validationCustom10").prop('disabled', true);
    $("#validationCustom08").prop('disabled', true);
    $("#btnupdateinfocomer").prop('disabled', true);
    $("#btncancelar").prop('disabled', true);
    $("#btnupdateinfocomer").hide();
    $("#btncancelar").hide();

})
$("#btncancelarfoto").click(function () {
    myinfo();

    $("#btnupdatepicture").prop('disabled', true);
    $("#uploadimg").hide();
    $("#btncancelarfoto").hide();
    $("#btnupdatepicture").hide();

})
$("#btncancelarcontra").click(function () {

    $("#contrac").val('');
    $("#contranue").val('');
    $("#contraconfi").val('');
    $("#contrac").prop('disabled', true);
    $("#contranue").prop('disabled', true);
    $("#contraconfi").prop('disabled', true);
    $("#btnvalidar").prop('disabled', true);
    $("#btncancelarcontra").prop('disabled', true);
    $("#btncancelarcontra").hide();
    $("#btnvalidar").hide();

})
///habilitar Foto
$("#btneditfoto").click(function () {

    $("#btnupdatepicture").prop('disabled', false);
    $("#uploadimg").show();
    $("#btncancelarfoto").show();
    $("#btnupdatepicture").show();


});
//habilitar inputs contraseña
$("#btneditcontra").click(function () {

    $("#contrac").prop('disabled', false);
    $("#contranue").prop('disabled', false);
    $("#contraconfi").prop('disabled', false);
    $("#btncancelarcontra").prop('disabled', false);
    $("#btnvalidar").prop('disabled', false);
    $("#btncancelarcontra").show();
    $("#btnvalidar").show();


});
//habilitar textbox
$("#btnhabilit").click(function () {


    $("#validationCustom02").prop('disabled', false);
    $("#validationCustom04").prop('disabled', false);
    $("#validationCustom06").prop('disabled', false);
    $("#validationCustom10").prop('disabled', false);
    $("#validationCustom11").prop('disabled', false);
    $("#btnupdateinfocomer").prop('disabled', false);
    $("#btncancelar").prop('disabled', false);
    $("#btnupdateinfocomer").show();
    $("#btncancelar").show();


});
//actualizar info
$(document).ready(function () {
    $("#needs-validation").submit(function (e) {
        e.preventDefault();
        if ($("#validationCustom02").val() != "" && $("#validationCustom10").val() != "") {
            $.ajax({
                url: "/Ajax/Ajax?data=updateinfocomercio",
                type: "POST",
                data: $("#needs-validation").serialize(),
                beforeSend: function () {
                    $("#btnupdateinfocomer").html('<i class="fa fa-spinner fa-pulse fa-fw"></i> Actualizando');
                },
                success: function (a) {
                    if (a == 1) {

                        swal({
                            title: "Exito",
                            text: 'Se actualizaron sus datos',
                            type: "success",
                            confirmButtonText: "Aceptar",
                            closeOnCancel: true,
                            closeOnConfirm: true,
                            showLoaderOnConfirm: true

                        });
                        $("#btnupdateinfocomer").html('<i class="fa fa-save" aria-hidden="true"></i> Actualizar mis datos');
                        myinfo();

                        $("#validationCustom02").prop('disabled', true);
                        $("#validationCustom10").prop('disabled', true);
                        $("#contrac").prop('disabled', true);
                        $("#contranue").prop('disabled', true);
                        $("#contraconfi").prop('disabled', true);
                        $("#btnvalidar").prop('disabled', true);
                        $("#btnupdateinfocomer").prop('disabled', true);
                        $("#btncancelar").prop('disabled', true);
                        $("#btncancelarcontra").prop('disabled', true);
                        $("#btncancelar").hide();
                        $("#btnupdateinfocomer").hide();

                    }
                    else if (a == 0) {
                        swal({
                            text: 'Contraseña incorrecta, intentalo de nuevo!',
                            type: "error",
                            confirmButtonText: "Aceptar",
                            confirmButtonColor: "#4CAF50",
                            closeOnCancel: true,
                            closeOnConfirm: true,
                            showLoaderOnConfirm: true
                        })

                        $("#btnupdateinfocomer").html('<i class="fa fa-save" aria-hidden="true"></i> Actualizar mis datos');
                        $("#passprofilevalidar").val('');
                    }
                    else {

                    }
                }
            });
        }
        else {

            swal({
                text: 'Puedes dejar campos vacíos, valida tus campos porfavor!',
                type: "question",
                confirmButtonText: "Aceptar",
                confirmButtonColor: "#3F51B5",
                closeOnCancel: true,
                closeOnConfirm: true,
                showLoaderOnConfirm: true
            });

        }
    });
});
//cargarinfo
//span animado
$(document).ready(function () {
    $.ajax({
        url: "/Ajax/Ajax?data=messagenew",
        type: "POST",
        success: function (a) {

            $("#newinbox").html(a);

        }
    });
    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=messagenew",
            type: "POST",
            success: function (a) {

                $("#newinbox").html(a);

            }
        });
    }
    setInterval(ajaxCall, 1000)
});

function myinfo() {
    $.ajax({
        url: "/Ajax/Ajax?data=DatosUsuario",
        type: "POST",
        success: function (a) {

            var datos = JSON.parse(a);


            $('#usernameadmis').html(datos.nombreus);
            $('#userprofile').val(datos.usuario);
            $('#validationCustom02').val(datos.nombreus);
            $('#validationCustom04').val(datos.usuario);
            $('#validationCustom06').val(datos.apellidop);
            $('#validationCustom11').val(datos.rfc);
            $('#validationCustom10').val(datos.email);
            $("#imgcomer").prop("src", datos.foto)
            $("#roundphotoadmi").prop("src", datos.foto)
        }

    });
}

/**
 * Función que solo permite la entrada de numeros, un signo negativo y
 * un punto para separar los decimales
 */
function soloNumeros(e) {
    // capturamos la tecla pulsada
    var teclaPulsada = window.event ? window.event.keyCode : e.which;
    // capturamos el contenido del input
    var valor = document.getElementById("maxcanjeo").value;
    if (valor.length < 10) {
        // 13 = tecla enter
        // Si el usuario pulsa la tecla enter o el punto y no hay ningun otro
        // punto
        if (teclaPulsada == 13) {
            return true;
        }
        if (teclaPulsada == 8) {
            return true;
        }
        if (teclaPulsada == 9) {
            return true;
        }
        // devolvemos true o false dependiendo de si es numerico o no
        return /\d/.test(String.fromCharCode(teclaPulsada));
    } else {
        return false;
    }
}





