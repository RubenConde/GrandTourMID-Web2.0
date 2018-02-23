﻿


///cargar lugares
$(document).ready(function () {
    myinfo();
    $.ajax({
        url: "/Ajax/Ajax?data=loadlugares",
        type: "POST",
        success: function (a) {

            $("#contenedordelugares").html(a);

        }
    });
});
////
function verinfolugar(e) {
    clearInterval(interval);
    $.ajax({
        url: '/Ajax/Ajax?data=verinfolugar&idlugar=' + e,
        type: "post",

        success: function (a) {
            if (a == 1) {

                window.location = "/Admin/EditarLugar"
            }

        }
    });
};
///cargar info del lugar seleccionado

/// agregarlugar

$(document).ready(function () {
    $("#frmagregarlugar").submit(function (e) {
        e.preventDefault();
        if ($("#namelugar").val() != "" && $("#infolugarweb").val() != "" && $("#infolugarapp").val() != "" && $("#direccionlugar").val() != "" && $("#fechalugar").val() != "") {
            var form = $('#frmagregarlugar')[0];
            var dataString = new FormData(form);
            $.ajax({
                url: '/Ajax/Ajax?data=addlugar',  //Server script to process data
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
                            text: 'Se ha agregado el lugar correctamente!',
                            type: "success",
                            confirmButtonText: "Aceptar",
                            confirmButtonColor: "#7986CB",
                            closeOnCancel: true,
                            closeOnConfirm: true,
                            showLoaderOnConfirm: true
                        })
                        $("#btnagregarlugar").html('<i class="fa fa-plus"></i>  Añadir nuevo lugar');
                        $("#namelugar").val('');
                        $("#infolugarweb").val('');
                        $("#infolugarapp").val('');
                        $("#direccionlugar").val('');
                        $("#fechalugar").val('');

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
                        $("#btnagregarlugar").html('<i class="fa fa-plus"></i>  Añadir nuevo lugar');
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
            $("#btnagregarlugar").html('<i class="fa fa-plus"></i>  Añadir nuevo lugar');
        }
    });
});

///cargar imagen en <img> del lugar

var loadimagenlugar = function (event) {
    var imglugar = document.getElementById('imglugar');
    imglugar.src = URL.createObjectURL(event.target.files[0]);
};

////////cargra imagen de editar lugar en <img>
var loadimagenlugareditar = function (event) {
    var imgeditarlugar = document.getElementById('imgeditarlugar');
    imgeditarlugar.src = URL.createObjectURL(event.target.files[0]);
};


////////////////////EDITAR PERFIL ADMINISTRADOR////////////////////////
///cargar imagen en <img> del perfil del administrador
var loadfile = function (event) {
    var pic = document.getElementById('imgadmi');
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
                $("#sss").show();
                $("#uploadimg").hide();

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
                    $("#uploadimg").hide();
                    $("#sss").hide();

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
    $("#validationCustom08").prop('disabled', true);
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
    $("#sss").hide();


});

///cancelar 
$("#btncancelar").click(function () {

    myinfo();

    $("#validationCustom02").prop('disabled', true);
    $("#validationCustom04").prop('disabled', true);
    $("#validationCustom06").prop('disabled', true);
    $("#validationCustom10").prop('disabled', true);
    $("#validationCustom08").prop('disabled', true);
    $("#validationCustom10").prop('disabled', true);
    $("#validationCustom08").prop('disabled', true);
    $("#btnupdate").prop('disabled', true);
    $("#btncancelar").prop('disabled', true);
})
$("#btncancelarfoto").click(function () {
    myinfo();

    $("#btnupdatepicture").prop('disabled', true);
    $("#uploadimg").hide();
    $("#btncancelarfoto").hide();
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
})

///habilitar Foto
$("#btneditfoto").click(function () {

    $("#btnupdatepicture").prop('disabled', false);
    $("#uploadimg").show();
    $("#btncancelarfoto").show();



});
//habilitar inputs contraseña
$("#btneditcontra").click(function () {

    $("#contrac").prop('disabled', false);
    $("#contranue").prop('disabled', false);
    $("#contraconfi").prop('disabled', false);
    $("#btncancelarcontra").prop('disabled', false);
    $("#btnvalidar").prop('disabled', false);


});
//habilitar textbox
$("#btnhabilit").click(function () {


    $("#validationCustom02").prop('disabled', false);
    $("#validationCustom04").prop('disabled', false);
    $("#validationCustom06").prop('disabled', false);
    $("#validationCustom10").prop('disabled', false);
    $("#validationCustom08").prop('disabled', false);
    $("#btnupdate").prop('disabled', false);
    $("#btncancelar").prop('disabled', false);


});

