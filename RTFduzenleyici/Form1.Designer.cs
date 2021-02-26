namespace RTFduzenleyici
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.dosyaSec = new System.Windows.Forms.OpenFileDialog();
            this.btnDosyaSec = new System.Windows.Forms.Button();
            this.btnCevrilmisDosyaSec = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtCevrilcekYol = new System.Windows.Forms.TextBox();
            this.txtCevrilmisDosya = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dosyaKaydet = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // dosyaSec
            // 
            this.dosyaSec.FileName = "secilenDosya";
            this.dosyaSec.FileOk += new System.ComponentModel.CancelEventHandler(this.dosyaSec_FileOk);
            // 
            // btnDosyaSec
            // 
            this.btnDosyaSec.Location = new System.Drawing.Point(280, 60);
            this.btnDosyaSec.Name = "btnDosyaSec";
            this.btnDosyaSec.Size = new System.Drawing.Size(84, 23);
            this.btnDosyaSec.TabIndex = 0;
            this.btnDosyaSec.Text = "Seç";
            this.btnDosyaSec.UseVisualStyleBackColor = true;
            this.btnDosyaSec.Click += new System.EventHandler(this.btnDosyaSec_Click);
            // 
            // btnCevrilmisDosyaSec
            // 
            this.btnCevrilmisDosyaSec.Location = new System.Drawing.Point(280, 89);
            this.btnCevrilmisDosyaSec.Name = "btnCevrilmisDosyaSec";
            this.btnCevrilmisDosyaSec.Size = new System.Drawing.Size(84, 23);
            this.btnCevrilmisDosyaSec.TabIndex = 1;
            this.btnCevrilmisDosyaSec.Text = "Seç";
            this.btnCevrilmisDosyaSec.UseVisualStyleBackColor = true;
            this.btnCevrilmisDosyaSec.Click += new System.EventHandler(this.btnCevrilmisDosyaSec_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(151, 214);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Kaydet";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtCevrilcekYol
            // 
            this.txtCevrilcekYol.Location = new System.Drawing.Point(103, 60);
            this.txtCevrilcekYol.Name = "txtCevrilcekYol";
            this.txtCevrilcekYol.Size = new System.Drawing.Size(170, 20);
            this.txtCevrilcekYol.TabIndex = 3;
            // 
            // txtCevrilmisDosya
            // 
            this.txtCevrilmisDosya.Location = new System.Drawing.Point(103, 91);
            this.txtCevrilmisDosya.Name = "txtCevrilmisDosya";
            this.txtCevrilmisDosya.Size = new System.Drawing.Size(170, 20);
            this.txtCevrilmisDosya.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cevrilcek Dosya:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cevrilmiş Dosya:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 306);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCevrilmisDosya);
            this.Controls.Add(this.txtCevrilcekYol);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnCevrilmisDosyaSec);
            this.Controls.Add(this.btnDosyaSec);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(410, 345);
            this.MinimumSize = new System.Drawing.Size(410, 345);
            this.Name = "Form1";
            this.Text = "Docx Duzenleyici";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dosyaSec;
        private System.Windows.Forms.Button btnDosyaSec;
        private System.Windows.Forms.Button btnCevrilmisDosyaSec;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtCevrilcekYol;
        private System.Windows.Forms.TextBox txtCevrilmisDosya;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog dosyaKaydet;
    }
}

