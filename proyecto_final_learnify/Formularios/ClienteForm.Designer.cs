namespace proyecto_final_learnify.Formularios
{
    partial class ClienteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClienteForm));
            this.btnConectar = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.txtMensajes = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtEntrada = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(300, 20);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(94, 23);
            this.btnConectar.TabIndex = 0;
            this.btnConectar.Text = "Conectarse";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(45, 20);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(80, 22);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "IP";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(201, 20);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(80, 22);
            this.txtPuerto.TabIndex = 2;
            this.txtPuerto.Text = "Puerto";
            // 
            // txtMensajes
            // 
            this.txtMensajes.Location = new System.Drawing.Point(20, 60);
            this.txtMensajes.Multiline = true;
            this.txtMensajes.Name = "txtMensajes";
            this.txtMensajes.ReadOnly = true;
            this.txtMensajes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensajes.Size = new System.Drawing.Size(400, 300);
            this.txtMensajes.TabIndex = 3;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(330, 370);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(90, 23);
            this.btnEnviar.TabIndex = 4;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_click);
            // 
            // txtEntrada
            // 
            this.txtEntrada.Location = new System.Drawing.Point(20, 370);
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.Size = new System.Drawing.Size(300, 22);
            this.txtEntrada.TabIndex = 5;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(20, 406);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(400, 23);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Puerto:";
            // 
            // ClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtEntrada);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtMensajes);
            this.Controls.Add(this.txtPuerto);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnConectar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClienteForm";
            this.Text = "Cliente Learnify";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.TextBox txtMensajes;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtEntrada;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}