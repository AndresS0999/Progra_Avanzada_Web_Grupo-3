
// Interacciones visuales del detalle del producto.
// Las operaciones de carrito y favoritos se conectarán posteriormente con la API.

document.addEventListener('DOMContentLoaded', function () {
    const campo = document.getElementById('agata-cantidad');
    if (!campo) return;

    const normalizar = valor => {
        const numero = Number.parseInt(valor, 10);
        return Number.isFinite(numero) ? Math.max(1, Math.min(99, numero)) : 1;
    };

    const aumentar = document.querySelector('.agata-cantidad-control .qty-up');
    const disminuir = document.querySelector('.agata-cantidad-control .qty-down');

    aumentar?.addEventListener('click', () => {
        campo.value = normalizar(campo.value) +
            (normalizar(campo.value) < 99 ? 1 : 0);
    });

    disminuir?.addEventListener('click', () => {
        campo.value = Math.max(1, normalizar(campo.value) - 1);
    });

    campo.addEventListener('change', () => {
        campo.value = normalizar(campo.value);
    });
});
