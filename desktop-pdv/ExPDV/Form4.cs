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
    public partial class Form4 : Form
    {
        private int codigo;
        private ListView listView1;
        public Form4(int codigo, ListView listView1)
        {
            InitializeComponent();
            this.codigo = codigo;
            this.listView1 = listView1;
        }

        Biblioteca biblioteca = new Biblioteca();
        Conexao conn = new Conexao();


        private void PreencherListView(string query)
        {
            DataTable lista = conn.GetData(query);
            foreach (DataRow row in lista.Rows)
            {
                //DateTime date = DateTime.Parse(row["vencimento"].ToString());
                DateTime date = row.Field<DateTime>("vencimento");

                string cod = biblioteca.FormatarDadoComZeros(4, row["codigo"].ToString());
                ListViewItem item = new ListViewItem(cod);
                item.SubItems.Add(row["descricao"].ToString());
                item.SubItems.Add(biblioteca.FormatarDadoComZeros(4, row["quantidade"].ToString()));
                item.SubItems.Add($"{row["valor_unitario"]},00");
                item.SubItems.Add(date.ToString("dd/MM/yyyy"));
                item.SubItems.Add(row["hora_entrada"].ToString());

                listView1.Items.Add(item);
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            DataTable resultado = conn.GetData($"SELECT * FROM ex_pdv WHERE codigo='{codigo}'");
            foreach(DataRow row in resultado.Rows)
            {
                string cod = biblioteca.FormatarDadoComZeros(4, row["codigo"].ToString());
                txtCod.Text = cod;
                txtProd.Text = row["descricao"].ToString();
                txtEstoque.Text = row["quantidade"].ToString();
                txtValor.Text = row["valor_unitario"].ToString();
            }

            DesabledTxt();
        }

        private void EnabledTxt()
        {
            //txtCod.Enabled = true;
            txtProd.Enabled = true;
            txtEstoque.Enabled = true;
            txtValor.Enabled = true;
        }

        private void DesabledTxt()
        {
            txtCod.Enabled = false;
            txtProd.Enabled = false;
            txtEstoque.Enabled = false;
            txtValor.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(btnSalvar.Text == "Editar")
            {
                EnabledTxt();
                btnSalvar.Text = "Salvar";
            }
            else
            {
                bool update = conn.AtualizarProduto(int.Parse(txtCod.Text), txtProd.Text, int.Parse(txtEstoque.Text), int.Parse(txtValor.Text));
                if (update)
                {
                    MessageBox.Show("Salvo com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ClearTxt();
                    DesabledTxt();
                }

                
                btnSalvar.Text = "Editar";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            PreencherListView("SELECT * FROM ex_pdv");

            this.Close();
        }
    }
}
