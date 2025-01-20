function DF() {
    const form = document.getElementById('Mail');
    form.style.display = form.style.display === 'none' ? 'block' : 'none';
    const recu = document.getElementById('Recu');
    if (recu.style.display === 'block') {
        recu.style.display = 'none';  // Si "Recu" está visible, lo ocultamos
    } else {
        recu.style.display = 'none';  // Si "Recu" está oculto, se mantiene oculto
    }
}
function RC() {
    const form = document.getElementById('Recu');
    form.style.display = form.style.display === 'none' ? 'block' : 'none';
    const recu = document.getElementById('Mail');
    if (recu.style.display === 'block') {
        recu.style.display = 'none';  // Si "Recu" está visible, lo ocultamos
    } else {
        recu.style.display = 'none';  // Si "Recu" está oculto, se mantiene oculto
    }
}
// Obtener el elemento con la clase "nbar"
const nbars = document.querySelectorAll('.nbar');

nbars.forEach(nbar => {
    // Función para iluminar el texto al hacer hover
    nbar.addEventListener('mouseover', () => {
        nbar.style.color = '#f39c12';  // Cambiar el color cuando se hace hover
    });

    // Función para restaurar el color original al quitar el hover
    nbar.addEventListener('mouseout', () => {
        nbar.style.color = '';  // Restaurar el color original
    });
});