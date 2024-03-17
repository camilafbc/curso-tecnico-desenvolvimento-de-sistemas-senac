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
    public partial class Form9 : Form
    {
        private int numPedido;
        private string data;
        public Form9(int numPedidoSelecionado, string data)
        {
            InitializeComponent();
            this.numPedido = numPedidoSelecionado;
            this.data = data;
        }

        Biblioteca biblioteca = new Biblioteca();
        Conexao conn = new Conexao();
        private void Form9_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true; 
            listView1.GridLines = true;

            listView1.Columns.Add("ITEM", 70, HorizontalAlignment.Left);
            listView1.Columns.Add("COD", 70, HorizontalAlignment.Left);
            listView1.Columns.Add("DESCRIÇÃO", 300, HorizontalAlignment.Left);
            listView1.Columns.Add("QTD", 72, HorizontalAlignment.Center);
            listView1.Columns.Add("VL UNIT", 93, HorizontalAlignment.Right);
            listView1.Columns.Add("TOTAL", 90, HorizontalAlignment.Right);

            lblSaidaVenda.Text = biblioteca.FormatarDadoComZeros(4, numPedido.ToString());
            lblSaidaData.Text = data;
            this.Text = $"Venda Nº {biblioteca.FormatarDadoComZeros(4, numPedido.ToString())}";
            int num_Item = 1;
            DataTable lista = conn.GetData($"SELECT `ex_pdv_vendas`.`codigo_produto`, `ex_pdv`.`descricao`, `ex_pdv_vendas`.`quantidade`, `ex_pdv_vendas`.`valor_unitario`, `ex_pdv_vendas`.`quantidade` * `ex_pdv_vendas`.`valor_unitario` AS total_item FROM `ex_pdv_vendas` INNER JOIN `ex_pdv` ON `ex_pdv_vendas`.`codigo_produto` = `ex_pdv`.`codigo` WHERE `ex_pdv_vendas`.`codigo_compra`={numPedido}");
            foreach (DataRow row in lista.Rows)
            {
                string cod = biblioteca.FormatarDadoComZeros(4, $"{num_Item}");
                ListViewItem item = new ListViewItem(cod);
                item.SubItems.Add(biblioteca.FormatarDadoComZeros(4, row["codigo_produto"].ToString()));
                item.SubItems.Add(row["descricao"].ToString());
                item.SubItems.Add(biblioteca.FormatarDadoComZeros(4, row["quantidade"].ToString()));
                item.SubItems.Add($"{row["valor_unitario"]},00");
                item.SubItems.Add($"{row["total_item"]},00");
                listView1.Items.Add(item);
                num_Item++;
            }
        }
    }
}
