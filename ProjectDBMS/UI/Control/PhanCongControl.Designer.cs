namespace ProjectDBMS.UI
{
    partial class PhanCongControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPhanCong;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvPhanCong = new System.Windows.Forms.DataGridView();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanCong)).BeginInit();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Text = "📘 Danh sách phân công giảng dạy";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Height = 40;

            // dgvPhanCong
            this.dgvPhanCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhanCong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhanCong.RowHeadersWidth = 51;
            this.dgvPhanCong.RowTemplate.Height = 24;
            this.dgvPhanCong.Location = new System.Drawing.Point(0, 40);
            this.dgvPhanCong.Name = "dgvPhanCong";
            this.dgvPhanCong.TabIndex = 0;

            // pnlActions
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Height = 60;
            this.pnlActions.Padding = new System.Windows.Forms.Padding(10);
            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.pnlActions.Controls.Add(this.btnThem);
            this.pnlActions.Controls.Add(this.btnSua);
            this.pnlActions.Controls.Add(this.btnXoa);

            // btnThem
            this.btnThem.Text = "➕ Thêm";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.Location = new System.Drawing.Point(10, 10);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            // btnSua
            this.btnSua.Text = "✏️ Sửa";
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.Location = new System.Drawing.Point(120, 10);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            // btnXoa
            this.btnXoa.Text = "🗑️ Xóa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.Location = new System.Drawing.Point(230, 10);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // PhanCongControl
            this.Controls.Add(this.dgvPhanCong);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.lblTitle);
            this.Name = "PhanCongControl";
            this.Size = new System.Drawing.Size(800, 500);

            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanCong)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
