
namespace desktop_reserva_hotel
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnConsultarReservas = new System.Windows.Forms.Button();
            this.btnNovaReserva = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.panelMenu.Controls.Add(this.btnConsultarReservas);
            this.panelMenu.Controls.Add(this.btnNovaReserva);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Location = new System.Drawing.Point(-1, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1017, 78);
            this.panelMenu.TabIndex = 0;
            // 
            // btnConsultarReservas
            // 
            this.btnConsultarReservas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConsultarReservas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConsultarReservas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultarReservas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.btnConsultarReservas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultarReservas.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultarReservas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.btnConsultarReservas.Location = new System.Drawing.Point(644, -11);
            this.btnConsultarReservas.Name = "btnConsultarReservas";
            this.btnConsultarReservas.Size = new System.Drawing.Size(271, 89);
            this.btnConsultarReservas.TabIndex = 2;
            this.btnConsultarReservas.Text = "Consultar Reservas";
            this.btnConsultarReservas.UseVisualStyleBackColor = false;
            this.btnConsultarReservas.Click += new System.EventHandler(this.btnConsultarReservas_Click);
            this.btnConsultarReservas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnConsultarReservas_MouseDown);
            // 
            // btnNovaReserva
            // 
            this.btnNovaReserva.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNovaReserva.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNovaReserva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovaReserva.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.btnNovaReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovaReserva.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovaReserva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.btnNovaReserva.Location = new System.Drawing.Point(373, -11);
            this.btnNovaReserva.Name = "btnNovaReserva";
            this.btnNovaReserva.Size = new System.Drawing.Size(271, 89);
            this.btnNovaReserva.TabIndex = 1;
            this.btnNovaReserva.Text = "Nova Reserva";
            this.btnNovaReserva.UseVisualStyleBackColor = false;
            this.btnNovaReserva.Click += new System.EventHandler(this.btnNovaReserva_Click);
            this.btnNovaReserva.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnNovaReserva_MouseDown);
            // 
            // btnHome
            // 
            this.btnHome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHome.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(98)))), ((int)(((byte)(204)))));
            this.btnHome.Location = new System.Drawing.Point(102, -11);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(271, 89);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            this.btnHome.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnHome_MouseDown);
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelMain.Location = new System.Drawing.Point(-2, 106);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1017, 426);
            this.panelMain.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1015, 532);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HOTEL";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnConsultarReservas;
        private System.Windows.Forms.Button btnNovaReserva;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panelMain;
    }
}

