
var items = [];
var sum = 0;
var userId=0;
var orderItaems = [];
window.addEventListener("load", makeOrder());

async function makeOrder() {
    setPrice();
    //getUserId();
    getProductsItems();
    const order = {
        "orderId": 0,
         "orderDate":new Date(),
         "orderSum": sum,
         "userId": uderId,
         "orderItems":orderItaems

    }

    var res = await fetch("api/order",{
          headers: { "content-Type": "application/json" },
        method: 'POST',
        body: JSON.stringify(order)
    })
    if (res.ok) {
        alert("הזמנתך התקבלה בהצלחה");
        sessionStorage.removeItem("prod");
    }
    else (
        alert("תקלה בביצוע ההזמנה"))
}

function setPrice() {
    var prod = sessionStorage.getItem("prod");
    items = JSON.parse(prod);
    items.forEach((e) => {
        sum += e.price;
    })

}
//function getUserId(){
//    var id = sessionStorage.getItem("currentUser");
//     userId =1 //id["userId"];
//}
function getProductsItems() {

    for (var i = 0; i < items.length; i++) {

        var obj = {
            "orderItemId": 0,
            "productId": items[i].productId,
            "orderId": 0,
            "quantity":1
        }
        orderItaems.push(obj);


    }
}
