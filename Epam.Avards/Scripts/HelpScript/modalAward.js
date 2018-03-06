(function () {
    $(".imageAward").bind("click", (e) => {
        var title = $(e.currentTarget).attr("data-title"),
            description = $(e.currentTarget).attr("data-description");
        document.getElementById('titleAward').innerHTML = title;
        document.getElementById('descriptionAward').innerHTML = description;
    });
}());