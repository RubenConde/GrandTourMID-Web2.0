
var modal = document.getElementById('Modaledit');

var loadimageninicio1 = function (event) {
    var imginicio1 = document.getElementById('imginicio1');
    imginicio1.src = URL.createObjectURL(event.target.files[0]);
    $("#cancelaimagen1").show();
    $("#cambiarimagen1").show();


};

var loadimageninicio2 = function (event) {
    var imginicio2 = document.getElementById('imginicio2');
    imginicio2.src = URL.createObjectURL(event.target.files[0]);
    $("#cancelaimagen2").show();
    $("#cambiarimagen2").show();


};


var loadimagenpaso1 = function (event) {
    var imgpaso1 = document.getElementById('imgpaso1');
    imgpaso1.src = URL.createObjectURL(event.target.files[0]);
    $("#imgpaso1actualizar").show();
    $("#imgpaso1cancelar").show();


};

var loadimagenpaso2 = function (event) {
    var imgpaso2 = document.getElementById('imgpaso2');
    imgpaso2.src = URL.createObjectURL(event.target.files[0]);
    $("#imgpaso2actualizar").show();
    $("#imgpaso2cancelar").show();


};

var loadimagenpaso3 = function (event) {
    var imgpaso3 = document.getElementById('imgpaso3');
    imgpaso3.src = URL.createObjectURL(event.target.files[0]);
    $("#imgpaso3actualizar").show();
    $("#imgpaso3cancelar").show();


};

var loadimagenpaso4 = function (event) {
    var imgpaso4 = document.getElementById('imgpaso4');
    imgpaso4.src = URL.createObjectURL(event.target.files[0]);
    $("#imgpaso4actualizar").show();
    $("#imgpaso4cancelar").show();


};


$("#file").on("change", function () {
    var files = !!this.files ? this.files : [];
    if (!files.length || !window.FileReader) return;
    if (/^image/.test(files[0].type)) {
        var reader = new FileReader();
        reader.readAsDataURL(files[0]);
        reader.onloadend = function () {
            $("#imgheader1").css("background-image", "url(" + this.result + ")");
        }
    }
    $("#cancelaimagenheaderinicio").show();
    $("#cambiarimagenheaderinicio").show();

});


$("#file2").on("change", function () {
    var files = !!this.files ? this.files : [];
    if (!files.length || !window.FileReader) return;
    if (/^image/.test(files[0].type)) {
        var reader = new FileReader();
        reader.readAsDataURL(files[0]);
        reader.onloadend = function () {
            $("#header2").css("background-image", "url(" + this.result + ")");
        }
    }
    $("#cancelaimagenheader2").show();
    $("#cambiarimagenheader2").show();

});


$("#file3").on("change", function () {
    var files = !!this.files ? this.files : [];
    if (!files.length || !window.FileReader) return;
    if (/^image/.test(files[0].type)) {
        var reader = new FileReader();
        reader.readAsDataURL(files[0]);
        reader.onloadend = function () {
            $("#header3").css("background-image", "url(" + this.result + ")");
        }
    }
    $("#cancelaimagenheader3").show();
    $("#cambiarimagenheader3").show();

});


