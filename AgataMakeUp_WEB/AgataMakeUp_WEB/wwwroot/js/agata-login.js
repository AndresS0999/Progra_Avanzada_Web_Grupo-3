document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.agata-password-toggle').forEach(function (boton) {
        const input = boton.closest('.agata-login-password').querySelector('input');
        const icono = boton.querySelector('i');

        boton.addEventListener('click', function () {
            const mostrar = input.getAttribute('type') === 'password';

            input.setAttribute('type', mostrar ? 'text' : 'password');
            icono.classList.toggle('fa-eye', !mostrar);
            icono.classList.toggle('fa-eye-slash', mostrar);
            boton.setAttribute('aria-label', mostrar ? 'Ocultar contraseña' : 'Mostrar contraseña');
        });
    });
});
