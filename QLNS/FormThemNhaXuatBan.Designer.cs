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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThemNhaXuatBan));
            this.buttonLuu = new System.Windows.Forms.Button();
            this.textBoxTenNhaXuatBan = new System.Windows.Forms.TextBox();
            this.labelTenNhaXuatBan = new System.Windows.Forms.Label();
            this.labelThemNhaXuatBan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonLuu
            // 
            this.buttonLuu.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonLuu.Location = new System.Drawing.Point(155, 106);
            this.buttonLuu.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(67, 27);
            this.buttonLuu.TabIndex = 57;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.UseVisualStyleBackColor = true;
            this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
            // 
            // textBoxTenNhaXuatBan
            // 
            this.textBoxTenNhaXuatBan.Location = new System.Drawing.Point(176, 65);
            this.textBoxTenNhaXuatBan.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTenNhaXuatBan.Name = "textBoxTenNhaXuatBan";
            this.textBoxTenNhaXuatBan.Size = new System.Drawing.Size(133, 20);
            this.textBoxTenNhaXuatBan.TabIndex = 56;
            // 
            // labelTenNhaXuatBan
            // 
            this.labelTenNhaXuatBan.AutoSize = true;
            this.labelTenNhaXuatBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenNhaXuatBan.Location = new System.Drawing.Point(53, 67);
            this.labelTenNhaXuatBan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTenNhaXuatBan.Name = "labelTenNhaXuatBan";
            this.labelTenNhaXuatBan.Size = new System.Drawing.Size(119, 17);
            this.labelTenNhaXuatBan.TabIndex = 55;
            this.labelTenNhaXuatBan.Text = "Tên nhà xuất bản";
            // 
            // labelThemNhaXuatBan
            // 
            this.labelThemNhaXuatBan.AutoSize = true;
            this.labelThemNhaXuatBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThemNhaXuatBan.Location = new System.Drawing.Point(90, 22);
            this.labelThemNhaXuatBan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelThemNhaXuatBan.Name = "labelThemNhaXuatBan";
            this.labelThemNhaXuatBan.Size = new System.Drawing.Size(193, 20);
            this.labelThemNhaXuatBan.TabIndex = 54;
            this.labelThemNhaXuatBan.Text = "THÊM NHÀ XUẤT BẢN";
            // 
            // FormThemNhaXuatBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(375, 179);
            this.Controls.Add(this.buttonLuu);
            this.Controls.Add(this.textBoxTenNhaXuatBan);
            this.Controls.Add(this.labelTenNhaXuatBan);
            this.Controls.Add(this.labelThemNhaXuatBan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormThemNhaXuatBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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