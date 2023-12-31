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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Texto texto = new Texto();
        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if(txtNome.Text == string.Empty || maskedTBTelefone.Text == string.Empty || cBProcedimento.Text == string.Empty)
            {
                MessageBox.Show("Preencha todas as informações!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!maskedTBTelefone.MaskFull)
                {
                    MessageBox.Show("Campo 'telefone' não está no formato correto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult dialogResult = MessageBox.Show($"" +
                    $"Confirma os dados do agendamento?\n\n" +
                    $"Cliente: {txtNome.Text.Trim()}\n" +
                    //$"Tel: {txtTelefone.Text.Trim()}\n" +
                    $"Tel: {maskedTBTelefone.Text}\n" +
                    $"Procedimento: {cBProcedimento.Text}\n" +
                    $"Data: {dateTimeData.Value.ToShortDateString()}\n" +
                    $"Hora: {dateTimeHora.Value.ToShortTimeString()}", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if(dialogResult == DialogResult.Yes)
                {
                    string agendamento = $"" +
                        $"{txtNome.Text.Trim()}*" +
                        //$"{txtTelefone.Text.Trim()}*" +
                        $"{maskedTBTelefone.Text}*" +
                        $"{cBProcedimento.Text}*" +
                        $"{dateTimeData.Value.ToShortDateString()}*" +
                        $"{dateTimeHora.Value.ToShortTimeString()};";
                    
                    texto.Dados = agendamento;
                    texto.Gravar();

                    MessageBox.Show("Procedimento agendado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
