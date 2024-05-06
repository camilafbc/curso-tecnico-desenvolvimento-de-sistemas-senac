
<?php 

    class Utils {

        public static function getDataHora() {

            setlocale(LC_TIME, 'pt_BR', 'pt_BR.utf-8', 'pt_BR.utf-8', 'portuguese');
            date_default_timezone_set('America/Sao_Paulo');
            return date('d-m-Y')." ".date('H:i:s');
        }


        function formatarData($dataEntrada)
        {
            $dataExplode = explode("-", $dataEntrada);

            if (@count($dataExplode) == 3) {
                $dataSaida = "{$dataExplode[2]}-{$dataExplode[1]}-{$dataExplode[0]}";
                return $dataSaida;
            }
        }

    }


?>