<?php 

    require_once("./classes/Post.php");

    class ListaPosts {

        private $html;
        private $dados;
        private $saida = "";

        public function __construct()
        {
            $this->html = file_get_contents("./html/index.html");
        }

        public function list() {

            try {

                $this->dados = Post::all();

                if(count($this->dados) > 0) {

                    foreach($this->dados as $post) {

                        $this->saida .= file_get_contents("./html/componentes/list.html");
                        $this->saida = str_replace('{id}', $post['id'], $this->saida);
                        $this->saida = str_replace('{data}', $post['data'], $this->saida);
                        $this->saida = str_replace('{hora}', $post['hora'], $this->saida);
                        $this->saida = str_replace('{titulo}', $post['titulo'], $this->saida);
                        $this->saida = str_replace('{post}', $post['post'], $this->saida);
                        $this->saida = str_replace('{numLikes}', $post['likePost'], $this->saida);
                        $this->saida = str_replace('{numDislikes}', $post['DesLike'], $this->saida);
                    }

                }


            } catch (Exception $error) {

                echo "<pre>";
                print_r($error);
                exit();

            }

        }

        public function reactions($param) {

            $action = Post::updateReactions($param);

            echo $action > 0 ? "ok" : "erro";
            exit();

        }

        public function show() {

            $ini = parse_ini_file('./config/config.ini');

            $header = file_get_contents("./html/componentes/header.html");
            $header = str_replace('{tituloMenu}', 'Novo Post', $header);
            $header = str_replace('{urlLink}', $ini['caminho'].'index.php?class=PostForm', $header);
            $footer = file_get_contents("./html/componentes/footer.html");

            
            $this->html = str_replace('{header}', $header, $this->html);
            $this->html = str_replace('{footer}', $footer, $this->html);
            $this->html = str_replace('{listItem}', $this->saida, $this->html);

            print $this->html;

        }

    }