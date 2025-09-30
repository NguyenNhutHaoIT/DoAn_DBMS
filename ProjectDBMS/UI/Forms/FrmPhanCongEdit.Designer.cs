namespace ProjectDBMS.UI
{
    partial class FrmPhanCongEdit
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cboGiaoVien;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.ComboBox cboMon;
        private System.Windows.Forms.TextBox txtSoTiet;
        private System.Windows.Forms.Label lblGV;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.Label lblSoTiet;
        private System.Windows.Forms.Button btnLuu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cboGiaoVien = new System.Windows.Forms.ComboBox();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.cboMon = new System.Windows.Forms.ComboBox();
            this.txtSoTiet = new System.Windows.Forms.TextBox();
            this.lblGV = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblMon = new System.Windows.Forms.Label();
            this.lblSoTiet = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGV
            // 
            this.lblGV.AutoSize = true;
            this.lblGV.Location = new System.Drawing.Point(20, 20);
            this.lblGV.Text = "Giáo viên:";
            // 
            // cboGiaoVien
            // 
            this.cboGiaoVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGiaoVien.Location = new System.Drawing.Point(120, 20);
            this.cboGiaoVien.Size = new System.Drawing.Size(200, 24);
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(20, 60);
            this.lblLop.Text = "Lớp học:";
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.Location = new System.Drawing.Point(120, 60);
            this.cboLop.Size = new System.Drawing.Size(200, 24);
            // 
            // lblMon
            // 
            this.lblMon.AutoSize = true;
            this.lblMon.Location = new System.Drawing.Point(20, 100);
            this.lblMon.Text = "Môn học:";
            // 
            // cboMon
            // 
            this.cboMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMon.Location = new System.Drawing.Point(120, 100);
            this.cboMon.Size = new System.Drawing.Size(200, 24);
            // 
            // lblSoTiet
            // 
            this.lblSoTiet.AutoSize = true;
            this.lblSoTiet.Location = new System.Drawing.Point(20, 140);
            this.lblSoTiet.Text = "Số tiết:";
            // 
            // txtSoTiet
            // 
            this.txtSoTiet.Location = new System.Drawing.Point(120, 140);
            this.txtSoTiet.Size = new System.Drawing.Size(100, 22);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(120, 180);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AcceptButton = this.btnLuu;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // FrmPhanCongEdit
            // 
            this.ClientSize = new System.Drawing.Size(360, 230);
            this.Controls.Add(this.lblGV);
            this.Controls.Add(this.cboGiaoVien);
            this.Controls.Add(this.lblLop);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.lblMon);
            this.Controls.Add(this.cboMon);
            this.Controls.Add(this.lblSoTiet);
            this.Controls.Add(this.txtSoTiet);
            this.Controls.Add(this.btnLuu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Phân công giảng dạy";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
