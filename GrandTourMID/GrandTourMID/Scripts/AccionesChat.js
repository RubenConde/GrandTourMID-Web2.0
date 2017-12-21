
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


