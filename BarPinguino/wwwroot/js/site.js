function DF() {
    const form = document.getElementById('Mail');
    form.style.display = form.style.display === 'none' ? 'block' : 'none';
    const formdos = document.getElementById('Maildos');
    formdos.style.display = formdos.style.display === 'none' ? 'block' : 'none';
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