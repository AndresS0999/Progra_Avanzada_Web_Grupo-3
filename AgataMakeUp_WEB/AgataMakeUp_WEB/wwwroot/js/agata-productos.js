
// Filtros de demostración sobre productos estáticos.
// La API se integrará después.

document.addEventListener('DOMContentLoaded', () => {

    const opciones = document.querySelectorAll('input[name="categoriaProducto"]');
    const tarjetas = Array.from(document.querySelectorAll('.agata-producto-card'));
    const conteo = document.getElementById('agata-conteo-productos');
    const vacio = document.getElementById('agata-sin-resultados');

    if (!opciones.length || !conteo || !vacio) return;

    const filtrar = () => {

        const seleccion = document.querySelector(
            'input[name="categoriaProducto"]:checked'
        )?.value || 'Todas';

        let visibles = 0;

        tarjetas.forEach(tarjeta => {

            const mostrar = seleccion === 'Todas' ||
                tarjeta.dataset.categoria === seleccion;

            tarjeta.hidden = !mostrar;

            if (mostrar) {
                visibles++;
            }
        });

        conteo.textContent = `Mostrando ${visibles} producto${visibles === 1 ? '' : 's'} de ejemplo`;

        vacio.hidden = visibles > 0;
    };

    opciones.forEach(opcion => {
        opcion.addEventListener('change', filtrar);
    });

    filtrar();
});
