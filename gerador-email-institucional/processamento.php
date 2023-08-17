<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <!-- Bootstrap -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css">
    <!-- CSS -->
    <link rel="stylesheet" href="./css/style.css">
</head>
<body class="vh-100 d-flex align-items-center justify-content-center bg-secondary">

    <div class="container d-flex flex-column">
        <div class="card mx-auto w-100 p-5 d-flex justify-content-center align-items-center shadow-lg bg-light">
            <!-- <h1 class="display-5 text-center mb-4">Criar E-mail Institucional</h1> -->
            <img src="./img/undraw_online_ad_re_ol62.svg" alt="ilustração" class="mb-4">
            <hr class="w-100">
            <div class="text-center">

                <?php
                     $employee_name = $_POST["name"];
                     $name_explode = explode(" ", strtolower($employee_name));
                     $user = "";
             
                     // Armazena o último nome
                     $lastname = $name_explode[sizeof($name_explode) - 1];
                     
                     // Percorre os outros nomes e verifica a quantidade de caracteres; se maior que 3, concatena as iniciais na variável $user
                     for($i = 0; $i < count($name_explode) - 1; $i++){
                         if(strlen($name_explode[$i]) > 3){
                             $user = $user.$name_explode[$i][0];
                         };
                     };
             
                     //Concatena os elementos para gerar o e-mail
                     echo "<h2>E-mail:</h2>";
                     echo "<h3>".$user.$lastname."@empresa.com.br</h3>";
                ?>

            </div>
        </div>
        <a href="index.php" class="mx-auto my-4">
            <button class="btn btn-outline-light">VOLTAR</button>
        </a>
    </div>
    
<script src="ttps://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>