<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="shortcut icon" href="./img/icons8-mail-contact-32.png" type="image/x-icon">
    <title>Gerar E-mail Institucional</title>
    <!-- Bootstrap -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css">
    <!-- CSS -->
    <link rel="stylesheet" href="./css/style.css">
</head>
<body class="vh-100 d-flex align-items-center justify-content-center bg-primary">

    <div class="container">
        <div class="card mx-auto w-100 p-5 d-flex justify-content-center align-items-center shadow-lg bg-light">
            <h1 class="display-5 text-center">Gerar E-mail Institucional</h1>
            <hr class="w-100">
            <img src="./img/undraw_online_ad_re_ol62.svg" alt="ilustração" class="mb-4">
            <form action="processamento.php" method="post" class="w-100 mt-2">
                <input type="text" class="form-control " id="name"  name="name" placeholder="Nome Completo do Funcionário" required>
                <button class="btn btn-primary w-100 my-2">GERAR E-MAIL</button>
            </form>
        </div>
    </div>
    
    <script src="ttps://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>