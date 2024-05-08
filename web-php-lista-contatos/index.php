<?php 

 require_once("./classes/Contato.php");

 if(isset($_REQUEST['action']) && $_REQUEST['action'] == 'delete') {

    $id = $_GET['id'];
    $delete = Contato::delete($id);

    echo $delete > 0 ? "Contato deletado com sucesso!" : "Erro ao deletar contato!";

 } else {

    $output = '';
    $contatos = Contato::listAll();

    if(count($contatos) > 0) {

        foreach($contatos as $contato) {

            $output .= file_get_contents("./html/componentes/cardContato.html");
            $output = str_replace('{id}', $contato['id'], $output);
            $output = str_replace('{nome}', $contato['nome'], $output);
            $output = str_replace('{email}', $contato['email'], $output);
            $output = str_replace('{celular}', $contato['celular'], $output);

            $icon = $contato['zap'] == "1" ? "<img id='logo-whatsapp' src='./img/icons8-whatsapp-48.png' alt='logo-whatsapp'>" : "" ;
            $output = str_replace('{icon}', $icon, $output);

        }
    }

    $html_page = file_get_contents("./html/index.html");
    $formContato = file_get_contents("./html/forms/form_contato.html");
    $formModal = file_get_contents("./html/forms/form_modal.html");
    $modal = file_get_contents("./html/componentes/modal.html");


    $html_page = str_replace('{cardContato}', $output, $html_page);
    $html_page = str_replace('{formContato}', $formContato, $html_page);
    $modal = str_replace('{formModal}', $formModal, $modal);
    $html_page = str_replace('{modal}', $modal, $html_page);
    print $html_page;

 }

?>