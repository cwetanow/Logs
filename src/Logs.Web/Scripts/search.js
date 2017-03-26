$('#search-box').keyup(function () {
    if ($('#search-box').val().length > 0) {
        $('#ajaxForm').submit();
    } else {
        $('#results').empty();
    }
})