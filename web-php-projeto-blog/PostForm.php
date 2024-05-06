<?php 

    require_once("./classes/Post.php");

    class PostForm {

        private $html;
        public function __construct()
        {
            $this->html = file_get_contents("./html/forms/form_post.html");
        }

        public function save($param) {

            $save = Post::save($param);

            echo $save;
            exit();

        }

        public function show() {

            $ini = parse_ini_file('./config/config.ini');

            $header = file_get_contents("./html/componentes/header.html");
            $header = str_replace('{tituloMenu}', 'Início', $header);
            $header = str_replace('{urlLink}', $ini['caminho'].'index.php?', $header);
            $footer = file_get_contents("./html/componentes/footer.html");

            $this->html = str_replace('{header}', $header, $this->html);
            $this->html = str_replace('{footer}', $footer, $this->html);
            print $this->html;

        }

    }
