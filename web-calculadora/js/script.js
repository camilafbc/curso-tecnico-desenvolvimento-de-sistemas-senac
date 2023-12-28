const display = document.getElementById("display");
const nums = document.querySelectorAll(".num");
const operadores = document.querySelectorAll(".operador");
const to_negative = document.getElementById("to-negative");
const quadrado = document.getElementById("quadrado");
const resultado = document.getElementById("result");
const clear = document.getElementById("clear");
const clear_all = document.getElementById("clear_all");

let value_1 = "";
let operador = "";
let value_2 = "";

nums.forEach((num) => {
  num.addEventListener("click", () => {
    // Se já houver operador, value_2 assume o valor, cas contrário, value_1 recebe o valor
    if (operador != "") {
      if (num.value === "." && value_2.includes(".")) return; 
      value_2 += num.value;
      display.value = value_2;
    } else {
      if (num.value === "." && value_1.includes(".")) return;
      value_1 += num.value;
      display.value = value_1;
    }
  });
});

operadores.forEach((op) => {
  op.addEventListener("click", () => {
    if (value_1 !== "") {
      // Operador só é atribuído se houver um primeiro valor

      if (value_2 !== "") {
        // Se já houver um operador e um segundo valor, calcula o resultado antes de definir o novo operador
        calcularResultado();
      }

      operador = op.value;
      display.value = operador;
    }
  });
});

to_negative.addEventListener("click", () => {
  //  Troca o sinal
  //  Verifica a existência de um operador para lidar com 1º ou 2º valor
  if (operador != "") {
    value_2.includes("-") ? value_2 = value_2.slice(1) : value_2 = "-" + value_2;
    display.value = value_2;
  } else {
    value_1.includes("-") ? value_1 = value_1.slice(1) : value_1 = "-" + value_1;
    display.value = value_1;
  }
});

quadrado.addEventListener("click", () => {
  if (operador != "") {
    value_2 = parseFloat(value_2) * parseFloat(value_2);
    display.value = value_2;
  } else {
    value_1 = parseFloat(value_1) * parseFloat(value_1);
    display.value = value_1;
  }
});

clear.addEventListener("click", () => {
  if (operador == "") {
    value_1 = value_1.slice(0, -1);
    display.value = value_1;
  } else {
    value_2 = value_2.slice(0, -1);
    display.value = value_2;
  }
});

clear_all.addEventListener("click", () => {
  display.value = "";
  value_1 = "";
  value_2 = "";
  operador = "";
});

resultado.addEventListener("click", () => {
  // Se os valores não estiverem em branco, exibe o resultado  
  if (value_1 != "" && value_2 != ""){
    calcularResultado();
  }
});

function calcularResultado(){
  let resultado = 0;

  if (value_1 === "" || value_2 === "") return;

  switch (operador) {
    case "+":
      resultado = parseFloat(value_1) + parseFloat(value_2);
      nextOp(resultado);
      break;
    case "-":
      resultado = parseFloat(value_1) - parseFloat(value_2);
      nextOp(resultado);
      break;
    case "x":
      resultado = parseFloat(value_1) * parseFloat(value_2);
      nextOp(resultado);
      break;
    case "/":
      resultado = parseFloat(value_1) / parseFloat(value_2);
      nextOp(resultado);
      break;
  }
}

const nextOp = (result) => {
  // Salva o resultado da operação no 1º valor e limpa o segundo para garantir as operações contínuas
  display.value = result;
  operador = "";
  value_1 = String(result);
  value_2 = "";
};