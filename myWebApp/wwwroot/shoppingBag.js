
var userId;
products = [];
categories = [];
tmpProduct = [];
window.addEventListener("load", GetProduct());


async function GetProduct() {

    var product = sessionStorage.getItem('prod');
    products = JSON.parse(product);
    console.log(products);
    //var res = await fetch(url);
    //if (!res.ok)
    //    console.log('שגיאה בחיבור לנתונים');
    //else
    //    if (res.status == 204)
    //        console.log('אין נתונים');
    //    else {
    //        console.log("התחבר")
    //        products = await res.json();
            send()
        //}


}
function send() {
    for (var i = 0; i < products.length; i++) {
        drawProducts(products[i]);
    }
}
function drawProducts(product) {
   
        var temp = document.getElementById("temp-row");
        var clon = temp.content.cloneNode(true);
    clon.querySelector("img").src = product.image;
        //clon.querySelector("h1").innerText = products[i].productName;
    clon.querySelector(".price").innerText = product.price;
      
    clon.querySelector(".totalColumn").addEventListener("click", () => removeProduct(product))
    clon.querySelector(".descriptionColumn").innerText = product.description;
    clon.querySelector(".availabilityColumn").innerText = "במלאי";
        document.body.appendChild(clon);


    }






function removeProduct(prod) {
    sessionStorage.removeItem("prod");
    var ind = products.findIndex((e, i) => e.productId == prod.productId);
    //products.removeItem(i)
    products.splice(ind,1);
    sessionStorage.setItem("prod", JSON.stringify(products) );
    var prods = document.getElementsByClassName("item-row");
    for (var i = prods.length - 1; i >= 0; i--) {
        document.body.removeChild(prods[i]);

    }
    GetProduct();
}

function saveBaskate()
{
    tmpProduct = products;
    window.location.href = "product.html?fromShoppingBag=1";
}


function placeOrder() {
    var user = sessionStorage.getItem("currentUser");
    if (!user)
       window.location.href = "Login.html";
    
    else {   
        userId = user['userId']
    window.location.href = "order.html";
}
    
}