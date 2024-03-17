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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        Biblioteca biblioteca = new Biblioteca();
        Conexao conn = new Conexao();
        Datas datas = new Datas();

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
        private void Form6_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Add("COD", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("PRODUTO", 330, HorizontalAlignment.Left);
            listView1.Columns.Add("QTD", 120, HorizontalAlignment.Right);
            listView1.Columns.Add("VL UNIT", 135, HorizontalAlignment.Right);
            listView1.Columns.Add("VENCIMENTO", 150, HorizontalAlignment.Right);
            listView1.Columns.Add("HR ENTRADA", 150, HorizontalAlignment.Right);

            PreencherListView("SELECT * FROM ex_pdv");
        }

        private void btnBuscarPorData_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            datas.data1 = dateTimePicker1.Value;
            datas.data2 = dateTimePicker2.Value;

            if (datas.DiferencaEntreDatas() < 0)
            {
                MessageBox.Show("Data Inicial maior que a Data Final!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                PreencherListView($"SELECT * FROM ex_pdv WHERE vencimento BETWEEN '{datas.data1.ToString("yyyy/MM/dd")}' AND '{datas.data2.ToString("yyyy/MM/dd")}' ORDER BY vencimento");
            }
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
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
