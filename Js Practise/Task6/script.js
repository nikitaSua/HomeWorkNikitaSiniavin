
(function(){
    "use strict";
    let inputedStr = prompt("введите строку", "");
    console.log(isEmptyOrStartWithRy(inputedStr));
})();

function isEmptyOrStartWithRy(inpstr){
    let count =0;
    for (let index = 0; index < inpstr.length; index++) {
        let char = inpstr[index].toLowerCase();
        if (char=="a"||char=="e"||char=="u"
        ||char=="y"||char=="q"||char=="i"||char=="o" ) {
            count +=1;
        }
    }
    return count;
}