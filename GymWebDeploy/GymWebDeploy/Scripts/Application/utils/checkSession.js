//Este archivo revisa la Sessión activa
var User = '<%=Session["User"] %>';
var nameEntity = 'Login';
var path = '../' + nameEntity ;
function checkStatus(){
    ajaxPostCall(path + '/sessionStatus/', ReturnJson('')).done(function (response) {
        console.log(response);
        if (response)
            return false;
        else
            window.location.href = "../Login";
    });
}

function sessionAbandon() {
    ajaxPostCall(path + '/sessionAbandon/', ReturnJson('')).done(function (response) {
        console.log(response);
            MsgSuccess('info', response.Message);
            var url = response.TargetURL;
            window.location.href = "../Login";        
    });
}