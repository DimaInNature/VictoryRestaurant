var currentTab = 0;
document.addEventListener("DOMContentLoaded", function (event) {


    showTab(currentTab);

});

function showTab(n) {
    var x = document.getElementsByClassName("tab");
    x[n].style.display = "block";
    if (n == 0) {
        document.getElementById("prevBtn").style.display = "none";
    } else {
        document.getElementById("prevBtn").style.display = "inline";
    }
    if (n == (x.length - 1)) {
        document.getElementById("nextBtn").innerHTML = '<i class="fa fa-angle-double-right"></i>';
    } else {
        document.getElementById("nextBtn").innerHTML = '<i class="fa fa-angle-double-right"></i>';
    }
    fixStepIndicator(n)
}

function nextPrev(n) {
    var x = document.getElementsByClassName("tab");
    if (n == 1 && !validateForm()) return false;
    x[currentTab].style.display = "none";
    currentTab = currentTab + n;
    if (currentTab >= x.length) {

        document.getElementById("nextprevious").style.display = "none";
        document.getElementById("all-steps").style.display = "none";
        document.getElementById("register").style.display = "none";
        document.getElementById("text-message").style.display = "block";




    }
    showTab(currentTab);
}

function validateForm() {

    var x, y, i, valid = true;

    x = document.getElementsByClassName("tab");

    y = x[currentTab].getElementsByTagName("input");

    for (i = 0; i < y.length; i++) {

        if (y[i].id == "bookingFormPersonCount") {

            if (y[i].value <= 0 | y[i].value >= 200) {
                y[i].className += " invalid";
                valid = false;
            }

        }

        if (y[i].id == "bookingFormDate") {

            if (new Date(y[i].value) <= new Date()) {
                y[i].className += " invalid";
                valid = false;
            }

        }

        if (y[i].id == "bookingFormPhone") {

            let regex = /^(\+7|7|8)?[\s\-]?\(?[489][0-9]{2}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$/;

            if (regex.test(y[i].value) == false) {
                y[i].className += " invalid";
                valid = false;
            }
        }

        if (y[i].id == "bookingFormName") {

            let regex = /^(|[a-zA-Zа-яА-Я][a-zA-Zа-яА-Я\s]*)$/;

            if (regex.test(y[i].value) == false) {
                y[i].className += " invalid";
                valid = false;
            }
        }

        if (y[i].value == "") {

            y[i].className += " invalid";
            valid = false;

        }

    }
    if (valid) {

        document.getElementsByClassName("step")[currentTab].className += " finish";

    }

    return valid;
}

function fixStepIndicator(n) {
    var i, x = document.getElementsByClassName("step");
    for (i = 0; i < x.length; i++) {
        x[i].className = x[i].className.replace(" active", "");
    }
    x[n].className += " active";
}