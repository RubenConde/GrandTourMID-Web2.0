//info inicio


$(document).ready(function () {
    $.ajax({
        url: "/Ajax/Ajax?data=loadinfo",
        type: "POST",
        success: function (a) {
            var datos = JSON.parse(a);
            $('#edittitulo').html(datos.titulo);
            $('#edititulo2').html(datos.titulo2);
            $('#editsubtitulo').html(datos.subtitulo);
            $('#editinfoapp').html(datos.infoapp);
            $('#infoadicional').html(datos.infoadicional);
            $('#edititulo3').html(datos.titulo3);
            $('#edittitulo4').html(datos.titulo4);
           
        }
    });

    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=loadinfo",
            type: "POST",
            success: function (a) {
                var datos = JSON.parse(a);
                $('#edittitulo').html(datos.titulo);
                $('#edititulo2').html(datos.titulo2);
                $('#editsubtitulo').html(datos.subtitulo);
                $('#editinfoapp').html(datos.infoapp);
                $('#infoadicional').html(datos.infoadicional);
                $('#edititulo3').html(datos.titulo3);
                $('#edittitulo4').html(datos.titulo4);





            }
        });
    }
    setInterval(ajaxCall, 1000);
});


function Updateimagen() {
    $.ajax({
        url: "/Ajax/GuardarImagen1",
        type: "POST",
        data: $("#about").serialize(),
        beforeSend: function () {

        },
        success: function (a) {

            if (a == 1) {

                swal({
                    text: 'Titulo 1 Actualizado!',
                    type: "success",
                    confirmButtonText: "Aceptar",
                    confirmButtonColor: "#4CAF50",
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



///actualizar titulo1
function updatetitulo1() {
    $.ajax({
        url: "/Ajax/Ajax?data=updatetitulo1",
        type: "POST",
        data: $("#frmtitulo1").serialize(),
        beforeSend: function () {

        },
        success: function (a) {

            if (a == 1) {

                swal({
                    text: 'Titulo 1 Actualizado!',
                    type: "success",
                    confirmButtonText: "Aceptar",
                    confirmButtonColor: "#4CAF50",
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

//actualizar info Acercade

function updateacerca() {
    $.ajax({
        url: "/Ajax/Ajax?data=updateacerca",
        type: "POST",
        data: $("#frmacerca").serialize(),
        beforeSend: function () {

        },
        success: function (a) {

            if (a == 1) {

                swal({
                    text: 'Información actualizada!',
                    type: "success",
                    confirmButtonText: "Aceptar",
                    confirmButtonColor: "#4CAF50",
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
//titulo3

function updatetitulo3() {
    $.ajax({
        url: "/Ajax/Ajax?data=updatetitulo3",
        type: "POST",
        data: $("#frmtitulo3").serialize(),
        beforeSend: function () {

        },
        success: function (a) {

            if (a == 1) {

                swal({
                    text: 'Información actualizada!',
                    type: "success",
                    confirmButtonText: "Aceptar",
                    confirmButtonColor: "#4CAF50",
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

                })
            }
        });
    }
    setInterval(ajaxCall, 1000);
});

function scrollToEnd() {
    var container = document.getElementById('contact');
    var scrollHeight = container.scrollHeight;
    container.scrollTop = scrollHeight;
}

////editar contacto
$(document).ready(function () {
    $("#frmContacto").submit(function (e) {
        e.preventDefault();
        if ($('#la').val() != "" && $("#lon").val() != "" && $("#tit").val() != "" && $("#subt").val() != "" && $("#dire").val() != "" && $("#tel").val() != "" && $("#corr").val() != "") {
            $.ajax({
                url: "/Ajax/Ajax?data=InsertInfoContact",
                type: "POST",
                data: $("#frmContacto").serialize(),
                beforeSend: function () {
                    $("#btnconbtntacto").html('<i class="fa fa-spinner fa-pulse fa-fw"></i> Iniciando sesión');
                },
                success: function (a) {
                    if (a == 1) {
                        swal({
                            text: 'Se actualizo la información correctamente!',
                            type: "success",
                            confirmButtonText: "Aceptar",
                            confirmButtonColor: "#4CAF50",
                            closeOnCancel: true,
                            closeOnConfirm: true,
                            showLoaderOnConfirm: true
                        });
                        $("#btnconbtntacto").html('<i class="fa fa-paper-plane" aria-hidden="true"></i> ACTUALIZAR');
                        scrollToEnd();
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
                        $("#btnconbtntacto").html('<i class="fa fa-paper-plane"></i> Actualizar');




                    }
                    else {

                    }
                }
            });
        }
        else {
        }
    });

});



$("#edit1").click(function () {

    $('#contenedorprimario').html(
        '<form id="frmtitulo1">' +
        '<label>Titulo</label>' +
        '</br><input placeholder="Ingrese el titulo" id="titulo1" name="titulo1" class="w3-round w3-transparent w3-border w3-input" type="text"/></br>' +
        '<button type="button" onclick="updatetitulo1()" class="w3-button w3-small w3-right w3-green w3-hover-green w3-round"><li class="fa fa-save"></li> Actualizar</button><br /><br />' +
        '</form>'
    )
});

$("#edit2").click(function () {

    $('#contenedorprimario').html(
        '<form id="frmacerca">' +
        '<label>Titulo</label>' +
        '</br><input placeholder="Ingrese el titulo" id="titulo2" name="titulo2" class="w3-round w3-transparent w3-border w3-input" type="text"/></br>' +
        '<label>Subtitulo</label>' +
        '</br><input placeholder="Ingrese el Subtitulo" id="subtitulo2" name="subtitulo2" class="w3-round w3-transparent w3-border w3-input" type="text"/></br>' +
        '<label>Informacion acerca de la app</label>' +
        '</br><textarea placeholder="Ingrese la información acerca de la app" id="infoapp2" name="infoapp2" class="w3-round w3-transparent w3-border w3-input" type="text"></textarea></br>' +
        '<label>Informacion adicional</label>' +
        '</br><textarea placeholder="Ingrese la información acerca de la app" id="infoadicional2" name="infoadicional2" class="w3-round w3-transparent w3-border w3-input" type="text"></textarea></br>' +

        '<button type="button" onclick="updateacerca()" class="w3-button w3-small w3-right w3-green w3-hover-green w3-round"><li class="fa fa-save"></li> Actualizar</button><br /><br />' +
        '</form>'
    )
    $.ajax({
        url: "/Ajax/Ajax?data=loadinfo",
        type: "POST",
        success: function (a) {
            var datos = JSON.parse(a);
            $('#titulo2').val(datos.titulo2);
            $('#subtitulo2').val(datos.subtitulo);
            $('#infoapp2').html(datos.infoapp);
            $('#infoadicional2').html(datos.infoadicional);

        }
    });
});

$("#edit3").click(function () {

    $('#contenedorprimario').html(
        '<form id="frmtitulo3"> ' +
        '<label>Titulo</label>' +
        '</br><input placeholder="Ingrese el titulo" id="titulo3" name="titulo3" class="w3-round w3-transparent w3-border w3-input" type="text"/></br>' +
        '<button type="button" onclick="updatetitulo3()" class="w3-button w3-small w3-right w3-green w3-hover-green w3-round"><li class="fa fa-save"></li> Actualizar</button><br /><br />' +
        '</form>'
    )
});

$("#edit4").click(function () {

    $('#contenedorprimario').html(
        '<label>Titulo</label>' +
        '</br><input placeholder="Ingrese el titulo" class="w3-round w3-transparent w3-border w3-input" type="text"/></br>' +
        '<button class="w3-button w3-small w3-right w3-green w3-hover-green w3-round"><li class="fa fa-save"></li> Actualizar</button><br /><br />'
    )



});

$("#edit5").click(function () {

    $('#contenedorprimario').html(
        '<div class="w3-row w3-padding-32 w3-section">' +
        '<div class="w3-col m4 w3-container">' +
        '<input class="w3-round w3-transparent w3-border" style="width:500px;" id="txtubi" name="txtubi" /><br/><br/>' +
        ////mAPS
        '<div id="googleMap2" class="w3-round-large" style="width:206px;height:400px;"></div>' +
        '</div ><br />' +

        '<div class="w3-col m8 w3-panel">' +

        '<form id="frmContacto" class="w3-large w3-margin-bottom">' +
        '<label id="mes" class="w3-text-green"></label><br /><br />' +
        '<li class="fa fa-text-width fa-fw w3-hover-text-black w3-xlarge w3-margin-right"></li><input id="tit" name="tit" class=" w3-transparent w3-round w3-border" style="width:300px" placeholder="Ingrese Titúlo" required /><br /><br />' +
        '<li class="fa fa-text-width fa-fw w3-hover-text-black w3-xlarge w3-margin-right"></li><input id="subt" name="subt" class="w3-transparent w3-border w3-round"  style="width:300px" placeholder="Ingrese un subtitulo" required /><br /><br />' +
        '<i class="fa fa-map-marker fa-fw w3-hover-text-black w3-xlarge w3-margin-right"></i><input id="dire" name="dire" placeholder="Dirección" class="w3-transparent w3-border w3-round"  style="width:300px" required /> <br><br>' +
        '<i class="fa fa-phone fa-fw w3-hover-text-black w3-xlarge w3-margin-right"></i><input id="tel" name="tel" placeholder="Ingrese número de telefono" class="w3-border w3-round w3-transparent"  style="width:300px" required /><br><br />' +
        '<i class="fa fa-envelope fa-fw w3-hover-text-black w3-xlarge w3-margin-right"></i><input id="corr" name="corr" placeholder="Correo electronico" class="w3-round w3-transparent w3-border"  style="width:300px" required /><br><br />' +
        '<i class="fa fa-coffee fa-fw w3-hover-text-black w3-xlarge w3-margin-right"></i><input id="mensajecontacto2" name="mensajecontacto" placeholder="Mensaje personalizado para el usuario" class="w3-round w3-transparent w3-border"  style="width:300px" required /><br><br />' +
        '<input type="hidden" class="w3-round w3-transparent" id="la" name="la" />' +
        ' <input type="hidden" class="w3-round w3-transparent w3-border" id="lon" name="lon" />' +
        '<button id="btnconbtntacto" class="w3-button w3-right w3-section w3-blue w3-hover-blue" type="sumbit"><i class="fa fa-paper-plane"></i> ACTUALIZAR</button>' +
        '<button id="btn" type="button"></button>' +
        ' </form >' +
        '</div >' +
        '</div > ')

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
            $('#mensajecontacto2').val(datos.mensaje);
            $('#googleMap2').locationpicker({
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

var verimg = function (event) {
    var img1 = document.getElementById('img1');
    img1.src = URL.createObjectURL(event.target.files[0]);
};
