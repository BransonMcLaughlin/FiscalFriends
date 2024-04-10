// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function changeLanguage(language) {

    document.getElementById('currentLanguage').textContent = language;

}

document.addEventListener('DOMContentLoaded', function () {

    var languageItems = document.querySelectorAll('.dropdown-item');
    languageItems.forEach(function (item) {

        item.addEventListener('click', function () {

            changeLanguage(this.textContent);

        });

    });

});