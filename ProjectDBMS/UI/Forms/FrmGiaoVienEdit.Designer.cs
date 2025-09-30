namespace ProjectDBMS.UI.Forms
{
    partial class FrmGiaoVienEdit
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblLoaiNV;
        private System.Windows.Forms.Label lblCMND;
        private System.Windows.Forms.Label lblSoDinhDanh;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.Label lblDanToc;
        private System.Windows.Forms.Label lblTonGiao;
        private System.Windows.Forms.Label lblSoSoBHXH;
        private System.Windows.Forms.Label lblNoiThuongTru;
        private System.Windows.Forms.Label lblQueQuan;

        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.TextBox txtLoaiNV;
        private System.Windows.Forms.CheckBox chkLaTuyenMoi;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.TextBox txtSoDinhDanh;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.TextBox txtDanToc;
        private System.Windows.Forms.TextBox txtTonGiao;
        private System.Windows.Forms.CheckBox chkLaDoanVien;
        private System.Windows.Forms.CheckBox chkLaDangVien;
        private System.Windows.Forms.TextBox txtSoSoBHXH;
        private System.Windows.Forms.TextBox txtNoiThuongTru;
        private System.Windows.Forms.TextBox txtQueQuan;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblLoaiNV = new System.Windows.Forms.Label();
            this.lblCMND = new System.Windows.Forms.Label();
            this.lblSoDinhDanh = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.lblDanToc = new System.Windows.Forms.Label();
            this.lblTonGiao = new System.Windows.Forms.Label();
            this.lblSoSoBHXH = new System.Windows.Forms.Label();
            this.lblNoiThuongTru = new System.Windows.Forms.Label();
            this.lblQueQuan = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.txtLoaiNV = new System.Windows.Forms.TextBox();
            this.chkLaTuyenMoi = new System.Windows.Forms.CheckBox();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.txtSoDinhDanh = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.txtDanToc = new System.Windows.Forms.TextBox();
            this.txtTonGiao = new System.Windows.Forms.TextBox();
            this.chkLaDoanVien = new System.Windows.Forms.CheckBox();
            this.chkLaDangVien = new System.Windows.Forms.CheckBox();
            this.txtSoSoBHXH = new System.Windows.Forms.TextBox();
            this.txtNoiThuongTru = new System.Windows.Forms.TextBox();
            this.txtQueQuan = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHoTen
            // 
            this.lblHoTen.Location = new System.Drawing.Point(30, 20);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(100, 23);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Họ tên *";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.Location = new System.Drawing.Point(30, 60);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(100, 23);
            this.lblNgaySinh.TabIndex = 2;
            this.lblNgaySinh.Text = "Ngày sinh *";
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.Location = new System.Drawing.Point(30, 100);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(100, 23);
            this.lblGioiTinh.TabIndex = 4;
            this.lblGioiTinh.Text = "Giới tính *";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Location = new System.Drawing.Point(30, 140);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(100, 23);
            this.lblTrangThai.TabIndex = 6;
            this.lblTrangThai.Text = "Trạng thái *";
            // 
            // lblLoaiNV
            // 
            this.lblLoaiNV.Location = new System.Drawing.Point(30, 180);
            this.lblLoaiNV.Name = "lblLoaiNV";
            this.lblLoaiNV.Size = new System.Drawing.Size(100, 23);
            this.lblLoaiNV.TabIndex = 8;
            this.lblLoaiNV.Text = "Loại NV";
            // 
            // lblCMND
            // 
            this.lblCMND.Location = new System.Drawing.Point(30, 260);
            this.lblCMND.Name = "lblCMND";
            this.lblCMND.Size = new System.Drawing.Size(100, 23);
            this.lblCMND.TabIndex = 11;
            this.lblCMND.Text = "CMND/CCCD";
            // 
            // lblSoDinhDanh
            // 
            this.lblSoDinhDanh.Location = new System.Drawing.Point(30, 300);
            this.lblSoDinhDanh.Name = "lblSoDinhDanh";
            this.lblSoDinhDanh.Size = new System.Drawing.Size(100, 23);
            this.lblSoDinhDanh.TabIndex = 13;
            this.lblSoDinhDanh.Text = "Số định danh";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(30, 340);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 15;
            this.lblEmail.Text = "Email";
            // 
            // lblDienThoai
            // 
            this.lblDienThoai.Location = new System.Drawing.Point(380, 20);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Size = new System.Drawing.Size(100, 23);
            this.lblDienThoai.TabIndex = 17;
            this.lblDienThoai.Text = "Điện thoại";
            // 
            // lblDanToc
            // 
            this.lblDanToc.Location = new System.Drawing.Point(380, 60);
            this.lblDanToc.Name = "lblDanToc";
            this.lblDanToc.Size = new System.Drawing.Size(100, 23);
            this.lblDanToc.TabIndex = 19;
            this.lblDanToc.Text = "Dân tộc";
            // 
            // lblTonGiao
            // 
            this.lblTonGiao.Location = new System.Drawing.Point(380, 100);
            this.lblTonGiao.Name = "lblTonGiao";
            this.lblTonGiao.Size = new System.Drawing.Size(100, 23);
            this.lblTonGiao.TabIndex = 21;
            this.lblTonGiao.Text = "Tôn giáo";
            // 
            // lblSoSoBHXH
            // 
            this.lblSoSoBHXH.Location = new System.Drawing.Point(380, 210);
            this.lblSoSoBHXH.Name = "lblSoSoBHXH";
            this.lblSoSoBHXH.Size = new System.Drawing.Size(100, 23);
            this.lblSoSoBHXH.TabIndex = 25;
            this.lblSoSoBHXH.Text = "Số sổ BHXH";
            // 
            // lblNoiThuongTru
            // 
            this.lblNoiThuongTru.Location = new System.Drawing.Point(380, 250);
            this.lblNoiThuongTru.Name = "lblNoiThuongTru";
            this.lblNoiThuongTru.Size = new System.Drawing.Size(100, 23);
            this.lblNoiThuongTru.TabIndex = 27;
            this.lblNoiThuongTru.Text = "Nơi thường trú";
            // 
            // lblQueQuan
            // 
            this.lblQueQuan.Location = new System.Drawing.Point(380, 290);
            this.lblQueQuan.Name = "lblQueQuan";
            this.lblQueQuan.Size = new System.Drawing.Size(100, 23);
            this.lblQueQuan.TabIndex = 29;
            this.lblQueQuan.Text = "Quê quán";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(150, 20);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(200, 22);
            this.txtHoTen.TabIndex = 1;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Location = new System.Drawing.Point(150, 60);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(200, 22);
            this.dtpNgaySinh.TabIndex = 3;
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.Location = new System.Drawing.Point(150, 100);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(200, 24);
            this.cboGioiTinh.TabIndex = 5;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Location = new System.Drawing.Point(150, 140);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(200, 24);
            this.cboTrangThai.TabIndex = 7;
            // 
            // txtLoaiNV
            // 
            this.txtLoaiNV.Location = new System.Drawing.Point(150, 180);
            this.txtLoaiNV.Name = "txtLoaiNV";
            this.txtLoaiNV.Size = new System.Drawing.Size(200, 22);
            this.txtLoaiNV.TabIndex = 9;
            // 
            // chkLaTuyenMoi
            // 
            this.chkLaTuyenMoi.Location = new System.Drawing.Point(150, 220);
            this.chkLaTuyenMoi.Name = "chkLaTuyenMoi";
            this.chkLaTuyenMoi.Size = new System.Drawing.Size(104, 24);
            this.chkLaTuyenMoi.TabIndex = 10;
            this.chkLaTuyenMoi.Text = "Là tuyển mới";
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(150, 260);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(200, 22);
            this.txtCMND.TabIndex = 12;
            // 
            // txtSoDinhDanh
            // 
            this.txtSoDinhDanh.Location = new System.Drawing.Point(150, 300);
            this.txtSoDinhDanh.Name = "txtSoDinhDanh";
            this.txtSoDinhDanh.Size = new System.Drawing.Size(200, 22);
            this.txtSoDinhDanh.TabIndex = 14;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(150, 340);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 22);
            this.txtEmail.TabIndex = 16;
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(500, 20);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(200, 22);
            this.txtDienThoai.TabIndex = 18;
            // 
            // txtDanToc
            // 
            this.txtDanToc.Location = new System.Drawing.Point(500, 60);
            this.txtDanToc.Name = "txtDanToc";
            this.txtDanToc.Size = new System.Drawing.Size(200, 22);
            this.txtDanToc.TabIndex = 20;
            // 
            // txtTonGiao
            // 
            this.txtTonGiao.Location = new System.Drawing.Point(500, 100);
            this.txtTonGiao.Name = "txtTonGiao";
            this.txtTonGiao.Size = new System.Drawing.Size(200, 22);
            this.txtTonGiao.TabIndex = 22;
            // 
            // chkLaDoanVien
            // 
            this.chkLaDoanVien.Location = new System.Drawing.Point(500, 140);
            this.chkLaDoanVien.Name = "chkLaDoanVien";
            this.chkLaDoanVien.Size = new System.Drawing.Size(116, 24);
            this.chkLaDoanVien.TabIndex = 23;
            this.chkLaDoanVien.Text = "Là đoàn viên";
            // 
            // chkLaDangVien
            // 
            this.chkLaDangVien.Location = new System.Drawing.Point(500, 170);
            this.chkLaDangVien.Name = "chkLaDangVien";
            this.chkLaDangVien.Size = new System.Drawing.Size(116, 24);
            this.chkLaDangVien.TabIndex = 24;
            this.chkLaDangVien.Text = "Là đảng viên";
            // 
            // txtSoSoBHXH
            // 
            this.txtSoSoBHXH.Location = new System.Drawing.Point(500, 210);
            this.txtSoSoBHXH.Name = "txtSoSoBHXH";
            this.txtSoSoBHXH.Size = new System.Drawing.Size(200, 22);
            this.txtSoSoBHXH.TabIndex = 26;
            // 
            // txtNoiThuongTru
            // 
            this.txtNoiThuongTru.Location = new System.Drawing.Point(500, 250);
            this.txtNoiThuongTru.Name = "txtNoiThuongTru";
            this.txtNoiThuongTru.Size = new System.Drawing.Size(200, 22);
            this.txtNoiThuongTru.TabIndex = 28;
            // 
            // txtQueQuan
            // 
            this.txtQueQuan.Location = new System.Drawing.Point(500, 290);
            this.txtQueQuan.Name = "txtQueQuan";
            this.txtQueQuan.Size = new System.Drawing.Size(200, 22);
            this.txtQueQuan.TabIndex = 30;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(280, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(380, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmGiaoVienEdit
            // 
            this.ClientSize = new System.Drawing.Size(750, 460);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.lblGioiTinh);
            this.Controls.Add(this.cboGioiTinh);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.lblLoaiNV);
            this.Controls.Add(this.txtLoaiNV);
            this.Controls.Add(this.chkLaTuyenMoi);
            this.Controls.Add(this.lblCMND);
            this.Controls.Add(this.txtCMND);
            this.Controls.Add(this.lblSoDinhDanh);
            this.Controls.Add(this.txtSoDinhDanh);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblDienThoai);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.lblDanToc);
            this.Controls.Add(this.txtDanToc);
            this.Controls.Add(this.lblTonGiao);
            this.Controls.Add(this.txtTonGiao);
            this.Controls.Add(this.chkLaDoanVien);
            this.Controls.Add(this.chkLaDangVien);
            this.Controls.Add(this.lblSoSoBHXH);
            this.Controls.Add(this.txtSoSoBHXH);
            this.Controls.Add(this.lblNoiThuongTru);
            this.Controls.Add(this.txtNoiThuongTru);
            this.Controls.Add(this.lblQueQuan);
            this.Controls.Add(this.txtQueQuan);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "FrmGiaoVienEdit";
            this.Text = "Thông tin Giáo viên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
