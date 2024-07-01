document.getElementById("descrProduto").focus();

document.getElementById("qtdProduto").addEventListener('input',function(){
    this.value = this.value.replace(/\D/g, "");
});

document.addEventListener('DOMContentLoaded', () => {

    const tabela = document.querySelector("tbody");

    document.querySelectorAll('input[type="checkbox"]').forEach((input) => {
        
        if(input.checked){

            const linha = input.closest("tr");
            isChecked(linha, tabela);

        };

        input.addEventListener('change', function() {
        
            const status = this.checked;
            const idProduto = this.getAttribute('id');
            const linha = input.closest("tr");
    
            if (status){
                
                isChecked(linha, tabela);
    
            } else {
    
                isNotChecked(linha, tabela)
            }
    
            $.get(`index.php?action=changeStatus&id=${idProduto}&status=${status}`).done(function(data){
                // 
            })
    
        });

    });

});

function isChecked(rowElement, tableElement){

    const row = rowElement;

    row.style.opacity = '0.5';
    row.cells[1].style.textDecoration = 'line-through';
    row.cells[2].style.textDecoration = 'line-through';
    row.cells[3].style.textDecoration = 'line-through';

    tableElement.appendChild(row);

};

function isNotChecked(rowElement, tableElement){

    const row = rowElement;
    row.style.opacity = '1';
    row.cells[1].style.textDecoration = 'none';
    row.cells[2].style.textDecoration = 'none';
    row.cells[3].style.textDecoration = 'none';

    let totalInputs = document.querySelectorAll('input[type="checkbox"]').length;
    let inputsChecked = document.querySelectorAll('input[type="checkbox"]:checked').length;
    let indice = (parseInt(totalInputs) - parseInt(inputsChecked) - 1);

    tableElement.insertBefore(row, tableElement.rows[indice])
};

document.getElementById("btnAdicionar").addEventListener('click', (ev) => {

    ev.preventDefault();

    const dados = {

        id: document.getElementById("id").value,
        produto: document.getElementById("descrProduto").value,
        marca: document.getElementById("marcaProduto").value,
        quantidade: document.getElementById("qtdProduto").value
    };

    

    if (dados.produto == "" || dados.marca == ""|| dados.quantidade == "") {

        Swal.fire({
            showConfirmButton: false,
            text: "Preencha todos os campos!",
            icon: 'error',
            timer: 3000,
            allowOutsideClick: false,
        });

    } else {

        $.post("form_produto.php?action=save", dados).done(function(data){
        
            let text = data > 0 ? "Produto salvo com sucesso!" : "Erro ao salvar produto!";
            
            document.getElementById("descrProduto").value = "";
            document.getElementById("marcaProduto").value = "";
            document.getElementById("qtdProduto").value = "";

            Swal.fire({
                showConfirmButton: false,
                text: text,
                icon: 'success',
                timer: 3000,
                allowOutsideClick: false,
            }).then((result) => {
            
                if (result.dismiss === Swal.DismissReason.timer) {
                  
                    window.location.href = "index.php";
        
                }
            });

        });
    }

});

document.querySelectorAll(".btn-del").forEach((btn) => {

    btn.addEventListener('click', function (ev){

        ev.preventDefault();

        const idToDelete = this.getAttribute("id");

        $.get(`index.php?action=delete&id=${idToDelete}`).done(function(data){

            Swal.fire({
                showConfirmButton: false,
                text: data,
                icon: 'success',
                timer: 3000,
                allowOutsideClick: false,
            }).then((result) => {
            
                if (result.dismiss === Swal.DismissReason.timer) {
                
                    window.location.reload();window.location.href = "index.php";
        
                }
            });
            
        });

    });

});