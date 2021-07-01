
(function(){
    "use strict";
    console.log(combine([1,2,3,4,5],"*****"));
})();

function combine(inparr,separator){
    let string ="";

    for (let i = 0; i < inparr.length; i++) {
        if (i==inparr.length-1) {
            return string+inparr[i];
        }
        string=string+inparr[i]+separator;
    }
    
}