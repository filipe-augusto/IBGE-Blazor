function MensagemCriacao () {
    Swal.fire({
        title: 'Localidade criada com sucesso',
        text: 'Localidade foi criada, voc� ser� direcionado para tela inicial',
        icon: 'success',
        customClass: {
            confirmButton: 'btn btn-primary',
            cancelButton: 'btn btn-danger'
  
        }
    });
}