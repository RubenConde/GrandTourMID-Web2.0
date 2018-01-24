
var loadimagenpublic1 = function (event) {
    var imgpublic1 = document.getElementById('imgpublic1');
    imgpublic1.src = URL.createObjectURL(event.target.files[0]);
    $("#spancloseimagen1").show();
};

var loadimagenpublic2 = function (event) {
    var imgpublic2 = document.getElementById('imgpublic2');
    imgpublic2.src = URL.createObjectURL(event.target.files[0]);
    $("#spancloseimagen2").show();
};

var loadimagenpublic3 = function (event) {
    var imgpublic3 = document.getElementById('imgpublic3');
    imgpublic3.src = URL.createObjectURL(event.target.files[0]);
    $("#spancloseimagen3").show();
};


$(document).ready(function () {
    $.ajax({
        url: "/Ajax/Ajax?data=loadlugaresvisitados",
        type: "POST",
        success: function (a) {

            $("#usuariovisitas").html(a);

        }
    });
});

$(document).ready(function () {
    $.ajax({
        url: "/Ajax/Ajax?data=loadfotosusuarioxlugar",
        type: "POST",
        success: function (a) {

            $("#fotosusuariolugar").html(a);

        }
    });
});

$(document).ready(function () {
    $.ajax({
        url: "/Ajax/Ajax?data=loadultimasfotosuser",
        type: "POST",
        success: function (a) {

            $("#ultimasfotosusuario").html(a);

        }
    });
});


var interval;

function verinfolugar(e) {
    clearInterval(interval);
    $.ajax({
        url: '/Ajax/Ajax?data=verinfolugar&idlugar=' + e,
        type: "post",

        success: function (a) {
            if (a == 1) {

                window.location = "/Profile/InfoLugarVisitado"
            }

        }
    });
};









///////

$(document).ready(function () {
    info();
    $("#comentarios").hide();
})

function myFunction() {
    var x = document.getElementById("de");
    if (x.className.indexOf("w3-show") == -1) {
        x.className += " w3-show";
    } else {
        x.className = x.className.replace(" w3-show", "");
    }
}

function info() {
    $.ajax({
        url: '/Ajax/Ajax?data=comentarios',
        method: 'Post',
        success: function (a) {

            $("#comentarios").html(a);

        }
    });

    var ajaxCall = function () {
        $.ajax({
            url: '/Ajax/Ajax?data=comentarios',
            method: 'Post',
            success: function (a) {

                $("#comentarios").html(a);

            }
        });
    }
    setInterval(ajaxCall, 1000)
}

function info() {
    $.ajax({
        url: '/Ajax/Ajax?data=publicaciones',
        method: 'Post',
        success: function (a) {

            $("#publicaciones").html(a);

        }
    });

    var ajaxCall = function () {
        $.ajax({
            url: '/Ajax/Ajax?data=publicaciones',
            method: 'Post',
            success: function (a) {

                $("#publicaciones").html(a);

            }
        });
    }
    setInterval(ajaxCall, 1000)
}


$(document).ready(function () {

    $("#divimagenes").hide();
    $("#spanclose").hide();
    $("#spancloseimagen1").hide();
    $("#spancloseimagen2").hide();
    $("#spancloseimagen3").hide();
    $("#cancelarsubida").hide();
    myinfo();
    



});

$("#subirimg").click(function () {
    $("#divimagenes").show();
    $("#spanclose").show();
    $("#subirimg").hide();
    $("#cancelarsubida").show();
})


function ocultarinfo() {
    
    $("#divimagenes").hide();
    $("#spanclose").hide();
    $("#subirimg").show();
    $("#cancelarsubida").hide();
    $("#imgpublic2").prop("src", "/img/subirfoto.png");
    $("#imgpublic3").prop("src", "/img/subirfoto.png");


}

function eliminarimagen1() {
    $("#fileimg").val(null);
    $("#imgpublic1").prop("src", "/img/subirfoto.png");
    $("#spancloseimagen1").hide();


}

function eliminarimagen2() {
    $("#fileimg2").val(null);
    $("#imgpublic2").prop("src", "/img/subirfoto.png");
    $("#spancloseimagen2").hide();
}


function eliminarimagen3() {
    $("#fileimg3").val(null);
    $("#imgpublic3").prop("src", "/img/subirfoto.png");
    $("#spancloseimagen3").hide();
}

function myinfo() {
    $.ajax({
        url: "/Ajax/Ajax?data=DatosUsuario",
        type: "POST",
        success: function (a) {

            var datos = JSON.parse(a);

            $('#nombreperfil').html(datos.usuario);
            $('#namecomple').html('<i class="fa fa-pencil fa-fw w3-margin-right w3-text-theme"></i> ' + datos.nombreus + " " + datos.apellidop + " " + datos.apellidom);
            
            $('#nameuser').val(datos.nombreus);
            $('#userprofile').val(datos.usuario);
            $('#apellidouserpate').val(datos.apellidop);
            $('#apellidousermate').val(datos.apellidom);
            $('#emailuser').val(datos.email);
            $("#imgedit").prop("src", datos.foto)
            $("#fotoperfil").prop("src", datos.foto)
        }

    });
}

$("#btnhabilit").click(function () {


    $("#nameuser").prop('disabled', false);
    $("#emailuser").prop('disabled', false);
    $("#apellidousermate").prop('disabled', false);
    $("#apellidouserpate").prop('disabled', false);
    $("#userprofile").prop('disabled', false);
    $("#userprofile").prop('disabled', false);

    $("#btncancelar").prop('disabled', false);
    $("#btncancelar").show();


});


