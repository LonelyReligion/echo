namespace ECHO
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.asmdll = new System.Windows.Forms.CheckBox();
            this.obraz = new System.Windows.Forms.PictureBox();
            this.opisczaswykonania = new System.Windows.Forms.Label();
            this.czaswykonania = new System.Windows.Forms.Label();
            this.opisstatus = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.tytul = new System.Windows.Forms.Label();
            this.opis1 = new System.Windows.Forms.Label();
            this.opis2 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.wybierz = new System.Windows.Forms.Button();
            this.opiswatkow = new System.Windows.Forms.Label();
            this.watki = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.obraz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.watki)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "BMP Files (*.bmp)|*.bmp";
            this.openFileDialog1.Title = "Wybierz plik bmp";
            // 
            // asmdll
            // 
            this.asmdll.AutoSize = true;
            this.asmdll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.asmdll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(154)))), ((int)(((byte)(178)))));
            this.asmdll.Location = new System.Drawing.Point(32, 301);
            this.asmdll.Name = "asmdll";
            this.asmdll.Size = new System.Drawing.Size(221, 28);
            this.asmdll.TabIndex = 14;
            this.asmdll.Text = "skorzystaj z wersji .asm";
            this.asmdll.UseVisualStyleBackColor = true;
            // 
            // obraz
            // 
            this.obraz.Location = new System.Drawing.Point(590, 79);
            this.obraz.Name = "obraz";
            this.obraz.Size = new System.Drawing.Size(512, 512);
            this.obraz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.obraz.TabIndex = 15;
            this.obraz.TabStop = false;
            // 
            // opisczaswykonania
            // 
            this.opisczaswykonania.AutoSize = true;
            this.opisczaswykonania.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.opisczaswykonania.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(115)))), ((int)(((byte)(150)))));
            this.opisczaswykonania.Location = new System.Drawing.Point(788, 31);
            this.opisczaswykonania.Name = "opisczaswykonania";
            this.opisczaswykonania.Size = new System.Drawing.Size(150, 24);
            this.opisczaswykonania.TabIndex = 16;
            this.opisczaswykonania.Text = "Czas wykonania:";
            this.opisczaswykonania.Click += new System.EventHandler(this.opisczaswykonania_Click);
            // 
            // czaswykonania
            // 
            this.czaswykonania.AutoSize = true;
            this.czaswykonania.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.czaswykonania.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(154)))), ((int)(((byte)(178)))));
            this.czaswykonania.Location = new System.Drawing.Point(964, 31);
            this.czaswykonania.Name = "czaswykonania";
            this.czaswykonania.Size = new System.Drawing.Size(138, 24);
            this.czaswykonania.TabIndex = 17;
            this.czaswykonania.Text = "0000000 tiknięć";
            this.czaswykonania.Click += new System.EventHandler(this.czaswykonania_Click);
            // 
            // opisstatus
            // 
            this.opisstatus.AutoSize = true;
            this.opisstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.opisstatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(115)))), ((int)(((byte)(150)))));
            this.opisstatus.Location = new System.Drawing.Point(12, 627);
            this.opisstatus.Name = "opisstatus";
            this.opisstatus.Size = new System.Drawing.Size(159, 24);
            this.opisstatus.TabIndex = 18;
            this.opisstatus.Text = "Status wykonania:";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(154)))), ((int)(((byte)(178)))));
            this.status.Location = new System.Drawing.Point(177, 627);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(105, 24);
            this.status.TabIndex = 19;
            this.status.Text = "zatrzymane";
            // 
            // tytul
            // 
            this.tytul.AutoSize = true;
            this.tytul.Font = new System.Drawing.Font("Microsoft Sans Serif", 68F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tytul.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(115)))), ((int)(((byte)(150)))));
            this.tytul.Location = new System.Drawing.Point(16, 79);
            this.tytul.Name = "tytul";
            this.tytul.Size = new System.Drawing.Size(307, 102);
            this.tytul.TabIndex = 20;
            this.tytul.Text = "ECHO";
            // 
            // opis1
            // 
            this.opis1.AutoSize = true;
            this.opis1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.opis1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(154)))), ((int)(((byte)(178)))));
            this.opis1.Location = new System.Drawing.Point(27, 201);
            this.opis1.Name = "opis1";
            this.opis1.Size = new System.Drawing.Size(405, 31);
            this.opis1.TabIndex = 21;
            this.opis1.Text = "Wczytaj obraz w formacie .bmp, ";
            // 
            // opis2
            // 
            this.opis2.AutoSize = true;
            this.opis2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.opis2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(154)))), ((int)(((byte)(178)))));
            this.opis2.Location = new System.Drawing.Point(27, 232);
            this.opis2.Name = "opis2";
            this.opis2.Size = new System.Drawing.Size(474, 31);
            this.opis2.TabIndex = 22;
            this.opis2.Text = "na którym chcesz uzyskać efekt echa.";
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.start.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(154)))), ((int)(((byte)(178)))));
            this.start.Location = new System.Drawing.Point(32, 482);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(126, 39);
            this.start.TabIndex = 25;
            this.start.Text = "Wykonaj";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click_1);
            // 
            // wybierz
            // 
            this.wybierz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(115)))), ((int)(((byte)(150)))));
            this.wybierz.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wybierz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(207)))), ((int)(((byte)(227)))));
            this.wybierz.Location = new System.Drawing.Point(32, 417);
            this.wybierz.Name = "wybierz";
            this.wybierz.Size = new System.Drawing.Size(468, 46);
            this.wybierz.TabIndex = 26;
            this.wybierz.Text = "Wybierz obraz na dysku";
            this.wybierz.UseVisualStyleBackColor = false;
            this.wybierz.Click += new System.EventHandler(this.wybierz_Click);
            // 
            // opiswatkow
            // 
            this.opiswatkow.AutoSize = true;
            this.opiswatkow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.opiswatkow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(154)))), ((int)(((byte)(178)))));
            this.opiswatkow.Location = new System.Drawing.Point(28, 349);
            this.opiswatkow.Name = "opiswatkow";
            this.opiswatkow.Size = new System.Drawing.Size(130, 24);
            this.opiswatkow.TabIndex = 27;
            this.opiswatkow.Text = "liczba wątków:";
            // 
            // watki
            // 
            this.watki.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.watki.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.watki.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(154)))), ((int)(((byte)(178)))));
            this.watki.Location = new System.Drawing.Point(175, 347);
            this.watki.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.watki.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.watki.Name = "watki";
            this.watki.Size = new System.Drawing.Size(120, 29);
            this.watki.TabIndex = 28;
            this.watki.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.watki.ValueChanged += new System.EventHandler(this.watki_ValueChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(115)))), ((int)(((byte)(150)))));
            this.button1.Location = new System.Drawing.Point(968, 612);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 38);
            this.button1.TabIndex = 29;
            this.button1.Text = "Save as...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(207)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(1132, 670);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.watki);
            this.Controls.Add(this.opiswatkow);
            this.Controls.Add(this.wybierz);
            this.Controls.Add(this.start);
            this.Controls.Add(this.opis2);
            this.Controls.Add(this.opis1);
            this.Controls.Add(this.tytul);
            this.Controls.Add(this.status);
            this.Controls.Add(this.opisstatus);
            this.Controls.Add(this.czaswykonania);
            this.Controls.Add(this.opisczaswykonania);
            this.Controls.Add(this.obraz);
            this.Controls.Add(this.asmdll);
            this.Name = "Form1";
            this.Text = "ECHO";
            ((System.ComponentModel.ISupportInitialize)(this.obraz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.watki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox asmdll;
        private System.Windows.Forms.PictureBox obraz;
        private System.Windows.Forms.Label opisczaswykonania;
        private System.Windows.Forms.Label czaswykonania;
        private System.Windows.Forms.Label opisstatus;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label tytul;
        private System.Windows.Forms.Label opis1;
        private System.Windows.Forms.Label opis2;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button wybierz;
        private System.Windows.Forms.Label opiswatkow;
        private System.Windows.Forms.NumericUpDown watki;
        private System.Windows.Forms.Button button1;
    }
}

