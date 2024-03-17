using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExPDV
{
    public partial class Form10 : Form
    {
        Biblioteca biblioteca = new Biblioteca();
        Conexao conn = new Conexao();

        private string codigo_pedido;
        private int valor_compra;
        public Form10(string codigo_pedido, int valor_compra)
        {
            InitializeComponent();
            this.codigo_pedido = codigo_pedido;
            this.valor_compra = valor_compra;
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            lblNumCompra.Text = biblioteca.FormatarDadoComZeros(4, codigo_pedido);
            lblValor.Text = $"R$ {valor_compra},00";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Selecione a forma de pagamento!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string pagamento = null;

                if (comboBox1.Text == "Dinheiro")
                {
                    pagamento = "Dinheiro";
                }
                else if (comboBox1.Text == "Cartão de Débito")
                {
                    pagamento = "Débito";
                }
                else if (comboBox1.Text == "Cartão de Crédito a Vista")
                {
                    pagamento = "Crédito a Vista";
                }
                else if (comboBox1.Text == "Cartão de Crédito Parcelado")
                {
                    pagamento = "Crédito Parcelado";
                }


                bool finalizar = conn.AtualizarPedido(int.Parse(codigo_pedido), "Pago", pagamento);
                if (finalizar)
                {
                    MessageBox.Show("Compra finalizada!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Obtém a instância original do Form
                    Form2 form2 = Application.OpenForms.OfType<Form2>().FirstOrDefault();

                    // Limpa o Form2
                    form2?.ReiniciarForm2();

                    // Aplica Refresh no Form2
                    form2?.Refresh();


                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Confirmar o cancelamento da compra nº {biblioteca.FormatarDadoComZeros(4, codigo_pedido)} no valor de R$ {valor_compra},00 ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(dialogResult == DialogResult.Yes)
            {
                bool cancelar = conn.AtualizarPedido(int.Parse(codigo_pedido), "Cancelado", "Cancelado");
                if (cancelar)
                {
                    MessageBox.Show("Compra Cancelada!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Form2 form2 = Application.OpenForms.OfType<Form2>().FirstOrDefault();
                    form2?.ReiniciarForm2();
                    form2?.Refresh();

                    this.Close();
                }
            }
        
        }
    }
}
