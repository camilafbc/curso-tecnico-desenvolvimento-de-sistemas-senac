using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExPDV
{
    internal class Biblioteca
    {

        /* Método para acrescentar zeros no início de uma string
         * Recebe uma entrada com o número de casas desejadas e outra com a string a ser alterada
         */
        public string FormatarDadoComZeros(int casas, string entrada)
        {
            while (entrada.Trim().Length < casas) // ajustar tamanho
            {
                entrada = "0" + entrada;
            }

            return entrada.Trim().ToString();
        }

        public string FuncaoD(string casas, string entrada)
        {
            return int.Parse(entrada).ToString('D' + casas);
        }

        // Métodos de Hora e Data

        public string DataAtualBr()
        {
            string dataHoje = DateTime.Now.ToString("dd/MM/yyyy");
            return dataHoje;
        }

        public string DataAmericana()
        {
            string dataAmericana = DateTime.Now.ToString("yyyy/MM/dd");
            return dataAmericana;
        }

        public string HoraAtual()
        {
            string horaAtual = DateTime.Now.ToString("HH:mm");
            return horaAtual;
        }

        //Convertendo Data de Brasileiro para Americano
        public string ConvertDateFromBrToAm(string entrada) // recebe um dateTimePicker.ToShortDateString();
        {
            string[] minhaData = entrada.Split('/');
            return $"{minhaData[2]}-{minhaData[1]}-{minhaData[0]}";
        }

        public string ConverterDataParaMySQL(DateTime date)
        {
            return date.ToString("yyyy/MM/dd");
        }

        //Convertendo Data de Americano para Brasileiro
        public string ConvertDateAMparaBR(string entrada) // recebe um dateTimePicker.ToShortDateString();
        {
            string[] minhaData = entrada.Split('-');
            return $"{minhaData[2]}/{minhaData[1]}/{minhaData[0]}";
        }

        public string ConverterDataParaList(string entrada) // recebe um row["x"].ToString();
        {
            DateTime date = DateTime.Parse(entrada);
            return date.ToString("dd/MM/yyyy");
        }
    }
}
