

    tinymce.init({
        selector: "#Content",
        width: '100%',
        height: 600,
        statusbar: false,
        menubar: true,

        setup: function (ed) {
            ed.on('init', function () {
                this.getDoc().body.style.fontSize = '14px';
                this.getDoc().body.style.fontFamily = '"Helvetica Neue", Helvetica, Arial, sans-serif';
            });
        },

        paste_data_images: true,

        plugins: [
            "advlist autolink lists link base64_image charmap hr anchor pagebreak",
            "searchreplace wordcount visualblocks visualchars code",
            "insertdatetime media nonbreaking save table contextmenu directionality",
            "emoticons textcolor colorpicker textpattern "
        ],
        toolbar: "undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link base64_image media | forecolor backcolor"
    });