function cargarimagenesinicio() {
    $.ajax({
        url: "/Ajax/Ajax?data=loadimagesinicio",
        type: "POST",
        success: function (a) {

            var datos = JSON.parse(a);
            $('#imginicio1').prop("src", datos.img);
            $('#imginicio2').prop("src", datos.img1);
            $('#imgpaso1').prop("src", datos.imgpaso1);
            $('#imgpaso2').prop("src", datos.imgpaso2);
            $('#imgpaso3').prop("src", datos.imgpaso3);
            $('#imgpaso4').prop("src", datos.imgpaso4);


            
            $("#header2").css("background-image", "url(" + datos.header2 + ")");
            $("#imgheader1").css("background-image", "url(" + datos.header1 + ")");
            $("#header3").css("background-image", "url(" + datos.header3 + ")");
            
            $("#cancelaimagen2").hide();
            $("#cambiarimagen2").hide();
            $("#cancelaimagen1").hide();
            $("#cambiarimagen1").hide();
            $("#cancelaimagenheaderinicio").hide();
            $("#cambiarimagenheaderinicio").hide();
            $("#cancelaimagenheader2").hide();
            $("#cambiarimagenheader2").hide();
            $("#cancelaimagenheader3").hide();
            $("#cambiarimagenheader3").hide();
            $("#imgpaso1actualizar").hide();
            $("#imgpaso1cancelar").hide();
            $("#imgpaso2actualizar").hide();
            $("#imgpaso2cancelar").hide();
            $("#imgpaso3actualizar").hide();
            $("#imgpaso3cancelar").hide();
            $("#imgpaso4actualizar").hide();
            $("#imgpaso4cancelar").hide();
        }
    });

}



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
            $("#tituloju").html(datos.titulojugar)
            $("#subtituju").html(datos.subtitulojugar)
            $("#cancelaimagen1").hide();
            $("#cambiarimagen1").hide();
            $("#cancelaimagen2").hide();
            $("#cambiarimagen2").hide();
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
                $('#infoapp').html(datos.infoapp);
                $('#edititulo3').html(datos.titulo3);
                $('#edittitulo4').html(datos.titulo4);
                $("#tituloju").html(datos.titulojugar)
                $("#subtituju").html(datos.subtitulojugar)
            }
        });
    }
    setInterval(ajaxCall, 2000);

}


$(document).ready(function () {
    cargarinfoinicio();
    cargarimagenesinicio();
});


function cancelar() {

    cargarinfoinicio();

}


//////////Guardafoto1

$("#cambiarimagen1").click(function () {

    var form = $('#frmcambiarimagen1')[0];
    var dataString = new FormData(form);
    $.ajax({
        url: '/Ajax/Ajax?data=GuardarImagen1',  //Server script to process data
        type: 'POST',
        data: dataString,
        //Options to tell jQuery not to process data or worry about content-type.
        cache: false,
        contentType: false,
        processData: false,
        success: function (a) {
            if (a == 1) {
                swal({
                    text: 'Se ha actualizado tu foto de perfil!',
                    type: "success",
                    confirmButtonText: "Aceptar",
                    confirmButtonColor: "#006064",
                    closeOnCancel: true,
                    closeOnConfirm: true,
                    showLoaderOnConfirm: true
                })
                cargarimagenesinicio();
                cargarinfoinicio();
                modal.style.display = "none";


            }

        }
    });
});

/////guardar foto 2

$("#cambiarimagen2").click(function () {

    var form = $('#frmcambiarimagen2')[0];
    var dataString = new FormData(form);
    $.ajax({
        url: '/Ajax/Ajax?data=GuardarImagen2',  //Server script to process data
        type: 'POST',
        data: dataString,
        //Options to tell jQuery not to process data or worry about content-type.
        cache: false,
        contentType: false,
        processData: false,
        success: function (a) {
            if (a == 1) {
                swal({
                    text: 'Se ha actualizado la imagen!',
                    type: "success",
                    confirmButtonText: "Aceptar",
                    confirmButtonColor: "#006064",
                    closeOnCancel: true,
                    closeOnConfirm: true,
                    showLoaderOnConfirm: true
                })
                cargarimagenesinicio();
                cargarinfoinicio();
                modal.style.display = "none";


            }

        }
    });
});


////////////imagen header 1
$("#cambiarimagenheaderinicio").click(function () {

    var form = $('#frmimagenheader1')[0];
    var dataString = new FormData(form);
    $.ajax({
        url: '/Ajax/Ajax?data=GuardarImagenheader1',  //Server script to process data
        type: 'POST',
        data: dataString,
        //Options to tell jQuery not to process data or worry about content-type.
        cache: false,
        contentType: false,
        processData: false,
        success: function (a) {
            if (a == 1) {
                swal({
                    text: 'Se ha actualizado la imagen!',
                    type: "success",
                    confirmButtonText: "Aceptar",
                    confirmButtonColor: "#006064",
                    closeOnCancel: true,
                    closeOnConfirm: true,
                    showLoaderOnConfirm: true
                })
                cargarimagenesinicio();
                cargarinfoinicio();
                modal.style.display = "none";


            }

        }
    });
});
//////////////

/////////actualizar imagen paso1 


