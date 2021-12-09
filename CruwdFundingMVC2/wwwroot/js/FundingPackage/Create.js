// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).on('change keyup', '.required', function (e) {
    let Disabled = true;
    $(".required").each(function () {
        let value = this.value
        if ((value) && (value.trim() != '')) {
            Disabled = false
        } else {
            Disabled = true
            return false
        }
    });
})

$('form').submit(function () {
    $('input[type=submit]', this).attr('disabled', 'disabled');
});