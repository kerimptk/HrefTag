function success(message) {
    Swal.fire({
        title: 'Good job!',
        text: message,
        icon: 'success'

    });
}

function failure(message) {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: message.responseJSON.error
    });
}


