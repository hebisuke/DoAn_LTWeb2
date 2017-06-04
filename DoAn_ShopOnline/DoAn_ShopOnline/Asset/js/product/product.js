var product = {
    init: function () {
        product.registerEvents();
    },
    registerEvents: function () {

        $('.btn_images').off('click').on('click', function (e) {
            e.preventDefault();
            $('#imagesManange').modal('show');
            $('#_hidProductID').val($(this).data('id'));
            product.loadImages();
        });
        },
    loadImages: function () {
        $.ajax({
            url: '/Shop/LoadImages',
            type: 'GET',
            data: {
                id: $('#_hidProductID').val()
            },
            dataType: 'json',
            success: function (response) {
                var data = response.data;
                var html = '';
                $.each(data, function (i, item) {
                    html += '<div style="float:left" class="col-lg-4 col-md-4 col-xs-12"><img src="' + item + '" style="width:200px;height:220px;"/></div>'
                });
                $('#_imageList').html(html);

                //thong bao thanh cong
            }
        });
    }
}
product.init();