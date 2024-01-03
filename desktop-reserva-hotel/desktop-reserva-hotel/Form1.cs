using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using desktop_reserva_hotel.UserControls;

namespace desktop_reserva_hotel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UCHome ucHome = new UCHome();
            AddUserControl(ucHome);
            btnHome.FlatAppearance.BorderColor = SystemColors.ControlLightLight;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            UCHome ucHome = new UCHome();
            AddUserControl(ucHome);
        }

        private void btnNovaReserva_Click(object sender, EventArgs e)
        {
            UCNovaReserva ucNovaReserva = new UCNovaReserva();
            AddUserControl(ucNovaReserva);
        }

        private void btnConsultarReservas_Click(object sender, EventArgs e)
        {
            UCConsulta ucConsulta = new UCConsulta();
            AddUserControl(ucConsulta);
        }

        private void btnHome_MouseDown(object sender, MouseEventArgs e)
        {
            btnHome.FlatAppearance.BorderColor = SystemColors.ControlLightLight;
            btnNovaReserva.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#3362CC");
            btnConsultarReservas.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#3362CC");
        }

        private void btnNovaReserva_MouseDown(object sender, MouseEventArgs e)
        {
            btnNovaReserva.FlatAppearance.BorderColor = SystemColors.ControlLightLight;
            btnHome.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#3362CC");
            btnConsultarReservas.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#3362CC");
        }

        private void btnConsultarReservas_MouseDown(object sender, MouseEventArgs e)
        {
            btnConsultarReservas.FlatAppearance.BorderColor = SystemColors.ControlLightLight;
            btnNovaReserva.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#3362CC");
            btnHome.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#3362CC");
        }
    }
}
