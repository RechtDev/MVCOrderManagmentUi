// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.addEventListener("DOMContentLoaded", onDomLoaded);
function onDomLoaded() {
    let cartTabs = document.getElementsByClassName("cartIdRow");
    let rowbutton = document.getElementsByClassName("dropdown-icon-arrow-btn");
    let rowText = document.getElementsByClassName("row-text")

    for (var i = 0; i < rowbutton.length; i++) {
        rowbutton[i].id = `CartDropDownButtonId${i + 1}`;
        rowbutton[i].onclick = function (e) {
            var contents = this.parentElement.nextElementSibling.classList.toggle("cart-item-table");
            
        }
        
    }
    
}
