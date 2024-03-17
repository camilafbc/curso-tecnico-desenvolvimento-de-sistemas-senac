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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        Conexao conn = new Conexao();
        Biblioteca biblioteca = new Biblioteca();

        private void PreencherListView(string query)
        {
            DataTable lista = conn.GetData(query);
            foreach (DataRow row in lista.Rows)
            {
                string cod = biblioteca.FormatarDadoComZeros(4, row["codigo"].ToString());
                ListViewItem item = new ListViewItem(cod);
                item.SubItems.Add(row["descricao"].ToString());
                item.SubItems.Add(biblioteca.FormatarDadoComZeros(4, row["quantidade"].ToString()));
                item.SubItems.Add(biblioteca.FormatarDadoComZeros(4, row["valor_unitario"].ToString()));

                listView1.Items.Add(item);
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details; 
            listView1.FullRowSelect = true; 
            listView1.GridLines = true;

            listView1.Columns.Add("COD", 80 ,HorizontalAlignment.Left); 
            listView1.Columns.Add("PRODUTO", 360, HorizontalAlignment.Left);
            listView1.Columns.Add("QTD", 85, HorizontalAlignment.Right);
            listView1.Columns.Add("Valor Unitário", 135, HorizontalAlignment.Right);

            PreencherListView("SELECT codigo, descricao, quantidade, valor_unitario FROM ex_pdv");
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            PreencherListView($"SELECT * FROM ex_pdv WHERE descricao LIKE '%{txtBusca.Text}%'");
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem itemSelecionado = listView1.SelectedItems[0];

            int codigo = int.Parse(itemSelecionado.SubItems[0].Text.Trim());

            Form4 form4 = new Form4(codigo, listView1);
            form4.Show();
        }
    }
}
