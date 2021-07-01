
(function(){
    "use strict";
    alert(poligonSquare(prompt("введите значение", 0)));
})();

function poligonSquare(n){
    if (n>=10**4 || n<1){
        return;
    }else{
        return (n**2+(n-1)**2);
    }
}