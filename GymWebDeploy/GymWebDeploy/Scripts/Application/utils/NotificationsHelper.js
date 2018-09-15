//success|error|warning|info|question
function MsgSuccess(typeMsg, msg) {
    const toast = swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 4000
    });

    toast({
        type: typeMsg,
        title: msg
    });
}