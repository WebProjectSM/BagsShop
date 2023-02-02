
let items = [];
let products = [];
let categories = [];
let num = 0;
window.addEventListener("load", GetProduct("https://localhost:44380/api/Product"));
window.addEventListener("load", GetCategory());

    async function GetProduct(url)
    {
         
       
        let res = await fetch(url);
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
    for (let i = 0; i < products.length; i++) {
        drawProducts(products[i]);
    }
    }

    function drawProducts(product){
       
        let temp = document.getElementById("temp-card");
        let clon = temp.content.cloneNode(true);
        clon.querySelector("img").src = "../images/"+product.image;
        clon.querySelector("h1").innerText = product.productName
        clon.querySelector("h3").innerText=product.categoryName;
        clon.querySelector(".price").innerText = product.price;
        clon.querySelector("button").addEventListener("click",() => addProduct(product))
        clon.querySelector(".description").innerText = product.description;
        document.body.appendChild(clon);

            
}

async function GetCategory() {
    
    let res = await fetch('https://localhost:44380/api/Category');
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
    for (let i = 0; i < categories.length; i++) {
        let temp = document.getElementById("temp-category");
        let clon = temp.content.cloneNode(true);
        clon.querySelector(".opt").id = categories[i].categoryId;
        clon.querySelector(".opt").value = categories[i].categoryId;
        clon.querySelector(".OptionName").innerText = categories[i].categoryName;
        document.getElementById("categoryList").appendChild(clon);
    }
}

function searchCategories() {
    let count = 0;
    let categories = document.getElementsByClassName("opt");
    let category;
    for (let i = 1; i < categories?.length; i++) {
        if (categories[i].checked)
        {
            count++;
        if(count==1)
            category += `categories=${document.getElementById(categories[i].value)}`;
       
        else
            category += `&categories=${document.getElementById(categories[i].value)}`;
        }
    }

    window.addEventListener("load", GetProduct(`https://localhost:44380/api/Product?${category}`));
}
async function filterProducts() {
    let name = document.getElementById("nameSearch").value;
    let minPrice = document.getElementById("minPrice").value;
    let maxPrice = document.getElementById("maxPrice").value;

    let categoryList = document.getElementsByClassName("opt");
    let CategoryIds = "";
    for (let i = 0; i < categoryList.length; i++) {
        if (categoryList[i].checked) {
            CategoryIds += `&categories=${categoryList[i].value}`;
        }
    }
    removeProducts();
    window.addEventListener("load",
        GetProduct(`https://localhost:44380/api/Product?$position=1&skip=1&desc=${name}&minPrice=${minPrice}&maxPrice=${maxPrice}${CategoryIds}`));
  
}

function removeProducts()
{
    let prods = document.getElementsByClassName("card");
    for (let i = prods.length - 1; i >= 0; i--)
    { 
        document.body.removeChild(prods[i]);
    }
  
}

function addProduct(prod) {   
    let prev = JSON.parse(sessionStorage.getItem("prod"));
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


   


    



    
