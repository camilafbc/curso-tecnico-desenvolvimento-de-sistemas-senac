const minutos_container = document.getElementById("minutos")
const segundos_container = document.getElementById("segundos")
const milisegundos_container = document.getElementById("milisegundos")
const btn_start = document.getElementById("btn_start")
const btn_end = document.getElementById("btn_end")
const btn_stop = document.getElementById("btn_stop")

let milisegundos = 0
let segundos = 0
let minutos = 0
let contador;

function contagem(){
    milisegundos += 1

    if(milisegundos < 10){
        milisegundos_container.innerText = "0" + milisegundos
    } else {
        milisegundos_container.innerText = milisegundos
    }

    if(milisegundos === 100){
        segundos += 1
        milisegundos = 0
    }
    
    if(segundos < 10){
        segundos_container.innerText = "0" + segundos
    } else {
        segundos_container.innerText = segundos
    }

    if(segundos == 60){
        segundos = 0
        minutos += 1
        minutos_container.innerText = `0${minutos}`
    }
}

btn_start.addEventListener('click', () => {
    contador = setInterval(contagem, 10)
})

btn_end.addEventListener('click', () => {
    if(contador){
        clearInterval(contador)
    }
})

btn_stop.addEventListener('click', () => {
    if(contador){
        clearInterval(contador)
    }
    milisegundos = 0;
    segundos = 0;
    minutos = 0;

    milisegundos_container.innerText = "0" + milisegundos
    segundos_container.innerText = "0" + segundos
    minutos_container.innerText = "0" + minutos
})

// setInterval(contagem, 1000)
