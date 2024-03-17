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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        Biblioteca biblioteca = new Biblioteca();
        Conexao conn = new Conexao();
        Datas datas = new Datas();

        private void PreencherListBox(string query)
        {
            DataTable resultado = conn.GetData(query);
            foreach (DataRow row in resultado.Rows)
            {
                ListViewItem item = new ListViewItem(biblioteca.FormatarDadoComZeros(4, row["codigo_compra"].ToString()));
                item.SubItems.Add($"R$ {row["total_compra"]},00");

                DateTime date = row.Field<DateTime>("data_compra");
                //item.SubItems.Add(date.ToString("dd/MM/yy HH:mm:ss"));
                item.SubItems.Add(date.ToShortDateString());
                item.SubItems.Add(date.ToLongTimeString());
                item.SubItems.Add(row["status"].ToString());
                item.SubItems.Add(row["pagamento"].ToString());
                item.SubItems.Add(row["nome"].ToString());

                listView1.Items.Add(item);
            }
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Add("Nº VENDA", 110, HorizontalAlignment.Left);
            listView1.Columns.Add("VALOR", 130, HorizontalAlignment.Right);
            listView1.Columns.Add("DATA", 125, HorizontalAlignment.Right);
            listView1.Columns.Add("HORA", 120, HorizontalAlignment.Right);
            listView1.Columns.Add("STATUS", 200, HorizontalAlignment.Center);
            listView1.Columns.Add("PAGAMENTO", 200, HorizontalAlignment.Right);
            listView1.Columns.Add("CAIXA", 150, HorizontalAlignment.Right);

            PreencherListBox("SELECT `ex_pdv_vendas`.`codigo_compra`, SUM(`ex_pdv_vendas`.`quantidade` * `ex_pdv_vendas`.`valor_unitario`) AS total_compra, MAX(`ex_pdv_vendas`.`data`) AS data_compra, `ex_pdv_vendas`.`status`, `ex_pdv_vendas`.`pagamento`, `ex_pdv_caixas`.`nome` FROM `ex_pdv_vendas` INNER JOIN `ex_pdv_caixas` ON `ex_pdv_vendas`.`id_caixa` = `ex_pdv_caixas`.`codigo_caixa` GROUP BY `ex_pdv_vendas`.`codigo_compra` ORDER BY `ex_pdv_vendas`.`codigo_compra` DESC");
        }

        private void txtNumVenda_TextChanged(object sender, EventArgs e)
        {
            int num_compra;

            if(txtNumVenda.Text == "")
            {
                listView1.Items.Clear();
                PreencherListBox("SELECT `ex_pdv_vendas`.`codigo_compra`, SUM(`ex_pdv_vendas`.`quantidade` * `ex_pdv_vendas`.`valor_unitario`) AS total_compra, MAX(`ex_pdv_vendas`.`data`) AS data_compra, `ex_pdv_vendas`.`status`, `ex_pdv_vendas`.`pagamento`, `ex_pdv_caixas`.`nome` FROM `ex_pdv_vendas` INNER JOIN `ex_pdv_caixas` ON `ex_pdv_vendas`.`id_caixa` = `ex_pdv_caixas`.`codigo_caixa` GROUP BY `ex_pdv_vendas`.`codigo_compra` ORDER BY `ex_pdv_vendas`.`codigo_compra` DESC");
            }
            else
            {
                bool isNum = int.TryParse(txtNumVenda.Text, out num_compra);
                if (isNum)
                {
                    listView1.Items.Clear();
                    PreencherListBox($"SELECT `ex_pdv_vendas`.`codigo_compra`, SUM(`ex_pdv_vendas`.`quantidade` * `ex_pdv_vendas`.`valor_unitario`) AS total_compra, MAX(`ex_pdv_vendas`.`data`) AS data_compra, `ex_pdv_vendas`.`status`, `ex_pdv_vendas`.`pagamento`, `ex_pdv_caixas`.`nome` FROM `ex_pdv_vendas` INNER JOIN `ex_pdv_caixas` ON `ex_pdv_vendas`.`id_caixa` = `ex_pdv_caixas`.`codigo_caixa` WHERE `ex_pdv_vendas`.`codigo_compra` LIKE '%{num_compra}%' GROUP BY `ex_pdv_vendas`.`codigo_compra` ORDER BY `ex_pdv_vendas`.`codigo_compra` DESC");
                }
            }  
        }

        private void btnBuscarPorData_Click(object sender, EventArgs e)
        {
            datas.data1 = dateTimePickerInicial.Value;
            datas.data2 = dateTimePickerFinal.Value;

            if(datas.DiferencaEntreDatas() < 0)
            {
                MessageBox.Show("Data Inicial maior que a Data Final!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listView1.Items.Clear();
                PreencherListBox($"SELECT `ex_pdv_vendas`.`codigo_compra`, SUM(`ex_pdv_vendas`.`quantidade` * `ex_pdv_vendas`.`valor_unitario`) AS total_compra, MAX(`ex_pdv_vendas`.`data`) AS data_compra, `ex_pdv_vendas`.`status`, `ex_pdv_vendas`.`pagamento`, `ex_pdv_caixas`.`nome` FROM `ex_pdv_vendas` INNER JOIN `ex_pdv_caixas` ON `ex_pdv_vendas`.`id_caixa` = `ex_pdv_caixas`.`codigo_caixa` WHERE `ex_pdv_vendas`.`data` BETWEEN '{datas.data1.ToString("yyyy/MM/dd")} 00:00:00' AND '{datas.data2.ToString("yyyy/MM/dd")} 23:59:59' GROUP BY `ex_pdv_vendas`.`codigo_compra` ORDER BY `ex_pdv_vendas`.`codigo_compra` DESC");
            }   
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem itemSelecionado = listView1.SelectedItems[0];

            int numPedidoSelecionado = int.Parse(itemSelecionado.SubItems[0].Text);
            string data = itemSelecionado.SubItems[2].Text;

            Form9 form9 = new Form9(numPedidoSelecionado, data);
            form9.Show();
        }
    }
}
