const vel_permitida = document.getElementById("permitido");
const vel_condutor = document.getElementById("condutor");
const btn = document.getElementById("btn");
const saida_vel = document.getElementById("saida_vel");
const saida_multa = document.getElementById("saida_multa");

vel_permitida.addEventListener('input', () => {
    vel_permitida.value = vel_permitida.value.replace(/[^0-9\.]/ig, "");
})

vel_condutor.addEventListener('input', () => {
    vel_condutor.value = vel_condutor.value.replace(/[^0-9\.]/gi, "");
})

function verificarVelocidade(permitido, obtido){
    let porcentagemEmRelacao = (obtido/permitido);

    if(isNaN(porcentagemEmRelacao)){
        saida_vel.innerText = "Entrada Inválida!";
    } else {
        if(porcentagemEmRelacao >= 1.07 && porcentagemEmRelacao < 1.20){
            saida_vel.innerText = `Velocidade do Condutor ${((porcentagemEmRelacao - 1)*100).toFixed(2)}% acima da velocidade permitida!`;
            saida_multa.innerText = `Situação: Multa Leve - R$${(0.15 * 1320).toFixed(2)}`;
        } else if (porcentagemEmRelacao >= 1.20 && porcentagemEmRelacao < 1.35){
            saida_vel.innerText = `Velocidade do Condutor ${((porcentagemEmRelacao - 1)*100).toFixed(2)}% acima da velocidade permitida!`;
            saida_multa.innerText = `Situação: Multa Média - R$${(0.2 * 1320).toFixed(2)}`;
        } else if (porcentagemEmRelacao >= 1.35) {
            saida_vel.innerText = `Velocidade do Condutor ${((porcentagemEmRelacao - 1)*100).toFixed(2)}% acima da velocidade permitida!`;
            saida_multa.innerText = `Situação: Multa Grave - R$${(0.35 * 1320).toFixed(2)}`;
        } else {
            saida_vel.innerText = `Velocidade do Condutor dentro da velocidade permitida!`;
            saida_multa.innerText = "";
        }
    }
}

btn.addEventListener('click', () => {
    verificarVelocidade(Number(vel_permitida.value), Number(vel_condutor.value));
})
