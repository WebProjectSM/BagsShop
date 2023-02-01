
let userId;
products = [];
categories = [];
tmpProduct = [];
window.addEventListener("load", GetProduct());


async function GetProduct() {
   
    let product = sessionStorage.getItem('prod');
    products = JSON.parse(product);
    price(products);
    console.log(products);
    //let res = await fetch(url);
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
    for (let i = 0; i < products.length; i++) {
        drawProducts(products[i]);
    }
}
function drawProducts(product) {
   
        let temp = document.getElementById("temp-row");
        let clon = temp.content.cloneNode(true);
    clon.querySelector("img").src ="../images/"+ product.image;
        //clon.querySelector("h1").innerText = products[i].productName;
    clon.querySelector(".price").innerText = product.price;
      
    clon.querySelector(".totalColumn").addEventListener("click", () => removeProduct(product))
    clon.querySelector(".descriptionColumn").innerText = product.description;
    clon.querySelector(".availabilityColumn").innerText = "במלאי";
        document.body.appendChild(clon);


    }






function removeProduct(prod) {
    sessionStorage.removeItem("prod");
    let ind = products.findIndex((e, i) => e.productId == prod.productId);
    //products.removeItem(i)
    products.splice(ind,1);
    sessionStorage.setItem("prod", JSON.stringify(products) );
    let prods = document.getElementsByClassName("item-row");
    for (let i = prods.length - 1; i >= 0; i--) {
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
    let user = sessionStorage.getItem("currentUser");
    if (!user)
       window.location.href = "loginAndSign.html";
    
    else {   
        userId = user['userId']
    window.location.href = "order.html";
}
    
}

function price(product) {
   let price=0
    for (let i = 0; i < product.length; i++)
    {
        price += product[i].price;
    }
    document.getElementById("totalAmount").innerText = price;
}

