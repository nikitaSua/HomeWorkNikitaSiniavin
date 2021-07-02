
class Shape {
    constructor(width, height) {
        if (typeof (width) == "number" && typeof (height) == "number") {
            this.width = width;
            this.height = height;
        } else {
            console.log("error not a number");
        }
    }
    getSquare() {
        return this.height * this.width;
    }
    calculateSquare(width, height) {
        if (typeof (width) == "number" && typeof (height) == "number") {
            return height * width;
        } else {
            console.log("error not a number");
            return;
        }
    }
}

function getAllMethods(object) {
    return Object.getOwnPropertyNames(object).filter(function (property) {
        return typeof object[property] == 'function';
    });
}



(function () {
    'use strict';
    let cl = new Shape(5, 5);

    console.log();
    let propertyes = Object.getOwnPropertyNames(cl)
    for (var i = 0; i < propertyes.length; i++) {
        console.log(propertyes[i]);
    }
    console.log(Object.getOwnPropertyNames(cl).filter(item => typeof cl[item] === 'function'));

})();