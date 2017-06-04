var product = {
    init: function () {
        product.registerEvents();
    },
    registerEvents: function () {

        $('.btn-images').off('click').on('click', function (e) {
            e.preventDefault();
            $('#imagesManange').modal('show');
            $('#hidProductID').val($(this).data('id'));
           product.loadImages();
        });

        $('#btnChooImages').off('click').on('click', function (e) {
            e.preventDefault();
            var finder = new CKFinder();
            finder.selectActionFunction = function (url) {
                $('#imageList').append('<div style="float : left;" class="col-lg-3 col-md-3 col-xs-12"><img src ="' + url + '" width=100px   height=120px/> <a href="#" class="btn-delImage"><i class="fa fa-times"></i></a>   </div>');
                $('.btn-delImage').off('click').on('click', function (e) {
                    e.preventDefault();
                    $(this).parent().remove();
                });
            };
            finder.popup();

        });

        $('#btnSaveImages').off('click').on('click', function (e) {
            var images = [];
            var id = $('#hidProductID').val();
            $.each($('#imageList img'), function (i, item) {
                images.push($(item).prop('src'));
            })

            $.ajax({
                url: '/SanPhamAdmin/SaveImages',
                type: 'POST',
                data: {
                    id: id,
                    images: JSON.stringify(images)
                },
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        $('#imagesManange').modal('hide');
                        alert("Save ảnh thành công!!!");
                    }

                    // thông báo thành công
                }

            });
        });
    },
    loadImages: function () {
        $.ajax({
            url: '/SanPhamAdmin/LoadImages',
            type: 'GET',
            data: {
                id: $('#hidProductID').val()
            },
            dataType: 'json',
            success: function (response) {
                var data = response.data;
                var html = '';
                $.each(data, function (i, item) {
                    html += '<div style="float:left" class="col-lg-3 col-md-3 col-xs-12"><img src="' + item + '" width="100" height=120px/><a href="#" class="btn-delImage"><i class="fa fa-times"></i></a></div>'
                });
                $('#imageList').html(html);

                $('.btn-delImage').off('click').on('click', function (e) {
                    e.preventDefault();
                    $(this).parent().remove();
                });

                //thong bao thanh cong
            }
        });
    }
}
product.init();