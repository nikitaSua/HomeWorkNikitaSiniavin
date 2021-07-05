(function(){

const InputDisplay=document.getElementById("CalcDisplay");
const MathActionRegex = new RegExp('[+]|[-]|[*]|[/]|Sqr');
const DotCheck = new RegExp('[.]{2,}');
const LeftPartMath = new RegExp('^[0-9]*[.][0-9]*|[0-9]*');
const RightPartMath = new RegExp('[0-9]*[.][0-9]*$|[0-9]*$');

let resultCalcButton = document.getElementById("resultCalc");
let DotButton = document.getElementById("addDot");
let ClearButton=document.getElementById("clearButton");

function getAnswer(){
    let inputContent=InputDisplay.value;
    if (DotCheck.test(inputContent)) {
        inputContent=inputContent.replace(DotCheck,".");
    }
    let LeftPartOfExpr = Number(inputContent.match(LeftPartMath)[0]);
    let RightPartOfExpr = Number(inputContent.match(RightPartMath)[0]);
    let signExpr = inputContent.match(MathActionRegex)[0];

    console.log(signExpr);

    switch (signExpr) {
        case "+":
            InputDisplay.value=LeftPartOfExpr+RightPartOfExpr;
            break;
        case "-":
            InputDisplay.value=LeftPartOfExpr-RightPartOfExpr;
            break;
        case "*":
            InputDisplay.value=LeftPartOfExpr*RightPartOfExpr;
            break;
        case "/":
            InputDisplay.value=LeftPartOfExpr/RightPartOfExpr;
            break;
        case "Sqr":
            if (RightPartOfExpr!=0) {
                alert("А зачем вводить 2е значение? :) ps bug has been found ")
            }
            InputDisplay.value=LeftPartOfExpr*LeftPartOfExpr;
            break;
            
        default:
            break;
    }
    console.log(LeftPartOfExpr);
    console.log(RightPartOfExpr);
    console.log(inputContent);
}

function addNumberToDisplay(){
    InputDisplay.value += this.value;
}
function ClearDisplay(){
    InputDisplay.value = "";
}

function addMathActionDisplay(){
    if (InputDisplay.value=="") {
        InputDisplay.value=0;
    }
    if (!MathActionRegex.test(InputDisplay.value)) {
        InputDisplay.value += this.value;
    }
}

function addNumberEvent(){
    let elements = document.getElementsByClassName("number");
    for (var i = 0; i < elements.length; i++) {
        elements[i].addEventListener('click', addNumberToDisplay);
    }
}
function addActionToEventButton(){
    let elements = document.getElementsByClassName("Control");
    for (var i = 0; i < elements.length; i++) {
        elements[i].addEventListener('click', addMathActionDisplay);
    }
    ClearButton.addEventListener("click",ClearDisplay);
}

    console.log('hello world');
    addNumberEvent();
    addActionToEventButton();
    resultCalcButton.addEventListener('click', getAnswer);
})();

class ActionLogger{
    constructor(name) {
        this.input = inputContent.value;
      }
}