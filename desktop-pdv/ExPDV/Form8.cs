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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        Conexao conn = new Conexao();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            int existe = conn.QuantidadeRegistros($"SELECT codigo_caixa FROM ex_pdv_caixas WHERE email='{txtEmail.Text.Trim()}' AND senha='{txtSenha.Text.Trim()}'");

            if(existe == 0)
            {
                MessageBox.Show("E-mail e/ou senha não correspondem!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable resultado = conn.GetData($"SELECT codigo_caixa, nome FROM ex_pdv_caixas WHERE email='{txtEmail.Text.Trim()}' AND senha='{txtSenha.Text.Trim()}'");
                foreach(DataRow row in resultado.Rows)
                {
                    Program.cod_caixa = row["codigo_caixa"].ToString();
                    Program.nome_caixa = row["nome"].ToString();
                }
                

                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
        }
    }
}
