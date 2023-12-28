const btn = document.getElementById("btn");
const saida_1 = document.getElementById("saida_1");
const saida_2 = document.getElementById("saida_2");
const saida_3 = document.getElementById("saida_3");
const saida_4 = document.getElementById("saida_4");
const saida_5 = document.getElementById("saida_5");
const saida_6 = document.getElementById("saida_6");

function gerarAposta() {
  let aposta = [];

  while (aposta.length < 6) {
    let num = Math.floor(Math.random() * 60);

    if (num != 0 && !aposta.includes(num)) {
      aposta.push(num);
    }
  }

  aposta.sort((a, b) => a - b);

  saida_1.innerText = aposta[0];
  saida_2.innerText = aposta[1];
  saida_3.innerText = aposta[2];
  saida_4.innerText = aposta[3];
  saida_5.innerText = aposta[4];
  saida_6.innerText = aposta[5];
}

btn.addEventListener("click", gerarAposta);
