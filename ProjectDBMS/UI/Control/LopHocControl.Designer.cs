namespace ProjectDBMS.UI
{
    partial class LopHocControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckBox chkShowAll;
        private System.Windows.Forms.DataGridView dgvLop;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.chkShowAll = new System.Windows.Forms.CheckBox();
            this.dgvLop = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkShowAll
            // 
            this.chkShowAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkShowAll.Location = new System.Drawing.Point(0, 0);
            this.chkShowAll.Name = "chkShowAll";
            this.chkShowAll.Size = new System.Drawing.Size(1086, 25);
            this.chkShowAll.TabIndex = 2;
            this.chkShowAll.Text = "Xem cả lớp đã kết thúc";
            // 
            // dgvLop
            // 
            this.dgvLop.AllowUserToAddRows = false;
            this.dgvLop.AllowUserToDeleteRows = false;
            this.dgvLop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLop.ColumnHeadersHeight = 29;
            this.dgvLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLop.Location = new System.Drawing.Point(0, 25);
            this.dgvLop.MultiSelect = false;
            this.dgvLop.Name = "dgvLop";
            this.dgvLop.RowHeadersWidth = 51;
            this.dgvLop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLop.Size = new System.Drawing.Size(1086, 383);
            this.dgvLop.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnThem);
            this.panelButtons.Controls.Add(this.btnSua);
            this.panelButtons.Controls.Add(this.btnXoa);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 408);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1086, 50);
            this.panelButtons.TabIndex = 1;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(10, 10);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 23);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(100, 10);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 23);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(190, 10);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 23);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            // 
            // LopHocControl
            // 
            this.Controls.Add(this.dgvLop);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.chkShowAll);
            this.Name = "LopHocControl";
            this.Size = new System.Drawing.Size(1086, 458);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
