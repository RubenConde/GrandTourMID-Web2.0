
$(document).ready(function () {
    var ajaxCall = function () {
        $.ajax({
            url: "/Ajax/Ajax?data=DatosUsuario",
            type: "POST",
            success: function (a) {
                var datos = JSON.parse(a);

                $('#nombreperfil').html(datos.nombreus);
                $('#fotoperfil').prop("src", datos.foto);
                $('#apellidoperfilpaterno').html(datos.apellidop);
            }

        });
    }
    setInterval(ajaxCall, 900);
});


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
