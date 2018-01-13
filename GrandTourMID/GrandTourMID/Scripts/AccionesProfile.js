
var loadimagenpublic1 = function (event) {
    var imgpublic1 = document.getElementById('imgpublic1');
    imgpublic1.src = URL.createObjectURL(event.target.files[0]);
};

var loadimagenpublic2 = function (event) {
    var imgpublic2 = document.getElementById('imgpublic2');
    imgpublic2.src = URL.createObjectURL(event.target.files[0]);
};

var loadimagenpublic3 = function (event) {
    var imgpublic3 = document.getElementById('imgpublic3');
    imgpublic3.src = URL.createObjectURL(event.target.files[0]);
};

$(document).ready(function () {
    $("#frmvalidarcontra").submit(function (e) {
        e.preventDefault();
        $.ajax({
            url: "/Ajax/Ajax?data=checkpass",
            type: "POST",
            data: $("#frmvalidarcontra").serialize(),
            beforeSend: function () {
                $("#btnvalidar").html('<i class="fa fa-spinner fa-pulse fa-fw"></i> Validando');
            },
            success: function (a) {
                if (a == 1) {

                    window.location = "/Profile/EditProfile";

                    $("#btnvalidar").html('<i class="fa fa-sign-in" aria-hidden="true"></i> Validar contraseña');
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

                    $("#btnvalidar").html('<i class="fa fa-sign-in" aria-hidden="true"></i> Validar contraseña');
                    $("#passprofilevalidar").val('');


                }
                else {

                }
            }
        });
    });
});






///////
var start = 5;
var reachedMax = false;

$(window).scroll(function () {

    if ($(window).scrollTop() == $(document).height() - $(window).height())
        getData(start);

});




$(document).ready(function () {
    getData(start);
});


function getData(start){
    if (reachedMax)
        return;
    $.ajax({
        url: '/Ajax/Ajax?data=publicaciones&start='+ start,
        method: 'Post',
        success: function (a) {
            if (a == "reachedMax")
                reachedMax = true;
            else {
                start += 0;
                $("#publicaciones").append(a);
            }

        }

        

    })

}


$(document).ready(function () {

    $("#divimagenes").hide();
    $("#spanclose").hide();
    
    myinfo();

});

$("#subirimg").click(function () {
    $("#divimagenes").show();
    $("#spanclose").show();
    $("#subirimg").hide();

})


function ocultarinfo() {
    $("#divimagenes").hide();
    $("#spanclose").hide();
    $("#subirimg").show();

}

function myinfo() {
    $.ajax({
        url: "/Ajax/Ajax?data=DatosUsuario",
        type: "POST",
        success: function (a) {

            var datos = JSON.parse(a);

            $('#nombreperfil').html(datos.usuario);
            $('#namecomple').html('<i class="fa fa-pencil fa-fw w3-margin-right w3-text-theme"></i> ' + datos.nombreus +" "+ datos.apellidop +" "+ datos.apellidom);
            $('#validationCustom06').val();
            $('#validationCustom08').val();
            $('#validationCustom10').val(datos.email);
            $('#usernameadmis').html(datos.nombreus);
            $("#imgadmi").prop("src", datos.foto)
            $("#fotoperfil").prop("src", datos.foto)
            $('#validationCustom04').val(datos.usuario);
            $('#validationCustom06').val(datos.apellidop);
            $('#validationCustom08').val(datos.apellidom);

        }

    });

    



}