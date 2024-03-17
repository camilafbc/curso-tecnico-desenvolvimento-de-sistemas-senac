using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExPDV
{
    class Datas
    {
        public DateTime dataAtual = DateTime.Now;
        public DateTime data1;
        public DateTime data2;
        public int diasAdicionar;

        public string AdicionarDias()
        {
            string novaData = dataAtual.AddDays(diasAdicionar).ToShortDateString();
            return novaData;
        }

        public double DiferencaEntreDatas()
        {
            TimeSpan dias = data2.Subtract(data1);
            double diferenca = Math.Round(dias.TotalDays);

            return diferenca;
        }
    }
}
