
(function(){
    "use strict";
    deleteTheSame([1,1,2,2,3,4,5]);
})();

function deleteTheSame(inparr){
    let set=new Set(inparr);
    let arr=Array.from(set);
    console.log(arr);
}