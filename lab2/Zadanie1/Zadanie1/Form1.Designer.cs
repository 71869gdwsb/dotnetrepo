namespace Zadanie1
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxDzielna = new System.Windows.Forms.TextBox();
            this.textBoxDzielnik = new System.Windows.Forms.TextBox();
            this.textBoxWynik = new System.Windows.Forms.TextBox();
            this.labelDzielna = new System.Windows.Forms.Label();
            this.labelDzielnik = new System.Windows.Forms.Label();
            this.labelWynik = new System.Windows.Forms.Label();
            this.buttonDzielenie = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxDzielna
            // 
            this.textBoxDzielna.Location = new System.Drawing.Point(78, 197);
            this.textBoxDzielna.Name = "textBoxDzielna";
            this.textBoxDzielna.Size = new System.Drawing.Size(100, 20);
            this.textBoxDzielna.TabIndex = 0;
            // 
            // textBoxDzielnik
            // 
            this.textBoxDzielnik.Location = new System.Drawing.Point(231, 197);
            this.textBoxDzielnik.Name = "textBoxDzielnik";
            this.textBoxDzielnik.Size = new System.Drawing.Size(100, 20);
            this.textBoxDzielnik.TabIndex = 1;
            // 
            // textBoxWynik
            // 
            this.textBoxWynik.Location = new System.Drawing.Point(499, 197);
            this.textBoxWynik.Name = "textBoxWynik";
            this.textBoxWynik.ReadOnly = true;
            this.textBoxWynik.Size = new System.Drawing.Size(100, 20);
            this.textBoxWynik.TabIndex = 2;
            // 
            // labelDzielna
            // 
            this.labelDzielna.AutoSize = true;
            this.labelDzielna.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDzielna.Location = new System.Drawing.Point(61, 145);
            this.labelDzielna.Name = "labelDzielna";
            this.labelDzielna.Size = new System.Drawing.Size(141, 39);
            this.labelDzielna.TabIndex = 3;
            this.labelDzielna.Text = "Dzielna:";
            this.labelDzielna.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelDzielnik
            // 
            this.labelDzielnik.AutoSize = true;
            this.labelDzielnik.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDzielnik.Location = new System.Drawing.Point(215, 146);
            this.labelDzielnik.Name = "labelDzielnik";
            this.labelDzielnik.Size = new System.Drawing.Size(147, 39);
            this.labelDzielnik.TabIndex = 4;
            this.labelDzielnik.Text = "Dzielnik:";
            // 
            // labelWynik
            // 
            this.labelWynik.AutoSize = true;
            this.labelWynik.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelWynik.Location = new System.Drawing.Point(493, 146);
            this.labelWynik.Name = "labelWynik";
            this.labelWynik.Size = new System.Drawing.Size(119, 39);
            this.labelWynik.TabIndex = 5;
            this.labelWynik.Text = "Wynik:";
            // 
            // buttonDzielenie
            // 
            this.buttonDzielenie.Location = new System.Drawing.Point(313, 279);
            this.buttonDzielenie.Name = "buttonDzielenie";
            this.buttonDzielenie.Size = new System.Drawing.Size(177, 65);
            this.buttonDzielenie.TabIndex = 6;
            this.buttonDzielenie.Text = "Podziel";
            this.buttonDzielenie.UseVisualStyleBackColor = true;
            this.buttonDzielenie.Click += new System.EventHandler(this.buttonDzielenie_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDzielenie);
            this.Controls.Add(this.labelWynik);
            this.Controls.Add(this.labelDzielnik);
            this.Controls.Add(this.labelDzielna);
            this.Controls.Add(this.textBoxWynik);
            this.Controls.Add(this.textBoxDzielnik);
            this.Controls.Add(this.textBoxDzielna);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDzielna;
        private System.Windows.Forms.TextBox textBoxDzielnik;
        private System.Windows.Forms.TextBox textBoxWynik;
        private System.Windows.Forms.Label labelDzielna;
        private System.Windows.Forms.Label labelDzielnik;
        private System.Windows.Forms.Label labelWynik;
        private System.Windows.Forms.Button buttonDzielenie;
    }
}

