using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop_reserva_hotel
{
    class Reserva
    {
        public DateTime dataReserva;
        public string nome;
        public string email;
        public string cpf;
        public string telefone;
        public int qtd_adultos;
        public int qtd_criancas;
        public string tipo_quarto;
        public DateTime dataChegada;
        public DateTime dataSaida;
        public double duracaoEstadia;

        public string CalcularEstadia()
        {
            if (tipo_quarto == "Standard")
            {
                return (duracaoEstadia * 100.00).ToString("C2");
            }
            else if (tipo_quarto == "Standard Casal")
            {
                return (duracaoEstadia * 180).ToString("C2");
            }
            else if (tipo_quarto == "Família")
            {
                return (duracaoEstadia * 210).ToString("C2"); 
            }
            else if (tipo_quarto == "Suíte Júnior")
            {
                return (duracaoEstadia * 300).ToString("C2"); 
            }
            else if (tipo_quarto == "Suíte Master Família")
            {
                return (duracaoEstadia * 450).ToString("C2"); 
            }
            else if (tipo_quarto == "Suíte Deluxe")
            {
                return (duracaoEstadia * 600).ToString("C2"); 
            }
            else
            {
                return "";
            }
        }

        public string RegistroDaReserva()
        {
           return $"{dataReserva}*{cpf}*{nome}*{email}*{telefone}*{qtd_adultos}*{qtd_criancas}*{tipo_quarto}*{dataChegada.ToShortDateString()}*{dataSaida.ToShortDateString()}*{CalcularEstadia()}";
        }
    }
}
