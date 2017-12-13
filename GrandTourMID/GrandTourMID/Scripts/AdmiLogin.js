

$(document).ready(function () {
    $("#frmloginadmi").submit(function (e) {
        e.preventDefault();
        $.ajax({
            url: "/Ajax/Ajax?data=login",
            type: "POST",
            data: $("#frmloginadmi").serialize(),
            beforeSend: function () {
                $("#btnlogin").html('<i class="fa fa-spinner fa-pulse fa-fw"></i> Iniciando sesión');
            },
            success: function (a) {
                if (a == 1) {
                    $("#btnlogin").html('<i class="fa fa-check-circle" aria-hidden="true"></i> Iniciar Sesión');
                    window.location = "/Admin/Back";
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


                    $("#codigopass").modal("show");

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
                    $("#cambiocontra").modal('show');
                    $("#codigopass").modal('hide');
                    $("#cod").val('');

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
                        window.location = "/Admin/Back";
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