$("#imgpaso1actualizar").click(function () {

    var form = $('#frmimgpaso1')[0];
    var dataString = new FormData(form);
    $.ajax({
        url: '/Ajax/Ajax?data=guardarimagenpaso1',  //Server script to process data
        type: 'POST',
        data: dataString,
        //Options to tell jQuery not to process data or worry about content-type.
        cache: false,
        contentType: false,
        processData: false,
        success: function (a) {
            if (a == 1) {
                swal({
                    text: 'Se ha actualizado la imagen!',
                    type: "success",
                    confirmButtonText: "Aceptar",
                    confirmButtonColor: "#006064",
                    closeOnCancel: true,
                    closeOnConfirm: true,
                    showLoaderOnConfirm: true
                })
                cargarimagenesinicio();
                cargarinfoinicio();
                modal.style.display = "none";


            }

        }
    });
});
///////////
$("#imgpaso2actualizar").click(function () {

    var form = $('#frmimgpaso2')[0];
    var dataString = new FormData(form);
    $.ajax({
        url: '/Ajax/Ajax?data=guardarimagenpaso2',  //Server script to process data
        type: 'POST',
        data: dataString,
        //Options to tell jQuery not to process data or worry about content-type.
        cache: false,
        contentType: false,
        processData: false,
        success: function (a) {
            if (a == 1) {
                swal({
                    text: 'Se ha actualizado la imagen!',
                    type: "success",
                    confirmButtonText: "Aceptar",
                    confirmButtonColor: "#006064",
                    closeOnCancel: true,
                    closeOnConfirm: true,
                    showLoaderOnConfirm: true
                })
                cargarimagenesinicio();
                cargarinfoinicio();
                modal.style.display = "none";


            }

        }
    });
});
///////////////
$("#imgpaso3actualizar").click(function () {

    var form = $('#frmimgpaso3')[0];
    var dataString = new FormData(form);
    $.ajax({
        url: '/Ajax/Ajax?data=guardarimagenpaso3',  //Server script to process data
        type: 'POST',
        data: dataString,
        //Options to tell jQuery not to process data or worry about content-type.
        cache: false,
        contentType: false,
        processData: false,
        success: function (a) {
            if (a == 1) {
                swal({
                    text: 'Se ha actualizado la imagen!',
                    type: "success",
                    confirmButtonText: "Aceptar",
                    confirmButtonColor: "#006064",
                    closeOnCancel: true,
                    closeOnConfirm: true,
                    showLoaderOnConfirm: true
                })
                cargarimagenesinicio();
                cargarinfoinicio();
                modal.style.display = "none";


            }

        }
    });
});
//////////////
$("#imgpaso4actualizar").click(function () {

    var form = $('#frmimgpaso4')[0];
    var dataString = new FormData(form);
    $.ajax({
        url: '/Ajax/Ajax?data=guardarimagenpaso4',  //Server script to process data
        type: 'POST',
        data: dataString,
        //Options to tell jQuery not to process data or worry about content-type.
        cache: false,
        contentType: false,
        processData: false,
        success: function (a) {
            if (a == 1) {
                swal({
                    text: 'Se ha actualizado la imagen!',
                    type: "success",
                    confirmButtonText: "Aceptar",
                    confirmButtonColor: "#006064",
                    closeOnCancel: true,
                    closeOnConfirm: true,
                    showLoaderOnConfirm: true
                })
                cargarimagenesinicio();
                cargarinfoinicio();
                modal.style.display = "none";


            }

        }
    });
});

//////primer parallax

$("#cambiarimagenheader2").click(function () {

    var form = $('#frmimagenheader2')[0];
    var dataString = new FormData(form);
    $.ajax({
        url: '/Ajax/Ajax?data=guardarparallax',  //Server script to process data
        type: 'POST',
        data: dataString,
        //Options to tell jQuery not to process data or worry about content-type.
        cache: false,
        contentType: false,
        processData: false,
        success: function (a) {
            if (a == 1) {
                swal({
                    text: 'Se ha actualizado la imagen!',
                    type: "success",
                    confirmButtonText: "Aceptar",
                    confirmButtonColor: "#006064",
                    closeOnCancel: true,
                    closeOnConfirm: true,
                    showLoaderOnConfirm: true
                })
                cargarimagenesinicio();
                cargarinfoinicio();
                modal.style.display = "none";


            }

        }
    });
});

////////parallax2

