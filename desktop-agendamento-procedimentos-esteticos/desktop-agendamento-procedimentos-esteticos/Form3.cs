using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop_agendamento_procedimentos_esteticos
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        Texto texto = new Texto();

        private void PreencherListView(List<string> entrada)
        {
            listView1.Items.Clear();

            List<string> arquivo = entrada;

            if(arquivo.Count > 0)
            {
                foreach (string linha in arquivo)
                {
                    string[] dados = linha.Split('*', ';');

                    ListViewItem item = new ListViewItem(dados[0]);
                    item.SubItems.Add(dados[1]);
                    item.SubItems.Add(dados[2]);
                    item.SubItems.Add(dados[3]);
                    item.SubItems.Add(dados[4]);

                    listView1.Items.Add(item);
                }
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Add("Nome", 245, HorizontalAlignment.Left);
            listView1.Columns.Add("Telefone", 150, HorizontalAlignment.Right);
            listView1.Columns.Add("Procedimento", 160, HorizontalAlignment.Right);
            listView1.Columns.Add("Data", 140, HorizontalAlignment.Right);
            listView1.Columns.Add("Hora", 90, HorizontalAlignment.Right);

            PreencherListView(texto.LerArquivo());
        }

        private void btnBuscarData_Click(object sender, EventArgs e)
        {
            PreencherListView(texto.BuscarDados(dateTimeData.Value.ToShortDateString()));
        }

        private void btnBuscarNome_Click(object sender, EventArgs e)
        {
            PreencherListView(texto.BuscarDados(txtNome.Text.Trim()));
        }
    }
}
