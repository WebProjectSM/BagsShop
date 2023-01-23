
     items = [];
    products = [];
categories = [];
num = 0;
window.addEventListener("load", GetProduct("https://localhost:44380/api/Product"));
window.addEventListener("load", GetCategory());

    async function GetProduct(url)
    {
         
       
        var res = await fetch(url);
        if (!res.ok)
            console.log('שגיאה בחיבור לנתונים');
        else 
            if (res.status == 204)
                console.log('אין נתונים');
            else {
                console.log("התחבר")
                products = await res.json();
                sendProduct()
            }
        setNumPtoducts();

}
function sendProduct() {
    for (var i = 0; i < products.length; i++) {
        drawProducts(products[i]);
    }
    }

    function drawProducts(product){
       
        var temp = document.getElementById("temp-card");
            var clon = temp.content.cloneNode(true);
            clon.querySelector("img").src = product.image;
            clon.querySelector("h1").innerText = product.productName+product.categoryName;
            clon.querySelector(".price").innerText = product.price;
            clon.querySelector("button").addEventListener("click",() => addProduct(product))
            clon.querySelector(".description").innerText = product.description;
            document.body.appendChild(clon);

            
}

async function GetCategory() {
    
    var res = await fetch('https://localhost:44380/api/Category');
    if (!res.ok)
        console.log('שגיאה בחיבור לנתונים');
    else
        if (res.status == 204)
            console.log('אין נתונים');
        else {
            console.log("התחבר")
            categories = await res.json();
            drawCategory()
        }


}
function drawCategory() {
    for (var i = 0; i < categories.length; i++) {
        var temp = document.getElementById("temp-category");
        var clon = temp.content.cloneNode(true);
        clon.querySelector(".opt").id = categories[i].categoryId;
        clon.querySelector(".opt").value = categories[i].categoryId;
        clon.querySelector(".OptionName").innerText = categories[i].categoryName;
        document.getElementById("categoryList").appendChild(clon);
    }
}

function searchCategories() {
    var count = 0;
    var desc = document.getElementById("nameSearch").value;
    var minPrice = document.getElementById("minPrice").value;
    var maxPrice = document.getElementById("maxPrice").value;
    var categories = document.getElementsByClassName("opt");
    var c;//=`categories=${document.getElementById(categories[0].value.categoryId)}`;
    for (let i = 1; i < categories?.length; i++) {
        if (categories[i].checked)
        {
            count++;
        if(count==1)
           c += `categories=${document.getElementById(categories[i].value)}`;
        //var categorey = document.getElementById(categories[i].categoryId);
        else
           c += `&categories=${document.getElementById(categories[i].value)}`;
        }
    }

   window.addEventListener("load", GetProduct( `https://localhost:44380/api/Product?${c}`));
}
async function filterProducts() {
    var name = document.getElementById("nameSearch").value;
    var minPrice = document.getElementById("minPrice").value;
    var maxPrice = document.getElementById("maxPrice").value;

    var categoryList = document.getElementsByClassName("opt");
    var start = 1;
    var limit = 20;
    var direction = "ASC";
    var orderBy = "price";
    var CategoryIds = "";
    for (let i = 0; i < categoryList.length; i++) {
        if (categoryList[i].checked) {
            CategoryIds += `&categories=${categoryList[i].value}`;
        }
    }
    removeProducts();
    window.addEventListener("load",
        GetProduct(`https://localhost:44380/api/Product?$position=1&skip=1&desc=${name}&minPrice=${minPrice}&maxPrice=${maxPrice}${CategoryIds}`));
    //const res = await fetch(`https://localhost:44380/api/Product/get?name=${name}&price_from=${minPrice}&price_to=${maxPrice}${CategoryIds}&start=${start}&limit=${limit}&direction=${direction}&orderBy=${orderBy}`)
    //const data = await res.json();
   
    //drawProducts(data);
}

function removeProducts()
{
    var prods = document.getElementsByClassName("card");
    for (var i = prods.length - 1; i >= 0; i--)
    { 
        document.body.removeChild(prods[i]);
    }
  
}

function addProduct(prod) {   
    var prev = JSON.parse(sessionStorage.getItem("prod"));
    if (prev!=null) { 
        items = prev;
    }
       items.push(prod);
    sessionStorage.setItem("prod", JSON.stringify(items));
    num = items.length;
    setNumPtoducts()
}

function setNumPtoducts(){
    document.getElementById("ItemsCountText").innerText = num;
}


   


    



    
