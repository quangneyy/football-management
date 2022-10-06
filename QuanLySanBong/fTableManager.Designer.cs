
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lsvHoaDon = new System.Windows.Forms.ListView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbSan = new System.Windows.Forms.ComboBox();
            this.cbDichVu = new System.Windows.Forms.ComboBox();
            this.btnThemSan = new System.Windows.Forms.Button();
            this.nmSoSan = new System.Windows.Forms.NumericUpDown();
            this.flpSan = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnChuyenSan = new System.Windows.Forms.Button();
            this.cbChuyenSan = new System.Windows.Forms.ComboBox();
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
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1023, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(73, 29);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(182, 29);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // pnlSan
            // 
            this.pnlSan.Controls.Add(this.flpSan);
            this.pnlSan.Location = new System.Drawing.Point(13, 46);
            this.pnlSan.Name = "pnlSan";
            this.pnlSan.Size = new System.Drawing.Size(555, 520);
            this.pnlSan.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lsvHoaDon);
            this.panel2.Location = new System.Drawing.Point(574, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(444, 339);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbChuyenSan);
            this.panel3.Controls.Add(this.btnChuyenSan);
            this.panel3.Controls.Add(this.btnThanhToan);
            this.panel3.Location = new System.Drawing.Point(575, 489);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(443, 74);
            this.panel3.TabIndex = 3;
            // 
            // lsvHoaDon
            // 
            this.lsvHoaDon.HideSelection = false;
            this.lsvHoaDon.Location = new System.Drawing.Point(4, 4);
            this.lsvHoaDon.Name = "lsvHoaDon";
            this.lsvHoaDon.Size = new System.Drawing.Size(437, 332);
            this.lsvHoaDon.TabIndex = 0;
            this.lsvHoaDon.UseCompatibleStateImageBehavior = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nmSoSan);
            this.panel4.Controls.Add(this.btnThemSan);
            this.panel4.Controls.Add(this.cbDichVu);
            this.panel4.Controls.Add(this.cbSan);
            this.panel4.Location = new System.Drawing.Point(574, 46);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(443, 74);
            this.panel4.TabIndex = 4;
            // 
            // cbSan
            // 
            this.cbSan.FormattingEnabled = true;
            this.cbSan.Location = new System.Drawing.Point(4, 4);
            this.cbSan.Name = "cbSan";
            this.cbSan.Size = new System.Drawing.Size(212, 28);
            this.cbSan.TabIndex = 0;
            // 
            // cbDichVu
            // 
            this.cbDichVu.FormattingEnabled = true;
            this.cbDichVu.Location = new System.Drawing.Point(4, 38);
            this.cbDichVu.Name = "cbDichVu";
            this.cbDichVu.Size = new System.Drawing.Size(212, 28);
            this.cbDichVu.TabIndex = 1;
            // 
            // btnThemSan
            // 
            this.btnThemSan.Location = new System.Drawing.Point(240, 4);
            this.btnThemSan.Name = "btnThemSan";
            this.btnThemSan.Size = new System.Drawing.Size(88, 58);
            this.btnThemSan.TabIndex = 2;
            this.btnThemSan.Text = "Thêm Sân";
            this.btnThemSan.UseVisualStyleBackColor = true;
            // 
            // nmSoSan
            // 
            this.nmSoSan.Location = new System.Drawing.Point(343, 21);
            this.nmSoSan.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmSoSan.Name = "nmSoSan";
            this.nmSoSan.Size = new System.Drawing.Size(83, 26);
            this.nmSoSan.TabIndex = 3;
            this.nmSoSan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // flpSan
            // 
            this.flpSan.Location = new System.Drawing.Point(3, 4);
            this.flpSan.Name = "flpSan";
            this.flpSan.Size = new System.Drawing.Size(549, 513);
            this.flpSan.TabIndex = 0;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(308, 3);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(88, 58);
            this.btnThanhToan.TabIndex = 4;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            // 
            // btnChuyenSan
            // 
            this.btnChuyenSan.Location = new System.Drawing.Point(38, 3);
            this.btnChuyenSan.Name = "btnChuyenSan";
            this.btnChuyenSan.Size = new System.Drawing.Size(148, 36);
            this.btnChuyenSan.TabIndex = 5;
            this.btnChuyenSan.Text = "Chuyển Sân";
            this.btnChuyenSan.UseVisualStyleBackColor = true;
            // 
            // cbChuyenSan
            // 
            this.cbChuyenSan.FormattingEnabled = true;
            this.cbChuyenSan.Location = new System.Drawing.Point(38, 45);
            this.cbChuyenSan.Name = "cbChuyenSan";
            this.cbChuyenSan.Size = new System.Drawing.Size(148, 28);
            this.cbChuyenSan.TabIndex = 6;
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 583);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlSan);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fTableManager";
            this.Text = "Phần mềm quản lý sân đá bóng";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlSan.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
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
    }
}