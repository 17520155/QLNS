namespace QLNS
{
    partial class FormThemTacGia
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
            this.buttonLuu = new System.Windows.Forms.Button();
            this.textBoxTenTacGia = new System.Windows.Forms.TextBox();
            this.labelTenTacGia = new System.Windows.Forms.Label();
            this.labelThemTacGia = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonLuu
            // 
            this.buttonLuu.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonLuu.Location = new System.Drawing.Point(132, 134);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(75, 23);
            this.buttonLuu.TabIndex = 49;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.UseVisualStyleBackColor = true;
            // 
            // textBoxTenTacGia
            // 
            this.textBoxTenTacGia.Location = new System.Drawing.Point(149, 82);
            this.textBoxTenTacGia.Name = "textBoxTenTacGia";
            this.textBoxTenTacGia.Size = new System.Drawing.Size(125, 22);
            this.textBoxTenTacGia.TabIndex = 42;
            // 
            // labelTenTacGia
            // 
            this.labelTenTacGia.AutoSize = true;
            this.labelTenTacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenTacGia.Location = new System.Drawing.Point(51, 84);
            this.labelTenTacGia.Name = "labelTenTacGia";
            this.labelTenTacGia.Size = new System.Drawing.Size(92, 20);
            this.labelTenTacGia.TabIndex = 41;
            this.labelTenTacGia.Text = "Tên tác giả";
            // 
            // labelThemTacGia
            // 
            this.labelThemTacGia.AutoSize = true;
            this.labelThemTacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThemTacGia.Location = new System.Drawing.Point(85, 29);
            this.labelThemTacGia.Name = "labelThemTacGia";
            this.labelThemTacGia.Size = new System.Drawing.Size(155, 25);
            this.labelThemTacGia.TabIndex = 40;
            this.labelThemTacGia.Text = "THÊM TÁC GIẢ";
            // 
            // FormThemTacGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 225);
            this.Controls.Add(this.buttonLuu);
            this.Controls.Add(this.textBoxTenTacGia);
            this.Controls.Add(this.labelTenTacGia);
            this.Controls.Add(this.labelThemTacGia);
            this.Name = "FormThemTacGia";
            this.Text = "Thêm tác giả";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLuu;
        private System.Windows.Forms.TextBox textBoxTenTacGia;
        private System.Windows.Forms.Label labelTenTacGia;
        private System.Windows.Forms.Label labelThemTacGia;
    }
}