$("#cambiarimagenheader3").click(function () {

    var form = $('#frmimagenheader3')[0];
    var dataString = new FormData(form);
    $.ajax({
        url: '/Ajax/Ajax?data=guardarparallax2',  //Server script to process data
        type: 'POST',
        data: dataString,
        //Options to tell jQuery not to process data or worry about content-type.
        cache: false,
        contentType: false,
        processData: false,
        success: function (a) {
            if (a == 1) {
                swal({
                    text: 'Se ha actualizado la imagen!',
                    type: "success",
                    confirmButtonText: "Aceptar",
                    confirmButtonColor: "#006064",
                    closeOnCancel: true,
                    closeOnConfirm: true,
                    showLoaderOnConfirm: true
                })
                cargarimagenesinicio();
                cargarinfoinicio();
                modal.style.display = "none";


            }

        }
    });
});

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
                    text: 'El titulo ha sido actualizado!',
                    type: "success",
                    confirmButtonText: "Aceptar",
                    confirmButtonColor: "#006064",
                    closeOnCancel: true,
                    closeOnConfirm: true,
                    showLoaderOnConfirm: true,
                    confirmButton: false
                });
                modal.style.display = "none";
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
                    confirmButtonColor: "#006064",
                    closeOnCancel: true,
                    closeOnConfirm: true,
                    showLoaderOnConfirm: true
                });
                modal.style.display = "none";
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
                    confirmButtonColor: "#006064",
                    closeOnCancel: true,
                    closeOnConfirm: true,
                    showLoaderOnConfirm: true
                });
                modal.style.display = "none";
            }
            else if (a == 0) {

            }
            else {


            }

        }
    });
};

////informacion de titulos jugar actualizar la información


function editinfojugar() {
    $.ajax({
        url: "/Ajax/Ajax?data=editinfojugar",
        type: "POST",
        data: $("#frmtitulosjugar").serialize(),
        beforeSend: function () {

        },
        success: function (a) {

            if (a == 1) {

                swal({
                    text: 'Información actualizada!',
                    type: "success",
                    confirmButtonText: "Aceptar",
                    confirmButtonColor: "#006064",
                    closeOnCancel: true,
                    closeOnConfirm: true,
                    showLoaderOnConfirm: true
                });
                modal.style.display = "none";
            }
            else if (a == 0) {

            }
            else {


            }

        }
    });
};
/////titulo4
function updatetitulo4() {
    $.ajax({
        url: "/Ajax/Ajax?data=updatetitulo4",
        type: "POST",
        data: $("#frmtitulo4").serialize(),
        beforeSend: function () {

        },
        success: function (a) {

            if (a == 1) {

                swal({
                    text: 'Información actualizada!',
                    type: "success",
                    confirmButtonText: "Aceptar",
                    confirmButtonColor: "#006064",
                    closeOnCancel: true,
                    closeOnConfirm: true,
                    showLoaderOnConfirm: true
                });
                modal.style.display = "none";
            }
            else if (a == 0) {

            }
            else {


            }

        }
    });
};

