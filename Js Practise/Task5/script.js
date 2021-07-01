
(function(){
    "use strict";
    let inputedStr = prompt("введите строку", "");
    console.log(isEmptyOrStartWithRy(inputedStr));
})();

function isEmptyOrStartWithRy(inpstr){
    if (typeof(inpstr) == 'string') {
        if (inpstr==""|| inpstr.startsWith("Ру")) {
            return inpstr;
        }
        else{
            return "Ру"+inpstr;
        }   
    }
}