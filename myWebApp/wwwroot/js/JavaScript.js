
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

function userValidate() {
    var validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    var letters = /^[A-Za-z]+$/;
    if (!document.getElementById("userName").value.match(validRegex)) {
        document.getElementById("emailValid").innerHTML = "email is not valid";
        return false;
            }
    if (document.getElementById("pass").value == "") {
        document.getElementById("passValid").innerHTML = "password is required";
        return false;
    }
    if (document.getElementById("lname").value.length < 2 || lname.value.length > 20) {
        document.getElementById("lnameValid").innerHTML = "name shuld be only letters and at least 4 letters";
        return false;
    }
    if (document.getElementById("fname") .value.length < 2 || fname.value.length > 20) {
        document.getElementById("fnameValid").innerHTML = "name shuld be only letters and at least 4 letters"
        return false;
    }
    return true;
}

async function singIn() {
    if (!userValidate())
   
    {

        const user = {
            "UserId": 0,
            "Email": document.getElementById("userName").value,
            "FirstName": document.getElementById("fname").value,
            "LastName": document.getElementById("lname").value,
            "Password": document.getElementById("pass").value,
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
    window.location.href = "loginAndSign.html";
}
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
        //document.getElementById("title").innerHTML = `שלום ${userName}`;
        let a = document.getElementById("userName");
        a.setAttribute("value", userName);
        let b = document.getElementById("fname");
        b.setAttribute("value", userFname);
        let c = document.getElementById("lname");
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
    if (userValidate()) {

    const tmpUser = sessionStorage.getItem('currentUser');
    const id = JSON.parse(tmpUser);
    const realId = id["userId"];


    const user = {
        "UserId": realId,
        "Email": document.getElementById("userName").value,
        "FirstName": document.getElementById("fname").value,
        "LastName": document.getElementById("lname").value,
        "Password": document.getElementById("pass").value
    }


    const res = await fetch(`https://localhost:44380/api/user/${realId}`, {

        headers: { "content-Type": "application/json" },
        method: 'PUT',
        body: JSON.stringify(user)
    });

    if (!res.ok) {
        alert("error")
        console.log(`your connect is fail ${res.status}`)

    }
    else {
        alert("your details were updated")
        window.location.href = "order.html";
    }

 }
    }

async function check() {
    password = document.getElementById("pass").value;
    var res = await fetch("https://localhost:44380/api/checkPassword", {
        headers: { "Content-Type": "application/json; charset=utf-8" },
        method: 'POST',
        body: JSON.stringify(password)
    })
    if (!res.ok) 
        console.log(`your connect is fail ${res.status}`)

        var data = await res.json();
    if (data !=null) {
        document.getElementById("strongPassword").innerHTML=`the strong level of your password is:${data}`
    }
      

    }
   

function continueOrder() {
       window.location.href = "order.html";
    }