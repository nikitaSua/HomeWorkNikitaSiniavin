
(function(){
    "use strict";
    console.log(checkElemOfArr([1,2,3,4,5],7));
})();

function checkElemOfArr(inparr,Nelem){
    if (inparr.length<Nelem) {
        Nelem=inparr.length;
    }
    for (let i = 0; i < Nelem; i++) {
        
        console.log(inparr[i]);
    }
    return false;
}