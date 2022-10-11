
namespace QuanLySanBong
{
    partial class fTableManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSan = new System.Windows.Forms.Panel();
            this.flpSan = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvHoaDon = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbChuyenSan = new System.Windows.Forms.ComboBox();
            this.btnChuyenSan = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nmSoSan = new System.Windows.Forms.NumericUpDown();
            this.btnThemSan = new System.Windows.Forms.Button();
            this.cbDichVu = new System.Windows.Forms.ComboBox();
            this.cbSan = new System.Windows.Forms.ComboBox();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtTongtien = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.pnlSan.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoSan)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(909, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // pnlSan
            // 
            this.pnlSan.Controls.Add(this.flpSan);
            this.pnlSan.Location = new System.Drawing.Point(12, 37);
            this.pnlSan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSan.Name = "pnlSan";
            this.pnlSan.Size = new System.Drawing.Size(493, 416);
            this.pnlSan.TabIndex = 1;
            // 
            // flpSan
            // 
            this.flpSan.AutoScroll = true;
            this.flpSan.Location = new System.Drawing.Point(3, 3);
            this.flpSan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpSan.Name = "flpSan";
            this.flpSan.Size = new System.Drawing.Size(488, 458);
            this.flpSan.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lsvHoaDon);
            this.panel2.Location = new System.Drawing.Point(510, 105);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(395, 271);
            this.panel2.TabIndex = 2;
            // 
            // lsvHoaDon
            // 
            this.lsvHoaDon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvHoaDon.GridLines = true;
            this.lsvHoaDon.HideSelection = false;
            this.lsvHoaDon.Location = new System.Drawing.Point(4, 3);
            this.lsvHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lsvHoaDon.Name = "lsvHoaDon";
            this.lsvHoaDon.Size = new System.Drawing.Size(389, 266);
            this.lsvHoaDon.TabIndex = 0;
            this.lsvHoaDon.UseCompatibleStateImageBehavior = false;
            this.lsvHoaDon.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên Thức Uống";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số Lượng";
            this.columnHeader2.Width = 90;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtTongtien);
            this.panel3.Controls.Add(this.cbChuyenSan);
            this.panel3.Controls.Add(this.btnChuyenSan);
            this.panel3.Controls.Add(this.btnThanhToan);
            this.panel3.Location = new System.Drawing.Point(511, 401);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(394, 79);
            this.panel3.TabIndex = 3;
            // 
            // cbChuyenSan
            // 
            this.cbChuyenSan.FormattingEnabled = true;
            this.cbChuyenSan.Location = new System.Drawing.Point(13, 44);
            this.cbChuyenSan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbChuyenSan.Name = "cbChuyenSan";
            this.cbChuyenSan.Size = new System.Drawing.Size(132, 24);
            this.cbChuyenSan.TabIndex = 6;
            // 
            // btnChuyenSan
            // 
            this.btnChuyenSan.Location = new System.Drawing.Point(13, 11);
            this.btnChuyenSan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChuyenSan.Name = "btnChuyenSan";
            this.btnChuyenSan.Size = new System.Drawing.Size(132, 29);
            this.btnChuyenSan.TabIndex = 5;
            this.btnChuyenSan.Text = "Chuyển Sân";
            this.btnChuyenSan.UseVisualStyleBackColor = true;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(300, 17);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(78, 46);
            this.btnThanhToan.TabIndex = 4;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nmSoSan);
            this.panel4.Controls.Add(this.btnThemSan);
            this.panel4.Controls.Add(this.cbDichVu);
            this.panel4.Controls.Add(this.cbSan);
            this.panel4.Location = new System.Drawing.Point(510, 37);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(394, 59);
            this.panel4.TabIndex = 4;
            // 
            // nmSoSan
            // 
            this.nmSoSan.Location = new System.Drawing.Point(305, 17);
            this.nmSoSan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmSoSan.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmSoSan.Name = "nmSoSan";
            this.nmSoSan.Size = new System.Drawing.Size(74, 22);
            this.nmSoSan.TabIndex = 3;
            this.nmSoSan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnThemSan
            // 
            this.btnThemSan.Location = new System.Drawing.Point(213, 3);
            this.btnThemSan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemSan.Name = "btnThemSan";
            this.btnThemSan.Size = new System.Drawing.Size(78, 46);
            this.btnThemSan.TabIndex = 2;
            this.btnThemSan.Text = "Thêm Sân";
            this.btnThemSan.UseVisualStyleBackColor = true;
            // 
            // cbDichVu
            // 
            this.cbDichVu.FormattingEnabled = true;
            this.cbDichVu.Location = new System.Drawing.Point(4, 30);
            this.cbDichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDichVu.Name = "cbDichVu";
            this.cbDichVu.Size = new System.Drawing.Size(189, 24);
            this.cbDichVu.TabIndex = 1;
            // 
            // cbSan
            // 
            this.cbSan.FormattingEnabled = true;
            this.cbSan.Location = new System.Drawing.Point(4, 3);
            this.cbSan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSan.Name = "cbSan";
            this.cbSan.Size = new System.Drawing.Size(189, 24);
            this.cbSan.TabIndex = 0;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn Giá";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành Tiền";
            this.columnHeader4.Width = 90;
            // 
            // txtTongtien
            // 
            this.txtTongtien.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongtien.ForeColor = System.Drawing.Color.Red;
            this.txtTongtien.Location = new System.Drawing.Point(151, 35);
            this.txtTongtien.Name = "txtTongtien";
            this.txtTongtien.ReadOnly = true;
            this.txtTongtien.Size = new System.Drawing.Size(139, 28);
            this.txtTongtien.TabIndex = 7;
            this.txtTongtien.Text = "0";
            this.txtTongtien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 509);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlSan);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fTableManager";
            this.Text = "Phần mềm quản lý sân đá bóng";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlSan.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmSoSan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Panel pnlSan;
        private System.Windows.Forms.FlowLayoutPanel flpSan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lsvHoaDon;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown nmSoSan;
        private System.Windows.Forms.Button btnThemSan;
        private System.Windows.Forms.ComboBox cbDichVu;
        private System.Windows.Forms.ComboBox cbSan;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.ComboBox cbChuyenSan;
        private System.Windows.Forms.Button btnChuyenSan;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txtTongtien;
    }
}