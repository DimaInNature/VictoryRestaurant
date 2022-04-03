window.addEventListener("load", () => {

    document.getElementById("logInSubmit").addEventListener("click", e => {
        e.preventDefault();

        document.getElementById("logInShowPopupButton").style.display = "None";
        document.getElementById("logOutButton").style.display = "Block";

        popupClose(document.getElementById("popup"));
    });

    document.getElementById("logOutButton").addEventListener("click", e => {

        e.preventDefault();
        document.getElementById("logInShowPopupButton").style.display = "Block";
        document.getElementById("logOutButton").style.display = "None";
    });

});
