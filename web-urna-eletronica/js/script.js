let voto = [];

const buttons = document.querySelectorAll(".nums_btn");
const first_num = document.querySelector(".first_number");
const second_num = document.querySelector(".second_number");
const btn_corrige = document.querySelector(".red");
const tela_candidato = document.getElementById("telaCandidato");
const btn_confirma = document.querySelector(".green");
const tela = document.getElementById("tela");
const btn_branco = document.querySelector(".white");

const tela_geral = document.querySelector(".left_container");

buttons.forEach((button) => {
  button.addEventListener("click", () => {
    voto.push(button.innerText);
    first_num.innerText = voto[0];
    if (voto.length > 1) {
      second_num.innerText = voto[1];
      if (voto.join("") == 11) {
        tela_candidato.style.display = "flex";
      }
    }
  });
});

btn_corrige.addEventListener("click", () => {
  voto = [];
  first_num.innerText = " ";
  second_num.innerText = " ";
  tela_candidato.style.display = "none";
});

btn_confirma.addEventListener("click", () => {
  tela.innerHTML = `
        <h1>FIM</h1>
    `;
  setTimeout(function () {
    location.reload();
    voto = [];
  }, 1000 * 3);
});

btn_branco.addEventListener("click", () => {
  tela_candidato.style.display = "none";
  tela.innerHTML = ` <h1>VOTO EM BRANCO</h1>`;
});