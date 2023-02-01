
let items = [];
let sum = 0;
let userId=0;
let orderItaems = [];
let orderId = 1;
window.addEventListener("load", makeOrder());


async function makeOrder() {

    setPrice();
    userId = JSON.parse(sessionStorage.getItem('currentUser')).userId;
    getProductsItems();
   
    const order = {
        "OrderDate": new Date(),
        "OrderId": 0,       
         "OrderSum": sum,
         "UserId": userId,
         "OrderItems":orderItaems

    }


        let res = await fetch("https://localhost:44380/api/order", {
        headers: { "content-Type": "application/json" },
        method: 'POST',
        body: JSON.stringify(order),
    })
    
    if (res.ok) {
        const orderRes = await res.json()
        
        alert(`your order have succes, number of order is: ${orderRes.orderId}`);
        console.log(orderRes)
        sessionStorage.removeItem("prod");
        window.location.href = "product.html";
    }
    else (
        alert("תקלה בביצוע ההזמנה"))
}

function setPrice() {
    let prod = sessionStorage.getItem("prod");
    items = JSON.parse(prod);
    items.forEach((e) => {
        sum += e.price;
    })

}
//function getUserId(){
//    let id = sessionStorage.getItem("currentUser");
//     userId =1 //id["userId"];
//}
function getProductsItems() {

    for (let i = 0; i < items.length; i++) {

        let obj = {
            "orderItemId": 0,
            "productId": items[i].productId,
            "orderId": 0,
            "quantity":1
        }
        orderItaems.push(obj);


    }
}
