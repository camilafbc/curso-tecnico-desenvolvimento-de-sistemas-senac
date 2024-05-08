
const elems = document.querySelectorAll('.modal');
const instances = M.Modal.init(elems);

$("#btnAdicionar").click(function(ev){
    ev.preventDefault();

    const dados = {
        nome: $('#nomeContato').val(),
        email: $('#emailContato').val(),
        celular: $('#telefoneContato').val(),
        zap: document.getElementById("isWhatsapp").checked
    }

    $.post("./form_contato.php?action=save", dados).done(function(data){
        
        alert(data);

        document.getElementById("nomeContato").value = "";
        document.getElementById("emailContato").value = "";
        document.getElementById("telefoneContato").value = "";
        document.getElementById("isWhatsapp").checked = false;

        window.location.reload();
    })
})

document.querySelectorAll(".btnExcluir").forEach((btn) => {
    btn.addEventListener('click', function(){

        const idToDelete = this.closest('li').getAttribute('id');

        $.get(`./index.php?action=delete&id=${idToDelete}`).done(function(data){

            alert(data);

            window.location.reload();

        })
    })
})

document.querySelectorAll(".modal-trigger").forEach((btn) => {
    btn.addEventListener('click', function () {

        const idToUpdate = this.getAttribute('data-id');

        $.get(`./form_contato.php?action=edit&id=${idToUpdate}`).done(function(data){

            const contato = JSON.parse(data)

            document.getElementById("idEdit").value = contato['id'];
            document.getElementById("nomeContatoEdit").value = contato['nome'];
            document.getElementById("emailContatoEdit").value = contato['email'];
            document.getElementById("telefoneContatoEdit").value = contato['celular'];
            
            const status = contato['zap'] == 0 ? false : true;
            document.getElementById("isWppEdit").checked = status;

        })
    })
})


$("#btnSalvar").click(function(ev){
    ev.preventDefault();

    const dados = {
        id:  $('#idEdit').val(),
        nome: $('#nomeContatoEdit').val(),
        email: $('#emailContatoEdit').val(),
        celular: $('#telefoneContatoEdit').val(),
        zap: document.getElementById("isWppEdit").checked
    }

    $.post("./form_contato.php?action=save", dados).done(function(data){
        
        alert(data);

        window.location.reload();
    })
})