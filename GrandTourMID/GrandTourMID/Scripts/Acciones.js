
function cargarinfoinicio() {
    $.ajax({
        url: "/Ajax/Ajax?data=loadinfo",
        type: "POST",
        success: function (a) {
            var datos = JSON.parse(a);
            $('#edittitulo').html(datos.titulo);
            $('#titulograndtour').html(datos.titulo2);
            $('#infoapp').html(datos.infoapp);
            $('#edititulo3').html(datos.titulo3);
            $('#edittitulo4').html(datos.titulo4);
            $("#tituloju").html(datos.titulojugar);
            $("#subtituju").html(datos.subtitulojugar);
        }
    });

    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=loadinfo",
            type: "POST",
            success: function (a) {
                var datos = JSON.parse(a);
                $('#edittitulo').html(datos.titulo);
                $('#titulograndtour').html(datos.titulo2);
                $('#infoapp').val(datos.infoapp);
                $('#edititulo3').html(datos.titulo3);
                $('#edititulo4').html(datos.titulo4);
                $("#tituloju").html(datos.titulojugar);
                $("#subtituju").html(datos.subtitulojugar);
            }
        });
    }

    setInterval(ajaxCall, 2000);
}

function cargarimagenesinicio() {
    $.ajax({
        url: "/Ajax/Ajax?data=loadimagesinicio",
        type: "POST",
        success: function (a) {
            var datos = JSON.parse(a);
            $('#imginicio1').prop("src", datos.img);
            $('#imginicio2').prop("src", datos.img1);
            $("#imgheader1").css("background-image", "url(" + datos.header1 + ")");
            $("#header2").css("background-image", "url(" + datos.header2 + ")");
            $("#header3").css("background-image", "url(" + datos.header3 + ")");
            $('#slide1').prop("src", datos.imgslide1);
            $('#slide2').prop("src", datos.imgslide2);
            $('#slide3').prop("src", datos.imgslide3);
            $('#slide4').prop("src", datos.imgslide4);
        }
    });

    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=loadimagesinicio",
            type: "POST",
            success: function (a) {
                var datos = JSON.parse(a);
                $('#imginicio1').prop("src", datos.img);
                $('#imginicio2').prop("src", datos.img1);
                $("#imgheader1").css("background-image", "url(" + datos.header1 + ")");
                $("#header2").css("background-image", "url(" + datos.header2 + ")");
                $("#header3").css("background-image", "url(" + datos.header3 + ")");
                $('#slide1').prop("src", datos.imgslide1);
                $('#slide2').prop("src", datos.imgslide2);
                $('#slide3').prop("src", datos.imgslide3);
                $('#slide4').prop("src", datos.imgslide4);
            }
        });
    }

    setInterval(ajaxCall, 2000);

}

$(document).ready(function () {
    $("#frmlogin").submit(function (e) {
        e.preventDefault();
        $.ajax({
            url: "/Ajax/Ajax?data=login",
            type: "POST",
            data: $("#frmlogin").serialize(),
            beforeSend: function () {
                $("#btnlogin").html('<i class="fa fa-spinner fa-pulse fa-fw"></i> Iniciando sesión');
            },
            success: function (a) {
                if (a == 1) {
                    $("#btnlogin").html('<i class="fa fa-check-circle" aria-hidden="true"></i> Iniciar Sesión');
                    window.location = "/Profile/Profile";
                    clear();
                }
                if (a == 2) {
                    swal({
                        title: 'Verificamos que eres administrador!',
                        text: 'Serás redirigido a tu inicio de sesión',
                        timer: 5000,
                        onOpen: () => {
                            swal.showLoading()
                        }
                    }).then((result) => {
                        if (result.dismiss === 'timer') {

                            $("#btnlogin").html('<i class="fa fa-check-circle" aria-hidden="true"></i> Iniciar Sesión');
                            window.location = "/Home/Login";
                            clear
                        }
                    })

                 
                }
                else if (a == 0) {
                    swal({
                        text: 'Usuario o contraseña incorrecta!',
                        type: "error",
                        confirmButtonText: "Aceptar",
                        confirmButtonColor: "#006064",
                        closeOnCancel: true,
                        closeOnConfirm: true,
                        showLoaderOnConfirm: true
                    })
                    $("#btnlogin").html('<i class="fa fa-sign-in"></i> Iniciar sesión');
                    clear();
                }
                else {
                }
            }
        });
    });
});

