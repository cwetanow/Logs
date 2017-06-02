$(function () {
    $('#datetimepicker').datetimepicker({
        format: 'DD/MM/YYYY'
    });

    $('#nutrition-form').hide();
    $('#measurement-form').hide();

    $('#datetimepicker').on("dp.change", function (e) {
        var date = $('#datetimepicker').val();
        var parts = date.split('/');

        var datetime = new Date(parts[2], (+parts[1]) - 1, (+parts[0]) + 1).toISOString();

        $('#nutrition-form').show();
        $('#measurement-form').show();

        $('#nutrition-model-date').val(datetime);
        $('#measurements-model-date').val(datetime);
    });

    $('#nutrition-form').submit(() => {
        $('#measurements').hide();
        $('#nutrition').show();
    });

    $('#measurement-form').submit(() => {
        $('#nutrition').hide();
        $('#measurements').show();
    });
});