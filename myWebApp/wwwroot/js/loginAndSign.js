
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
                window.location.href = "update.html";
                document.getElementById("title").innerHTML = `hello to: ${user.firstName}`;
            }
           
        }
} 

function userValidate() {
    let valid = true;
    const validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    const letters = /^[A-Za-z]+$/;
    if (!document.getElementById("userName").value.match(validRegex) ) {
        document.getElementById("emailValid").innerHTML = "email is not valid";
        valid= false;
            }
    if (document.getElementById("pass").value == "") {
        document.getElementById("passValid").innerHTML = "password is required";
        valid= false;
    }
    if (document.getElementById("lname").value.length < 2 || lname.value.length > 20 || !(document.getElementById("lname").value.match(letters))) {
        document.getElementById("lnameValid").innerHTML = "name shuld be only letters and at least 2 letters";
        valid= false;
    }
    if (document.getElementById("fname").value.length < 2 || fname.value.length > 20 || !(document.getElementById("fname").value.match(letters))) {
        document.getElementById("fnameValid").innerHTML = "name shuld be only letters and at least 2 letters"
        valid= false;
    }
    return valid;
}

async function singIn() {
    document.getElementById("emailValid").innerHTML = "";
    document.getElementById("passValid").innerHTML = "";
    document.getElementById("lnameValid").innerHTML = "";
    document.getElementById("fnameValid").innerHTML = ""
    if (userValidate())
   
    {

        const user = {
            "UserId": 0,
            "Email": document.getElementById("userName").value,
            "FirstName": document.getElementById("fname").value,
            "LastName": document.getElementById("lname").value,
            "Password": document.getElementById("pass").value,
        }


        let res = await fetch("https://localhost:44380/api/user", {

            headers: { "content-Type": "application/json" },
            method: 'POST',
            body: JSON.stringify(user)
        });
    

    if (!res.ok)
        throw Error(`your connect is fail ${res.status} ,try again`);


    const data = await res.json;
    if(data)
    window.location.href = "loginAndSign.html";
}
}
    




async function check() {
    password = document.getElementById("pass").value;
    let res = await fetch("https://localhost:44380/api/checkPassword", {
        headers: { "Content-Type": "application/json; charset=utf-8" },
        method: 'POST',
        body: JSON.stringify(password)
    })
    if (!res.ok) 
        console.log(`your connect is fail ${res.status}`)

        let data = await res.json();
    if (data !=null) {
        document.getElementById("strongPassword").innerHTML=`the strong level of your password is:${data}`
    }
      

    }
   

