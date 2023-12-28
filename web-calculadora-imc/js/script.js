const peso = document.getElementById("peso");
const altura = document.getElementById("altura");
const button = document.getElementById("btn");
const saida_container = document.getElementById("saida_container");

peso.addEventListener("input", () => {
  peso.value = peso.value.replace(/[^0-9\.\,]/gi, "").replace(/\,/, ".");
});

altura.addEventListener("input", () => {
  altura.value = altura.value.replace(/[^0-9\.\,]/gi, "").replace(/\,/, ".");
});

function calcularIMC(peso, altura) {
  let imc = peso / (altura * altura);

  if(!isNaN(imc)){
    printer(imc.toFixed(2));
  } else {
    saida_container.innerHTML = '<p>Entrada Inválida!</p>';
  }
}

function printer(imc) {
  if (imc < 18.5) {
    saida_container.innerHTML = `
            <p>Seu IMC é: <span id="saida">${imc}</span></p>
            <p>Indica que está abaixo do peso!</p>
            `;
  } else if (imc >= 18.5 && imc <= 24.9) {
    saida_container.innerHTML = `
            <p>Seu IMC é: <span id="saida">${imc}</span></p>
            <p>Indica que está com peso normal!</p>
            `;
  } else if (imc >= 25 && imc <= 29.9) {
    saida_container.innerHTML = `
            <p>Seu IMC é: <span id="saida">${imc}</span></p>
            <p>Indica situação de sobrepeso!</p>
            `;
  } else {
    saida_container.innerHTML = `
            <p>Seu IMC é: <span id="saida">${imc}</span></p>
            <p>Indica grau de obesidade!</p>
            `;
  }
}

button.addEventListener("click", (ev) => {
  ev.preventDefault();
  calcularIMC(Number(peso.value), Number(altura.value));
});