//Registro
$(document).ready(function () {
    $("#frmregistro").submit(function (e) {
        e.preventDefault();
        if ($('#nomc').val() != "" && $("#apep").val() != "" && $("#apem").val() != "" && $("#ps").val() != "" && $("#coe").val() != "" && $("#usr").val() != "" && $("#ps2").val() != "") {
            if ($("#ps").val() == $("#ps2").val()) {
                $.ajax({
                    url: "/Ajax/Ajax?data=registro",
                    type: "POST",
                    data: $("#frmregistro").serialize(),
                    beforeSend: function () {
                        $("#btnregistro").html('<i class="fa fa-spinner fa-pulse fa-fw"></i> Registrando');
                    },
                    success: function (a) {
                        if (a == 1) {
                            swal({
                                title: "Registro Exitoso",
                                text: 'Se ha registrado correctamente tu cuenta',
                                type: "success",
                                confirmButtonText: "Aceptar",
                                closeOnCancel: true,
                                closeOnConfirm: true,
                                showLoaderOnConfirm: true
                            });

                            $("#btnregistro").html('<i class="fa fa-plus-circle" aria-hidden="true"></i> Registrar');
                            $("#nomc").val('');
                            $("#apep").val('');
                            $("#apem").val('');
                            $("#ps").val('');
                            $("#coe").val('');
                            $("#usr").val('');
                            $("#ps2").val('');

                        }

                        else if (a == 0) {
                            swal({

                                title: "oops",
                                text: 'Se ha generado un error intentalo de nuevo',
                                type: "error",
                                confirmButtonText: "Aceptar",
                                closeOnCancel: true,
                                closeOnConfirm: true,
                                showLoaderOnConfirm: true
                            });

                            $("#btnregistro").html('<i class="fa fa-plus-circle" aria-hidden="true"></i> Registrar');
                        }
                        else if (a == 2) {
                            swal({
                                html: '<li class="fa fa-user"></li> El usuario ya ha sido registrado',
                                confirmButtonText: "Aceptar",
                                closeOnCancel: true,
                                closeOnConfirm: true,
                                showLoaderOnConfirm: true
                            });

                            $("#btnregistro").html('<i class="fa fa-plus-circle" aria-hidden="true"></i> Registrar');
                        }
                        else if (a == 3) {

                            swal({

                                title: "oops",
                                text: 'El correo ya ah sido  registrado',
                                type: "question",
                                confirmButtonText: "Aceptar",
                                closeOnCancel: true,
                                closeOnConfirm: true,
                                showLoaderOnConfirm: true
                            });

                            $("#btnregistro").html('<i class="fa fa-plus-circle" aria-hidden="true"></i> Registrar');

                        }

                        else {

                            $("#btnregistro").html('<i class="fa fa-plus-circle" aria-hidden="true"></i> Registrar');
                        }
                    }
                });

            }
            else {

                swal({
                    title: "Las contraseñas no coinciden",
                    text: 'Verifique sus datos nuevamente',
                    type: "error",
                    confirmButtonColor: "#006064",
                    confirmButtonText: "Aceptar",
                    closeOnCancel: true,
                    closeOnConfirm: true,
                    showLoaderOnConfirm: true
                });


            }
        }
        else {

            swal({
                title: "¿Estas seguro de haber llenado los campos?",
                text: 'Verifica los campos por favor',
                type: "question",
                confirmButtonColor: "#006064",
                confirmButtonText: "Aceptar",
                closeOnCancel: true,
                closeOnConfirm: true,
                showLoaderOnConfirm: true
            });




        }
    });

});

