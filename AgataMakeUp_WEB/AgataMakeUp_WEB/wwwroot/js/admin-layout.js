
// Interacciones visuales del panel administrativo.
document.addEventListener("DOMContentLoaded", () => {
    const toggle = document.querySelector('[data-lte-toggle="sidebar"]');

    if (toggle) {
        toggle.addEventListener("click", (event) => {
            event.preventDefault();
            document.body.classList.toggle("sidebar-collapse");
        });
    }

    // Evitar navegar a opciones aún sin una vista implementada.
    document.querySelectorAll("[data-visual]").forEach(link => {
        link.addEventListener("click", event => event.preventDefault());
    });
});
