<?php 

require_once("./classes/Produto.php");

$produto = [];
$produto = ['id'];
$produto = ['produto'];
$produto = ['marca'];
$produto = ['quantidade'];

if(!empty($_REQUEST['action'])) {

    if($_REQUEST['action'] == 'save') {

        $produto = $_POST;
        $save = Produto::saveProduto($produto);

       echo $save;
       exit();

    } else if ($_REQUEST['action'] == 'edit') {

        $id = $_GET['id'];

        $produto = Produto::findProduto($id);

    }

}

    $html_page = file_get_contents("./html/forms/form_produto.html");
    $html_page = str_replace('{id}', $produto['id'], $html_page);
    $html_page = str_replace('{produto}', $produto['produto'], $html_page);
    $html_page = str_replace('{marca}', $produto['marca'], $html_page);
    $html_page = str_replace('{quantidade}', $produto['quantidade'], $html_page);
    print $html_page;
