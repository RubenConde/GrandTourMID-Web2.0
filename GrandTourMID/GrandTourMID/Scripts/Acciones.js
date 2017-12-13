//login
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
                else if (a == 0) {

                    swal({
                        text: 'Usuario o contraseña incorrecta!',
                        type: "error",
                        confirmButtonText: "Aceptar",
                        confirmButtonColor: "#4CAF50",
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

                            $('#ModalRegistroUseradmi').modal('hide');
                            if ($('.modal-backdrop').is(':visible')) {
                                $('body').removeClass('modal-open');
                                $('.modal-backdrop').remove();
                            };


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

$(document).ready(function () {
    $("#contact").hide();
})

//cargar info contacto
$(document).ready(function () {
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



