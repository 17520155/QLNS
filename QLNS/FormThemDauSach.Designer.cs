namespace QLNS
{
    partial class FormThemDauSach
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
            this.textBoxTenDauSach = new System.Windows.Forms.TextBox();
            this.labelTenDauSach = new System.Windows.Forms.Label();
            this.labelThemDauSach = new System.Windows.Forms.Label();
            this.labelMaTheLoai = new System.Windows.Forms.Label();
            this.buttonThemMaTheLoai = new System.Windows.Forms.Button();
            this.comboBoxMaTheLoai = new System.Windows.Forms.ComboBox();
            this.textBoxTenTheLoai = new System.Windows.Forms.TextBox();
            this.labelTenTheLoai = new System.Windows.Forms.Label();
            this.textBoxTenTacGia = new System.Windows.Forms.TextBox();
            this.labelTenTacGia = new System.Windows.Forms.Label();
            this.buttonThemMaTacGia = new System.Windows.Forms.Button();
            this.comboBoxMaTacGia = new System.Windows.Forms.ComboBox();
            this.labelMaTacGia = new System.Windows.Forms.Label();
            this.buttonSuaChiTietTacGia = new System.Windows.Forms.Button();
            this.buttonXoaChiTietTacGia = new System.Windows.Forms.Button();
            this.buttonThemChiTietTacGia = new System.Windows.Forms.Button();
            this.dataGridViewQLS_DanhSachSach = new System.Windows.Forms.DataGridView();
            this.ColSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMaTacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTenTacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQLS_DanhSachSach)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLuu
            // 
            this.buttonLuu.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonLuu.Location = new System.Drawing.Point(372, 495);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(75, 23);
            this.buttonLuu.TabIndex = 61;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.UseVisualStyleBackColor = true;
            // 
            // textBoxTenDauSach
            // 
            this.textBoxTenDauSach.Location = new System.Drawing.Point(236, 75);
            this.textBoxTenDauSach.Name = "textBoxTenDauSach";
            this.textBoxTenDauSach.Size = new System.Drawing.Size(125, 22);
            this.textBoxTenDauSach.TabIndex = 60;
            // 
            // labelTenDauSach
            // 
            this.labelTenDauSach.AutoSize = true;
            this.labelTenDauSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenDauSach.Location = new System.Drawing.Point(120, 75);
            this.labelTenDauSach.Name = "labelTenDauSach";
            this.labelTenDauSach.Size = new System.Drawing.Size(110, 20);
            this.labelTenDauSach.TabIndex = 59;
            this.labelTenDauSach.Text = "Tên đầu sách";
            // 
            // labelThemDauSach
            // 
            this.labelThemDauSach.AutoSize = true;
            this.labelThemDauSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThemDauSach.Location = new System.Drawing.Point(324, 29);
            this.labelThemDauSach.Name = "labelThemDauSach";
            this.labelThemDauSach.Size = new System.Drawing.Size(178, 25);
            this.labelThemDauSach.TabIndex = 58;
            this.labelThemDauSach.Text = "THÊM ĐẦU SÁCH";
            // 
            // labelMaTheLoai
            // 
            this.labelMaTheLoai.AutoSize = true;
            this.labelMaTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaTheLoai.Location = new System.Drawing.Point(139, 103);
            this.labelMaTheLoai.Name = "labelMaTheLoai";
            this.labelMaTheLoai.Size = new System.Drawing.Size(91, 20);
            this.labelMaTheLoai.TabIndex = 62;
            this.labelMaTheLoai.Text = "Mã thể loại";
            // 
            // buttonThemMaTheLoai
            // 
            this.buttonThemMaTheLoai.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonThemMaTheLoai.Location = new System.Drawing.Point(363, 103);
            this.buttonThemMaTheLoai.Name = "buttonThemMaTheLoai";
            this.buttonThemMaTheLoai.Size = new System.Drawing.Size(33, 23);
            this.buttonThemMaTheLoai.TabIndex = 64;
            this.buttonThemMaTheLoai.Text = "+";
            this.buttonThemMaTheLoai.UseVisualStyleBackColor = true;
            this.buttonThemMaTheLoai.Click += new System.EventHandler(this.buttonThemMaTheLoai_Click);
            // 
            // comboBoxMaTheLoai
            // 
            this.comboBoxMaTheLoai.FormattingEnabled = true;
            this.comboBoxMaTheLoai.Location = new System.Drawing.Point(236, 103);
            this.comboBoxMaTheLoai.Name = "comboBoxMaTheLoai";
            this.comboBoxMaTheLoai.Size = new System.Drawing.Size(121, 24);
            this.comboBoxMaTheLoai.TabIndex = 63;
            // 
            // textBoxTenTheLoai
            // 
            this.textBoxTenTheLoai.Location = new System.Drawing.Point(546, 105);
            this.textBoxTenTheLoai.Name = "textBoxTenTheLoai";
            this.textBoxTenTheLoai.ReadOnly = true;
            this.textBoxTenTheLoai.Size = new System.Drawing.Size(125, 22);
            this.textBoxTenTheLoai.TabIndex = 66;
            // 
            // labelTenTheLoai
            // 
            this.labelTenTheLoai.AutoSize = true;
            this.labelTenTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenTheLoai.Location = new System.Drawing.Point(444, 105);
            this.labelTenTheLoai.Name = "labelTenTheLoai";
            this.labelTenTheLoai.Size = new System.Drawing.Size(96, 20);
            this.labelTenTheLoai.TabIndex = 65;
            this.labelTenTheLoai.Text = "Tên thể loại";
            // 
            // textBoxTenTacGia
            // 
            this.textBoxTenTacGia.Location = new System.Drawing.Point(546, 169);
            this.textBoxTenTacGia.Name = "textBoxTenTacGia";
            this.textBoxTenTacGia.ReadOnly = true;
            this.textBoxTenTacGia.Size = new System.Drawing.Size(125, 22);
            this.textBoxTenTacGia.TabIndex = 71;
            // 
            // labelTenTacGia
            // 
            this.labelTenTacGia.AutoSize = true;
            this.labelTenTacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenTacGia.Location = new System.Drawing.Point(444, 169);
            this.labelTenTacGia.Name = "labelTenTacGia";
            this.labelTenTacGia.Size = new System.Drawing.Size(92, 20);
            this.labelTenTacGia.TabIndex = 70;
            this.labelTenTacGia.Text = "Tên tác giả";
            // 
            // buttonThemMaTacGia
            // 
            this.buttonThemMaTacGia.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonThemMaTacGia.Location = new System.Drawing.Point(363, 169);
            this.buttonThemMaTacGia.Name = "buttonThemMaTacGia";
            this.buttonThemMaTacGia.Size = new System.Drawing.Size(33, 23);
            this.buttonThemMaTacGia.TabIndex = 69;
            this.buttonThemMaTacGia.Text = "+";
            this.buttonThemMaTacGia.UseVisualStyleBackColor = true;
            this.buttonThemMaTacGia.Click += new System.EventHandler(this.buttonThemMaTacGia_Click);
            // 
            // comboBoxMaTacGia
            // 
            this.comboBoxMaTacGia.FormattingEnabled = true;
            this.comboBoxMaTacGia.Location = new System.Drawing.Point(236, 169);
            this.comboBoxMaTacGia.Name = "comboBoxMaTacGia";
            this.comboBoxMaTacGia.Size = new System.Drawing.Size(121, 24);
            this.comboBoxMaTacGia.TabIndex = 68;
            // 
            // labelMaTacGia
            // 
            this.labelMaTacGia.AutoSize = true;
            this.labelMaTacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaTacGia.Location = new System.Drawing.Point(139, 171);
            this.labelMaTacGia.Name = "labelMaTacGia";
            this.labelMaTacGia.Size = new System.Drawing.Size(87, 20);
            this.labelMaTacGia.TabIndex = 67;
            this.labelMaTacGia.Text = "Mã tác giả";
            // 
            // buttonSuaChiTietTacGia
            // 
            this.buttonSuaChiTietTacGia.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonSuaChiTietTacGia.Location = new System.Drawing.Point(596, 199);
            this.buttonSuaChiTietTacGia.Name = "buttonSuaChiTietTacGia";
            this.buttonSuaChiTietTacGia.Size = new System.Drawing.Size(75, 23);
            this.buttonSuaChiTietTacGia.TabIndex = 74;
            this.buttonSuaChiTietTacGia.Text = "Sửa";
            this.buttonSuaChiTietTacGia.UseVisualStyleBackColor = true;
            // 
            // buttonXoaChiTietTacGia
            // 
            this.buttonXoaChiTietTacGia.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonXoaChiTietTacGia.Location = new System.Drawing.Point(515, 199);
            this.buttonXoaChiTietTacGia.Name = "buttonXoaChiTietTacGia";
            this.buttonXoaChiTietTacGia.Size = new System.Drawing.Size(75, 23);
            this.buttonXoaChiTietTacGia.TabIndex = 73;
            this.buttonXoaChiTietTacGia.Text = "Xóa";
            this.buttonXoaChiTietTacGia.UseVisualStyleBackColor = true;
            // 
            // buttonThemChiTietTacGia
            // 
            this.buttonThemChiTietTacGia.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonThemChiTietTacGia.Location = new System.Drawing.Point(434, 199);
            this.buttonThemChiTietTacGia.Name = "buttonThemChiTietTacGia";
            this.buttonThemChiTietTacGia.Size = new System.Drawing.Size(75, 23);
            this.buttonThemChiTietTacGia.TabIndex = 72;
            this.buttonThemChiTietTacGia.Text = "Thêm";
            this.buttonThemChiTietTacGia.UseVisualStyleBackColor = true;
            // 
            // dataGridViewQLS_DanhSachSach
            // 
            this.dataGridViewQLS_DanhSachSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQLS_DanhSachSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSTT,
            this.ColMaTacGia,
            this.ColTenTacGia});
            this.dataGridViewQLS_DanhSachSach.Location = new System.Drawing.Point(218, 232);
            this.dataGridViewQLS_DanhSachSach.Name = "dataGridViewQLS_DanhSachSach";
            this.dataGridViewQLS_DanhSachSach.RowTemplate.Height = 24;
            this.dataGridViewQLS_DanhSachSach.Size = new System.Drawing.Size(396, 212);
            this.dataGridViewQLS_DanhSachSach.TabIndex = 75;
            // 
            // ColSTT
            // 
            this.ColSTT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColSTT.HeaderText = "STT";
            this.ColSTT.Name = "ColSTT";
            this.ColSTT.ReadOnly = true;
            this.ColSTT.Width = 64;
            // 
            // ColMaTacGia
            // 
            this.ColMaTacGia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColMaTacGia.HeaderText = "Mã tác giả";
            this.ColMaTacGia.Name = "ColMaTacGia";
            this.ColMaTacGia.ReadOnly = true;
            this.ColMaTacGia.Width = 102;
            // 
            // ColTenTacGia
            // 
            this.ColTenTacGia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColTenTacGia.HeaderText = "Tên tác giả";
            this.ColTenTacGia.Name = "ColTenTacGia";
            this.ColTenTacGia.ReadOnly = true;
            // 
            // FormThemDauSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.dataGridViewQLS_DanhSachSach);
            this.Controls.Add(this.buttonSuaChiTietTacGia);
            this.Controls.Add(this.buttonXoaChiTietTacGia);
            this.Controls.Add(this.buttonThemChiTietTacGia);
            this.Controls.Add(this.textBoxTenTacGia);
            this.Controls.Add(this.labelTenTacGia);
            this.Controls.Add(this.buttonThemMaTacGia);
            this.Controls.Add(this.comboBoxMaTacGia);
            this.Controls.Add(this.labelMaTacGia);
            this.Controls.Add(this.textBoxTenTheLoai);
            this.Controls.Add(this.labelTenTheLoai);
            this.Controls.Add(this.buttonThemMaTheLoai);
            this.Controls.Add(this.comboBoxMaTheLoai);
            this.Controls.Add(this.labelMaTheLoai);
            this.Controls.Add(this.buttonLuu);
            this.Controls.Add(this.textBoxTenDauSach);
            this.Controls.Add(this.labelTenDauSach);
            this.Controls.Add(this.labelThemDauSach);
            this.Name = "FormThemDauSach";
            this.Text = "FormThemDauSach";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQLS_DanhSachSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLuu;
        private System.Windows.Forms.TextBox textBoxTenDauSach;
        private System.Windows.Forms.Label labelTenDauSach;
        private System.Windows.Forms.Label labelThemDauSach;
        private System.Windows.Forms.Label labelMaTheLoai;
        private System.Windows.Forms.Button buttonThemMaTheLoai;
        private System.Windows.Forms.ComboBox comboBoxMaTheLoai;
        private System.Windows.Forms.TextBox textBoxTenTheLoai;
        private System.Windows.Forms.Label labelTenTheLoai;
        private System.Windows.Forms.TextBox textBoxTenTacGia;
        private System.Windows.Forms.Label labelTenTacGia;
        private System.Windows.Forms.Button buttonThemMaTacGia;
        private System.Windows.Forms.ComboBox comboBoxMaTacGia;
        private System.Windows.Forms.Label labelMaTacGia;
        private System.Windows.Forms.Button buttonSuaChiTietTacGia;
        private System.Windows.Forms.Button buttonXoaChiTietTacGia;
        private System.Windows.Forms.Button buttonThemChiTietTacGia;
        private System.Windows.Forms.DataGridView dataGridViewQLS_DanhSachSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMaTacGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTenTacGia;
    }
}