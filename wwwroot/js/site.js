// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#loginForm").on("submit", function (event) {
    login();
    event.preventDefault();
});

function textToBase64(text) {
    return btoa(unescape(encodeURIComponent(text)));
}

function login() {
    let data = JSON.stringify({
        "Email": $("#email").val(),
        "Password": textToBase64(textToBase64($("#password").val())),
    });
    $.ajax({
        type: "POST",
        url: _URL_ROOT + "User/Login",
        data: data,
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.status === 200) {
                debugger;
                localStorage.setItem("user", $("#email").val());

                window.location.href = _URL_ROOT + "Home";
            }
            else {
                alert("Ño");
            }
        },
        error: function (response) {
            console.log(response);
        }
    });
}