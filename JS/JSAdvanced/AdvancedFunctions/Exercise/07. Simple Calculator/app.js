function calculator() {
    let firstNumber;
    let secondNumber;
    let result;

    function init(selector1, selector2, selector3) {
        firstNumber = document.querySelector(selector1);
        secondNumber = document.querySelector(selector2);
        result = document.querySelector(selector3);
    }

    function add() {
        result.value = Number(firstNumber.value) + Number(secondNumber.value);
    }

    function subtract() {
        result.value = Number(firstNumber.value) - Number(secondNumber.value);
    }

    return {
        init,
        add,
        subtract
    }
}

const calculate = calculator();
calculate.init('#num1', '#num2', '#result');




