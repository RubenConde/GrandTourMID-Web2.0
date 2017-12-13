

//Inbox Recibidos
$(document).ready(function () {
    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=InboxRecibidos",
            type: "POST",
            beforeSend: function () {

            },
            success: function (a) {

                $("#ContenedorUsuario").html(a);

            }
        });
    }
    setInterval(ajaxCall, 1000)
});
//inbox leidos

$(document).ready(function () {
    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=InboxLeidos",
            type: "POST",
            beforeSend: function () {

            },
            success: function (a) {

                $("#contenedorleidos").html(a);

            }
        });
    }
    setInterval(ajaxCall, 1000)
});

//Inbox enviados
$(document).ready(function () {
    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=usuariosenviados",
            type: "POST",
            beforeSend: function () {

            },
            success: function (a) {

                $("#contenedorenviados").html(a);

            }
        });
    }
    setInterval(ajaxCall, 1000)
});

//Numero recibidos
$(document).ready(function () {

    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=Inboxnotifica",
            type: "POST",
            beforeSend: function () {

            },
            success: function (a) {

                $("#numeroinbox").html(a);

            }
        });
    }
    setInterval(ajaxCall, 1000)
});


//numero vistos

$(document).ready(function () {

    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=Inboxnotificaleidos",
            type: "POST",
            beforeSend: function () {

            },
            success: function (a) {

                $("#numeroleidos").html(a);

            }
        });
    }
    setInterval(ajaxCall, 1000)
});

//numero enviados

$(document).ready(function () {

    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=inboxnotificenviados",
            type: "POST",
            beforeSend: function () {

            },
            success: function (a) {

                $("#numeroenviados").html(a);

            }
        });
    }
    setInterval(ajaxCall, 1000)
});


//Ver inbox
var interval;
function VerMensa(e) {
    $("#idmensajecontacto").val(e);
    clearInterval(interval);
    $.ajax({
        url: '/Ajax/Ajax?data=Verinbocs&idmensajecontac=' + e,
        type: "post",

        success: function (r) {
            $("#Borge").html(r);
        }
    });
};


//ver enviado

var interval;
function VerInbox(e) {
    $("#idcorreoenviado").val(e);
    clearInterval(interval);
    $.ajax({
        url: '/Ajax/Ajax?data=verenviado&idcorreoenviado=' + e,
        type: "post",

        success: function (r) {
            $("#Borge").html(r);
        }
    });
};

//cargar correo modal
function Correo() {
    $("#para").val($("#CorreoOculto").val());
};

//limpiar al seleccionar nuevo mensaje
function Limpiar() {
    $("#para").val('');
    $("#para").prop('disabled', false);
}

///Enviar Correo electronico

$(document).ready(function () {
    $("#frmenviarcorreocontacto").submit(function (e) {
        e.preventDefault();
        if ($("#para").val() != "" && $("#asu").val() != "" && $("#inb").val() != "") {
            $.ajax({
                url: "/Ajax/Ajax?data=responderinbox",
                type: "POST",
                data: $("#frmenviarcorreocontacto").serialize(),
                beforeSend: function () {
                    $("#btnenviarcorreo").html('<i class="fa fa-spinner fa-pulse fa-fw"></i> Enviando');
                },
                success: function (a) {

                    if (a == 1) {

                        swal({
                            title: "Correo enviado",
                            text: 'Se ha enviado tu correo electronico',
                            type: "success",
                            confirmButtonText: "Aceptar",
                            closeOnCancel: true,
                            closeOnConfirm: true,
                            showLoaderOnConfirm: true
                        });
                        $("#btnenviarcorreo").html('<i class="fa fa-paper-plane"></i> Enviar');
                        $("#para").val('');
                        $("#asu").val('');
                        $("#inb").val('');
                        var modal = document.getElementById('id01');
                        modal.style.display = "none";

                    }
                    else if (a == 0) {
                        swal({
                            title: "Error",
                            text: 'No se envio tu correo electronico, verifica tu conexion a internet e intentalo de nuevo',
                            type: "error",
                            confirmButtonText: "Aceptar",
                            closeOnCancel: true,
                            closeOnConfirm: true,
                            showLoaderOnConfirm: true
                        });
                        $("#btnenviarcorreo").html('<i class="fa fa-paper-plane"></i> Enviar');
                    }
                    else {

                        $("#btnenviarcorreo").html('<i class="fa fa-paper-plane"></i> Enviar');
                    }

                }
            });
        }
        else
        {
            swal({
                title: "¿Seguro que llenaste los campos?",
                text: 'No puedes dejar campos vacíos, validalos porfavor!',
                type: "question",
                confirmButtonText: "Aceptar",
                closeOnCancel: true,
                closeOnConfirm: true,
                showLoaderOnConfirm: true
            });

        }
    });

});





