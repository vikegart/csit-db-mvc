(function () {
    $(".buttonOnclik").click(function () {
        location.href = $(this).attr('data-href');
    });
    $(".loadImage").change(function () {
        $("#upload-file-info").html($(this).val());
    });
}());