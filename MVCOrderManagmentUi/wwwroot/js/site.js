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

    let metricPanelButtonLeft = document.getElementById("metricPanelLeftBtn");
    let metricPanelButtonRight = document.getElementById("metricPanelRightBtn");
    let metricTabs = document.getElementsByClassName("metrics-tab");
    let metricTabIndicators = document.getElementsByClassName("fa-grip-lines");
    let currentTab = 0;
    for (var i = 0; i < metricTabIndicators.length; i++) {
        metricTabIndicators[i].id = `metricTab${i+1}`
    }

    metricPanelButtonLeft.addEventListener("click", () => {
        if (currentTab - 1 < 0) {
            metricTabIndicators[currentTab].parentElement.classList.toggle("current")
            metricTabs[currentTab].classList.toggle("metrics-tab-disabled");
            currentTab = metricTabs.length - 1;
            metricTabs[currentTab].classList.toggle("metrics-tab-disabled")
            metricTabIndicators[currentTab].parentElement.classList.toggle("current")
        }
        else {
            metricTabIndicators[currentTab].parentElement.classList.toggle("current")
            metricTabs[currentTab--].classList.toggle("metrics-tab-disabled");
            metricTabIndicators[currentTab].parentElement.classList.toggle("current")
            metricTabs[currentTab].classList.toggle("metrics-tab-disabled");

        }
    });
    metricPanelButtonRight.addEventListener("click", () => {
        if (currentTab + 1 > metricTabs.length - 1) {
            metricTabIndicators[currentTab].parentElement.classList.toggle("current")
            metricTabs[currentTab].classList.toggle("metrics-tab-disabled")
            currentTab = metricTabs.length - metricTabs.length;
            metricTabIndicators[currentTab].parentElement.classList.toggle("current")
            metricTabs[currentTab].classList.toggle("metrics-tab-disabled");
        }
        else {
            metricTabIndicators[currentTab].parentElement.classList.toggle("current")
            metricTabs[currentTab++].classList.toggle("metrics-tab-disabled");
            metricTabIndicators[currentTab].parentElement.classList.toggle("current")
            metricTabs[currentTab].classList.toggle("metrics-tab-disabled");

        }
    });
}
