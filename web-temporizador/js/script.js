const minutos_container = document.getElementById("minutos");
const segundos_container = document.getElementById("segundos");
const btn_start = document.getElementById("btn_start");
const btn_pause = document.getElementById("btn_pause");
const btn_stop = document.getElementById("btn_stop");

let segundos = 0;
let minutos = 5;
let contador = null;

const formatarSaida = (saida, container) => {
  return saida < 10 ? (container.innerText = `0${saida}`) : (container.innerText = saida);
};

formatarSaida(segundos, segundos_container);
formatarSaida(minutos, minutos_container);

function contagem() {
  if (segundos === 0 && minutos > 0) {
    formatarSaida(segundos, segundos_container);
    minutos -= 1;
    segundos = 60;
    formatarSaida(minutos, minutos_container);
  }

  if (segundos > 0) {
    segundos -= 1;
    formatarSaida(segundos, segundos_container);
  }

  if (segundos <= 0 && minutos <= 0) {
    if (contador) {
      clearInterval(contador);
    }
  }
}

btn_start.addEventListener("click", () => {
  if (!contador) {
    contador = setInterval(contagem, 1000);
  }
});

btn_pause.addEventListener("click", () => {
  if (contador) {
    clearInterval(contador);
    contador = null;
  }
});

btn_stop.addEventListener("click", () => {
  if (contador) {
    clearInterval(contador);
  }
  segundos = 0;
  minutos = 5;
  formatarSaida(segundos, segundos_container);
  formatarSaida(minutos, minutos_container);
  contador = null;
});
