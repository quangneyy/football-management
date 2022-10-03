namespace QuanLySanBong
{
    partial class Form1QLSancs
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dvgthongtin = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtgiothue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtmasan = new System.Windows.Forms.TextBox();
            this.txtgiasan = new System.Windows.Forms.TextBox();
            this.txtmahd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnsua = new System.Windows.Forms.Button();
            this.btntrolai = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgthongtin)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dvgthongtin);
            this.groupBox1.Location = new System.Drawing.Point(50, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 263);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sân";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dvgthongtin
            // 
            this.dvgthongtin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgthongtin.Location = new System.Drawing.Point(7, 21);
            this.dvgthongtin.Name = "dvgthongtin";
            this.dvgthongtin.RowHeadersWidth = 51;
            this.dvgthongtin.RowTemplate.Height = 24;
            this.dvgthongtin.Size = new System.Drawing.Size(672, 236);
            this.dvgthongtin.TabIndex = 0;
            this.dvgthongtin.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgthongtin_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã hóa đơn";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtgiothue);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtmasan);
            this.groupBox2.Controls.Add(this.txtgiasan);
            this.groupBox2.Controls.Add(this.txtmahd);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(50, 303);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(540, 149);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "com";
            // 
            // txtgiothue
            // 
            this.txtgiothue.Location = new System.Drawing.Point(400, 104);
            this.txtgiothue.Name = "txtgiothue";
            this.txtgiothue.Size = new System.Drawing.Size(100, 22);
            this.txtgiothue.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Giờ thuê";
            // 
            // txtmasan
            // 
            this.txtmasan.Location = new System.Drawing.Point(400, 56);
            this.txtmasan.Name = "txtmasan";
            this.txtmasan.Size = new System.Drawing.Size(100, 22);
            this.txtmasan.TabIndex = 6;
            // 
            // txtgiasan
            // 
            this.txtgiasan.Location = new System.Drawing.Point(95, 101);
            this.txtgiasan.Name = "txtgiasan";
            this.txtgiasan.Size = new System.Drawing.Size(100, 22);
            this.txtgiasan.TabIndex = 5;
            // 
            // txtmahd
            // 
            this.txtmahd.Location = new System.Drawing.Point(95, 56);
            this.txtmahd.Name = "txtmahd";
            this.txtmahd.Size = new System.Drawing.Size(100, 22);
            this.txtmahd.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã sân";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Giá thuê";
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(619, 381);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(75, 23);
            this.btnsua.TabIndex = 3;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btntrolai
            // 
            this.btntrolai.Location = new System.Drawing.Point(619, 419);
            this.btntrolai.Name = "btntrolai";
            this.btntrolai.Size = new System.Drawing.Size(75, 23);
            this.btntrolai.TabIndex = 4;
            this.btntrolai.Text = "Trở Lại";
            this.btntrolai.UseVisualStyleBackColor = true;
            this.btntrolai.Click += new System.EventHandler(this.btntrolai_Click);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(619, 316);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(75, 23);
            this.btnthem.TabIndex = 5;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(619, 346);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(75, 23);
            this.btnxoa.TabIndex = 6;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // Form1QLSancs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 464);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.btntrolai);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1QLSancs";
            this.Text = "Form1QLSancs";
            this.Load += new System.EventHandler(this.Form1QLSancs_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgthongtin)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dvgthongtin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtgiothue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtmasan;
        private System.Windows.Forms.TextBox txtgiasan;
        private System.Windows.Forms.TextBox txtmahd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btntrolai;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btnxoa;
    }
}