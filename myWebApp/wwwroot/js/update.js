window.addEventListener("load", setHelloUser());

function setHelloUser() {
    const tmpUser = sessionStorage.getItem('currentUser');
    const user = JSON.parse(tmpUser);
    const userName = user["firstName"];
    const hello = document.getElementById("title")
    hello.innerText= `hello to: ${userName}`;
    document.getElementById("updaeDetails").appendChild(hello)
}
function userValidate() {
    let valid = true;
    const validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    const letters = /^[A-Za-z]+$/;
    if (!document.getElementById("userName").value.match(validRegex)) {
        document.getElementById("emailValid").innerHTML = "email is not valid";
        valid = false;
    }
    if (document.getElementById("pass").value == "") {
        document.getElementById("passValid").innerHTML = "password is required";
        valid = false;
    }
    if (document.getElementById("lname").value.length < 2 || lname.value.length > 20 || !(document.getElementById("lname").value.match(letters))) {
        document.getElementById("lnameValid").innerHTML = "name shuld be only letters and at least 2 letters";
        valid = false;
    }
    if (document.getElementById("fname").value.length < 2 || fname.value.length > 20 || !(document.getElementById("fname").value.match(letters))) {
        document.getElementById("fnameValid").innerHTML = "name shuld be only letters and at least 2 letters"
        valid = false;
    }
    return valid;
}
function setValues() {
    const tmpUser = sessionStorage.getItem('currentUser');
    const user = JSON.parse(tmpUser);
    const userName = user["email"];
    const userCod = user["password"];
    const userFname = user["firstName"];
    const userLname = user["lastName"];

    let fieldsToUp = document.getElementById("up")
    fieldsToUp.style.visibility = "visible";

    let a = document.getElementById("userName");
    a.setAttribute("value", userName);
    let b = document.getElementById("fname");
    b.setAttribute("value", userFname);
    let c = document.getElementById("lname");
    c.setAttribute("value", userLname);
    let e = document.getElementById("pass");
    e.setAttribute("value", userCod);


}



async function update() {
    document.getElementById("emailValid").innerHTML = "";
    document.getElementById("passValid").innerHTML = "";
    document.getElementById("lnameValid").innerHTML = "";
    document.getElementById("fnameValid").innerHTML = ""
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
function continueOrder() {
    window.location.href = "order.html";
}