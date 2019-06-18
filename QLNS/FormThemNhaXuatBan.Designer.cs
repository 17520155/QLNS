namespace QLNS
{
    partial class FormThemNhaXuatBan
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
            this.textBoxTenNhaXuatBan = new System.Windows.Forms.TextBox();
            this.labelTenNhaXuatBan = new System.Windows.Forms.Label();
            this.labelThemNhaXuatBan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonLuu
            // 
            this.buttonLuu.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonLuu.Location = new System.Drawing.Point(195, 134);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(75, 23);
            this.buttonLuu.TabIndex = 57;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.UseVisualStyleBackColor = true;
            this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
            // 
            // textBoxTenNhaXuatBan
            // 
            this.textBoxTenNhaXuatBan.Location = new System.Drawing.Point(226, 79);
            this.textBoxTenNhaXuatBan.Name = "textBoxTenNhaXuatBan";
            this.textBoxTenNhaXuatBan.Size = new System.Drawing.Size(125, 22);
            this.textBoxTenNhaXuatBan.TabIndex = 56;
            // 
            // labelTenNhaXuatBan
            // 
            this.labelTenNhaXuatBan.AutoSize = true;
            this.labelTenNhaXuatBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenNhaXuatBan.Location = new System.Drawing.Point(83, 79);
            this.labelTenNhaXuatBan.Name = "labelTenNhaXuatBan";
            this.labelTenNhaXuatBan.Size = new System.Drawing.Size(137, 20);
            this.labelTenNhaXuatBan.TabIndex = 55;
            this.labelTenNhaXuatBan.Text = "Tên nhà xuất bản";
            // 
            // labelThemNhaXuatBan
            // 
            this.labelThemNhaXuatBan.AutoSize = true;
            this.labelThemNhaXuatBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThemNhaXuatBan.Location = new System.Drawing.Point(113, 27);
            this.labelThemNhaXuatBan.Name = "labelThemNhaXuatBan";
            this.labelThemNhaXuatBan.Size = new System.Drawing.Size(239, 25);
            this.labelThemNhaXuatBan.TabIndex = 54;
            this.labelThemNhaXuatBan.Text = "THÊM NHÀ XUẤT BẢN";
            // 
            // FormThemNhaXuatBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(450, 220);
            this.Controls.Add(this.buttonLuu);
            this.Controls.Add(this.textBoxTenNhaXuatBan);
            this.Controls.Add(this.labelTenNhaXuatBan);
            this.Controls.Add(this.labelThemNhaXuatBan);
            this.Name = "FormThemNhaXuatBan";
            this.Text = "Thêm nhà xuất bản";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLuu;
        private System.Windows.Forms.TextBox textBoxTenNhaXuatBan;
        private System.Windows.Forms.Label labelTenNhaXuatBan;
        private System.Windows.Forms.Label labelThemNhaXuatBan;
    }
}