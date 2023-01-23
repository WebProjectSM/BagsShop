
    async function logIn(){
        const pass = document.getElementById("password").value;
        const name = document.getElementById("name").value;
        let res = await fetch(`https://localhost:44380/api/user?password=${pass}&name=${name}`);
        
            
        if (!res.ok) { 
            throw Error(`your connect is fail ${res.status} ,try again`);
            
        }
        if (res.status == 204)
            alert("you are not exist, for sigin press new user");
        else {
       

            const user = await res.json();
            if (user) {
                sessionStorage.setItem('currentUser', JSON.stringify(user));
                /*setValues();*/
                window.location.href = "update.html";
            }

            console.log("aa")
          

            
        }
} 
async function singIn() {

    
    const user = {
        "UserId": 0,        
        "Email": document.getElementById("userName").value,        
        "FirstName": document.getElementById("fname").value,
        "LastName": document.getElementById("lname").value,
        "Password": document.getElementById("password").value,
    }


    const res = await fetch("https://localhost:44380/api/user", {

        headers: { "content-Type": "application/json" },
        method: 'POST',
        body: JSON.stringify(user)
    });

    if (!res.ok)
        throw Error(`your connect is fail ${res.status} ,try again`);


    const data = await res.json;
    if(data)
    //sessionStorage.setItem('currentUser', JSON.stringify(data));
   /* setValues()*/;
    window.location.href = "login.html";
}

    function setValues() {
        const tmpUser = sessionStorage.getItem('currentUser');
        const user = JSON.parse(tmpUser);


        console.log(user['userName']);
        const userName = user["email"] ;
        const userCod = user["password"];            
        const userFname = user["firstName"];
        const userLname = user["lastName"];

        let div = document.getElementById("up")
        div.style.visibility = "visible";
        document.getElementById("title").innerHTML = `שלום ${userName}`;
        let a = document.getElementById("un");
        a.setAttribute("value", userName);
        let b = document.getElementById("fn");
        b.setAttribute("value", userFname);
        let c = document.getElementById("ln");
        c.setAttribute("value", userLname);
        
        let e = document.getElementById("pass");
        e.setAttribute("value", userCod);
        
        



     /*   getUserName.setAttribute('value', userName);*/
      

      

            //"Cod": document.getElementById("password").value,
            //    "Mail": document.getElementById("mail").value,
            //        "Phone": document.getElementById("phone").value,

            //            "FirstName" : document.getElementById("fname").value,
            //                "LastName" : document.getElementById("lname").value


    }



async function update() {
    const tmpUser = sessionStorage.getItem('currentUser');
    const id = JSON.parse(tmpUser);
    const realId = id["userId"];


    const user = {
        "UserId": realId,        
        "Email": document.getElementById("email").value,       
        "FirstName": document.getElementById("fn").value,
        "LastName": document.getElementById("ln").value,
        "Password": document.getElementById("pass").value
    }


    //const res = await fetch(`https://localhost:44380/Api/user/${realId}`, {

    //    headers: { "content-Type": "application/json" },
    //    method: 'PUT',
    //    body: JSON.stringify(user)
    //});

    //if (res.ok) {
    //    alert("your details were update")
    //    
    //}
    window.location.href="order.html";
  
}
async function  check (){
 password = document.getElementById("password").value;
    const res = await fetch("https://localhost:44387/api/checkPassword", {
        headers: { "Content-Type": "application/json; charset=utf-8" },
        method: 'POST',
        body: JSON.stringify(password)
    })
    if (res > 0)
        alert(res);

}
