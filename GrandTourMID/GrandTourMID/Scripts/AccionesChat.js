

$(document).on("ready", function () {
    
    var ajaxCall = function () {
        
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

var interval;

function chatGo(e, a) {
    $("#idchat").val(e);
    clearInterval(interval);
    interval = setInterval(function () {
        $.ajax({
            data: $("#sidepanel").serialize(),
            url: '/Ajax/Ajax?data=chat&id=' + e + '&name=' + a,
            type: "post",
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
            $("#usrnames").html(dt.nombreus);
            
        }
    });
};

function enviar() {    
    if ($("#menssage").val() != "") {
        $.ajax({
            data: $("#sentmensaje").serialize(),
            url: "/Ajax/Ajax?data=enviarchat",
            type: "post",
            success: function (e) {
                if (e == 1) {

                    $("#menssage").val('');
                    scrollToEnd();

                } else {

                }
            }
            
        });
        
    }
    else {

    }
};


