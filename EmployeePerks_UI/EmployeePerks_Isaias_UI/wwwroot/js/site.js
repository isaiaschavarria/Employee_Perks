// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let EMPLOYEE_ID = 0

$(document).ready(function () {
    var div = $('#userId');
    if (div.text() !== null) {
        EMPLOYEE_ID = div.text();
    }
});