//Ocultar div contacto



//cargar info contacto
$(document).ready(function () {
    cargarimagenesinicio();
    cargarinfoinicio();
    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=InfoContactoIndex",
            type: "POST",
            success: function (a) {
                $("#contact").show();
                var datos = JSON.parse(a);
                $('#latitud').val(datos.latitud);
                $('#longitud').val(datos.longitud);
                $('#txtTitulo').html(datos.titulo);
                $('#Subtitulo').html(datos.subtitulo);
                $('#direccion').html(datos.direccion);
                $('#telefono').html(datos.numero);
                $('#correo').html(datos.correo);
                $('#mesaage').html(datos.mensaje);

                $('#googleMap').locationpicker({
                    radius: 0,
                    location: {
                        latitude: $('#latitud').val(),
                        longitude: $('#longitud').val()
                    },
                    inputBinding: {
                        latitudeInput: $('#latitud'),
                        longitudeInput: $('#longitud'),

                    },

                });
            }
        });
    }
    setInterval(ajaxCall, 1000);
});


//Enviar Mensaje Contacto

$(document).ready(function () {
    $("#frmMensajeContacto").submit(function (e) {
        e.preventDefault();
        if ($('#nomcontacto').val() != "" && $("#correocontacto").val() != "" && $("#mensajecontacto").val() != "") {
            $.ajax({
                url: "/Ajax/Ajax?data=EnviarMensajeContacto",
                type: "POST",
                data: $("#frmMensajeContacto").serialize(),
                beforeSend: function () {
                    $("#enviarcontacto").html('<i class="fa fa-spinner fa-pulse fa-fw"></i> Eviando');
                },
                success: function (a) {

                    if (a == 1) {
                        swal({
                            title: "Tu mensaje ha sido enviado",
                            text: 'Nos pondremos en contacto a traves de tu correo electronico',
                            type: "success",
                            confirmButtonText: "Aceptar",
                            confirmButtonColor: "#4CAF50",
                            closeOnCancel: true,
                            closeOnConfirm: true,
                            
                        });
                        $("#enviarcontacto").html('<i class="fa fa-paper-plane"></i> Enviar');
                        $("#nomcontacto").val('');
                        $("#correocontacto").val('');
                        $("#mensajecontacto").val('');
                        $("#contact").load();
                    }
                    else if (a == 0) {

                        swal({
                            title: "Error",
                            text: 'No pudimos enviar tu mensaje, verfica tu conexión a internet o intentalo de nuevo',
                            type: "error",
                            confirmButtonText: "Aceptar",
                            confirmButtonColor: "#B71C1C",
                            closeOnCancel: true,
                            closeOnConfirm: true,
                            showLoaderOnConfirm: true
                        });

                        $("#enviarcontacto").html('<i class="fa fa-paper-plane"></i> Enviar');
                    }
                    else {
                        swal({
                            title: "Error 1",
                            text: 'Ocurrio una excepción intentalo más tarde',
                            type: "error",
                            confirmButtonText: "Aceptar",
                            confirmButtonColor: "#B71C1C",
                            closeOnCancel: true,
                            closeOnConfirm: true,
                            showLoaderOnConfirm: true
                        });

                        $("#enviarcontacto").html('<i class="fa fa-paper-plane"></i> Enviar');
                    }

                }
            });
        }
        else {

            swal({
                title: "¿Estas seguro de haber llenado los campos?",
                text: 'Verifica los campos por favor',
                type: "question",
                confirmButtonColor: "#006064",
                confirmButtonText: "Aceptar",
                closeOnCancel: true,
                closeOnConfirm: true,
                
                
            });


        }
        
    });
});



