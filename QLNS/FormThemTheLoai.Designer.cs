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
            this.buttonLuu = new System.Windows.Forms.Button();
            this.textBoxTenTheLoai = new System.Windows.Forms.TextBox();
            this.labelTenTheLoai = new System.Windows.Forms.Label();
            this.labelThemTheLoai = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonLuu
            // 
            this.buttonLuu.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonLuu.Location = new System.Drawing.Point(127, 126);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(75, 23);
            this.buttonLuu.TabIndex = 53;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.UseVisualStyleBackColor = true;
            // 
            // textBoxTenTheLoai
            // 
            this.textBoxTenTheLoai.Location = new System.Drawing.Point(144, 74);
            this.textBoxTenTheLoai.Name = "textBoxTenTheLoai";
            this.textBoxTenTheLoai.Size = new System.Drawing.Size(125, 22);
            this.textBoxTenTheLoai.TabIndex = 52;
            // 
            // labelTenTheLoai
            // 
            this.labelTenTheLoai.AutoSize = true;
            this.labelTenTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenTheLoai.Location = new System.Drawing.Point(42, 76);
            this.labelTenTheLoai.Name = "labelTenTheLoai";
            this.labelTenTheLoai.Size = new System.Drawing.Size(96, 20);
            this.labelTenTheLoai.TabIndex = 51;
            this.labelTenTheLoai.Text = "Tên thể loại";
            // 
            // labelThemTheLoai
            // 
            this.labelThemTheLoai.AutoSize = true;
            this.labelThemTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThemTheLoai.Location = new System.Drawing.Point(80, 21);
            this.labelThemTheLoai.Name = "labelThemTheLoai";
            this.labelThemTheLoai.Size = new System.Drawing.Size(178, 25);
            this.labelThemTheLoai.TabIndex = 50;
            this.labelThemTheLoai.Text = "THÊM THỂ LOẠI";
            // 
            // FormThemTheLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 209);
            this.Controls.Add(this.buttonLuu);
            this.Controls.Add(this.textBoxTenTheLoai);
            this.Controls.Add(this.labelTenTheLoai);
            this.Controls.Add(this.labelThemTheLoai);
            this.Name = "FormThemTheLoai";
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