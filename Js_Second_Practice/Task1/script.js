
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
    static calculateSquare(width, height) {
        if (typeof (width) == "number" && typeof (height) == "number") {
            return height * width;
        } else {
            console.log("error not a number");
            return;
        }
    }
}

class Circul extends Shape {
    constructor(radius) {
        super(radius, radius);
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
        super(SideSize, SideSize); // вызывает конструктор super класса и передаёт параметр name
    }
    getSquare() {
        return this.height * this.height;
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
    let cl = new Shape(5, 5);
    console.log(cl.width);
    console.log(cl.getSquare());

    let circul = new Circul(5);
    console.log(circul.getSquare());
    console.log(Shape.calculateSquare(10, 10));
    console.log(Circul.calculateSquare(6));
})();