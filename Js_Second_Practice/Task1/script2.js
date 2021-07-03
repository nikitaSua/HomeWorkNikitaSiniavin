function Shape() {
    this.square = function () { };
}
function Square(side) {
    this.side = side;
    __proto__: Shape;
    this.square = function () {
        return side * side;
    };
}
function Circle(radius) {
    this.radius = radius;
    __proto__: Shape;
    this.square = function () {
        return 3.14 * radius * radius;
    };
}