$(document).ready(function () {
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


////editar contacto

function actualizarcontacto() {
    if ($('#la').val() != "" && $("#lon").val() != "" && $("#tit").val() != "" && $("#subt").val() != "" && $("#dire").val() != "" && $("#tel").val() != "" && $("#corr").val() != "") {
        $.ajax({
            url: "/Ajax/Ajax?data=InsertInfoContact",
            type: "POST",
            data: $("#frmContac").serialize(),
            beforeSend: function () {
                $("#btnactualizar").html('<i class="fa fa-spinner fa-pulse fa-fw"></i> Iniciando sesión');
            },
            success: function (a) {
                if (a == 1) {
                    swal({
                        text: 'Se actualizo la información correctamente!',
                        type: "success",
                        confirmButtonText: "Aceptar",
                        confirmButtonColor: "#006064",
                        closeOnCancel: true,
                        closeOnConfirm: true,
                        showLoaderOnConfirm: true
                    });
                    $("#btnactualizar").html('<i class="fa fa-paper-plane" aria-hidden="true"></i> ACTUALIZAR');
                    modal.style.display = "none";
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
                    $("#btnactualizar").html('<i class="fa fa-paper-plane"></i> Actualizar');




                }
                else {

                }
            }
        });
    }
    else {
    }
}



$("#imgpaso1").click(function () {

    $('#contenedorprimario').html(
        '<br/><form id="frmtitulo1" onsubmit="return false;">' +
        '<center><b><label>Aqui puedes editar las instrucciones de del juego</label></b></center>'+
        '<br/><textarea placeholder="Aqui ingrese instrucciones de la aplicación" style="width:205px; height:323px; resize:none;" class="w3-left w3-round w3-transparent w3-border w3-input"></textarea>' +
        '<textarea placeholder="Aqui ingrese instrucciones de la aplicación" style="width:205px; height:323px; resize:none;" class="w3-right w3-round w3-transparent w3-border w3-input"></textarea>' +
        '<center>' +
        '<span id="" style="cursor:pointer" class="w3-text-red w3-center w3-round" onclick="cancelar();"><li class="fa fa-times-circle"></li></span>&nbsp;'+
        '<span id="" style="cursor:pointer" class="w3-text-green w3-center w3-round"><li class="fa fa-check-circle"></li></span>'+
        '<div class=" phone-display--carousel" > '+
            '<img class="phone-display--image" src="/img/phone-screenshot.png" width="190" height="330" />'+
            '<div class="phone-display--carousel-mask">'+
                '<lu>'+
                    '<li class="is-current">'+
                       ' <img id="imginicio1" class="phone-display--carousel-list" />'+
                   ' </li>'+
                '</lu>'+
          '</div>'+
        '</div><br/>' +
        
        '<center /><br /><br />'+
        '<h5><label class="w3-hover-gray w3-grayscale w3-round w3-text-gray" id="uploadimg" style="width:133px;cursor:pointer;"><li class="fa fa-paperclip"></li> Cambiar imagen<input id="file2" name="file" type="file" accept="image/*" style="display:none" onchange="loadimageninicioheader1(event)" /></label>&nbsp;</h5>' +
        '</form><br/><br/><br/>'
    )
});


$("#edit1").click(function () {

    $('#contenedorprimario').html(
        '<form id="frmtitulo1" onsubmit="return false;">' +
        '<label>Titulo</label>' +
        '</br><input placeholder="Ingrese el titulo" id="titulo1" name="titulo1" class="w3-round w3-transparent w3-border w3-input" type="text"/></br>' +
        '<button type="button" onclick="updatetitulo1()" class="w3-button w3-small w3-right w3-green w3-hover-green w3-round"><li class="fa fa-save"></li> Actualizar</button><br /><br />' +
        '</form>'
    )
    $.ajax({
        url: "/Ajax/Ajax?data=loadinfo",
        type: "POST",
        success: function (a) {
            var datos = JSON.parse(a);
            $('#titulo1').val(datos.titulo);
     

        }
    });
});

$("#edit2").click(function () {

    $('#contenedorprimario').html(
        '<form onsubmit="return false;" id="frmacerca">' +
        '<label>Titulo</label>' +
        '</br><input placeholder="Ingrese el titulo" id="titulo2" name="titulo2" class="w3-round w3-transparent w3-border w3-input" type="text"/></br>' +
        '<label>Informacion acerca de la app</label>' +
        '</br><textarea style="height:120px; resize:none;"  placeholder="Ingrese la información acerca de la app" id="infoapp2" name="infoapp2" class="w3-round w3-transparent w3-border w3-input" type="text"></textarea></br>' +
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
        '<form id="frmtitulo3" onsubmit="return false;"> ' +
        '<label>Titulo</label>' +
        '</br><input placeholder="Ingrese el titulo" id="titulo3" name="titulo3" class="w3-round w3-transparent w3-border w3-input" type="text"/></br>' +
        '<button type="button" onclick="updatetitulo3()" class="w3-button w3-small w3-right w3-green w3-hover-green w3-round"><li class="fa fa-save"></li> Actualizar</button><br /><br />' +
        '</form>'
    )
    $.ajax({
        url: "/Ajax/Ajax?data=loadinfo",
        type: "POST",
        success: function (a) {
            var datos = JSON.parse(a);
            $('#titulo3').val(datos.titulo3);


        }
    });
});

$("#edit4").click(function () {

    $('#contenedorprimario').html(
        '<form id="frmtitulo4" onsubmit="return false;">' +
        '<label>Titulo</label>' +
        '</br><input id="titulo4" name="titulo4" placeholder="Ingrese el titulo" class="w3-round w3-transparent w3-border w3-input" type="text"/></br>' +
        '<button type="button" onclick="updatetitulo4()" class="w3-button w3-small w3-right w3-green w3-hover-green w3-round"><li class="fa fa-save"></li> Actualizar</button><br /><br />' +
        '</form>'
    )

    $.ajax({
        url: "/Ajax/Ajax?data=loadinfo",
        type: "POST",
        success: function (a) {
            var datos = JSON.parse(a);
            $('#titulo4').val(datos.titulo4);


        }
    });

});


$("#btnjugar").click(function () {

    $('#contenedorprimario').html(
        '<form id="frmtitulosjugar" onsubmit="return false;">' +
        '<br/>'+
        '<label>Titulo</label>' +
        '</br><input id="titulojugar" name="titulojugar" placeholder="Ingrese el titulo" class="w3-round w3-transparent w3-border w3-input" type="text"/></br>' +
        '<label>Subtitulo</label>' +
        '</br><textarea id="subtitulojugar" name="subtitulojugar" placeholder="Ingrese el titulo" class="w3-round w3-transparent w3-border w3-input" style="resize:none" /></br>' +

        '<button type="button" onclick="editinfojugar()" class="w3-button w3-small w3-right w3-green w3-hover-green w3-round"><li class="fa fa-save"></li> Actualizar</button><br /><br />' +
        '</form>'
    )
    $.ajax({
        url: "/Ajax/Ajax?data=loadinfo",
        type: "POST",
        success: function (a) {
            var datos = JSON.parse(a);
            $('#titulojugar').val(datos.titulojugar);
            $('#subtitulojugar').val(datos.subtitulojugar);

        }
    });


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

        '<form onsubmit="return false;" id="frmContac" class="w3-large w3-margin-bottom">' +
        '<li class="fa fa-text-width fa-fw w3-hover-text-black w3-xlarge w3-margin-right"></li><input id="tit" name="tit" class=" w3-transparent w3-round w3-border" style="width:300px" placeholder="Ingrese Titúlo" required /><br /><br />' +
        '<li class="fa fa-text-width fa-fw w3-hover-text-black w3-xlarge w3-margin-right"></li><input id="subt" name="subt" class="w3-transparent w3-border w3-round"  style="width:300px" placeholder="Ingrese un subtitulo" required /><br /><br />' +
        '<i class="fa fa-map-marker fa-fw w3-hover-text-black w3-xlarge w3-margin-right"></i><input id="dire" name="dire" placeholder="Dirección" class="w3-transparent w3-border w3-round"  style="width:300px" required /> <br><br>' +
        '<i class="fa fa-phone fa-fw w3-hover-text-black w3-xlarge w3-margin-right"></i><input id="tel" name="tel" placeholder="Ingrese número de telefono" class="w3-border w3-round w3-transparent"  style="width:300px" required /><br><br />' +
        '<i class="fa fa-envelope fa-fw w3-hover-text-black w3-xlarge w3-margin-right"></i><input id="corr" name="corr" placeholder="Correo electronico" class="w3-round w3-transparent w3-border"  style="width:300px" required /><br><br />' +
        '<i class="fa fa-coffee fa-fw w3-hover-text-black w3-xlarge w3-margin-right"></i><input id="mensajecontacto2" name="mensajecontacto" placeholder="Mensaje personalizado para el usuario" class="w3-round w3-transparent w3-border"  style="width:300px" required /><br><br />' +
        '<input type="hidden" class="w3-round w3-transparent" id="la" name="la" />' +
        '<input type="hidden" class="w3-round w3-transparent w3-border" id="lon" name="lon" />' +

        '</form>' +
        '<button id="btnactualizar" onclick="actualizarcontacto()" type="button" class="w3-button w3-right w3-black w3-hover-green" > <li class="fa fa-send"></li> Actualizar informacion</button > ' +
        '</div >' +
        '</div > ')

    $.ajax({
        url: "/Ajax/Ajax?data=InfoContactoIndex",
        type: "POST",
        success: function (a) {

            var d = JSON.parse(a);
            $('#la').val(d.latitud);
            $('#lon').val(d.longitud);
            $('#tit').val(d.titulo);
            $('#subt').val(d.subtitulo);
            $('#dire').val(d.direccion);
            $('#tel').val(d.numero);
            $('#corr').val(d.correo);
            $('#mensajecontacto2').val(d.mensaje);
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