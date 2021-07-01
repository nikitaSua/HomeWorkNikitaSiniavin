
(function(){
    "use strict";
    console.log(checkElemOfArr([1]));
})();

function checkElemOfArr(inparr){
    if (inparr.length>1) {
        if (inparr[0]==1||inparr[length-1]==1) {
            return true;
        }
        else
        return false;
    }else{
        if (inparr[0]==1) {
            return true;
        }
    }

    return false;
}