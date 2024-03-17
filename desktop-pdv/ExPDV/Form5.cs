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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        Conexao conn = new Conexao();
        Biblioteca biblioteca = new Biblioteca();
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string hora = biblioteca.HoraAtual();
            //string data = biblioteca.ConvertDateFromBrToAm(dateTimePicker1.Value.ToShortDateString());
            DateTime date = dateTimePicker1.Value;

            bool salvar = conn.InserirProduto(txtProduto.Text, int.Parse(txtQuantidade.Text), int.Parse(txtValor.Text), date.ToString("yyyy/MM/dd"), hora);
            if (salvar)
            {
                MessageBox.Show("Salvo com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProduto.Clear();
                txtQuantidade.Clear();
                txtValor.Clear();
                txtProduto.Focus();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            txtProduto.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            
        }
    }
}
