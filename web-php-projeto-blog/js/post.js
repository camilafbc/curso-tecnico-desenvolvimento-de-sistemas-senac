const saida = document.getElementById("saida");
const btnEnviar = document.getElementById("btnEnviar");

const tituloElement = document.getElementById("titulo");
const postElement = document.getElementById("post");

changeDisplayElement(saida, 'none');

btnEnviar.addEventListener('click', (ev) => {

    ev.preventDefault();


    if (tituloElement.value == "" || postElement.value == "") {

        if (tituloElement.value == "") {

            setElementValue("titulo", "Campo obrigatório!");
            tituloElement.classList.add("error");
    
        } 
        
        if (postElement.value == "") {
    
            setElementValue("post", "Campo obrigatório!");
            postElement.classList.add("error");
    
        }

    } else {

        const dados = {
            id: getElementValue('id'),
            titulo: getElementValue('titulo'),
            post: getElementValue('post')
        }

        postRequest(
            "index.php?class=PostForm&method=save",
            dados,
            postRequestReturn(saida)
        )

    }

});

[tituloElement, postElement].forEach((el) => {

    el.addEventListener('focus', function(){

        if (this.classList.contains("error")) {

            this.value = "";
            this.classList.remove("error");
        }
    })

})


function postRequest(url, dados, callback) {
    $.post(url, dados).done(function(saida) {
        callback(saida);
    });
};

function postRequestReturn(elemento) {

    return function(resposta){

        let mensagem;

        mensagem = resposta == 1 ? "Post enviado com sucesso!" : "Erro ao enviar post!";
        
        changeDisplayElement(elemento, 'block');
        setElementValue('post', '');
        setElementValue('titulo', '');
        elemento.innerText = mensagem;

        setTimeout(()=> {
            window.location.href = 'index.php';
        }, 1000 * 3);
    }
    
};

function setElementValue(elementID, value) {
    document.getElementById(elementID).value = value;
};

function getElementValue(elementID) {
    return document.getElementById(elementID).value;
};

function changeDisplayElement(elemento, valor) {
    elemento.style.display = valor;
};