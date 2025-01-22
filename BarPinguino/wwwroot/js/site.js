function activarBtn() {
    const rutCompleto = document.getElementById('rut').value;
    const btnConsultar = document.getElementById('btncon');
    const btnRegistrar = document.getElementById('btnreg');

    // Validación del RUT
    const esValido = validarRutInterno(rutCompleto);

    // Activar o desactivar el botón según la validez del RUT
    btnConsultar.disabled = !esValido;
    btnRegistrar.disabled = !esValido;
}

// Función interna que valida el RUT
function validarRutInterno(rutCompleto) {
    rutCompleto = rutCompleto.replace("‐", "-");

    if (!/^[0-9]+[-|‐]{1}[0-9kK]{1}$/.test(rutCompleto)) return false;

    const [rut, digv] = rutCompleto.split('-');
    let M = 0, S = 1;

    for (let T = parseInt(rut, 10); T > 0; T = Math.floor(T / 10))
        S = (S + T % 10 * (9 - M++ % 6)) % 11;

    const calculatedDv = S ? S - 1 : 'k';

    return calculatedDv.toString() === digv.toLowerCase();
}

// Desactivar el botón de "Consultar" al cargar la página
window.onload = function () {
    const btnConsultar = document.getElementById('btncon');
    const btnRegistrar = document.getElementById('btnreg');
    btnConsultar.disabled = true;
    btnRegistrar.disabled = true;
}

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
})