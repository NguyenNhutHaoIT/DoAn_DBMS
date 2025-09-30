namespace ProjectDBMS.UI
{
    partial class FrmLopEdit
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTenLop;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.Label lblKhoi;
        private System.Windows.Forms.NumericUpDown numKhoi;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.NumericUpDown numHocKy;
        private System.Windows.Forms.Label lblNamHoc;
        private System.Windows.Forms.NumericUpDown numNamHoc;
        private System.Windows.Forms.CheckBox chkDaKetThuc;
        private System.Windows.Forms.Button btnLuu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTenLop = new System.Windows.Forms.Label();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.lblKhoi = new System.Windows.Forms.Label();
            this.numKhoi = new System.Windows.Forms.NumericUpDown();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.numHocKy = new System.Windows.Forms.NumericUpDown();
            this.lblNamHoc = new System.Windows.Forms.Label();
            this.numNamHoc = new System.Windows.Forms.NumericUpDown();
            this.chkDaKetThuc = new System.Windows.Forms.CheckBox();
            this.btnLuu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numKhoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHocKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNamHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTenLop
            // 
            this.lblTenLop.AutoSize = true;
            this.lblTenLop.Location = new System.Drawing.Point(20, 20);
            this.lblTenLop.Text = "Tên lớp:";
            // 
            // txtTenLop
            // 
            this.txtTenLop.Location = new System.Drawing.Point(120, 20);
            this.txtTenLop.Size = new System.Drawing.Size(200, 22);
            // 
            // lblKhoi
            // 
            this.lblKhoi.AutoSize = true;
            this.lblKhoi.Location = new System.Drawing.Point(20, 60);
            this.lblKhoi.Text = "Khối:";
            // 
            // numKhoi
            // 
            this.numKhoi.Location = new System.Drawing.Point(120, 60);
            this.numKhoi.Minimum = 1;
            this.numKhoi.Maximum = 12;
            // 
            // lblHocKy
            // 
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Location = new System.Drawing.Point(20, 100);
            this.lblHocKy.Text = "Học kỳ:";
            // 
            // numHocKy
            // 
            this.numHocKy.Location = new System.Drawing.Point(120, 100);
            this.numHocKy.Minimum = 1;
            this.numHocKy.Maximum = 2;
            // 
            // lblNamHoc
            // 
            this.lblNamHoc.AutoSize = true;
            this.lblNamHoc.Location = new System.Drawing.Point(20, 140);
            this.lblNamHoc.Text = "Năm học:";
            // 
            // numNamHoc
            // 
            this.numNamHoc.Location = new System.Drawing.Point(120, 140);
            this.numNamHoc.Minimum = 2000;
            this.numNamHoc.Maximum = 2100;
            this.numNamHoc.Value = 2025;
            // 
            // chkDaKetThuc
            // 
            this.chkDaKetThuc.AutoSize = true;
            this.chkDaKetThuc.Location = new System.Drawing.Point(120, 180);
            this.chkDaKetThuc.Text = "Đã kết thúc";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(120, 220);
            this.btnLuu.Size = new System.Drawing.Size(100, 30);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // FrmLopEdit
            // 
            this.ClientSize = new System.Drawing.Size(360, 270);
            this.Controls.Add(this.lblTenLop);
            this.Controls.Add(this.txtTenLop);
            this.Controls.Add(this.lblKhoi);
            this.Controls.Add(this.numKhoi);
            this.Controls.Add(this.lblHocKy);
            this.Controls.Add(this.numHocKy);
            this.Controls.Add(this.lblNamHoc);
            this.Controls.Add(this.numNamHoc);
            this.Controls.Add(this.chkDaKetThuc);
            this.Controls.Add(this.btnLuu);
            this.Text = "Thông tin lớp";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
