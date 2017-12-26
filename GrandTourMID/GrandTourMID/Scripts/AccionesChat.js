
var ajaxCall
$(document).on("ready", function () {

    ajaxCall = function () {

        $.ajax({
            data: $("#sidepanel").serialize(),
            url: '/Ajax/Ajax?data=users',
            type: "post",
            success: function (e) {

                $("#userscontainer").html(e);

            }

        });
    }
    setInterval(ajaxCall, 1000)

});

$(document).ready(function () {

    scroll();
})

function scrool() {

    var objDiv = document.getElementById("scroll");
    objDiv.scrollTop = objDiv.scrollHeight;

};

function chatGo(e, a) {
    $("#idchat").val(e);
    clearInterval(ajaxCall);
    ajaxCall = setInterval(function () {
        $.ajax({
            data: $("#sidepanel").serialize(),
            url: '/Ajax/Ajax?data=chat&id=' + e + '&name=' + a,
            type: "post",
            sendBefore: function () {

            },
            success: function (r) {
                $("#mensajes").html(r);
                cargarinfouser();
            }
        });

    }, 300);

};


function cargarinfouser() {
    $.ajax({
        url: '/Ajax/Ajax?data=infouser',
        type: "post",

        success: function (r) {

            var dt = JSON.parse(r);
            $("#userenvia").prop("src", dt.foto);
            $("#nameenvia").html(dt.nombreus);

        }
    });
};

function enviar() {
    if ($("#message").val() != "") {
        $.ajax({
            data: $("#sidepanel").serialize(),
            url: "/Ajax/Ajax?data=enviarchat",
            type: "post",
            success: function (e) {
                if (e == 1) {

                    $("#message").val('');
                    scrollToEnd();

                } else {

                }
            }

        });

    }
    else {

    }
};


$('#btnenviarchar').keypress(function (event) {
    if (event.keyCode == 13) {
        enviar();
    }
});

