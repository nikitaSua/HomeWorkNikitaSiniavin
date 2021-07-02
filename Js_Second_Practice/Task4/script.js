
class Validator {
    constructor() {
        //тут какой-то функционал
    }
    static isValid(string) {
        console.log(string)
    }
}
class EmailValidator extends Validator {
    constructor() {
        super();
        
    }
    static isValid(email) {
        const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(email).toLowerCase());
    }
}
class PhoneValidator extends Validator {
    constructor() {
        //тут какой-то функционал
        super();
    }
    static isValid(phone) {
        const re = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/im;
        return re.test(String(phone).toLowerCase());
    }
}





(function () {
    'use strict';
    alert(EmailValidator.isValid(prompt("enter your email", "")));
})();