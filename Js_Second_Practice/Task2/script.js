
class Shape {
    side = 223;
    square() { }
}
var shape = new Shape();
const getMethods = (obj) => {
    let properties = new Set();
    let currentObj = obj;
    do {
        Object.getOwnPropertyNames(currentObj).map((item) => properties.add(item));
    } while ((currentObj = Object.getPrototypeOf(currentObj)));
    return [...properties.keys()];
};
alert(getMethods(shape));