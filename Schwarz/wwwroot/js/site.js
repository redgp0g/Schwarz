var preview = document.getElementById('preview');
var fotoOriginal = preview.src;
function previewImage(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            preview.src = e.target.result;
        };
        reader.readAsDataURL(input.files[0]);
    } else {
        preview.src = fotoOriginal;
    }
}
function ShowLoading() {
    const divloading = document.createElement("div");
    const divbox = document.createElement("div");
    const label = document.createElement("label");
    divloading.classList.add("loading", "centralize");

    for (i = 0; i <= 7; i++) {
        var span = document.createElement("span");
        span.style = "--i:" + i;
        divbox.appendChild(span);
    }
    divbox.classList.add("box");

    label.innerText = "Carregando... Por favor aguarde";
    label.style = "color:white;";

    divloading.appendChild(label);
    divloading.appendChild(divbox);
    document.body.insertAdjacentElement('afterbegin', divloading);

}

function HideLoading() {
    const loadings = document.getElementsByClassName("loading");
    if (loadings.length) {
        loadings[0].remove();
    }
}