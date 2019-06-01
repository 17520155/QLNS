namespace QLNS
{
    partial class FormThemKH
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
            this.labelThemKH = new System.Windows.Forms.Label();
            this.textBoxTenKH = new System.Windows.Forms.TextBox();
            this.labelTenKH = new System.Windows.Forms.Label();
            this.textBoxDiaChi = new System.Windows.Forms.TextBox();
            this.labelDiaChi = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelDienThoai = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.buttonLuu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelThemKH
            // 
            this.labelThemKH.AutoSize = true;
            this.labelThemKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThemKH.Location = new System.Drawing.Point(125, 22);
            this.labelThemKH.Name = "labelThemKH";
            this.labelThemKH.Size = new System.Drawing.Size(207, 25);
            this.labelThemKH.TabIndex = 4;
            this.labelThemKH.Text = "THÊM KHÁCH HÀNG";
            // 
            // textBoxTenKH
            // 
            this.textBoxTenKH.Location = new System.Drawing.Point(200, 80);
            this.textBoxTenKH.Name = "textBoxTenKH";
            this.textBoxTenKH.Size = new System.Drawing.Size(125, 22);
            this.textBoxTenKH.TabIndex = 32;
            // 
            // labelTenKH
            // 
            this.labelTenKH.AutoSize = true;
            this.labelTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenKH.Location = new System.Drawing.Point(128, 82);
            this.labelTenKH.Name = "labelTenKH";
            this.labelTenKH.Size = new System.Drawing.Size(66, 20);
            this.labelTenKH.TabIndex = 31;
            this.labelTenKH.Text = "Tên KH";
            // 
            // textBoxDiaChi
            // 
            this.textBoxDiaChi.Location = new System.Drawing.Point(200, 108);
            this.textBoxDiaChi.Name = "textBoxDiaChi";
            this.textBoxDiaChi.Size = new System.Drawing.Size(125, 22);
            this.textBoxDiaChi.TabIndex = 34;
            // 
            // labelDiaChi
            // 
            this.labelDiaChi.AutoSize = true;
            this.labelDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiaChi.Location = new System.Drawing.Point(133, 108);
            this.labelDiaChi.Name = "labelDiaChi";
            this.labelDiaChi.Size = new System.Drawing.Size(61, 20);
            this.labelDiaChi.TabIndex = 33;
            this.labelDiaChi.Text = "Địa chỉ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(200, 136);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 22);
            this.textBox1.TabIndex = 36;
            // 
            // labelDienThoai
            // 
            this.labelDienThoai.AutoSize = true;
            this.labelDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDienThoai.Location = new System.Drawing.Point(110, 138);
            this.labelDienThoai.Name = "labelDienThoai";
            this.labelDienThoai.Size = new System.Drawing.Size(84, 20);
            this.labelDienThoai.TabIndex = 35;
            this.labelDienThoai.Text = "Điện thoại";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(200, 164);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(125, 22);
            this.textBoxEmail.TabIndex = 38;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(143, 166);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(51, 20);
            this.labelEmail.TabIndex = 37;
            this.labelEmail.Text = "Email";
            // 
            // buttonLuu
            // 
            this.buttonLuu.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonLuu.Location = new System.Drawing.Point(191, 214);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(75, 23);
            this.buttonLuu.TabIndex = 39;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.UseVisualStyleBackColor = true;
            this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
            // 
            // FormThemKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 268);
            this.Controls.Add(this.buttonLuu);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelDienThoai);
            this.Controls.Add(this.textBoxDiaChi);
            this.Controls.Add(this.labelDiaChi);
            this.Controls.Add(this.textBoxTenKH);
            this.Controls.Add(this.labelTenKH);
            this.Controls.Add(this.labelThemKH);
            this.Name = "FormThemKH";
            this.Text = "Thêm khách hàng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelThemKH;
        private System.Windows.Forms.TextBox textBoxTenKH;
        private System.Windows.Forms.Label labelTenKH;
        private System.Windows.Forms.TextBox textBoxDiaChi;
        private System.Windows.Forms.Label labelDiaChi;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelDienThoai;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Button buttonLuu;
    }
}