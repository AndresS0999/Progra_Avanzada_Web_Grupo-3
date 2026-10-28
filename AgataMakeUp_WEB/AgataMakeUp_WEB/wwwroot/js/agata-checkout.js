
document.addEventListener('DOMContentLoaded', () => {
    const alterna = document.getElementById('DireccionDiferente');
    const camposAlternos = document.getElementById('agata-direccion-alternativa');
    const confirmar = document.getElementById('agata-confirmar-pedido');
    const aviso = document.getElementById('agata-checkout-aviso');

    if (alterna && camposAlternos) {
        const actualizar = () => {
            camposAlternos.hidden = !alterna.checked;

            camposAlternos.querySelectorAll('input').forEach(input => {
                input.required = alterna.checked;
            });
        };

        alterna.addEventListener('change', actualizar);
        actualizar();
    }

});
