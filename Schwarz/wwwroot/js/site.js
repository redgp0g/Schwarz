$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

var tabs = document.querySelectorAll(".lboard_tabs ul li"),
    month = document.querySelector(".month"),
    year = document.querySelector(".year"),
    items = document.querySelectorAll(".lboard_item"),
    adicionaracao = document.getElementById('adicionar_acao'),
    removeracao = document.querySelectorAll('remover_acao');
tabs.forEach(function (tab) {
    tab.addEventListener("click", function () {
        var currentdatali = tab.getAttribute("data-li");

        tabs.forEach(function (tab) {
            tab.classList.remove("active");
        })

        tab.classList.add("active");

        items.forEach(function (item) {
            item.style.display = "none";
        })

        if (currentdatali == "mes") {
            month.style.display = "block";
        }
        else {
            year.style.display = "block";
        }
    })
});

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
    document.body.insertAdjacentElement('afterbegin',divloading);

}

function HideLoading() {
    const loadings = document.getElementsByClassName("loading");
    if (loadings.length) {
        loadings[0].remove();
    }
}