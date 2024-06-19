namespace WindowsFormsApp1
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
            this.comboBoxAlgorytm = new System.Windows.Forms.ComboBox();
            this.buttonGenerujKlucze = new System.Windows.Forms.Button();
            this.buttonSzyfruj = new System.Windows.Forms.Button();
            this.buttonDeszyfruj = new System.Windows.Forms.Button();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.textBoxIV = new System.Windows.Forms.TextBox();
            this.textBoxCipherTextASCII = new System.Windows.Forms.TextBox();
            this.textBoxCipherTextHEX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxAlgorytm
            // 
            this.comboBoxAlgorytm.FormattingEnabled = true;
            this.comboBoxAlgorytm.Location = new System.Drawing.Point(41, 36);
            this.comboBoxAlgorytm.Name = "comboBoxAlgorytm";
            this.comboBoxAlgorytm.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAlgorytm.TabIndex = 0;
            // 
            // buttonGenerujKlucze
            // 
            this.buttonGenerujKlucze.Location = new System.Drawing.Point(41, 93);
            this.buttonGenerujKlucze.Name = "buttonGenerujKlucze";
            this.buttonGenerujKlucze.Size = new System.Drawing.Size(121, 52);
            this.buttonGenerujKlucze.TabIndex = 1;
            this.buttonGenerujKlucze.Text = "Generuj Klucze";
            this.buttonGenerujKlucze.UseVisualStyleBackColor = true;
            this.buttonGenerujKlucze.Click += new System.EventHandler(this.buttonGenerujKlucze_Click);
            // 
            // buttonSzyfruj
            // 
            this.buttonSzyfruj.Location = new System.Drawing.Point(41, 173);
            this.buttonSzyfruj.Name = "buttonSzyfruj";
            this.buttonSzyfruj.Size = new System.Drawing.Size(121, 52);
            this.buttonSzyfruj.TabIndex = 2;
            this.buttonSzyfruj.Text = "Szyfruj";
            this.buttonSzyfruj.UseVisualStyleBackColor = true;
            this.buttonSzyfruj.Click += new System.EventHandler(this.buttonSzyfruj_Click);
            // 
            // buttonDeszyfruj
            // 
            this.buttonDeszyfruj.Location = new System.Drawing.Point(41, 248);
            this.buttonDeszyfruj.Name = "buttonDeszyfruj";
            this.buttonDeszyfruj.Size = new System.Drawing.Size(121, 52);
            this.buttonDeszyfruj.TabIndex = 3;
            this.buttonDeszyfruj.Text = "Deszyfruj";
            this.buttonDeszyfruj.UseVisualStyleBackColor = true;
            this.buttonDeszyfruj.Click += new System.EventHandler(this.buttonDeszyfruj_Click);
            // 
            // textBoxText
            // 
            this.textBoxText.Location = new System.Drawing.Point(213, 418);
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(359, 20);
            this.textBoxText.TabIndex = 4;
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(535, 79);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(217, 20);
            this.textBoxKey.TabIndex = 5;
            // 
            // textBoxIV
            // 
            this.textBoxIV.Location = new System.Drawing.Point(535, 125);
            this.textBoxIV.Name = "textBoxIV";
            this.textBoxIV.Size = new System.Drawing.Size(217, 20);
            this.textBoxIV.TabIndex = 6;
            // 
            // textBoxCipherTextASCII
            // 
            this.textBoxCipherTextASCII.Location = new System.Drawing.Point(535, 190);
            this.textBoxCipherTextASCII.Name = "textBoxCipherTextASCII";
            this.textBoxCipherTextASCII.Size = new System.Drawing.Size(217, 20);
            this.textBoxCipherTextASCII.TabIndex = 7;
            // 
            // textBoxCipherTextHEX
            // 
            this.textBoxCipherTextHEX.Location = new System.Drawing.Point(535, 248);
            this.textBoxCipherTextHEX.Name = "textBoxCipherTextHEX";
            this.textBoxCipherTextHEX.Size = new System.Drawing.Size(217, 20);
            this.textBoxCipherTextHEX.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(535, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Key";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(532, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "IV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(532, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "ASCII";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(532, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "HEX";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 402);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(288, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Wprowadź tekst do zaszyfrowania / szyfr do odszyfrowania:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCipherTextHEX);
            this.Controls.Add(this.textBoxCipherTextASCII);
            this.Controls.Add(this.textBoxIV);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.textBoxText);
            this.Controls.Add(this.buttonDeszyfruj);
            this.Controls.Add(this.buttonSzyfruj);
            this.Controls.Add(this.buttonGenerujKlucze);
            this.Controls.Add(this.comboBoxAlgorytm);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAlgorytm;
        private System.Windows.Forms.Button buttonGenerujKlucze;
        private System.Windows.Forms.Button buttonSzyfruj;
        private System.Windows.Forms.Button buttonDeszyfruj;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.TextBox textBoxIV;
        private System.Windows.Forms.TextBox textBoxCipherTextASCII;
        private System.Windows.Forms.TextBox textBoxCipherTextHEX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

