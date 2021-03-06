﻿

$(document).ready(function () {
    $("#frmloginadmi").submit(function (e) {
        e.preventDefault();
        $.ajax({
            url: "/Ajax/Ajax?data=loginadmin",
            type: "POST",
            data: $("#frmloginadmi").serialize(),
            beforeSend: function () {
                $("#btnlogin").html('<i class="fa fa-spinner fa-pulse fa-fw"></i> Iniciando sesión');
            },
            success: function (a) {
                if (a == 1) {
                    $("#btnlogin").html('<i class="fa fa-check-circle" aria-hidden="true"></i> Iniciar Sesión');
                    window.location = "/Admin/email";
                    clear();
                }
                else if (a == 2) {
                    $("#btnlogin").html('<i class="fa fa-check-circle" aria-hidden="true"></i> Iniciar Sesión');
                    window.location = "/Home/Index";
                    clear();
                }
                else if (a == 3) {
                    $("#btnlogin").html('<i class="fa fa-check-circle" aria-hidden="true"></i> Iniciar Sesión');
                    window.location = "/Comercio/Estadisticas";
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


$(document).ready(function () {
    $("#frmrecuperarpass").submit(function (e) {
        e.preventDefault();
        $.ajax({
            url: "/Ajax/Ajax?data=code",
            type: "POST",
            data: $("#frmrecuperarpass").serialize(),
            beforeSend: function () {
                $("#btncorreo").html('<i class="fa fa-spinner fa-pulse fa-fw" aria-hidden="true"></i> Enviando');
            },
            success: function (a) {

                if (a == 1) {

                    swal({
                        title: "Correo enviado",
                        text: 'Se ha enviado un correo electronico con tu codigo. verfica tu bandeja de entrada o mensajes de spam',
                        type: "success",
                        confirmButtonText: "Aceptar",
                        closeOnCancel: true,
                        closeOnConfirm: true,
                        showLoaderOnConfirm: true
                    });

                    document.getElementById('loginpass').style.display = 'none'
                    document.getElementById('codigopass').style.display = 'block'
                    $("#codigopass").modal('show');
                    $("#loginpass").modal("hide");
                    $("#btncorreo").html('<i class="" aria-hidden="true"></i> Enviar');
                    $("#ema").val('');

                }
                else if (a == 0) {

                    swal({
                        title: "Hubo un error",
                        text: 'Verifique su conexion a internet e intentelo de nuevo!',
                        type: "error",
                        confirmButtonText: "Aceptar",
                        closeOnCancel: true,
                        closeOnConfirm: true,
                        showLoaderOnConfirm: true
                    });

                    $("#btncorreo").html('<i class="" aria-hidden="true"></i> Enviar');

                }
                else {



                }

            }
        });
    });
});



$(document).ready(function () {
    $("#frmcodigo").submit(function (e) {
        e.preventDefault();
        $.ajax({
            url: "/Ajax/Ajax?data=CodeRecovery",
            type: "POST",
            data: $("#frmcodigo").serialize(),
            beforeSend: function () {

            },
            success: function (a) {

                if (a == 1) {

                    document.getElementById('codigopass').style.display = 'none'
                    document.getElementById('cambiocontra').style.display = 'block'

                    $("#cambiocontra").modal('show');
                    $("#codigopass").modal('hide');
                    $("#co  d").val('');

                }
                else if (a == 0) {
                    swal({
                        title: "Codigo erroneo",
                        text: 'Verifique el codigo e intentelo de nuevo!',
                        type: "error",
                        confirmButtonText: "Aceptar",
                        closeOnCancel: true,
                        closeOnConfirm: true,
                        showLoaderOnConfirm: true
                    });
                    $("#cod").val('');
                }
                else {


                }

            }
        });
    });
});



$(document).ready(function () {
    $("#frmcambiocontra").submit(function (e) {
        e.preventDefault();
        if ($("#pass1").val() == $("#pass2").val()) {
            $.ajax({
                url: "/Ajax/Ajax?data=Changepassword",
                type: "POST",
                data: $("#frmcambiocontra").serialize(),
                beforeSend: function () {

                    $("#btnRefresh").html('<i class="fa fa-spinner fa-pulse fa-fw" aria-hidden="true"></i> Atualizando');
                },
                success: function (a) {

                    if (a == 1) {
                        $("#btnRefresh").html('<i class="fa fa-check-circle" aria-hidden="true"></i> Actualizar contraseña');
                        swal({
                            title: "Contraseña cambiada",
                            text: 'Intente una vez mas iniciar sesión',
                            type: "success",
                            confirmButtonText: "Aceptar",
                            closeOnCancel: true,
                            closeOnConfirm: true,
                            showLoaderOnConfirm: true
                        });
                        document.getElementById('cambiocontra').style.display = 'none'
                        $("#cambiocontra").modal('hide');
                    }
                    else if (a == 0) {
                        $("#btnRefresh").html('<i "></i> Actualizar contraseña');
                    }
                    else {

                    }

                }
            });
        };
    });
});