
(function(){
    alert("введите чичло от 1 до 20");
    let maxvalue =20;
    let minValue =0;
    let random = getRandomInt(1, 20);
    let boolVal = true;

    do {
        let number = parseInt(prompt(" введите число ", 0));

        if (number<minValue || number>maxvalue || number===null) {
            alert("input Error");
            break;
        }
        if (random == number) {
            alert("правильно")
            boolVal = false;
        }
        if (number < random) {
            alert("меньше рандома");
        }
        if (number > random){
            alert("больше рандома");
        }

    } while (boolVal);
    



})();

function getRandomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max)+1;
    return Math.floor(Math.random() * (max - min)) + min;
}