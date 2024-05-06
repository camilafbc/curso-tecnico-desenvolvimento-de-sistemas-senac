<?php 

    class Connection {

        private static $conn;

        public static function getConnection()
        {
            if (empty(self::$conn)) {

                try {
                    $ini = parse_ini_file('./config/config.ini');
                    $banco = $ini['banco'];
                    $servidor = $ini['servidor'];
                    $usuario = $ini['usuario'];
                    $senha = $ini['senha'];

                    self::$conn = new PDO("mysql:dbname={$banco};host={$servidor};charset=utf8", $usuario, $senha);
                    self::$conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
                    return self::$conn;
                } catch (Exception $error) {

                    echo "<pre>";
                    print_r($error);
                    exit();
                }

            }
        }

    }

?>