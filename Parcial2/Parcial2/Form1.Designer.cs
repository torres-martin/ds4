namespace Parcial2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnGalones = new System.Windows.Forms.Button();
            this.btnLitros = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConversion = new System.Windows.Forms.TextBox();
            this.listBD = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Introduzca un valor:";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(162, 38);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(172, 22);
            this.txtValor.TabIndex = 1;
            // 
            // btnGalones
            // 
            this.btnGalones.Location = new System.Drawing.Point(162, 76);
            this.btnGalones.Name = "btnGalones";
            this.btnGalones.Size = new System.Drawing.Size(83, 44);
            this.btnGalones.TabIndex = 2;
            this.btnGalones.Text = "Convertir a galones";
            this.btnGalones.UseVisualStyleBackColor = true;
            this.btnGalones.Click += new System.EventHandler(this.btnGalones_Click);
            // 
            // btnLitros
            // 
            this.btnLitros.Location = new System.Drawing.Point(251, 76);
            this.btnLitros.Name = "btnLitros";
            this.btnLitros.Size = new System.Drawing.Size(83, 44);
            this.btnLitros.TabIndex = 3;
            this.btnLitros.Text = "Convertir a litros";
            this.btnLitros.UseVisualStyleBackColor = true;
            this.btnLitros.Click += new System.EventHandler(this.btnLitros_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Resultado de la conversion:";
            // 
            // txtConversion
            // 
            this.txtConversion.Location = new System.Drawing.Point(215, 148);
            this.txtConversion.Name = "txtConversion";
            this.txtConversion.Size = new System.Drawing.Size(119, 22);
            this.txtConversion.TabIndex = 5;
            // 
            // listBD
            // 
            this.listBD.FormattingEnabled = true;
            this.listBD.ItemHeight = 16;
            this.listBD.Location = new System.Drawing.Point(38, 211);
            this.listBD.Name = "listBD";
            this.listBD.Size = new System.Drawing.Size(296, 148);
            this.listBD.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Registro de conversiones:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(73, 79);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(83, 41);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(38, 365);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(73, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Salir";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Mostrar lista";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 396);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBD);
            this.Controls.Add(this.txtConversion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLitros);
            this.Controls.Add(this.btnGalones);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Conversor de galones o litros";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnGalones;
        private System.Windows.Forms.Button btnLitros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConversion;
        private System.Windows.Forms.ListBox listBD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
    }
}

