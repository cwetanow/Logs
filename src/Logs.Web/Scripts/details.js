$("#entries-btn")
          .click(function () {
              $('#entry-form').toggle();
          });
$("#comment-btn")
    .click(function () {
        $('#comment-form').toggle();
    });

$('#rating-btn')
    .click(function () {
        $('#rating-btn').hide();
    });

$('#edit-button')
    .click(function () {
        $('#edit-form').toggle();
    });

$('#edit')
    .submit(function () {
        $('#edit-form').toggle();
    });

$('.edit-comment')
   .submit(function () {
       $(this).toggle();
   });

$('.edit-entry')
  .submit(function () {
      $(this).toggle();
  });

$('.edit-entry-button')
   .click(function () {
       $(this.parentElement.children[3]).toggle();
   });

$('.edit-comment-button')
 .click(function () {
     $(this.parentElement.parentElement.children[2]).toggle();
 });