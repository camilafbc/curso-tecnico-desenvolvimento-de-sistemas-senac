<?php 

    require_once("./classes/Contato.php");

    $contato = [];
    $contato['id'] = "";
    $contato['nome'] = "";
    $contato['email'] = "";
    $contato['celular'] = "";

    if(!empty($_REQUEST['action'])) {

        if ($_REQUEST['action'] == 'save') {

            $contato = $_POST;
            $save = Contato::save($contato);

            echo $save > 0 ? "Contato salvo com sucesso!" : "Erro ao salvar contato!";

        } else if ($_REQUEST['action'] == 'edit') {

            $id = $_GET['id'];

            $contato = Contato::find($id);

            echo json_encode($contato);

        }

    }