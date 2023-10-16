namespace echo_ja
{
    partial class ECHO
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tytul = new System.Windows.Forms.Label();
            this.instrukcja = new System.Windows.Forms.Label();
            this.uzyj_asm = new System.Windows.Forms.CheckBox();
            this.wybor_obrazu = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.opis_kontrolki_czas_wykonania = new System.Windows.Forms.Label();
            this.opis_kontrolki_status = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.ramka = new System.Windows.Forms.PictureBox();
            this.opis_kontrolki = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.czas_wykonania = new System.Windows.Forms.Label();
            this.instrukcja_cd = new System.Windows.Forms.Label();
            this.okno_plikow = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramka)).BeginInit();
            this.SuspendLayout();
            // 
            // tytul
            // 
            this.tytul.AutoSize = true;
            this.tytul.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tytul.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(115)))), ((int)(((byte)(150)))));
            this.tytul.Location = new System.Drawing.Point(23, 48);
            this.tytul.Name = "tytul";
            this.tytul.Size = new System.Drawing.Size(169, 72);
            this.tytul.TabIndex = 0;
            this.tytul.Text = "ECHO";
            // 
            // instrukcja
            // 
            this.instrukcja.AutoSize = true;
            this.instrukcja.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.instrukcja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(115)))), ((int)(((byte)(150)))));
            this.instrukcja.Location = new System.Drawing.Point(23, 134);
            this.instrukcja.Name = "instrukcja";
            this.instrukcja.Size = new System.Drawing.Size(404, 37);
            this.instrukcja.TabIndex = 1;
            this.instrukcja.Text = "Wczytaj obraz, na którym chcesz ";
            // 
            // uzyj_asm
            // 
            this.uzyj_asm.AutoSize = true;
            this.uzyj_asm.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uzyj_asm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(154)))), ((int)(((byte)(178)))));
            this.uzyj_asm.Location = new System.Drawing.Point(23, 263);
            this.uzyj_asm.Name = "uzyj_asm";
            this.uzyj_asm.Size = new System.Drawing.Size(198, 36);
            this.uzyj_asm.TabIndex = 2;
            this.uzyj_asm.Text = "użyj wersji .asm";
            this.uzyj_asm.UseVisualStyleBackColor = true;
            // 
            // wybor_obrazu
            // 
            this.wybor_obrazu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(115)))), ((int)(((byte)(150)))));
            this.wybor_obrazu.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.wybor_obrazu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(207)))), ((int)(((byte)(227)))));
            this.wybor_obrazu.Location = new System.Drawing.Point(23, 438);
            this.wybor_obrazu.Name = "wybor_obrazu";
            this.wybor_obrazu.Size = new System.Drawing.Size(404, 48);
            this.wybor_obrazu.TabIndex = 3;
            this.wybor_obrazu.Text = "Wybierz obraz na dysku";
            this.wybor_obrazu.UseVisualStyleBackColor = false;
            this.wybor_obrazu.Click += new System.EventHandler(this.wybor_obrazu_Click);
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.start.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.start.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(115)))), ((int)(((byte)(150)))));
            this.start.Location = new System.Drawing.Point(23, 517);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(150, 43);
            this.start.TabIndex = 4;
            this.start.Text = "Wykonaj";
            this.start.UseVisualStyleBackColor = false;
            // 
            // opis_kontrolki_czas_wykonania
            // 
            this.opis_kontrolki_czas_wykonania.AutoSize = true;
            this.opis_kontrolki_czas_wykonania.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.opis_kontrolki_czas_wykonania.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(115)))), ((int)(((byte)(150)))));
            this.opis_kontrolki_czas_wykonania.Location = new System.Drawing.Point(820, 613);
            this.opis_kontrolki_czas_wykonania.Name = "opis_kontrolki_czas_wykonania";
            this.opis_kontrolki_czas_wykonania.Size = new System.Drawing.Size(150, 25);
            this.opis_kontrolki_czas_wykonania.TabIndex = 5;
            this.opis_kontrolki_czas_wykonania.Text = "Czas wykonania:";
            // 
            // opis_kontrolki_status
            // 
            this.opis_kontrolki_status.AutoSize = true;
            this.opis_kontrolki_status.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.opis_kontrolki_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(115)))), ((int)(((byte)(150)))));
            this.opis_kontrolki_status.Location = new System.Drawing.Point(23, 613);
            this.opis_kontrolki_status.Name = "opis_kontrolki_status";
            this.opis_kontrolki_status.Size = new System.Drawing.Size(66, 25);
            this.opis_kontrolki_status.TabIndex = 6;
            this.opis_kontrolki_status.Text = "Status:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(115)))), ((int)(((byte)(150)))));
            this.numericUpDown1.Location = new System.Drawing.Point(307, 330);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 39);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ramka
            // 
            this.ramka.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ramka.Location = new System.Drawing.Point(542, 48);
            this.ramka.Name = "ramka";
            this.ramka.Size = new System.Drawing.Size(512, 512);
            this.ramka.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ramka.TabIndex = 8;
            this.ramka.TabStop = false;
            // 
            // opis_kontrolki
            // 
            this.opis_kontrolki.AutoSize = true;
            this.opis_kontrolki.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.opis_kontrolki.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(115)))), ((int)(((byte)(150)))));
            this.opis_kontrolki.Location = new System.Drawing.Point(23, 332);
            this.opis_kontrolki.Name = "opis_kontrolki";
            this.opis_kontrolki.Size = new System.Drawing.Size(131, 32);
            this.opis_kontrolki.TabIndex = 9;
            this.opis_kontrolki.Text = "Ile wątków:";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(154)))), ((int)(((byte)(178)))));
            this.status.Location = new System.Drawing.Point(93, 613);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(61, 25);
            this.status.TabIndex = 10;
            this.status.Text = "status";
            // 
            // czas_wykonania
            // 
            this.czas_wykonania.AutoSize = true;
            this.czas_wykonania.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.czas_wykonania.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(154)))), ((int)(((byte)(178)))));
            this.czas_wykonania.Location = new System.Drawing.Point(993, 613);
            this.czas_wykonania.Name = "czas_wykonania";
            this.czas_wykonania.Size = new System.Drawing.Size(61, 25);
            this.czas_wykonania.TabIndex = 11;
            this.czas_wykonania.Text = "00 ms";
            this.czas_wykonania.Click += new System.EventHandler(this.czas_wykonania_Click);
            // 
            // instrukcja_cd
            // 
            this.instrukcja_cd.AutoSize = true;
            this.instrukcja_cd.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.instrukcja_cd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(115)))), ((int)(((byte)(150)))));
            this.instrukcja_cd.Location = new System.Drawing.Point(23, 180);
            this.instrukcja_cd.Name = "instrukcja_cd";
            this.instrukcja_cd.Size = new System.Drawing.Size(162, 32);
            this.instrukcja_cd.TabIndex = 12;
            this.instrukcja_cd.Text = "uzyskać efekt.";
            // 
            // okno_plikow
            // 
            this.okno_plikow.FileName = "openFileDialog1";
            this.okno_plikow.Filter = "pliki .bmp|*.bmp";
            // 
            // ECHO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(207)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(1078, 677);
            this.Controls.Add(this.instrukcja_cd);
            this.Controls.Add(this.czas_wykonania);
            this.Controls.Add(this.status);
            this.Controls.Add(this.opis_kontrolki);
            this.Controls.Add(this.ramka);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.opis_kontrolki_status);
            this.Controls.Add(this.opis_kontrolki_czas_wykonania);
            this.Controls.Add(this.start);
            this.Controls.Add(this.wybor_obrazu);
            this.Controls.Add(this.uzyj_asm);
            this.Controls.Add(this.instrukcja);
            this.Controls.Add(this.tytul);
            this.Name = "ECHO";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramka)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label tytul;
        private Label instrukcja;
        private CheckBox uzyj_asm;
        private Button wybor_obrazu;
        private Button start;
        private Label opis_kontrolki_czas_wykonania;
        private Label opis_kontrolki_status;
        private NumericUpDown numericUpDown1;
        private PictureBox ramka;
        private Label opis_kontrolki;
        private Label status;
        private Label czas_wykonania;
        private Label instrukcja_cd;
        private OpenFileDialog okno_plikow;
    }
}