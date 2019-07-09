namespace QLNS
{
    partial class FormThemTheLoai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThemTheLoai));
            this.buttonLuu = new System.Windows.Forms.Button();
            this.textBoxTenTheLoai = new System.Windows.Forms.TextBox();
            this.labelTenTheLoai = new System.Windows.Forms.Label();
            this.labelThemTheLoai = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonLuu
            // 
            this.buttonLuu.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonLuu.Location = new System.Drawing.Point(112, 102);
            this.buttonLuu.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(56, 28);
            this.buttonLuu.TabIndex = 53;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.UseVisualStyleBackColor = true;
            this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
            // 
            // textBoxTenTheLoai
            // 
            this.textBoxTenTheLoai.Location = new System.Drawing.Point(115, 61);
            this.textBoxTenTheLoai.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTenTheLoai.Name = "textBoxTenTheLoai";
            this.textBoxTenTheLoai.Size = new System.Drawing.Size(120, 20);
            this.textBoxTenTheLoai.TabIndex = 52;
            // 
            // labelTenTheLoai
            // 
            this.labelTenTheLoai.AutoSize = true;
            this.labelTenTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenTheLoai.Location = new System.Drawing.Point(26, 61);
            this.labelTenTheLoai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTenTheLoai.Name = "labelTenTheLoai";
            this.labelTenTheLoai.Size = new System.Drawing.Size(83, 17);
            this.labelTenTheLoai.TabIndex = 51;
            this.labelTenTheLoai.Text = "Tên thể loại";
            // 
            // labelThemTheLoai
            // 
            this.labelThemTheLoai.AutoSize = true;
            this.labelThemTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThemTheLoai.Location = new System.Drawing.Point(60, 17);
            this.labelThemTheLoai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelThemTheLoai.Name = "labelThemTheLoai";
            this.labelThemTheLoai.Size = new System.Drawing.Size(144, 20);
            this.labelThemTheLoai.TabIndex = 50;
            this.labelThemTheLoai.Text = "THÊM THỂ LOẠI";
            // 
            // FormThemTheLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 170);
            this.Controls.Add(this.buttonLuu);
            this.Controls.Add(this.textBoxTenTheLoai);
            this.Controls.Add(this.labelTenTheLoai);
            this.Controls.Add(this.labelThemTheLoai);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormThemTheLoai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm thể loại";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLuu;
        private System.Windows.Forms.TextBox textBoxTenTheLoai;
        private System.Windows.Forms.Label labelTenTheLoai;
        private System.Windows.Forms.Label labelThemTheLoai;
    }
}