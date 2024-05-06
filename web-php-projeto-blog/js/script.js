const btnHeartFill = document.querySelectorAll(".btnHeartFill");
const btnHeartbreakFill = document.querySelectorAll(".btnHeartbreakFill");


btnHeartFill.forEach((btn) => {

    btn.addEventListener('click', function() {

        const thisBtn = this;
        const oppositeBtn = getOppositeBtn(this, 1);
        const btnContainsClass = classListContains(oppositeBtn, 'ativo');

        if (!btnContainsClass) {

            toggleClass(thisBtn, 'ativo');

        } else {

            thisBtn.classList.add('ativo');
            handleOppositeButton(oppositeBtn, 0);

        }

        handleButton(thisBtn, 1);

    })
});


btnHeartbreakFill.forEach((btn) => {
    btn.addEventListener('click', function() {

        const thisBtn = this;
        const oppositeBtn = getOppositeBtn(this, 0);
        const btnContainsClass = classListContains(oppositeBtn, 'ativo');

        if (!btnContainsClass) {

            toggleClass(thisBtn, 'ativo');

        } else {

            thisBtn.classList.add('ativo');
            handleOppositeButton(oppositeBtn, 1);

        }

        handleButton(thisBtn, 0);

    })
});

function handleButton(elemento, tipoReacao) {

    let count = getSpanValue(elemento);
    const classContains = classListContains(elemento, 'ativo');
    classContains ? count++ : count--;
        
    const dados = {
        id: elemento.getAttribute('data-id'),
        tipo: tipoReacao,
        num: count
    }

    postRequest(
        "index.php?class=ListaPosts&method=reactions",
        dados,
        postRequestReturn(elemento, count)
    );

};

function handleOppositeButton(elemento, tipoReacao) {

    elemento.classList.remove('ativo');

    let oppositeCount = getSpanValue(elemento);
    oppositeCount--;
    
    const dados = {
        id: elemento.getAttribute('data-id'),
        tipo: tipoReacao,
        num: oppositeCount
    }

    postRequest(
        "index.php?class=ListaPosts&method=reactions",
        dados,
        postRequestReturn(elemento, oppositeCount)
    );

};

function postRequestReturn(elemento, contador) {

    return function(resposta){

        if(resposta == "ok") {
            setSpanNewValue(elemento, contador);
        }
    }
    
};

function postRequest(url, dados, callback) {
    $.post(url, dados).done(function(saida) {
        callback(saida);
    });
};

function setSpanNewValue(elemento, contador) {
    const spanElement = getSpanElement(elemento);
    spanElement.innerText = contador < 0 ? "0" : contador.toString();
};

function getSpanValue(elemento) {
    const spanElement = getSpanElement(elemento);
    let numLikes = parseInt(spanElement.innerText);
    return numLikes;
};

function getSpanElement(elemento) {
    const spanElement = elemento.parentElement.children[1];
    return spanElement;
};

function getOppositeBtn(elemento, indice) {
    return elemento.closest('div').parentNode.children[indice].children[0];
};

function classListContains(elemento, classe) {
    return elemento.classList.contains(classe);
};

function classListContains(elemento, classe) {
    return elemento.classList.contains(classe);
};

function toggleClass(elemento, classe){
    elemento.classList.toggle(classe);
};