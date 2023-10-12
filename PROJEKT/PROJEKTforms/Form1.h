#pragma once

namespace CppCLRWinFormsProject {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Form1
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^ label1;
	private: System::Windows::Forms::Button^ wybierz_obraz;



	private: System::Windows::Forms::CheckBox^ checkBox1;

	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::PictureBox^ pictureBox1;
	private: System::Windows::Forms::Label^ label3;
	private: System::Windows::Forms::Label^ label4;
	private: System::Windows::Forms::Label^ label5;
	private: System::Windows::Forms::Button^ start;
	private: System::Windows::Forms::Label^ status;
	private: System::Windows::Forms::NumericUpDown^ numericUpDown1;
	private: System::Windows::Forms::Label^ watki_info;


	protected:

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->wybierz_obraz = (gcnew System::Windows::Forms::Button());
			this->checkBox1 = (gcnew System::Windows::Forms::CheckBox());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->pictureBox1 = (gcnew System::Windows::Forms::PictureBox());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->start = (gcnew System::Windows::Forms::Button());
			this->status = (gcnew System::Windows::Forms::Label());
			this->numericUpDown1 = (gcnew System::Windows::Forms::NumericUpDown());
			this->watki_info = (gcnew System::Windows::Forms::Label());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->numericUpDown1))->BeginInit();
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 22, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->label1->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(226)), static_cast<System::Int32>(static_cast<System::Byte>(115)),
				static_cast<System::Int32>(static_cast<System::Byte>(150)));
			this->label1->Location = System::Drawing::Point(31, 100);
			this->label1->Margin = System::Windows::Forms::Padding(8, 0, 8, 0);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(457, 36);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Wczytaj obraz, na którym chcesz ";
			this->label1->Click += gcnew System::EventHandler(this, &Form1::label1_Click);
			// 
			// wybierz_obraz
			// 
			this->wybierz_obraz->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(226)), static_cast<System::Int32>(static_cast<System::Byte>(115)),
				static_cast<System::Int32>(static_cast<System::Byte>(150)));
			this->wybierz_obraz->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 14, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->wybierz_obraz->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(239)), static_cast<System::Int32>(static_cast<System::Byte>(207)),
				static_cast<System::Int32>(static_cast<System::Byte>(227)));
			this->wybierz_obraz->Location = System::Drawing::Point(37, 382);
			this->wybierz_obraz->Margin = System::Windows::Forms::Padding(8, 7, 8, 7);
			this->wybierz_obraz->Name = L"wybierz_obraz";
			this->wybierz_obraz->Size = System::Drawing::Size(451, 62);
			this->wybierz_obraz->TabIndex = 1;
			this->wybierz_obraz->Text = L"Wybierz obraz na dysku.";
			this->wybierz_obraz->UseVisualStyleBackColor = false;
			this->wybierz_obraz->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// checkBox1
			// 
			this->checkBox1->AutoSize = true;
			this->checkBox1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 14, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->checkBox1->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(234)), static_cast<System::Int32>(static_cast<System::Byte>(154)),
				static_cast<System::Int32>(static_cast<System::Byte>(178)));
			this->checkBox1->Location = System::Drawing::Point(37, 214);
			this->checkBox1->Margin = System::Windows::Forms::Padding(8, 7, 8, 7);
			this->checkBox1->Name = L"checkBox1";
			this->checkBox1->Size = System::Drawing::Size(168, 28);
			this->checkBox1->TabIndex = 2;
			this->checkBox1->Text = L"skorzystaj z .asm";
			this->checkBox1->UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->label2->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(226)), static_cast<System::Int32>(static_cast<System::Byte>(115)),
				static_cast<System::Int32>(static_cast<System::Byte>(150)));
			this->label2->Location = System::Drawing::Point(837, 20);
			this->label2->Margin = System::Windows::Forms::Padding(8, 0, 8, 0);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(127, 20);
			this->label2->TabIndex = 4;
			this->label2->Text = L"Czas wykonania:";
			// 
			// pictureBox1
			// 
			this->pictureBox1->BackColor = System::Drawing::SystemColors::Info;
			this->pictureBox1->Location = System::Drawing::Point(531, 58);
			this->pictureBox1->Margin = System::Windows::Forms::Padding(8, 7, 8, 7);
			this->pictureBox1->Name = L"pictureBox1";
			this->pictureBox1->Size = System::Drawing::Size(480, 529);
			this->pictureBox1->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
			this->pictureBox1->TabIndex = 5;
			this->pictureBox1->TabStop = false;
			this->pictureBox1->Click += gcnew System::EventHandler(this, &Form1::pictureBox1_Click);
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 22, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->label3->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(226)), static_cast<System::Int32>(static_cast<System::Byte>(115)),
				static_cast<System::Int32>(static_cast<System::Byte>(150)));
			this->label3->Location = System::Drawing::Point(31, 155);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(274, 36);
			this->label3->TabIndex = 6;
			this->label3->Text = L"uzyskaæ efekt echa.";
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->label4->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(234)), static_cast<System::Int32>(static_cast<System::Byte>(154)),
				static_cast<System::Int32>(static_cast<System::Byte>(178)));
			this->label4->Location = System::Drawing::Point(966, 20);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(45, 20);
			this->label4->TabIndex = 7;
			this->label4->Text = L"0\'00\'\'";
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->label5->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(226)), static_cast<System::Int32>(static_cast<System::Byte>(115)),
				static_cast<System::Int32>(static_cast<System::Byte>(150)));
			this->label5->Location = System::Drawing::Point(33, 587);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(135, 20);
			this->label5->TabIndex = 8;
			this->label5->Text = L"status wykonania:";
			this->label5->Click += gcnew System::EventHandler(this, &Form1::label5_Click);
			// 
			// start
			// 
			this->start->BackColor = System::Drawing::SystemColors::Info;
			this->start->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 18));
			this->start->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(226)), static_cast<System::Int32>(static_cast<System::Byte>(115)),
				static_cast<System::Int32>(static_cast<System::Byte>(150)));
			this->start->Location = System::Drawing::Point(37, 473);
			this->start->Name = L"start";
			this->start->Size = System::Drawing::Size(168, 55);
			this->start->TabIndex = 9;
			this->start->Text = L"Wykonaj";
			this->start->UseVisualStyleBackColor = false;
			this->start->Click += gcnew System::EventHandler(this, &Form1::start_Click);
			// 
			// status
			// 
			this->status->AutoSize = true;
			this->status->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->status->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12));
			this->status->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(226)), static_cast<System::Int32>(static_cast<System::Byte>(115)),
				static_cast<System::Int32>(static_cast<System::Byte>(150)));
			this->status->Location = System::Drawing::Point(174, 587);
			this->status->Name = L"status";
			this->status->Size = System::Drawing::Size(53, 20);
			this->status->TabIndex = 10;
			this->status->Text = L"status";
			this->status->Click += gcnew System::EventHandler(this, &Form1::status_Click);
			// 
			// numericUpDown1
			// 
			this->numericUpDown1->BackColor = System::Drawing::SystemColors::Info;
			this->numericUpDown1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 14));
			this->numericUpDown1->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(234)), static_cast<System::Int32>(static_cast<System::Byte>(154)),
				static_cast<System::Int32>(static_cast<System::Byte>(178)));
			this->numericUpDown1->Location = System::Drawing::Point(185, 272);
			this->numericUpDown1->Maximum = System::Decimal(gcnew cli::array< System::Int32 >(4) { 3000, 0, 0, 0 });
			this->numericUpDown1->Minimum = System::Decimal(gcnew cli::array< System::Int32 >(4) { 1, 0, 0, 0 });
			this->numericUpDown1->Name = L"numericUpDown1";
			this->numericUpDown1->Size = System::Drawing::Size(120, 29);
			this->numericUpDown1->TabIndex = 11;
			this->numericUpDown1->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) { 1, 0, 0, 0 });
			this->numericUpDown1->ValueChanged += gcnew System::EventHandler(this, &Form1::numericUpDown1_ValueChanged);
			// 
			// watki_info
			// 
			this->watki_info->AutoSize = true;
			this->watki_info->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 14));
			this->watki_info->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(234)), static_cast<System::Int32>(static_cast<System::Byte>(154)),
				static_cast<System::Int32>(static_cast<System::Byte>(178)));
			this->watki_info->Location = System::Drawing::Point(38, 272);
			this->watki_info->Name = L"watki_info";
			this->watki_info->Size = System::Drawing::Size(130, 24);
			this->watki_info->TabIndex = 12;
			this->watki_info->Text = L"liczba w¹tków:";
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(15, 32);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(239)), static_cast<System::Int32>(static_cast<System::Byte>(207)),
				static_cast<System::Int32>(static_cast<System::Byte>(227)));
			this->ClientSize = System::Drawing::Size(1042, 625);
			this->Controls->Add(this->watki_info);
			this->Controls->Add(this->numericUpDown1);
			this->Controls->Add(this->status);
			this->Controls->Add(this->start);
			this->Controls->Add(this->label5);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->pictureBox1);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->checkBox1);
			this->Controls->Add(this->wybierz_obraz);
			this->Controls->Add(this->label1);
			this->Font = (gcnew System::Drawing::Font(L"Cambria", 20.25F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(95)), static_cast<System::Int32>(static_cast<System::Byte>(116)),
				static_cast<System::Int32>(static_cast<System::Byte>(112)));
			this->Margin = System::Windows::Forms::Padding(8, 7, 8, 7);
			this->Name = L"Form1";
			this->Text = L"ECHO";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->numericUpDown1))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void Form1_Load(System::Object^ sender, System::EventArgs^ e) {
	}
	private: System::Void label1_Click(System::Object^ sender, System::EventArgs^ e) {
	}
	private: System::Void label5_Click(System::Object^ sender, System::EventArgs^ e) {
	}
private: System::Void button1_Click(System::Object^ sender, System::EventArgs^ e) {
	OpenFileDialog openFileDialog;
	openFileDialog.InitialDirectory = "c:\\";
	openFileDialog.Filter = "bitmapa (*.bmp)|*.bmp"; //zmienic 
	openFileDialog.FilterIndex = 1; 
	openFileDialog.RestoreDirectory = true;
	openFileDialog.ShowDialog(); 

	if (openFileDialog.FileName != "") {
		pictureBox1->Load(openFileDialog.FileName);
	};

}
private: System::Void pictureBox1_Click(System::Object^ sender, System::EventArgs^ e) {
}
private: System::Void start_Click(System::Object^ sender, System::EventArgs^ e) {
}
private: System::Void status_Click(System::Object^ sender, System::EventArgs^ e) {
}
private: System::Void numericUpDown1_ValueChanged(System::Object^ sender, System::EventArgs^ e) {
}
};
}
