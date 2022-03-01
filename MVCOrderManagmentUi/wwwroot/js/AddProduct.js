window.addEventListener("load", onLoaded);


function onLoaded() {
    let priceInput = document.getElementById("priceProdInput");

    priceInput.addEventListener("blur", () => {
        let value = priceInput.value;

        if (value.length >= 3) {
            console.log("testing");
            
            priceInput.value = separator(value);
        }
    });
}

function separator(numb) {var str = numb.toString().split(".");
    str[0] = str[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");return str.join(".");}