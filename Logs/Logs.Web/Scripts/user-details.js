$('.edit-button')
        .click(function () {
            $('#send').show();
            $("#edit-stats").toggle();
        });

$('#edit-stats-form')
   .submit(function () {
       $('#edit-stats').hide();
       $('#send').hide();
   });