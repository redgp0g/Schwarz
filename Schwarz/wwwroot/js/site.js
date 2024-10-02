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
    let num = $(this).val().replace(/\D/g, '');

    if (num.length > 9) {
        num = num.substring(0, 9);
    }

    let formattedNum = '';
    for (let i = 0; i < num.length; i++) {
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

function converterTabelaEmExcel(idTabela, nomeArquivo) {
    TableToExcel.convert(document.getElementById(idTabela), {
        name: nomeArquivo + '.xlsx',
        sheet: {
            name: nomeArquivo
        }
    });
}

$('#ano').text(new Date().getFullYear());

setTimeout(function () {
    const notificacao = document.getElementById('notification');
    if (notificacao) {
        notificacao.classList.add('hidden');
    }
}, 7000);