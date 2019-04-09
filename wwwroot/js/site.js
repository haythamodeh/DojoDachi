// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ajaxFeed() {
    $.ajax ({
        type: "GET",
        url: "/feed",
        success: data => {
            console.log(data);
        },
        error: data => {
            console.log(data);
        }
    });
}