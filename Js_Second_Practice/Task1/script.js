
class Shape {
    constructor() {
        
    }
    getSquare() {
    }
    static calculateSquare(width, height) {
        
    }
}

class Circul extends Shape {
    constructor(radius) {
        super();
        this.radius = radius;
    }
    getSquare() {
        return (this.radius * this.radius)*3.14;
    }
    static calculateSquare(radius) {
        if (typeof (radius) == "number") {
            return (radius * radius) * 3.14;
        } else {
            console.log("error not a number");
            return;
        }
    }
}
class Square extends Shape {
    constructor(SideSize) {
        super();
        this.SideSize=SideSize;
    }
    getSquare() {
        return this.SideSize * this.SideSize;
    }
    static calculateSquare(SideSize) {
        if (typeof (SideSize) == "number") {
            return SideSize * SideSize;
        } else {
            console.log("error not a number");
            return;
        }
    }
}
(function () {
    'use strict';

    let circul = new Circul(5);
    console.log(circul.getSquare());
    console.log(Circul.calculateSquare(6));
})();
