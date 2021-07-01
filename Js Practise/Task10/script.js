
(function(){
    "use strict";
    maxOFtwoNearest([1,2,3,4,5]);
})();

function maxOFtwoNearest(inparr){
    let maxSum=0;
    let current=0;
    for (let i = 0; i < inparr.length; i++) {
        if (i!=inparr.length-1) {
            current=(inparr[i]*inparr[i+1]);
            if (maxSum<=current) {
                maxSum=current;
            }
        }
    }
    console.log(maxSum);
}