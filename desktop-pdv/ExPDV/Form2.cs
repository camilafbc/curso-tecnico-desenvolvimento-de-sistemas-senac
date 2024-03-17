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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Conexao conn = new Conexao();
        Biblioteca biblioteca = new Biblioteca();

        private string codigo_pedido; 
        private string valor;
        private string produtoCancelar;
        private int codToCancel;
        private int qtdToCancel;

        private void CriarPedido()
        {
            DataTable resultado = conn.GetData("SELECT LAST_INSERT_ID(codigo_compra) FROM ex_pdv_vendas");
            int num_compra = 0;

            if (resultado != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    num_compra = int.Parse(row["LAST_INSERT_ID()"].ToString());
                }
            }

            codigo_pedido = $"{(num_compra + 1)}";

            lblNumPedido.Text = $"COMPRA Nº {lblNumPedido.Text = biblioteca.FormatarDadoComZeros(4, codigo_pedido)}";

            txtCod.Enabled = true;
            txtCod.Focus();
            btnAdicionar.Enabled = true;
            btnNovaCompra.Enabled = false;
        }

        public void ReiniciarForm2()
        {
            listView1.Items.Clear();
            lblNumPedido.Text = "";
            lblTotalCompra.Text = "";
            txtQtd.Clear();

            lblItem.Text = "";
            lblProduto.Text = "";
            lblDesc.Text = "";
            lblValorUni.Text = "";
            lblSubTotal.Text = "";
            lblTotal.Text = "";

            txtCod.Enabled = false;
            txtQtd.Enabled = false;
            btnAdicionar.Enabled = false;
            button1.Enabled = false;
            btnCancelarItem.Enabled = false;
            btnNovaCompra.Enabled = true;

            lblNumPedido.Text = $"CAIXA LIVRE";
        }

        private void PreencherListView(string query)
        {
            int contador = 1;
            DataTable lista = conn.GetData(query);
            foreach (DataRow row in lista.Rows)
            {
                ListViewItem item = new ListViewItem(biblioteca.FormatarDadoComZeros(4, $"{contador}"));
                item.SubItems.Add(biblioteca.FormatarDadoComZeros(4, row["codigo_produto"].ToString()));
                item.SubItems.Add(row["descricao"].ToString());
                item.SubItems.Add(biblioteca.FormatarDadoComZeros(4, row["quantidade"].ToString()));
                item.SubItems.Add($"{row["valor_unitario"]},00");
                item.SubItems.Add($"{row["total_item"]},00");
                contador++;
                listView1.Items.Add(item);
            }
        }

        private int PegarTotalCompra(int numPedido)
        {
            int totalCompra = 0;
            DataTable total = conn.GetData($"SELECT SUM(`ex_pdv_vendas`.`quantidade` * `ex_pdv_vendas`.`valor_unitario`) AS total_compra FROM `ex_pdv_vendas` INNER JOIN `ex_pdv` ON `ex_pdv_vendas`.`codigo_produto` = `ex_pdv`.`codigo` WHERE `ex_pdv_vendas`.`codigo_compra` = {numPedido} GROUP BY `ex_pdv_vendas`.`codigo_compra`");
            foreach (DataRow row in total.Rows)
            {
                totalCompra = int.Parse(row["total_compra"].ToString());
            }
            return totalCompra;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = $"CAIXA - {Program.nome_caixa}";
            lblNumPedido.Text = $"CAIXA LIVRE";

            lblTimer.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();

            listView1.Columns.Add("ITEM", 65, HorizontalAlignment.Left);
            listView1.Columns.Add("COD", 62, HorizontalAlignment.Left);
            listView1.Columns.Add("DESCRIÇÃO", 300, HorizontalAlignment.Left);
            listView1.Columns.Add("QTD", 64, HorizontalAlignment.Center);
            listView1.Columns.Add("VL UNIT", 80, HorizontalAlignment.Right);
            listView1.Columns.Add("TOTAL", 70, HorizontalAlignment.Right);

            txtCod.Enabled = false;
            txtQtd.Enabled = false;
            btnAdicionar.Enabled = false;
            button1.Enabled = false;
            btnCancelarItem.Enabled = false;
            btnNovaCompra.Enabled = true;

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

           btnNovaCompra.Focus();
        }

        private void txtQtd_TextChanged(object sender, EventArgs e)
        {
            int valor2 = int.Parse(valor);

            if (txtQtd.Text == "")
            {
                lblQtd.Text = "";
                lblSubTotal.Text = "";
                lblTotal.Text = "";
                txtQtd.Clear();
                txtQtd.Focus();
            }
            else if (txtQtd.Text != "")
            {
                int entrada;
                bool isNum = int.TryParse(txtQtd.Text, out entrada);

                if (isNum)
                {
                    if(entrada == 0)
                    {
                        MessageBox.Show("Quantidade Inválida!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtQtd.Clear();
                        txtQtd.Focus();
                    }
                    else
                    {
                        lblQtd.Text = txtQtd.Text;
                        int subtotal = valor2 * int.Parse(lblQtd.Text);
                        lblSubTotal.Text = $"R$ {subtotal},00";
                        lblTotal.Text = $"R$ {subtotal},00";

                        btnAdicionar.Enabled = true;
                        button1.Enabled = true;
                    }
                } else
                {
                    MessageBox.Show("Entrada Inválida!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQtd.Clear();
                    txtQtd.Focus();
                }
            }
        }

        private int quantidadeEstoque;
        private void txtCod_Leave(object sender, EventArgs e)
        {
            if(txtCod.Text != "")
            {

                bool isNum = int.TryParse(txtCod.Text, out int entrada);

                if (isNum)
                {
                    int buscarCodigo = conn.QuantidadeRegistros($"SELECT codigo FROM ex_pdv WHERE codigo='{txtCod.Text}'");

                    if (buscarCodigo <= 0)
                    {
                        MessageBox.Show("Código não encontrado!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCod.Clear();
                        txtCod.Focus();
                    }
                    else if (buscarCodigo > 0)
                    {
                        DataTable lista = conn.GetData($"SELECT descricao, valor_unitario, quantidade FROM ex_pdv WHERE codigo='{txtCod.Text}'");
                        foreach (DataRow row in lista.Rows)
                        {
                            txtCod.Text = biblioteca.FormatarDadoComZeros(4, $"{txtCod.Text}");
                            lblProduto.Text = row["descricao"].ToString();
                            lblDesc.Text = row["descricao"].ToString();
                            valor = row["valor_unitario"].ToString();
                            quantidadeEstoque = int.Parse(row["quantidade"].ToString());
                            lblValorUni.Text = $"R$ {valor},00";
                            int count = listView1.Items.Count;
                            lblItem.Text = biblioteca.FormatarDadoComZeros(4, (count + 1).ToString());
                        }

                        txtQtd.Enabled = true;
                        txtQtd.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Código inválido!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCod.Clear();
                    txtCod.Focus();
                }

            }
            
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string codigo_produto = txtCod.Text;
            int quantidade = int.Parse(lblQtd.Text);
            int valor_unitario = int.Parse(valor);

            if (quantidadeEstoque >= quantidade)
            {
                conn.InserirItens(int.Parse(codigo_pedido), int.Parse(codigo_produto), quantidade, valor_unitario, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), int.Parse(Program.cod_caixa), "Andamento", "Em Aberto");
                conn.AtualizarEstoque((quantidadeEstoque - quantidade), int.Parse(codigo_produto));

                if (listView1.Items != null)
                {
                    listView1.Items.Clear();
                    PreencherListView($"SELECT `ex_pdv_vendas`.`codigo_produto`, `ex_pdv`.`descricao`, `ex_pdv_vendas`.`quantidade`, `ex_pdv_vendas`.`valor_unitario`, `ex_pdv_vendas`.`quantidade` * `ex_pdv_vendas`.`valor_unitario` AS total_item FROM `ex_pdv_vendas` INNER JOIN `ex_pdv` ON `ex_pdv_vendas`.`codigo_produto` = `ex_pdv`.`codigo` WHERE `ex_pdv_vendas`.`codigo_compra`={codigo_pedido}");
                }

                lblTotalCompra.Text = $"R$ {PegarTotalCompra(int.Parse(codigo_pedido))},00";

                lblItem.Text = "";
                lblProduto.Text = "";
                lblDesc.Text = "";
                lblValorUni.Text = "";
                lblSubTotal.Text = "";
                lblTotal.Text = "";
                txtQtd.Clear();
                txtCod.Clear();
                txtCod.Focus();

                button1.Enabled = true;
                btnCancelarItem.Enabled = true;
            }
            else
            {
                MessageBox.Show($"Quantidade informada é maior do que a quantidade do produto em estoque ({quantidadeEstoque} unidades)", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            int valor_compra = PegarTotalCompra(int.Parse(codigo_pedido));
            Form10 form10 = new Form10(codigo_pedido, valor_compra);
            form10.Show();
        }

        private void btnCancelarItem_Click(object sender, EventArgs e)
        {
            if(codToCancel == 0)
            {
                MessageBox.Show("Nenhum item selecionado!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show($"Deseja mesmo cancelar o item?\n\nCOD: {biblioteca.FormatarDadoComZeros(4, codToCancel.ToString())}\nPROD: {produtoCancelar}\n", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    bool removerItem = conn.ExecuteQuery($"DELETE FROM ex_pdv_vendas WHERE codigo_compra={int.Parse(codigo_pedido)} AND codigo_produto={codToCancel}");
                    if (removerItem)
                    {
                        conn.AtualizarEstoque(quantidadeEstoque + qtdToCancel, int.Parse(codigo_pedido));

                        listView1.Items.Clear();
                        PreencherListView($"SELECT `ex_pdv_vendas`.`codigo_produto`, `ex_pdv`.`descricao`, `ex_pdv_vendas`.`quantidade`, `ex_pdv_vendas`.`valor_unitario`, `ex_pdv_vendas`.`quantidade` * `ex_pdv_vendas`.`valor_unitario` AS total_item FROM `ex_pdv_vendas` INNER JOIN `ex_pdv` ON `ex_pdv_vendas`.`codigo_produto` = `ex_pdv`.`codigo` WHERE `ex_pdv_vendas`.`codigo_compra`={codigo_pedido}");
                        lblTotalCompra.Text = $"R$ {PegarTotalCompra(int.Parse(codigo_pedido))},00";

                        MessageBox.Show("Produto cancelado!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtCod.Focus();
                    }
                }
            } 
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            ListViewItem itemSelecionado = listView1.SelectedItems[0];
            codToCancel = int.Parse(itemSelecionado.SubItems[1].Text);
            produtoCancelar = itemSelecionado.SubItems[2].Text;
            qtdToCancel = int.Parse(itemSelecionado.SubItems[3].Text);
        }

        private void btnNovaCompra_Click(object sender, EventArgs e)
        {
            CriarPedido();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F3)
            {
                btnNovaCompra.PerformClick();
            }
        }

        private void txtQtd_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F4)
            {
                btnAdicionar.PerformClick();
            }
        }

        private void txtCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                button1.PerformClick();
            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                ListViewItem itemSelecionado = listView1.SelectedItems[0];
                codToCancel = int.Parse(itemSelecionado.SubItems[1].Text);
                produtoCancelar = itemSelecionado.SubItems[2].Text;
                btnCancelarItem.PerformClick();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnNovaCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                btnNovaCompra.PerformClick();
            }
        }
    }
}
