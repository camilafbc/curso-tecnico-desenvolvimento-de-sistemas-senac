<?php 

    class Contato {

        private static $conn;

        public static function getConnection()
        {
            if (empty(self::$conn)) {

                try {
                    $ini = parse_ini_file('./config/config.ini');
                    $servidor = $ini['servidor'];
                    $banco = $ini['banco'];
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

        public static function listAll() {

            try {

                $conn = self::getConnection();

                $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
                $sql = "SELECT * FROM contatos WHERE raAluno = '972244' ORDER BY nome";
                
                $result = $conn->query($sql);
                $list = $result->fetchAll(PDO::FETCH_ASSOC);

                return $list;

            } catch (Exception $error) {

                echo "<pre>";
                print_r($error);
                exit();
            }

        }

        public static function find($id) {

            try {

                $conn = self::getConnection();

                $sql = "SELECT * FROM contatos WHERE id = {$id}";

                $result = $conn->query($sql);
                $contato = $result->fetch(PDO::FETCH_ASSOC);

                return $contato;

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

                $prepare = $conn->prepare("DELETE FROM contatos WHERE id=:id AND raAluno='972244'");
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

        public static function save($contato) {

            try {

                $conn = self::getConnection();

                if(empty($contato['id'])) {

                    $zap = $contato['zap'] === 'true' ? 1 : 0 ;

                    $prepare = $conn->prepare("INSERT INTO contatos (nome, email, celular, zap, raAluno) VALUES (:nome, :email, :celular, :zap, :raAluno)");

                    $prepare->bindValue(":nome", $contato['nome'], PDO::PARAM_STR);
                    $prepare->bindValue(":email", $contato['email'], PDO::PARAM_STR);
                    $prepare->bindValue(":celular", $contato['celular'], PDO::PARAM_STR);
                    $prepare->bindValue(":zap", $zap, PDO::PARAM_INT);
                    $prepare->bindValue(":raAluno", "972244", PDO::PARAM_STR);
                    $count = $prepare->execute();

                    return $count;

                } else {

                    $zap = $contato['zap'] === 'true' ? 1 : 0 ;

                    $prepare = $conn->prepare("UPDATE contatos SET nome = :nome, email = :email, celular = :celular, zap = :zap WHERE id=:id AND raAluno = '972244'");
                    $prepare->bindValue(":id", $contato['id']);
                    $prepare->bindValue(":nome", $contato['nome'], PDO::PARAM_STR);
                    $prepare->bindValue(":email", $contato['email'], PDO::PARAM_STR);
                    $prepare->bindValue(":celular", $contato['celular'], PDO::PARAM_STR);
                    $prepare->bindValue(":zap", $zap, PDO::PARAM_INT);
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

    }
