using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop_reserva_hotel.UserControls
{
    public partial class UCNovaReserva : UserControl
    {
        public UCNovaReserva()
        {
            InitializeComponent();
        }

        Datas datas = new Datas();
        Reserva reserva = new Reserva();
        Texto texto = new Texto();
        private void UCNovaReserva_Load(object sender, EventArgs e)
        {
            txtNome.Focus();
        }
        private void btnReservar_Click(object sender, EventArgs e)
        {

            if (txtNome.Text.Equals(string.Empty) || maskedTBCpf.Text.Equals(string.Empty) || txtEmail.Text.Equals(string.Empty) || 
                maskedTBTelefone.Text.Equals(string.Empty) || txtNumAdultos.Text.Equals(string.Empty) || txtNumCriancas.Text.Equals(string.Empty)
                || cBTipoQuarto.Text.Equals(string.Empty))
            {
                MessageBox.Show("Preencha todas informações para registrar uma reserva!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (!maskedTBCpf.MaskFull)
                {
                    MessageBox.Show("CPF inválido!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!maskedTBTelefone.MaskFull)
                {
                    MessageBox.Show("Telefone inválido!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (int.Parse(txtNumAdultos.Text) < 1)
                {
                    MessageBox.Show("É preciso ao menos 1 adulto para registro da reserva!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dateTimePickerEntrada.Value > dateTimePickerSaida.Value)
                {
                    MessageBox.Show("Data de entrada maior que data de saída!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                reserva.dataReserva = datas.dataAtual;
                reserva.nome = txtNome.Text.Trim();
                reserva.cpf = maskedTBCpf.Text;
                reserva.email = txtEmail.Text;
                reserva.telefone = maskedTBTelefone.Text;
                reserva.qtd_adultos = int.Parse(txtNumAdultos.Text);
                reserva.qtd_criancas = int.Parse(txtNumCriancas.Text);
                reserva.tipo_quarto = cBTipoQuarto.Text;
                reserva.dataChegada = dateTimePickerEntrada.Value;
                reserva.dataSaida = dateTimePickerSaida.Value;

                datas.dataEntrada = reserva.dataChegada;
                datas.dataSaida = reserva.dataSaida;
                reserva.duracaoEstadia = datas.CalcularDiferencaDatas();

                DialogResult dialogResult = MessageBox.Show($"Confirma os dados da seguinte reserva?\n\n" +
                    $"Nome: {reserva.nome}\n" +
                    $"CPF: {reserva.cpf}\n" +
                    $"E-mail: {reserva.email}\n" +
                    $"Telefone: {reserva.telefone}\n" +
                    $"Nº Adultos: {reserva.qtd_adultos}\n" +
                    $"Nº Crianças: {reserva.qtd_criancas}\n" +
                    $"Tipo de quarto: {reserva.tipo_quarto}\n" +
                    $"Entrada: {reserva.dataChegada.ToShortDateString()}\n" +
                    $"Saída: {reserva.dataSaida.ToShortDateString()}\n" +
                    $"Estadia: {reserva.duracaoEstadia} dias\n" +
                    $"Valor: {reserva.CalcularEstadia()}", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    texto.Dados = reserva.RegistroDaReserva();
                    texto.Gravar();
                    btnLimpar.PerformClick();
                    MessageBox.Show("Reserva registrada com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }  
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            maskedTBCpf.Text = "";
            txtEmail.Text = "";
            maskedTBTelefone.Text = "";
            txtNumAdultos.Text = "";
            txtNumCriancas.Text = "";
            cBTipoQuarto.SelectedIndex = -1;
            dateTimePickerEntrada.Value = DateTime.Now;
            dateTimePickerSaida.Value = DateTime.Now;
        }

        private void txtNumAdultos_Leave(object sender, EventArgs e)
        {
            bool isNum = int.TryParse(txtNumAdultos.Text, out int valor);

            if (!isNum)
            {
                MessageBox.Show("Entrada inválida!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumAdultos.Focus();
            }
        }

        private void txtNumCriancas_Leave(object sender, EventArgs e)
        {
            bool isNum = int.TryParse(txtNumCriancas.Text, out int valor);

            if (!isNum)
            {
                MessageBox.Show("Entrada inválida!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumCriancas.Focus();
            }
        }  
    }
}