var tabs = document.querySelectorAll(".lboard_tabs ul li"),
    month = document.querySelector(".month"),
    year = document.querySelector(".year"),
    items = document.querySelectorAll(".lboard_item");

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