//actualizar info admi
$(document).ready(function () {
    $("#needs-validation").submit(function (e) {
        e.preventDefault();
        if ($("#validationCustom02").val() != "" && $("#validationCustom04").val() != "" && $("#validationCustom06").val() != "" && $("#validationCustom08").val() != "" && $("#validationCustom10").val() != "") {
            $.ajax({
                url: "/Ajax/Ajax?data=updateinfo",
                type: "POST",
                data: $("#needs-validation").serialize(),
                beforeSend: function () {
                    $("#btnupdate").html('<i class="fa fa-spinner fa-pulse fa-fw"></i> Actualizando');
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
                        $("#btnupdate").html('<i class="fa fa-save" aria-hidden="true"></i> Actualizar mis datos');
                        myinfo();

                        $("#validationCustom02").prop('disabled', true);
                        $("#validationCustom04").prop('disabled', true);
                        $("#validationCustom06").prop('disabled', true);
                        $("#validationCustom10").prop('disabled', true);
                        $("#validationCustom08").prop('disabled', true);
                        $("#contrac").prop('disabled', true);
                        $("#contranue").prop('disabled', true);
                        $("#contraconfi").prop('disabled', true);
                        $("#btnvalidar").prop('disabled', true);
                        $("#btnupdate").prop('disabled', true);
                        $("#btncancelar").prop('disabled', true);
                        $("#btncancelarcontra").prop('disabled', true);
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

                        $("#btnupdate").html('<i class="fa fa-save" aria-hidden="true"></i> Actualizar mis datos');
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

///////ver todos emails

function verinboxall() {
    $.ajax({
        url: "/Ajax/Ajax?data=viewall",
        type: "POST",

        success: function (a) {
            window.location = "/Admin/email";


        }
    });

    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=viewall",
            type: "POST",
            beforeSend: function () {

            },
            success: function (a) {

                $("#contenedorecibidos").html(a);

            }
        });
    }
    setInterval(ajaxCall, 1000)


};


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
            $('#validationCustom08').val(datos.apellidom);
            $('#validationCustom10').val(datos.email);
            $("#imgadmi").prop("src", datos.foto)
            $("#roundphotoadmi").prop("src", datos.foto)
        }

    });
}

///ultimos inbox recibidos
$(document).ready(function () {

    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=ultimosinboxrecibidos",
            type: "POST",
            beforeSend: function () {

            },
            success: function (a) {

                $("#ultimosrecibidos").html(a);

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
    $.ajax({
        url: "/Ajax/Ajax?data=numberuser",
        type: "POST",
        beforeSend: function () {

        },
        success: function (a) {

            $("#numerousers").html(a);

        }
    });
    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=numberuser",
            type: "POST",
            beforeSend: function () {

            },
            success: function (a) {

                $("#numerousers").html(a);

            }
        });
    }
    setInterval(ajaxCall, 3000)
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

                if (a == 1) {
                    $("#userscontent").html(a);

                }
                else if (a == 0) {

                }


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
                if (a == 1) {
                    $("#userscontentInactive").html(a);
                }
                else if (a == 0) {

                }


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

                if (a == 1) {

                    $("#usersblocked").html(a);
                }
                else {

                }

            }

        });

    }
    setInterval(ajaxCall, 1000);

});


//cargar info contacto



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


$(document).ready(function () {
    $("#frmaddcomer").submit(function (e) {
        e.preventDefault();
        if ($('#nombrecomercio').val() != "" && $("#rfccomercio").val() != "" && $("#usercomercio").val() != "" && $("#emailcomercio").val() != "" && $("#passcomercio").val() != "" && $("#passcomerciocon").val() != "") {
            if ($("#passcomercio").val() == $("#passcomerciocon").val()) {
                $.ajax({
                    url: "/Ajax/Ajax?data=registrocomercio",
                    type: "POST",
                    data: $("#frmaddcomer").serialize(),
                    beforeSend: function () {
                        $("#btnaddcomercio").html('<i class="fa fa-spinner fa-pulse fa-fw"></i> Registrando');
                    },
                    success: function (a) {
                        if (a == 1) {
                            swal({
                                title: "Registro Exitoso",
                                text: 'Se ha registrado correctamente el comercio',
                                type: "success",
                                confirmButtonText: "Aceptar",
                                closeOnCancel: true,
                                closeOnConfirm: true,
                                showLoaderOnConfirm: true,
                                });
                            
                            $("#btnregistro").html('<i class="fa fa-plus-circle" aria-hidden="true"></i> Registrar comercio');
                            $("#nombrecomercio").val('');
                            $("#rfccomercio").val('');
                            $("#usercomercio").val('');
                            $("#emailcomercio").val('');
                            $("#passcomercio").val('');
                            $("#passcomerciocon").val('');
                            window.setTimeout(function () { }, 3000);
                            location.reload();
                        }

                        else if (a == 0) {
                            swal({

                                title: "Oops",
                                text: 'Se ha generado un error intentalo de nuevo',
                                type: "error",
                                confirmButtonText: "Aceptar",
                                closeOnCancel: true,
                                closeOnConfirm: true,
                                showLoaderOnConfirm: true
                            });

                            $("#btnaddcomercio").html('<i class="fa fa-plus-circle" aria-hidden="true"></i> Registrar comercio');
                        }
                        else if (a == 2) {
                            swal({
                                html: '<li class="fa fa-user"></li> El usuario ya ha sido registrado',
                                confirmButtonText: "Aceptar",
                                closeOnCancel: true,
                                closeOnConfirm: true,
                                showLoaderOnConfirm: true
                            });

                            $("#btnaddcomercio").html('<i class="fa fa-plus-circle" aria-hidden="true"></i> Registrar comercio');
                        }
                        else if (a == 3) {

                            swal({

                                title: "oops",
                                text: 'El correo ya ah sido registrado',
                                type: "question",
                                confirmButtonText: "Aceptar",
                                closeOnCancel: true,
                                closeOnConfirm: true,
                                showLoaderOnConfirm: true
                            });

                            $("#btnaddcomercio").html('<i class="fa fa-plus-circle" aria-hidden="true"></i> Registrar comercio');

                        }

                        else {

                            $("#btnaddcomercio").html('<i class="fa fa-plus-circle" aria-hidden="true"></i> Registrar comercio');
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
$(document).ready(function () {
    $("#frmregistro").submit(function (e) {
        e.preventDefault();
        if ($('#nomc').val() != "" && $("#apep").val() != "" && $("#apem").val() != "" && $("#ps").val() != "" && $("#coe").val() != "" && $("#usr").val() != "" && $("#ps2").val() != "") {
            if ($("#ps").val() == $("#ps2").val()) {
                $.ajax({
                    url: "/Ajax/Ajax?data=registroadmin",
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
