//span animado

$(document).ready(function () {

    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=messagenew",
            type: "POST",
            beforeSend: function () {

            },
            success: function (a) {

                $("#newinbox").html(a);

            }
        });
    }
    setInterval(ajaxCall, 1000)
});

//numero de mensajes recibidos en widget

$(document).ready(function () {

    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=mensajesnumeroprincipal",
            type: "POST",
            beforeSend: function () {

            },
            success: function (a) {

                $("#contarmensajes").html(a);

            }
        });
    }
    setInterval(ajaxCall, 1000)
});

//numero de usuarios en la pagina
$(document).ready(function () {
    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=numberuser",
            type: "POST",
            beforeSend: function () {

            },
            success: function (a) {

                $("#numerousuarios").html(a);

            }
        });
    }
    setInterval(ajaxCall, 1000)
});

//cargar listas de usuarios activos
$(document).ready(function () {
    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=ListadoUsuarios",
            type: "POST",
            beforeSend: function () {
                $("#mensaje").html("Información en tiempo real")
            },
            success: function (a) {

                $("#userscontent").html(a);
            }

        });

    }
    setInterval(ajaxCall, 1000);

});

//Inactivos
$(document).ready(function () {
    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=ListadoUsuariosInactivos",
            type: "POST",
            beforeSend: function () {
                $("#mess").html("Información en tiempo real")
            },
            success: function (a) {

                $("#userscontentInactive").html(a);
            }

        });

    }
    setInterval(ajaxCall, 1000);

});


//Bloqueados
$(document).ready(function () {
    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=ListadoUsuariosBloqueados",
            type: "POST",
            beforeSend: function () {
                $("#message").html("Información en tiempo real")
            },
            success: function (a) {

                $("#usersblocked").html(a);
            }

        });

    }
    setInterval(ajaxCall, 1000);

});

//Deshabilitar inputs
$(document).ready(function () {
    $("#btncontacto").prop('disabled', true);
    $("#tit").prop('disabled', true);
    $("#subt").prop('disabled', true);
    $("#dire").prop('disabled', true);
    $("#tel").prop('disabled', true);
    $("#corr").prop('disabled', true);
    $("#me").prop('disabled', true);
    $("#btncancelar").prop('disabled', true);

});

//habilitar textbox
$("#btned").click(function () {

    $("#tit").prop('disabled', false);
    $("#subt").prop('disabled', false);
    $("#dire").prop('disabled', false);
    $("#tel").prop('disabled', false);
    $("#corr").prop('disabled', false);
    $("#me").prop('disabled', false);
    $("#btncontacto").prop('disabled', false);
    $("#btncancelar").prop('disabled', false);
    $("#mes").html('Ya puedes editar la información');
});

//recargar pagina
$("#btncancelar").click(function () {
    location.reload();
})


//maps

//cargar info contacto
$(document).ready(function () {
    $.ajax({
        url: "/Ajax/Ajax?data=cargarInfoContact",
        type: "POST",
        success: function (a) {
            var datos = JSON.parse(a);
            $('#la').val(datos.latitud);
            $('#lon').val(datos.longitud);
            $('#tit').val(datos.titulo);
            $('#subt').val(datos.subtitulo);
            $('#dire').val(datos.direccion);
            $('#tel').val(datos.numero);
            $('#corr').val(datos.correo);
            $('#mensajecontacto').val(datos.mensaje);
            $('#googleMap').locationpicker({
                radius: 0,
                location: {
                    latitude: $('#la').val(),
                    longitude: $('#lon').val()
                },
                inputBinding: {
                    latitudeInput: $('#la'),
                    longitudeInput: $('#lon'),
                    locationNameInput: $('#txtubi')

                },
                enableAutocomplete: true

            });




        }
    });
});


