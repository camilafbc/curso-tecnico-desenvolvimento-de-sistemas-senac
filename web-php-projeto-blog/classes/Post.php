<?php 

    require_once("Connection.php");

    class Post {

        public static function all() {

            try {

                $conn = Connection::getConnection();
    
                $sql = "SELECT * FROM posts WHERE RA = '972244' ORDER BY id DESC";
                $result = $conn->query($sql);
                $registros = $result->fetchAll(PDO::FETCH_ASSOC);
                $conn = null;
                
                return $registros;

            } catch (Exception $error) {

                echo "<pre>";
                print_r($error);
                exit();

            } 

        }

        public static function save($post) {

            try {

                require_once("Utils.php");

                $conn = Connection::getConnection();

                $id = "";
                $sql = "";
                $dataEHora = explode(" ", Utils::getDataHora());

                $data = $dataEHora[0];
                $hora = $dataEHora[1];

                
                
                if(empty($post['id'])) {

                    // Pegando o próximo ID
                    $sqlF = "SELECT max(id) AS next FROM posts";
                    $result = $conn->query($sqlF);
                    $linha = $result->fetch(PDO::FETCH_ASSOC);
                    $nextId = (int) $linha['next'] + 1;

                    $id = $nextId;
                    $sql = "INSERT INTO posts (id, titulo, post, data, hora, likePost, DesLike, RA) VALUES (:id, :titulo, :post, :data, :hora, :likePost, :DesLike, :RA)";

                } 

                $prepare = $conn->prepare($sql);
                $prepare->bindValue(":id", $id, PDO::PARAM_INT);
                $prepare->bindValue(":titulo", $post["titulo"], PDO::PARAM_STR);
                $prepare->bindValue(":post", $post["post"], PDO::PARAM_STR);
                $prepare->bindValue(":data", $data, PDO::PARAM_STR);
                $prepare->bindValue(":hora", $hora, PDO::PARAM_STR);
                $prepare->bindValue(":likePost", 0, PDO::PARAM_INT);
                $prepare->bindValue(":DesLike", 0, PDO::PARAM_INT);
                $prepare->bindValue(":RA", '972244', PDO::PARAM_STR);
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

        public static function updateReactions($data) {

            try {

                $conn = Connection::getConnection();
 
                if ($data['tipo'] == 1) {

                    $sql = "UPDATE posts SET likePost = :likePost WHERE id = :id AND RA = '972244'";
                    $prepare = $conn->prepare($sql);
                    $prepare->bindValue(":id", (int) $data['id'], PDO::PARAM_INT);
                    $prepare->bindValue(":likePost", (int) $data['num'], PDO::PARAM_INT);
                    $count = $prepare->execute();

                } else {

                    $sql = "UPDATE posts SET DesLike = :deslikePost WHERE id = :id AND RA = '972244'";
                    $prepare = $conn->prepare($sql);
                    $prepare->bindValue(":id", (int) $data['id'], PDO::PARAM_INT);
                    $prepare->bindValue(":deslikePost", (int) $data['num'], PDO::PARAM_INT);
                    $count = $prepare->execute();

                }

                return $count;


            } catch (Exception $error) {

                echo "<pre>";
                print_r($error);
                exit();

            } finally {

                $conn = null;

            }

        }

    }