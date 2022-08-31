function myFunction() {
    var x = document.querySelectorAll(".passwordInput");
    x.forEach(i => {
        if (i.type === "password") {
            i.type = "text";
        } else {
            i.type = "password";
        }
    });
    
}

function checkPasswords(event) {
    if (document.querySelector(".password").value !== document.querySelector(".confirmPassword").value) {
        alert("password and confirm password do not match");
        event.preventDefault();
    } else {
        event.submit();
    }
}
    