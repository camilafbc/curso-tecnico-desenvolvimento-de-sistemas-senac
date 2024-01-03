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
    public partial class UCConsulta : UserControl
    {
        public UCConsulta()
        {
            InitializeComponent();
        }

        Texto texto = new Texto();
        private string[] dados = new string[10];
        private void UCConsulta_Load(object sender, EventArgs e)
        {
            btnExcluir.Enabled = false;

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Add("CPF", 160, HorizontalAlignment.Left);
            listView1.Columns.Add("NOME", 220, HorizontalAlignment.Left);
            listView1.Columns.Add("E-MAIL", 250, HorizontalAlignment.Right);
            listView1.Columns.Add("TELEFONE", 170, HorizontalAlignment.Right);
            listView1.Columns.Add("ADULTOS", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("CRIANÇAS", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("QUARTO", 150, HorizontalAlignment.Right);
            listView1.Columns.Add("ENTRADA", 120, HorizontalAlignment.Right);
            listView1.Columns.Add("SAIDA", 120, HorizontalAlignment.Right);
            listView1.Columns.Add("VALOR", 130, HorizontalAlignment.Right);

            PreencherListView(texto.LerArquivo());
        }

        private void PreencherListView(List<string> entrada)
        {
            List<string> arquivo = entrada;

            listView1.Items.Clear();

            if (arquivo.Count > 0)
            {
                foreach (string linha in arquivo)
                {
                    string[] dados = linha.Split('*', ';');

                    ListViewItem item = new ListViewItem(dados[1]);
                    item.SubItems.Add(dados[2]);
                    item.SubItems.Add(dados[3]);
                    item.SubItems.Add(dados[4]);
                    item.SubItems.Add(dados[5]);
                    item.SubItems.Add(dados[6]);
                    item.SubItems.Add(dados[7]);
                    item.SubItems.Add(dados[8]);
                    item.SubItems.Add(dados[9]);
                    item.SubItems.Add(dados[10]);

                    listView1.Items.Add(item);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            PreencherListView(texto.BuscarDados($"{maskedTBCpf.Text}"));
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            btnExcluir.Enabled = true;

            ListViewItem itemSelecionado = listView1.SelectedItems[0];
            dados[0] = itemSelecionado.SubItems[0].Text;
            dados[1] = itemSelecionado.SubItems[1].Text;
            dados[2] = itemSelecionado.SubItems[2].Text;
            dados[3] = itemSelecionado.SubItems[3].Text;
            dados[4] = itemSelecionado.SubItems[4].Text;
            dados[5] = itemSelecionado.SubItems[5].Text;
            dados[6] = itemSelecionado.SubItems[6].Text;
            dados[7] = itemSelecionado.SubItems[7].Text;
            dados[8] = itemSelecionado.SubItems[8].Text;
            dados[9] = itemSelecionado.SubItems[9].Text;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                $"Deseja excluir a seguinte reserva?\n\n" +
                $"CPF: {dados[0]}\n" +
                $"Nome: {dados[1]}\n" +
                $"E-mail: {dados[2]}\n" +
                $"Telefone: {dados[3]}\n" +
                $"Nº Adultos: {dados[4]}\n" +
                $"Nº Crianças: {dados[5]}\n" +
                $"Quarto: {dados[6]}\n" +
                $"Entrada: {dados[7]}\n" +
                $"Saída: {dados[8]}\n" +
                $"Valor: {dados[9]}", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if(dialogResult == DialogResult.Yes)
            {
                string reserva = $"{dados[0]}*{dados[1]}*{dados[2]}*{dados[3]}*{dados[4]}*{dados[5]}*{dados[6]}*{dados[7]}*{dados[8]}*{dados[9]}";
                texto.ApagarDado(reserva);

                PreencherListView(texto.LerArquivo());

                MessageBox.Show("Reserva removida com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskedTBCpf.Text = "";
            }
        }
    }
}
