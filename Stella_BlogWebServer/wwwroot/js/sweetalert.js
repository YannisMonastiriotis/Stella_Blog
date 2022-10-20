window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire({
            icon: 'success',
            title: 'Good job',
            text:   message
        })
    }
    if (type === "error") {
        Swal.fire({
            icon: 'error',
            title: 'Ops...',
            text: message
        })
    }
  
}