const valorBruto = document.getElementById("total");
const desconto = document.getElementById("desconto");
const btn = document.getElementById("btn");

valorBruto.addEventListener("change", () => {
  valorBruto.value = valorBruto.value.replace(/[^0-9,]/gi, "").replace(/\,/, ".");
});

desconto.addEventListener("change", () => {
  desconto.value = desconto.value.replace(/[^0-9,]/gi, "").replace(/\,/, ".");
});

function calcular(total, desconto) {
  const valorDescontado = total * (desconto / 100);
  const novoValor = total - valorDescontado;

  printer(total, desconto, valorDescontado, novoValor);
}

function printer(total, desconto, valorDescontado, novoValor) {
  const saida_valorBruto = document.getElementById("bruto");
  const saida_descAplicado = document.getElementById("desc_apl");
  const saida_valorDescontado = document.getElementById("valor_desc");
  const saida_novoValor = document.getElementById("valor_final");

  saida_valorBruto.innerText = `R$${total}`;
  saida_descAplicado.innerText = `${desconto}%`;
  saida_valorDescontado.innerText = `R$${valorDescontado.toFixed(2)}`;
  saida_novoValor.innerText = `R$${novoValor.toFixed(2)}`;
}

btn.addEventListener("click", () => {
  calcular(Number(valorBruto.value), Number(desconto.value));
});
