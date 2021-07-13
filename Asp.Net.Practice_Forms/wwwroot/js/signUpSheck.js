let inputs = document.getElementsByClassName("Input_text_constr");
let input_email = document.getElementsByClassName("email_inp");
let input_pass = document.getElementsByClassName("pass_inp");
let button = document.getElementById("sendButton");
let form = document.getElementById('myForm');

function seyHello() {
    console.log("?adsasdsa");
}


function CheckLength(buttons) {
    for (var i = 0; i < buttons.length; i++) {
        if (buttons[i].value.length > 50 || buttons[i].value.length <= 0) {
            alert("to short or to long name");
            return false;
        }
    }
    return true;
}
function CheckRegEmailAndEquals(inputs) {
    let reg = /^[^\s@]+@[^\s@]+$/;
    for (var i = 0; i < inputs.length; i++) {
        if (!reg.test(inputs[i].value)) {
            alert("not correct format of Email");
            return false;
        }
        if (inputs.length = 0 || inputs[0].value != inputs[i].value || inputs[i].value == "") {
            alert("emails doesn`t matches");
            return false;
        }
    }
    return true;
}

function CheckPassEquals(inputs) {
    for (var i = 0; i < inputs.length; i++) {
        if (inputs[0].value != inputs[i].value || inputs[i].value=="") {
            alert("Password doesn`t matches");
            return false;
        }
    }
    return true;
}

function Validate() {
    if (CheckLength(inputs) && CheckRegEmailAndEquals(input_email) && CheckPassEquals(input_pass)) {
        form.submit();
    }
    else false;
}


function stopDefAction(evt) {
    evt.preventDefault();}

(function () {

    button.addEventListener("click", stopDefAction);
    button.addEventListener("click", seyHello);
    button.addEventListener("click", Validate);
    for (let i = 0; i < inputs.length; i++) {

        console.log(inputs[i].classList);
    }
})();