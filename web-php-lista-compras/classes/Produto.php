<?php
class Produto {

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

    public static function listAll()
    {

        try {

            $conn = self::getConnection();

            $sql = "SELECT * FROM produtos ORDER BY comprado, produto";
            $result = $conn->query($sql);
            $registros = $result->fetchAll(PDO::FETCH_ASSOC);
            
            return $registros;

        } catch (Exception $error) {

            echo "<pre>";
            print_r($error);
            exit();

        } finally {

            $conn = null;

        }

    }

    public static function delete($id) {
        
        try {

            $conn = self::getConnection();

            $prepare = $conn->prepare("DELETE FROM produtos WHERE id=:id");
            $prepare->bindValue(":id", $id);
            $count = $prepare->execute();

            return $count;

        } catch (Exception $error) {

            echo "<pre>";
            print_r($error);
            exit();

        } finally {

            $conn = null;

        }

    }

    public static function changeStatus($id, $status) {

        try {

            $conn = self::getConnection();

            $comprado = $status == "true" ? true : false;

            $prepare = $conn->prepare("UPDATE produtos SET comprado = :comprado WHERE id=:id");
            $prepare->bindValue(":id", $id);
            $prepare->bindValue(":comprado", $comprado);
            $count = $prepare->execute();

            return $count;

        } catch (Exception $error) {

            echo "<pre>";
            print_r($error);
            exit();

        } finally {

            $conn = null;

        }

    }

    public static function saveProduto($produto) {

        try {

            $conn = self::getConnection();

            if(empty($produto['id'])){

                $prepare = $conn->prepare("INSERT INTO produtos (produto, quantidade, marca) VALUES (:produto, :quantidade, :marca)");
                $prepare->bindValue(":produto", $produto['produto']);
                $prepare->bindValue(":marca", $produto['marca']);
                $prepare->bindValue(":quantidade", $produto['quantidade']);
                $count = $prepare->execute();

                return $count;

            } else {

                $prepare = $conn->prepare("UPDATE produtos SET produto = :produto, quantidade = :quantidade, marca = :marca WHERE id=:id");
                $prepare->bindValue(":id", $produto['id']);
                $prepare->bindValue(":produto", $produto['produto']);
                $prepare->bindValue(":quantidade", $produto['quantidade']);
                $prepare->bindValue(":marca", $produto['marca']);
                $count = $prepare->execute();

                return $count;

            }

        } catch (Exception $error) {

            echo "<pre>";
            print_r($error);
            exit();

        } finally {

            $conn = null;

        }

    }

    public static function findProduto($id) {

        try {

            $conn = self::getConnection();

            $idToUp = $_GET["id"];

            $sql = "SELECT * FROM produtos WHERE id = $idToUp";

            $result = $conn->query($sql);
            $produto = $result->fetch(PDO::FETCH_ASSOC);

            return $produto;

        } catch (Exception $error) {

            echo "<pre>";
            print_r($error);
            exit();

        } finally {

            $conn = null;

        }

    }

}
