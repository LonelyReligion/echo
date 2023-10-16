namespace echo_ja
{
    partial class Form1
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
            tytul = new Label();
            instrukcja = new Label();
            uzyj_asm = new CheckBox();
            wybor_obrazu = new Button();
            start = new Button();
            opis_kontrolki_czas_wykonania = new Label();
            opis_kontrolki_status = new Label();
            numericUpDown1 = new NumericUpDown();
            ramka = new PictureBox();
            opis_kontrolki = new Label();
            status = new Label();
            czas_wykonania = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ramka).BeginInit();
            SuspendLayout();
            // 
            // tytul
            // 
            tytul.AutoSize = true;
            tytul.Location = new Point(28, 39);
            tytul.Name = "tytul";
            tytul.Size = new Size(40, 15);
            tytul.TabIndex = 0;
            tytul.Text = "TYTUŁ";
            // 
            // instrukcja
            // 
            instrukcja.AutoSize = true;
            instrukcja.Location = new Point(28, 68);
            instrukcja.Name = "instrukcja";
            instrukcja.Size = new Size(72, 15);
            instrukcja.TabIndex = 1;
            instrukcja.Text = "INSTRUKCJA";
            // 
            // uzyj_asm
            // 
            uzyj_asm.AutoSize = true;
            uzyj_asm.Location = new Point(31, 118);
            uzyj_asm.Name = "uzyj_asm";
            uzyj_asm.Size = new Size(108, 19);
            uzyj_asm.TabIndex = 2;
            uzyj_asm.Text = "użyj wersji .asm";
            uzyj_asm.UseVisualStyleBackColor = true;
            // 
            // wybor_obrazu
            // 
            wybor_obrazu.Location = new Point(22, 274);
            wybor_obrazu.Name = "wybor_obrazu";
            wybor_obrazu.Size = new Size(240, 23);
            wybor_obrazu.TabIndex = 3;
            wybor_obrazu.Text = "Wybierz obraz";
            wybor_obrazu.UseVisualStyleBackColor = true;
            // 
            // start
            // 
            start.Location = new Point(100, 316);
            start.Name = "start";
            start.Size = new Size(75, 23);
            start.TabIndex = 4;
            start.Text = "Wykonaj";
            start.UseVisualStyleBackColor = true;
            // 
            // opis_kontrolki_czas_wykonania
            // 
            opis_kontrolki_czas_wykonania.AutoSize = true;
            opis_kontrolki_czas_wykonania.Location = new Point(393, 19);
            opis_kontrolki_czas_wykonania.Name = "opis_kontrolki_czas_wykonania";
            opis_kontrolki_czas_wykonania.Size = new Size(94, 15);
            opis_kontrolki_czas_wykonania.TabIndex = 5;
            opis_kontrolki_czas_wykonania.Text = "Czas wykonania:";
            // 
            // opis_kontrolki_status
            // 
            opis_kontrolki_status.AutoSize = true;
            opis_kontrolki_status.Location = new Point(22, 444);
            opis_kontrolki_status.Name = "opis_kontrolki_status";
            opis_kontrolki_status.Size = new Size(42, 15);
            opis_kontrolki_status.TabIndex = 6;
            opis_kontrolki_status.Text = "Status:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(134, 158);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 7;
            // 
            // ramka
            // 
            ramka.Location = new Point(293, 83);
            ramka.Name = "ramka";
            ramka.Size = new Size(226, 256);
            ramka.TabIndex = 8;
            ramka.TabStop = false;
            // 
            // opis_kontrolki
            // 
            opis_kontrolki.AutoSize = true;
            opis_kontrolki.Location = new Point(28, 163);
            opis_kontrolki.Name = "opis_kontrolki";
            opis_kontrolki.Size = new Size(66, 15);
            opis_kontrolki.TabIndex = 9;
            opis_kontrolki.Text = "Ile wątków:";
            // 
            // status
            // 
            status.AutoSize = true;
            status.Location = new Point(77, 444);
            status.Name = "status";
            status.Size = new Size(38, 15);
            status.TabIndex = 10;
            status.Text = "status";
            // 
            // czas_wykonania
            // 
            czas_wykonania.AutoSize = true;
            czas_wykonania.Location = new Point(499, 21);
            czas_wykonania.Name = "czas_wykonania";
            czas_wykonania.Size = new Size(38, 15);
            czas_wykonania.TabIndex = 11;
            czas_wykonania.Text = "00 ms";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(546, 478);
            Controls.Add(czas_wykonania);
            Controls.Add(status);
            Controls.Add(opis_kontrolki);
            Controls.Add(ramka);
            Controls.Add(numericUpDown1);
            Controls.Add(opis_kontrolki_status);
            Controls.Add(opis_kontrolki_czas_wykonania);
            Controls.Add(start);
            Controls.Add(wybor_obrazu);
            Controls.Add(uzyj_asm);
            Controls.Add(instrukcja);
            Controls.Add(tytul);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ramka).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}