//Actualizar info contacto
$("#btncontacto").click(function () {
    if ($('#la').val() != "" && $("#lon").val() != "" && $("#tit").val() != "" && $("#subt").val() != "" && $("#dire").val() != "" && $("#tel").val() != "" && $("#corr").val() != "") {
        $.ajax({
            url: "/Ajax/Ajax?data=InsertInfoContact",
            type: "POST",
            data: $("#frmContacto").serialize(),
            beforeSend: function () {

            },
            success: function (a) {

                if (a == 1) {
                   
                    swal({
                        title: "Informacion Actualizada",
                        text: 'Se ha actualizado correctamente la información',
                        type: "success",
                        confirmButtonText: "Aceptar",
                        closeOnCancel: true,
                        closeOnConfirm: true,
                        showLoaderOnConfirm: true
                    });


                    $("#tit").prop('disabled', true);
                    $("#subt").prop('disabled', true);
                    $("#dire").prop('disabled', true);
                    $("#tel").prop('disabled', true);
                    $("#corr").prop('disabled', true);
                    $("#me").prop('disabled', true);
                    $("#btncontacto").prop('disabled', true);
                    $("#btncancelar").prop('disabled', true);
                    $("#mes").hide();
                }
                else if (a == 0) {


                }
                else {
                    


                }

            }
        });
    }
    else {

        swal({
            title: "¿Olvidas algo?",
            text: 'Valida que los campos no esten vacíos',
            type: "question",
            confirmButtonText: "Aceptar",
            closeOnCancel: true,
            closeOnConfirm: true,
            showLoaderOnConfirm: true
        });

    }


});

//ver información de usuario
var interval;
function VerInfo(e) {
    clearInterval(interval);
    $.ajax({
        url: '/Ajax/Ajax?data=verinfousuariosregistrados&iduser=' + e,
        type: "post",

        success: function (r) {
            var modal = document.getElementById('modalinfousers');
            modal.style.display = "block";

            var datos = JSON.parse(r);
            $("#nameregister").val(datos.nombreus);
            $("#lastnamep").val(datos.apellidop);
            $("#lastnamem").val(datos.apellidom);
            $("#userregister").val(datos.usuario);
            $("#perfilimg").prop("src", datos.foto);
        }
    });
};

////Desactivar cuenta

function desact(e) {

    swal({
        title: '¿Estas seguro?',
        text: "¿Desactivar cuenta?!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, Desactivar cuenta!  ',
        cancelButtonText: 'No, Cancelar!',
        confirmButtonClass: 'w3-button w3-green',
        cancelButtonClass: 'w3-button w3-red',
        reverseButtons: true
    }).then((result) => {
        if (result.value) {

            DesactivarAccount(e);


        } else if (result.dismiss === 'cancel') {
            swal(
                'Cancelado',
                'No se desactivo la cuenta',
                'error'
            )
        }
    })

}
var interval;
function DesactivarAccount(e) {
    clearInterval(interval);
    $.ajax({
        url: '/Ajax/Ajax?data=desactivarcuenta&iduser=' + e,
        type: "post",

        success: function (r) {

            if (r == 1) {
                swal(
                    'Exito!',
                    'La cuenta ha sido desactivada!.',
                    'success'
                );
                $("#btnusarnew").html('<button class="w3-red w3-round w3-button">Desactivado</button>');
            }
            else if (r == 2) {

            }
            else {


            }

        }
    });
};


//actualizar info acercade


function ver() {
    var file = document.getElementById('fileacerca');
    var img = file.files[0];
    var file = file.value.split("\\");
    var fileName = file[file.length - 1];
    var nameunic = fileName.replace(/\s/g, '');
    alert(fileName);
    $("#imagenacercas").val(nameunic);
    var imd = file.value;
}

function Acercade(imd) {
    $.ajax({
        url: "/Ajax/Ajax?data=acercaAdmi&files=" + imd,
        type: "POST",
        data: $("#frmAcercade").serialize(),
        beforeSend: function () {

        },
        success: function (a) {

            if (a == 1) {

                swal({
                    title: "Informacion Actualizada",
                    text: 'Se ha actualizado correctamente la información',
                    type: "success",
                    confirmButtonText: "Aceptar",
                    closeOnCancel: true,
                    closeOnConfirm: true,
                    showLoaderOnConfirm: true
                });

            }
            else if (a == 0) {

            }
            else {
            }

        }
    });
};