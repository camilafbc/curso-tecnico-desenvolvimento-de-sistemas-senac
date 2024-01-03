using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop_reserva_hotel
{
    class Datas
    {
        public DateTime dataAtual = DateTime.Now;
        public DateTime dataEntrada;
        public DateTime dataSaida;

        public double CalcularDiferencaDatas()
        {
            TimeSpan estadia;
            estadia = dataSaida.Subtract(dataEntrada);
            double saida = Math.Round(estadia.TotalDays);
            return saida;
        }
    }
}
