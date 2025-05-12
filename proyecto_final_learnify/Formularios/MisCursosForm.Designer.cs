namespace proyecto_final_learnify.Formularios
{
    partial class MisCursosForm
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
            this.lblMisCursos = new System.Windows.Forms.Label();
            this.flpCursos = new System.Windows.Forms.FlowLayoutPanel();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMisCursos
            // 
            this.lblMisCursos.AutoSize = true;
            this.lblMisCursos.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMisCursos.Location = new System.Drawing.Point(20, 20);
            this.lblMisCursos.Name = "lblMisCursos";
            this.lblMisCursos.Size = new System.Drawing.Size(276, 38);
            this.lblMisCursos.TabIndex = 0;
            this.lblMisCursos.Text = "Mis Cursos Inscritos";
            // 
            // flpCursos
            // 
            this.flpCursos.AutoScroll = true;
            this.flpCursos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpCursos.Location = new System.Drawing.Point(20, 60);
            this.flpCursos.Name = "flpCursos";
            this.flpCursos.Size = new System.Drawing.Size(740, 400);
            this.flpCursos.TabIndex = 1;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(655, 20);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 30);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_click);
            // 
            // MisCursosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 483);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.flpCursos);
            this.Controls.Add(this.lblMisCursos);
            this.Name = "MisCursosForm";
            this.Text = "Mis Cursos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMisCursos;
        private System.Windows.Forms.FlowLayoutPanel flpCursos;
        private System.Windows.Forms.Button btnVolver;
    }
}