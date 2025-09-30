namespace ProjectDBMS.UI
{
    partial class TaiKhoanRoleControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTaiKhoan;
        private System.Windows.Forms.TabPage tabRole;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.Button btnThemTaiKhoan;
        private System.Windows.Forms.Button btnSuaTaiKhoan;
        private System.Windows.Forms.Button btnXoaTaiKhoan;
        private System.Windows.Forms.DataGridView dgvRole;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTaiKhoan = new System.Windows.Forms.TabPage();
            this.btnXoaTaiKhoan = new System.Windows.Forms.Button();
            this.btnSuaTaiKhoan = new System.Windows.Forms.Button();
            this.btnThemTaiKhoan = new System.Windows.Forms.Button();
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.tabRole = new System.Windows.Forms.TabPage();
            this.dgvRole = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabTaiKhoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.tabRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRole)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTaiKhoan);
            this.tabControl1.Controls.Add(this.tabRole);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabTaiKhoan
            // 
            this.tabTaiKhoan.Controls.Add(this.btnXoaTaiKhoan);
            this.tabTaiKhoan.Controls.Add(this.btnSuaTaiKhoan);
            this.tabTaiKhoan.Controls.Add(this.btnThemTaiKhoan);
            this.tabTaiKhoan.Controls.Add(this.dgvTaiKhoan);
            this.tabTaiKhoan.Location = new System.Drawing.Point(4, 24);
            this.tabTaiKhoan.Name = "tabTaiKhoan";
            this.tabTaiKhoan.Padding = new System.Windows.Forms.Padding(3);
            this.tabTaiKhoan.Size = new System.Drawing.Size(792, 422);
            this.tabTaiKhoan.TabIndex = 0;
            this.tabTaiKhoan.Text = "Tài khoản";
            this.tabTaiKhoan.UseVisualStyleBackColor = true;
            // 
            // btnXoaTaiKhoan
            // 
            this.btnXoaTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaTaiKhoan.Location = new System.Drawing.Point(692, 6);
            this.btnXoaTaiKhoan.Name = "btnXoaTaiKhoan";
            this.btnXoaTaiKhoan.Size = new System.Drawing.Size(94, 29);
            this.btnXoaTaiKhoan.TabIndex = 3;
            this.btnXoaTaiKhoan.Text = "Xóa";
            this.btnXoaTaiKhoan.UseVisualStyleBackColor = true;
            this.btnXoaTaiKhoan.Click += new System.EventHandler(this.btnXoaTaiKhoan_Click);
            // 
            // btnSuaTaiKhoan
            // 
            this.btnSuaTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuaTaiKhoan.Location = new System.Drawing.Point(592, 6);
            this.btnSuaTaiKhoan.Name = "btnSuaTaiKhoan";
            this.btnSuaTaiKhoan.Size = new System.Drawing.Size(94, 29);
            this.btnSuaTaiKhoan.TabIndex = 2;
            this.btnSuaTaiKhoan.Text = "Sửa";
            this.btnSuaTaiKhoan.UseVisualStyleBackColor = true;
            this.btnSuaTaiKhoan.Click += new System.EventHandler(this.btnSuaTaiKhoan_Click);
            // 
            // btnThemTaiKhoan
            // 
            this.btnThemTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemTaiKhoan.Location = new System.Drawing.Point(492, 6);
            this.btnThemTaiKhoan.Name = "btnThemTaiKhoan";
            this.btnThemTaiKhoan.Size = new System.Drawing.Size(94, 29);
            this.btnThemTaiKhoan.TabIndex = 1;
            this.btnThemTaiKhoan.Text = "Thêm";
            this.btnThemTaiKhoan.UseVisualStyleBackColor = true;
            this.btnThemTaiKhoan.Click += new System.EventHandler(this.btnThemTaiKhoan_Click);
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.AllowUserToAddRows = false;
            this.dgvTaiKhoan.AllowUserToDeleteRows = false;
            this.dgvTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiKhoan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTaiKhoan.Location = new System.Drawing.Point(3, 41);
            this.dgvTaiKhoan.MultiSelect = false;
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.ReadOnly = true;
            this.dgvTaiKhoan.RowHeadersVisible = false;
            this.dgvTaiKhoan.RowTemplate.Height = 25;
            this.dgvTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(786, 378);
            this.dgvTaiKhoan.TabIndex = 0;
            // 
            // tabRole
            // 
            this.tabRole.Controls.Add(this.dgvRole);
            this.tabRole.Location = new System.Drawing.Point(4, 24);
            this.tabRole.Name = "tabRole";
            this.tabRole.Padding = new System.Windows.Forms.Padding(3);
            this.tabRole.Size = new System.Drawing.Size(792, 422);
            this.tabRole.TabIndex = 1;
            this.tabRole.Text = "Role";
            this.tabRole.UseVisualStyleBackColor = true;
            // 
            // dgvRole
            // 
            this.dgvRole.AllowUserToAddRows = false;
            this.dgvRole.AllowUserToDeleteRows = false;
            this.dgvRole.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRole.Location = new System.Drawing.Point(3, 3);
            this.dgvRole.Name = "dgvRole";
            this.dgvRole.RowHeadersVisible = false;
            this.dgvRole.RowTemplate.Height = 25;
            this.dgvRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRole.Size = new System.Drawing.Size(786, 416);
            this.dgvRole.TabIndex = 0;
            this.dgvRole.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRole_CellContentClick);
            // 
            // TaiKhoanRoleControl
            // 
            this.Controls.Add(this.tabControl1);
            this.Name = "TaiKhoanRoleControl";
            this.Size = new System.Drawing.Size(800, 450);
            this.Load += new System.EventHandler(this.TaiKhoanRoleControl_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabTaiKhoan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.tabRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRole)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
