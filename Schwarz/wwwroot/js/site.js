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
$('.ordemServico').on('input', function () {
    var num = $(this).val().replace(/\D/g, '');

    if (num.length > 11) {
        num = num.substring(0, 11);
    }

    var formattedNum = '';
    for (var i = 0; i < num.length; i++) {
        if (i === 3 || i === 6) {
            formattedNum += '.';
        }
        formattedNum += num[i];
    }
    $(this).val(formattedNum);
});

$('.select2').select2({
    width: '100%',
});