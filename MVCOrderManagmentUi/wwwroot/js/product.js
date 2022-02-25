
window.addEventListener("DOMContentLoaded", ondomLoaded);
function ondomLoaded() {
    let searchBar = document.getElementById("productsearchbar");
    let searchValue = searchBar.value.toUpperCase();
    let productTable = document.getElementById("ProductTable");
    let productContent = ProductTable.getElementsByTagName("tr");

    searchBar.addEventListener("keyup", () => {
        let searchValue = searchBar.value.toUpperCase();
        for (var i = 0; i < productContent.length; i++) {
           let td = productContent[i].querySelectorAll("tr > td")[0];
            textValue = td.textContent || td.innerText;
            if (textValue.toUpperCase().indexOf(searchValue) > -1) {
                productContent[i].style.display = "";
            }
            else {
                productContent[i].style.display = "none";
            }
        }
    })
}