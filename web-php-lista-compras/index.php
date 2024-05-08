<?php 

    require_once("./classes/Produto.php");

    if (isset($_REQUEST['action'])){

        if($_GET['action'] == "delete") {

            $id = $_GET['id'];

            $delete = Produto::delete($id);

            echo $delete > 0 ? "Produto deletado!" : "Erro ao deletar produto";
            exit();

        } else if ($_GET['action'] == "changeStatus") {

            $id = $_GET['id'];
            $status = $_GET['status'];

            $changeStatus = Produto::changeStatus($id, $status);

            exit();

        }

    } else {

        $output = '';

        $produtos = Produto::listAll();

        if(count($produtos) > 0) {

            foreach($produtos as $produto) {
                $output .= file_get_contents("./html/componentes/tableRow.html");
                $output = str_replace('{id}', $produto['id'], $output);
                $output = str_replace('{produto}', $produto['produto'], $output);
                $output = str_replace('{marca}', $produto['marca'], $output);
                $output = str_replace('{quantidade}', $produto['quantidade'], $output);

                $checked = $produto['comprado'] == "1" ? "checked" : "" ;

                $output = str_replace('{checked}', $checked, $output);
            }

        }
    }

    $html_page = file_get_contents("./html/index.html");
    $html_page = str_replace('{tableRow}', $output, $html_page);
    print $html_page;
