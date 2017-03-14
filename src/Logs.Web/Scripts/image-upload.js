$.cloudinary.config("cloud_name", "cwetanow");
$(function () {
    if ($.fn.cloudinary_fileupload !== undefined) {
        $("input.cloudinary-fileupload[type=file]").cloudinary_fileupload();
    }
    $('.cloudinary-fileupload')
        .fileupload({
            dropZone: '#direct_upload',
            start: function () {
                $('#profile-pic').toggle();
                $('.status_value').text('Starting direct upload...');
            },
            progress: function () {
                $('.status_value').text('Uploading...');
            },
        })
        .on('cloudinarydone',
            function (e, data) {
                $('.status_value').text('Selected Picture');
                $('.upload-box').hide();

                var info = $('<div class="uploaded_info"/>');
                console.log(data.result);

                $("#pic-url").val(data.result.url);

                $(info)
                    .append($('<div class="image"/>')
                        .append(
                            $.cloudinary.image(data.result.public_id,
                            {
                                format: data.result.format,
                                width: 400,
                                height: 400,
                                crop: "fill"
                            })
                        ));
                $('.uploaded_info_holder').append(info);
                $('#upload-btn').toggle();
            });
});