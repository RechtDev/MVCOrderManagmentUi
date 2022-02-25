window.addEventListener("DOMContentLoaded", onProductLoaded);
function onProductLoaded() {
    let searchBar = document.getElementById("productsearchbar");
    let productTable = document.getElementById("ProductTable");
    let productContents = productTable.getElementsByTagName("tr");

    searchBar.addEventListener("keyup", () => {
        let searchValue = searchBar.value.toUpperCase();
        for (var i = 0; i < productContents.length; i++) {
            let td = productContents[i].querySelectorAll("tr > td")[0];
            let textValue = td.innerText;
            if (textValue.toUpperCase().indexOf(searchValue) > -1) {
                productContents[i].style.display = "";
            }
            else {
                productContents[i].style.display = "none";
            }
        }
    })
}